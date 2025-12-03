using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Turno : MapperBase<Turno>, IMapper<Turno>
    {
        private static MPP_Turno _instancia;
        private readonly MPP_Cobro _mppCobro;
        private readonly MPP_Paciente _mppPaciente;
        private readonly MPP_Medico _mppMedico;
        protected override string NombreTabla => "Turno";

        private MPP_Turno() : base() 
        {
            _mppCobro = MPP_Cobro.ObtenerInstancia();
            _mppPaciente = MPP_Paciente.ObtenerInstancia();
            _mppMedico = MPP_Medico.ObtenerInstancia();
        }

        public static MPP_Turno ObtenerInstancia()
        {
            return _instancia ??= new MPP_Turno();
        }

        public void Agregar(Turno entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Cobro);
            if (Existe(entidad)) 
                return;

            //turno
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt_turno = ds.Tables["Turno"];
            var dr_turno = dt_turno.NewRow();
            long nuevoId_turno = DataRowHelper.ObtenerSiguienteId(dt_turno, "Id");
            
            //Cobro
            var dt_cobro = ds.Tables["Cobro"];
            var dr_cobro = dt_cobro.NewRow();
            long nuevoId_cobro = DataRowHelper.ObtenerSiguienteId(dt_cobro, "Id");
            
            //Cargo datos nuevos
            dr_turno["Id"] = nuevoId_turno;
            entidad.CobroId= nuevoId_cobro;
            AsignarDatos(dr_turno, entidad);
            //Cargo datos nuevos
            dr_cobro["Id"] = nuevoId_cobro;
            dr_cobro["FechaHora"] = entidad.Cobro.FechaHora;
            dr_cobro["MontoTotal"] = entidad.MontoTotal;
            dr_cobro["MontoAcumulado"] = entidad.Cobro.MontoAcumulado;
            dr_cobro["MediodePago"] = entidad.Cobro.MediodePago;
            dr_cobro["Importe"] = entidad.Cobro.Importe;
            dr_cobro["Estado"] = entidad.Cobro.Estado.ToString();
            dr_cobro["TurnoId"] = nuevoId_turno;

            //Cre4o en bd turno
            dt_turno.Rows.Add(dr_turno);
            //Cre4o en bd cobro
            dt_cobro.Rows.Add(dr_cobro);
            _datos.Actualizar_BDSiAP(ds);
        }

        public void Modificar(Turno entidad)
        {
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Turno entidad)
        {
            EliminarEntidad(entidad);
        }

        public bool Existe(Turno entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Turno entidad) => false;

        public IList<Turno> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Turno LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public void AsignarDatos(DataRow dr, Turno entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio;
            dr["HoraFin"] = entidad.HoraFin;
            dr["TipoAtencion"] = entidad.TipoAtencion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["MedicoId"] = entidad.MedicoId;
            dr["PacienteId"] = entidad.PacienteId;
            dr["AgendaId"] = entidad.AgendaId;
            dr["CobroId"] = entidad.CobroId ?? 0;
        }

        public Turno HidratarObjeto(DataRow r)
        {
            var turno =  new Turno
            {
                Id = Convert.ToInt64(r["Id"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                HoraInicio = TimeSpan.Parse(r["HoraInicio"].ToString()),
                HoraFin = TimeSpan.Parse(r["HoraFin"].ToString()),
                TipoAtencion = r["TipoAtencion"].ToString(),
                Estado = Enum.Parse<EstadoTurno>(r["Estado"].ToString()),
                MedicoId = Convert.ToInt64(r["MedicoId"]),
                PacienteId = Convert.ToInt64(r["PacienteId"]),
                AgendaId = Convert.ToInt64(r["AgendaId"]),
                CobroId = Convert.ToInt64(r["CobroId"]),
                Cobro = new Cobro(),
                Paciente = new Paciente()
            };
            turno.Cobro = _mppCobro.LeerPorId(turno.CobroId);
            turno.Paciente = _mppPaciente.LeerPorId(turno.PacienteId);
            turno.Medico = _mppMedico.LeerPorId(turno.MedicoId);
            return turno;
        }

        //Otros
        public IList<Turno> BuscarTurnoPorpaciente(long pacienteId)
        {
            var lista = ObtenerTodos().Where(t => t.PacienteId == pacienteId).OrderByDescending(x=>x.Fecha).OrderByDescending(x=>x.HoraInicio).ToList();
            return lista;
        }
        
        public bool BuscarTurnoPorpacienteyFecha(Turno item)
        {

            var result = ObtenerTodos().Any(t => t.PacienteId == item.PacienteId && t.Fecha.Date == item.Fecha.Date &
                                           (t.HoraInicio == item.HoraInicio | t.HoraFin == item.HoraFin));
            return result;
        }

        public IList<Turno> BuscarporRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return ObtenerTodos()
                .Where(t => t.Fecha.Date >= fechaDesde.Date
                         && t.Fecha.Date <= fechaHasta.Date)
                .ToList();
        }

        public IList<Turno> BuscarPorMedicoyRango(long medicoId, DateTime fechadesde, DateTime fechahasta)
        {
            var lista = ObtenerTodos()
                .Where(t => t.MedicoId == medicoId &&
                           t.Fecha >= fechadesde &&
                           t.Fecha <= fechahasta)
                .ToList();
            return lista;
        }

    }
}