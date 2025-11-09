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

            if (Existe(entidad))
                return;

            AgregarEntidad(entidad, AsignarDatos);

            if (entidad.Medicamentos != null && entidad.Medicamentos.Any())
            {
                foreach (var droga in entidad.Medicamentos)
                {
                    droga.RecetaId = entidad.Id;
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

            foreach (var receta in recetas)
            {
                receta.Medicamentos = _mppMedicamento.BuscarPorRecetaId(receta.Id).ToList();
            }

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

        public IList<Receta> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var recetas = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return recetas;

            return campo.ToLower() switch
            {
                "consultaid" => recetas.Where(r => r.ConsultaId == Convert.ToInt64(valor)).ToList(),
                "profesional" => recetas.Where(r => r.Profesional?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "obrasocial" => recetas.Where(r => r.Obra_social?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "nrosocio" => recetas.Where(r => r.Nro_Socio == Convert.ToInt32(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public IList<Receta> BuscarPorConsultaId(long consultaId)
        {
            var recetas = ObtenerTodos().Where(r => r.ConsultaId == consultaId)
                .OrderByDescending(r => r.Fecha)
                .ToList();

            return recetas;
        }

        public IList<Receta> BuscarCronicasVigentes()
        {
            return ObtenerTodos()
                .Where(r => r.EsCronica && r.ValidarVigencia())
                .OrderByDescending(r => r.Fecha)
                .ToList();
        }

        public IList<Receta> BuscarPorRangoFechas(DateTime desde, DateTime hasta)
        {
            return ObtenerTodos()
                .Where(r => r.Fecha >= desde && r.Fecha <= hasta)
                .OrderByDescending(r => r.Fecha)
                .ToList();
        }

        private void ModificarDatos(DataRow dr, Receta entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["Profesional"] = entidad.Profesional ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
            dr["EsCronica"] = entidad.EsCronica;
        }

        private void AsignarDatos(DataRow dr, Receta entidad)
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

        private Receta HidratarObjeto(DataRow r)
        {
            return new Receta
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
        }
    }
}