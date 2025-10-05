using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Turno : MapperBase<Turno>, IMapper<Turno>
    {
        private static MPP_Turno _instancia;
        protected override string NombreTabla => "Turno";

        private MPP_Turno() : base() { }

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

        public IList<Turno> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var lista = ObtenerTodos();
            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return lista;

            return campo.ToLower() switch
            {
                "medicoid" => lista.Where(a => a.MedicoId == Convert.ToInt64(valor)).ToList(),
                "fecha" => lista.Where(a => a.Fecha.ToShortDateString().Contains(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Turno BuscarTurnoPorMedIdyRangoHorario(long medicoId, DateTime fecha, TimeSpan horaDesde, TimeSpan horaHasta)
        {
            var lista = ObtenerTodos();
            return lista.FirstOrDefault(
                t => t.MedicoId == medicoId &&
                t.Fecha.Date == fecha.Date &&
                (t.HoraInicio >= horaDesde && t.HoraInicio < horaHasta ||
                 t.HoraFin > horaDesde && t.HoraFin <= horaHasta)
            );
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
        }

        private Turno HidratarObjeto(DataRow r)
        {
            return new Turno
            {
                Id = Convert.ToInt64(r["Id"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                HoraInicio = TimeSpan.Parse(r["HoraInicio"].ToString()),
                HoraFin = TimeSpan.Parse(r["HoraFin"].ToString()),
                TipoAtencion = r["TipoAtencion"].ToString(),
                Estado = Enum.Parse<EstadoTurno>(r["Estado"].ToString()),
                MedicoId = Convert.ToInt64(r["MedicoId"]),
                PacienteId = Convert.ToInt64(r["PacienteId"]),
                AgendaId = Convert.ToInt64(r["AgendaId"])
            };
        }
    }
}