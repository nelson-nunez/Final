using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.MPP.Base;
using Policonsultorio.BE;

namespace SiAP.MPP
{
    public class MPP_Certificado : MapperBase<Certificado>, IMapper<Certificado>
    {
        private static MPP_Certificado _instancia;
        protected override string NombreTabla => "Certificado";

        private MPP_Certificado() : base() { }

        public static MPP_Certificado ObtenerInstancia()
        {
            return _instancia ??= new MPP_Certificado();
        }

        public void Agregar(Certificado entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (Existe(entidad))
                return;

            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Certificado entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ModificarEntidad(entidad, ModificarDatos);
        }

        public void Eliminar(Certificado entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            EliminarEntidad(entidad);
        }

        public bool Existe(Certificado entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Certificado entidad)
        {
            return false; // Los certificados no tienen dependencias
        }

        public IList<Certificado> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Certificado LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Certificado> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var certificados = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return certificados;

            return campo.ToLower() switch
            {
                "consultaid" => certificados.Where(c => c.Consulta?.Id == Convert.ToInt64(valor)).ToList(),
                "tipo" => certificados.Where(c => c.TipoCertificado?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "descripcion" => certificados.Where(c => c.Descripcion?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        // Busca todos los certificados de una consulta específica
        public IList<Certificado> BuscarPorConsultaId(long consultaId)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var certificados = ds.Tables[NombreTabla].AsEnumerable()
                .Where(r => r["ConsultaId"] != DBNull.Value &&
                           Convert.ToInt64(r["ConsultaId"]) == consultaId)
                .Select(HidratarObjeto)
                .OrderByDescending(c => c.Fecha)
                .ToList();

            return certificados;
        }

        // Busca certificados por tipo
        public IList<Certificado> BuscarPorTipo(string tipoCertificado)
        {
            if (string.IsNullOrWhiteSpace(tipoCertificado))
                return new List<Certificado>();

            return ObtenerTodos()
                .Where(c => c.TipoCertificado?.Equals(tipoCertificado, StringComparison.OrdinalIgnoreCase) ?? false)
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        // Busca certificados vigentes
        public IList<Certificado> BuscarVigentes()
        {
            return ObtenerTodos()
                .Where(c => c.EstaVigente())
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        // Busca certificados en un rango de fechas
        public IList<Certificado> BuscarPorRangoFechas(DateTime desde, DateTime hasta)
        {
            return ObtenerTodos().Where(c => c.Fecha >= desde && c.Fecha <= hasta)
                .OrderByDescending(c => c.Fecha).ToList();
        }

        // Busca certificados que vencen en un rango de fechas
        public IList<Certificado> BuscarProximosAVencer(int dias)
        {
            var fechaLimite = DateTime.Now.AddDays(dias);

            return ObtenerTodos()
                    .Where(c => c.FechaVigenciaHasta != default(DateTime) &&
                               c.FechaVigenciaHasta <= fechaLimite &&
                               c.FechaVigenciaHasta >= DateTime.Now)
                    .OrderBy(c => c.FechaVigenciaHasta).ToList();
        }

        private void ModificarDatos(DataRow dr, Certificado entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["TipoCertificado"] = entidad.TipoCertificado ?? string.Empty;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
            dr["FechaVigenciaDesde"] = entidad.FechaVigenciaDesde != default(DateTime) ? entidad.FechaVigenciaDesde : (object)DBNull.Value;
            dr["FechaVigenciaHasta"] = entidad.FechaVigenciaHasta != default(DateTime) ? entidad.FechaVigenciaHasta : (object)DBNull.Value;
        }

        private void AsignarDatos(DataRow dr, Certificado entidad)
        {
            dr["ConsultaId"] = entidad.Consulta?.Id ?? (object)DBNull.Value;
            dr["Fecha"] = entidad.Fecha;
            dr["TipoCertificado"] = entidad.TipoCertificado ?? string.Empty;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["Profesional"] = entidad.Profesional ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
            dr["FechaVigenciaDesde"] = entidad.FechaVigenciaDesde != default(DateTime) ? entidad.FechaVigenciaDesde : (object)DBNull.Value;
            dr["FechaVigenciaHasta"] = entidad.FechaVigenciaHasta != default(DateTime) ? entidad.FechaVigenciaHasta : (object)DBNull.Value;
        }

        private Certificado HidratarObjeto(DataRow r)
        {
            return new Certificado
            {
                Id = Convert.ToInt64(r["Id"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                TipoCertificado = r["TipoCertificado"]?.ToString() ?? string.Empty,
                Descripcion = r["Descripcion"]?.ToString() ?? string.Empty,
                Observaciones = r["Observaciones"]?.ToString() ?? string.Empty,
                Profesional = r["Profesional"]?.ToString() ?? string.Empty,
                FechaVigenciaDesde = r["FechaVigenciaDesde"] != DBNull.Value ? Convert.ToDateTime(r["FechaVigenciaDesde"]) : default(DateTime),
                FechaVigenciaHasta = r["FechaVigenciaHasta"] != DBNull.Value ? Convert.ToDateTime(r["FechaVigenciaHasta"]) : default(DateTime)
            };
        }
    }
}