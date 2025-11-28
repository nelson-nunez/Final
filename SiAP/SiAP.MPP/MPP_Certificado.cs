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

        public void AsignarDatos(DataRow dr, Certificado entidad)
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

        public Certificado HidratarObjeto(DataRow r)
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

        // Otros
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

        private void ModificarDatos(DataRow dr, Certificado entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["TipoCertificado"] = entidad.TipoCertificado ?? string.Empty;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
            dr["FechaVigenciaDesde"] = entidad.FechaVigenciaDesde != default(DateTime) ? entidad.FechaVigenciaDesde : (object)DBNull.Value;
            dr["FechaVigenciaHasta"] = entidad.FechaVigenciaHasta != default(DateTime) ? entidad.FechaVigenciaHasta : (object)DBNull.Value;
        }
    }
}