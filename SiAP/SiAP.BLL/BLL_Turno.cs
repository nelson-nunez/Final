using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Turno : IBLL<Turno>
    {
        private readonly MPP_Turno _mppTurno;
        private readonly MPP_Cobro _mppCobro;
        private static BLL_Turno _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Turno()
        {
            _mppTurno = MPP_Turno.ObtenerInstancia();
            _mppCobro = MPP_Cobro.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Turno ObtenerInstancia()
        {
            return _instancia ??= new BLL_Turno();
        }

        #region interfaz

        public void Agregar(Turno turno)
        {
            if (!EsValido(turno))
                throw new ArgumentException(MensajeError);
            if (turno.Fecha < DateTime.Now)
                throw new InvalidOperationException("No se puede asignar un turno con fecha anterior al corriente día.");

            if (_mppTurno.Existe(turno))
                throw new InvalidOperationException("El turno ya existe.");

            turno.Cobro = new Cobro();
            turno.Cobro.MontoTotal = turno.Medico.ArancelConsulta;
            turno.Cobro.Estado = EstadoCobro.PagoParcial;
            turno.Cobro.TurnoId = turno.Id;
            _mppCobro.Agregar(turno.Cobro);
            //poco elegante, veeer
            var item = _mppCobro.LeerPorTurnoId(turno.Id);
            turno.CobroId = item.Id;
            turno.Cobro = item;
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
            if (turno.Fecha < DateTime.Now)
                throw new InvalidOperationException("No se puede eliminar un turno con fecha anterior al corriente día."); 
            
            if (turno.Estado == EstadoTurno.Atendido || turno.Estado == EstadoTurno.Ausente)
                throw new InvalidOperationException("El turno ya no puede eliminarse.");
            _mppTurno.Eliminar(turno);
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

        #endregion

        public IList<Turno> BuscarTurnoPorPaciente(Paciente paciente)
        {
            return _mppTurno.BuscarTurnoPorpaciente(paciente.Id);
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

        public void CambiarEstado(Turno turno, EstadoTurno nuevoEstado)
        {
            turno.Estado = nuevoEstado;
            Modificar(turno);
        }
    }
}
