using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Agenda : MapperBase<Agenda>, IMapper<Agenda>
    {
        private static MPP_Agenda _instancia;
        protected override string NombreTabla => "Agenda";

        private MPP_Agenda() : base() { }

        public static MPP_Agenda ObtenerInstancia()
        {
            return _instancia ??= new MPP_Agenda();
        }

        public void Agregar(Agenda entidad)
        {
            if (Existe(entidad)) return;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void AgregarAgendas(List<Agenda> entidades)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables[NombreTabla];

            foreach (var entidad in entidades)
            {
                ArgumentNullException.ThrowIfNull(entidad);
                if (Existe(entidad)) continue;

                var dr = dt.NewRow();
                long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
                dr["Id"] = nuevoId;
                AsignarDatos(dr, entidad);
                dt.Rows.Add(dr);
                entidad.Id = nuevoId;
            }
            _datos.Actualizar_BDSiAP(ds);
        }

        public void Modificar(Agenda entidad)
        {
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Agenda entidad)
        {
            EliminarEntidad(entidad);
        }

        public void EliminarAgendas(List<Agenda> entidades)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();

            foreach (var entidad in entidades)
            {
                ArgumentNullException.ThrowIfNull(entidad);
                var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
                dr?.Delete();
            }

            _datos.Actualizar_BDSiAP(ds);
        }

        public bool Existe(Agenda entidad)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            return ds.Tables[NombreTabla].AsEnumerable()
                .Any(r =>
                    Convert.ToDateTime(r["Fecha"]) == entidad.Fecha &&
                    TimeSpan.Parse(r["HoraInicio"].ToString()) == entidad.HoraInicio &&
                    Convert.ToInt64(r["MedicoId"]) == entidad.MedicoId);
        }

        public bool TieneDependencias(Agenda entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Turno", "AgendaId");
        }

        public IList<Agenda> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Agenda LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public void AsignarDatos(DataRow dr, Agenda entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio.ToString(@"hh\:mm");
            dr["HoraFin"] = entidad.HoraFin.ToString(@"hh\:mm");
            dr["MedicoId"] = entidad.MedicoId;
        }

        public Agenda HidratarObjeto(DataRow r)
        {
            return new Agenda
            {
                Id = Convert.ToInt64(r["Id"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                HoraInicio = TimeSpan.Parse(r["HoraInicio"].ToString()),
                HoraFin = TimeSpan.Parse(r["HoraFin"].ToString()),
                MedicoId = Convert.ToInt64(r["MedicoId"])
            };
        }

        //Otros
        public IList<Agenda> BuscarPorMedicoyRango(long medicoId, DateTime fechadesde, DateTime fechahasta)
        {
            return ObtenerTodos()
                .Where(a => a.MedicoId == medicoId &&
                            a.Fecha >= fechadesde &&
                            a.Fecha <= fechahasta)
                .ToList();
        }

        public IList<Agenda> BuscarAgendasdelMes(DateTime fechadesde)
        {
            var lista = new List<Agenda>();
            if (fechadesde == DateTime.MinValue)
                lista = ObtenerTodos().ToList();
            else
                lista = ObtenerTodos().Where(t => t.Fecha.Month == fechadesde.Month).ToList();
            return lista;
        }

        public IList<Agenda> BuscarporRangoFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return ObtenerTodos()
                .Where(t => t.Fecha.Date >= fechaDesde.Date
                         && t.Fecha.Date <= fechaHasta.Date)
                .ToList();
        }
    }
}