using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.MPP.Base;
using Policonsultorio.BE;

namespace SiAP.MPP
{
    public class MPP_Receta : MapperBase<Receta>, IMapper<Receta>
    {
        private static MPP_Receta _instancia;
        protected override string NombreTabla => "Receta";

        private MPP_Receta() : base() { }

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
        }

        public void Modificar(Receta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Receta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            EliminarEntidad(entidad);
        }

        public bool Existe(Receta entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Receta entidad)
        {
            return false; // Las recetas no tienen dependencias
        }

        public IList<Receta> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Receta LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Receta> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var recetas = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return recetas;

            return campo.ToLower() switch
            {
                "consultaid" => recetas.Where(r => r.Consulta?.Id == Convert.ToInt64(valor)).ToList(),
                "profesional" => recetas.Where(r => r.Profesional?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "obrasocial" => recetas.Where(r => r.Obra_social?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "nrosocio" => recetas.Where(r => r.Nro_Socio == Convert.ToInt32(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        /// Busca todas las recetas de una consulta específica
        public IList<Receta> BuscarPorConsultaId(long consultaId)
        {
            var ds = _datos.Obtener_Datos();
            var recetas = ds.Tables[NombreTabla].AsEnumerable()
                .Where(r => r["ConsultaId"] != DBNull.Value &&
                           Convert.ToInt64(r["ConsultaId"]) == consultaId)
                .Select(HidratarObjeto)
                .OrderByDescending(r => r.Fecha)
                .ToList();

            return recetas;
        }

        /// Busca recetas crónicas vigentes
        public IList<Receta> BuscarCronicasVigentes()
        {
            return ObtenerTodos()
                .Where(r => r.EsCronica && r.ValidarVigencia())
                .OrderByDescending(r => r.Fecha)
                .ToList();
        }

        /// Busca recetas por número de socio
        public IList<Receta> BuscarPorNumeroSocio(int numeroSocio)
        {
            return ObtenerTodos()
                .Where(r => r.Nro_Socio == numeroSocio)
                .OrderByDescending(r => r.Fecha)
                .ToList();
        }

        /// Busca recetas en un rango de fechas
        public IList<Receta> BuscarPorRangoFechas(DateTime desde, DateTime hasta)
        {
            return ObtenerTodos()
                .Where(r => r.Fecha >= desde && r.Fecha <= hasta)
                .OrderByDescending(r => r.Fecha)
                .ToList();
        }

        private void AsignarDatos(DataRow dr, Receta entidad)
        {
            dr["ConsultaId"] = entidad.Consulta?.Id ?? (object)DBNull.Value;
            dr["Fecha"] = entidad.Fecha;
            dr["Medicamentos"] = entidad.Medicamentos ?? string.Empty;
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
                Fecha = Convert.ToDateTime(r["Fecha"]),
                Medicamentos = r["Medicamentos"]?.ToString() ?? string.Empty,
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