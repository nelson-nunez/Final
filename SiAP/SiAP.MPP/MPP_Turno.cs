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
            if (Existe(entidad)) return;
            AgregarEntidad(entidad, AsignarDatos);
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

        public IList<Turno> BuscarTurnoPorpaciente(long pacienteId)
        {
            var lista = ObtenerTodos().Where(t => t.PacienteId == pacienteId).ToList();
            return lista;
        }

        public IList<Turno> BuscarTurnodelMes(DateTime fechadesde)
        {
            var lista = new List<Turno>();
            if (fechadesde == DateTime.MinValue)
                lista = ObtenerTodos().ToList();
            else
                lista = ObtenerTodos().Where(t => t.Fecha.Month == fechadesde.Month).ToList();
            return lista;
        }
        
        public IList<Turno> BuscarTurnosdelAño(DateTime fechadesde)
        {
            var lista = new List<Turno>();
            if (fechadesde == DateTime.MinValue)
                lista = ObtenerTodos().ToList();
            else
                lista = ObtenerTodos().Where(t => t.Fecha.Year == fechadesde.Year).ToList();
            return lista;
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

        private void AsignarDatos(DataRow dr, Turno entidad)
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

        private Turno HidratarObjeto(DataRow r)
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
    }
}