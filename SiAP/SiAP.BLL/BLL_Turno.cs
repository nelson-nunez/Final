using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BE.Vistas;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Turno : IBLL<Turno>
    {
        private readonly MPP_Turno _mppTurno;
        private readonly MPP_Cobro _mppCobro;
        private readonly MPP_Factura _mppFactura;


        private static BLL_Turno _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Turno()
        {
            _mppTurno = MPP_Turno.ObtenerInstancia();
            _mppCobro = MPP_Cobro.ObtenerInstancia();
            _mppFactura = MPP_Factura.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Turno ObtenerInstancia()
        {
            return _instancia ??= new BLL_Turno();
        }


        public void Agregar(Turno turno)
        {
            if (!EsValido(turno))
                throw new ArgumentException(MensajeError);
            if (turno.Fecha < DateTime.Now)
                throw new InvalidOperationException("No se puede asignar un turno con fecha anterior al corriente día.");

            if (_mppTurno.Existe(turno))
                throw new InvalidOperationException("El turno ya existe.");
            //Validar que no tenga otro turno
            if(_mppTurno.BuscarTurnoPorpacienteyFecha(turno))
                throw new InvalidOperationException("El paciente ya registra otro turno en la misma fecha y hora.");

            //Creo el cobro
            turno.Cobro = new Cobro
            {
                FechaHora = turno.Fecha,
                MediodePago = MediodePago.sinInformar,
                MontoTotal = turno.Medico.ArancelConsulta,
                MontoAcumulado = 0,
                Importe = 0,
                Estado = EstadoCobro.PagoParcial
            };
            //Creo el turno junto al cobro
            _mppTurno.Agregar(turno);
            _logger.GenerarLog($"Turno agregado: Médico ID {turno.MedicoId}, Paciente ID {turno.PacienteId}, Fecha {turno.Fecha:dd/MM/yyyy}");
        }

        public void Modificar(Turno turno)
        {
            if (!EsValido(turno))
                throw new ArgumentException(MensajeError);
            _mppTurno.Modificar(turno);
            _logger.GenerarLog($"Turno modificado: ID {turno.Id}, Estado {turno.Estado}");
        }

        public void Eliminar(Turno turno)
        {
            if (_mppTurno.TieneDependencias(turno))
                throw new InvalidOperationException("El turno tiene dependencias y no puede eliminarse.");

            if (turno.Cobro.MontoAcumulado > 0)
                throw new InvalidOperationException("El turno tiene cobros y no puede eliminarse. Debe rembolsarse el pago antes de eliminar");

            if (turno.Fecha < DateTime.Now)
                throw new InvalidOperationException("No se puede eliminar un turno con fecha anterior al corriente día."); 
            
            if (turno.Estado == EstadoTurno.Confirmado || turno.Estado == EstadoTurno.Atendido || turno.Estado == EstadoTurno.Ausente)
                throw new InvalidOperationException("El turno ya no puede eliminarse.");
            _mppTurno.Eliminar(turno);
            _mppCobro.Eliminar(turno.Cobro);
            _logger.GenerarLog($"Turno eliminado: ID {turno.Id}");
        }

        public IList<Turno> ObtenerTodos()
        {
            return _mppTurno.ObtenerTodos();
        }

        public Turno Leer(long turnoId)
        {
            return _mppTurno.LeerPorId(turnoId);
        }

        public bool EsValido(Turno turno)
        {
            _mensajeError = "";

            if (turno.Fecha == default(DateTime))
                _mensajeError += "La fecha es obligatoria. ";
            if (turno.HoraInicio >= turno.HoraFin)
                _mensajeError += "La hora de inicio debe ser anterior a la hora de fin. ";
            if (turno.MedicoId <= 0)
                _mensajeError += "El ID del médico es obligatorio. ";
            if (turno.PacienteId <= 0)
                _mensajeError += "El ID del paciente es obligatorio. ";
            if (!Enum.IsDefined(typeof(EstadoTurno), turno.Estado))
                _mensajeError += "El estado del turno no es válido. ";

            return string.IsNullOrEmpty(_mensajeError);
        }

        //Otros
        public IList<Turno> BuscarTurnoPorPaciente(Paciente paciente)
        {
            return _mppTurno.BuscarTurnoPorpaciente(paciente.Id);
        }
        
        public IList<Turno> BuscarporRango(DateTime desde, DateTime hasta)
        {
            var turnos = _mppTurno.BuscarporRangoFecha(desde, hasta);
            return turnos;
        }
        
        public IList<Vista_Ingresos_Esp> BuscarVistaporRango(DateTime desde, DateTime hasta)
        {
            var turnos = _mppTurno.BuscarporRangoFecha(desde, hasta);
            var facturas = _mppFactura.BuscarFacturasporRangoFecha(desde, hasta);

            var ingresosPorEspecialidad = from turno in turnos
                                          join factura in facturas on turno.CobroId equals factura.CobroId
                                          group factura by turno.Medico.Especialidad.Nombre into grupo
                                          select new Vista_Ingresos_Esp
                                          {
                                              Especialidad = grupo.Key,
                                              CantidadTurnos = grupo.Count(),
                                              TotalIngresos = grupo.Sum(f => f.Total)
                                          };

            return ingresosPorEspecialidad.ToList();
        }

        public IList<Turno> BuscarPorMedicoyRango(Medico medico, DateTime fecha)
        {
            // Calcular el inicio de semana (lunes)
            var diasDesdeLunes = (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;
            if (diasDesdeLunes < 0) diasDesdeLunes += 7;
            var desde = fecha.Date.AddDays(-diasDesdeLunes);
            var hasta = desde.AddDays(6);
            return _mppTurno.BuscarPorMedicoyRango(medico.Id, desde, hasta);
        }
    }
}
