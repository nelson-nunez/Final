using System.Data;
using SiAP.Abstracciones;
using SiAP.MPP.Base;
using Policonsultorio.BE;

namespace SiAP.MPP
{
    public class MPP_Receta : MapperBase<Receta>, IMapper<Receta>
    {
        private static MPP_Receta _instancia;
        private readonly MPP_Medicamento _mppMedicamento;
        protected override string NombreTabla => "Receta";

        private MPP_Receta() : base()
        {
            _mppMedicamento = MPP_Medicamento.ObtenerInstancia();
        }

        public static MPP_Receta ObtenerInstancia()
        {
            return _instancia ??= new MPP_Receta();
        }

        public void Agregar(Receta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables[NombreTabla];
            var dr = dt.NewRow();

            long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Id"] = nuevoId;
            AsignarDatos(dr, entidad);

            dt.Rows.Add(dr);
            _datos.Actualizar_BDSiAP(ds);

            if (entidad.Medicamentos != null && entidad.Medicamentos.Any())
            {
                foreach (var droga in entidad.Medicamentos)
                {
                    droga.RecetaId = nuevoId;
                    _mppMedicamento.Agregar(droga);
                }
            }
        }

        public void Modificar(Receta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            ModificarEntidad(entidad, ModificarDatos);

            _mppMedicamento.EliminarPorRecetaId(entidad.Id);
            if (entidad.Medicamentos != null && entidad.Medicamentos.Any())
            {
                foreach (var droga in entidad.Medicamentos)
                {
                    droga.RecetaId = entidad.Id;
                    _mppMedicamento.Agregar(droga);
                }
            }
        }

        public void Eliminar(Receta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            _mppMedicamento.EliminarPorRecetaId(entidad.Id);
            EliminarEntidad(entidad);
        }

        public bool Existe(Receta entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Receta entidad)
        {
            return false;
        }

        public IList<Receta> ObtenerTodos()
        {
            var recetas = ObtenerTodasEntidades(HidratarObjeto);
            return recetas;
        }

        public Receta LeerPorId(object id)
        {
            var receta = LeerEntidadPorId(id, HidratarObjeto);

            if (receta != null)
            {
                receta.Medicamentos = _mppMedicamento.BuscarPorRecetaId(receta.Id).ToList();
            }

            return receta;
        }

        public void AsignarDatos(DataRow dr, Receta entidad)
        {
            dr["ConsultaId"] = entidad.Consulta?.Id ?? (object)DBNull.Value;
            dr["Fecha"] = entidad.Fecha;
            dr["Profesional"] = entidad.Profesional ?? string.Empty;
            dr["Nro_Socio"] = entidad.Nro_Socio;
            dr["Obra_social"] = entidad.Obra_social ?? string.Empty;
            dr["Plan"] = entidad.Plan ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
            dr["EsCronica"] = entidad.EsCronica;
        }

        public Receta HidratarObjeto(DataRow r)
        {
            var item = new Receta
            {
                Id = Convert.ToInt64(r["Id"]),
                ConsultaId = Convert.ToInt64(r["ConsultaId"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                Profesional = r["Profesional"]?.ToString() ?? string.Empty,
                Nro_Socio = r["Nro_Socio"] != DBNull.Value ? Convert.ToInt32(r["Nro_Socio"]) : 0,
                Obra_social = r["Obra_social"]?.ToString() ?? string.Empty,
                Plan = r["Plan"]?.ToString() ?? string.Empty,
                Observaciones = r["Observaciones"]?.ToString() ?? string.Empty,
                EsCronica = r["EsCronica"] != DBNull.Value && Convert.ToBoolean(r["EsCronica"])
            };
            item.Medicamentos = _mppMedicamento.BuscarPorRecetaId(item.Id).ToList();
            return item;
        }

        //Otros
        public IList<Receta> BuscarPorConsultaId(long consultaId)
        {
            var recetas = ObtenerTodos().Where(r => r.ConsultaId == consultaId).OrderByDescending(r => r.Fecha).ToList();
            return recetas;
        }

        private void ModificarDatos(DataRow dr, Receta entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["Profesional"] = entidad.Profesional ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
            dr["EsCronica"] = entidad.EsCronica;
        }
    }
}