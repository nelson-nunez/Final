using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Respaldo : MapperBase<Respaldo>, IMapper<Respaldo>
    {
        private static MPP_Respaldo _instancia;
        private readonly IAccesoDatos _datos;
        protected override string NombreTabla => "Respaldo";

        private MPP_Respaldo() : base()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Respaldo ObtenerInstancia()
        {
            return _instancia ??= new MPP_Respaldo();
        }

        public void Agregar(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            if (Existe(entidad))
                return;

            try
            {
                ArgumentNullException.ThrowIfNull(entidad);
                
                // Crear el backup físico en el sistema de archivos
                _datos.CrearRespaldo(entidad);
                // Registrar el backup en la tabla
                entidad.Tipo = TipoRespaldo.Backup;
                var ds = _datos.ObtenerDatos_BDRespaldos();
                var dt = ds.Tables[NombreTabla];
                var dr = dt.NewRow();
                long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
                dr["Id"] = nuevoId;
                AsignarDatos(dr, entidad);
                dt.Rows.Add(dr);
                _datos.Actualizar_BDRespaldos(ds);
                entidad.Id = nuevoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el respaldo: {ex.Message}", ex);
            }
        }
        
        public void Eliminar(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            try
            {
                ArgumentNullException.ThrowIfNull(entidad);
                
                if (entidad.Tipo == TipoRespaldo.Restore)
                    throw new Exception($"No se pueden eliminar acciones de restauración");

                // Eliminar el backup físico del sistema de archivos
                _datos.EliminarRespaldo(entidad);

                // Eliminar el registro de la tabla
                var ds = _datos.ObtenerDatos_BDRespaldos();
                var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
                dr?.Delete();
                _datos.Actualizar_BDRespaldos(ds);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el respaldo: {ex.Message}", ex);
            }
        }

        public void RestaurarRespaldo(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (!Existe(entidad))
                throw new Exception("El respaldo no existe en el sistema.");

            try
            {
                _datos.RestaurarRespaldo(entidad);
                // Modifico
                entidad.Tipo = TipoRespaldo.Restore;
                Modificar(entidad);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar el respaldo: {ex.Message}", ex);
            }
        }
        
        public void Modificar(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var ds = _datos.ObtenerDatos_BDRespaldos();
            var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            AsignarDatos(dr, entidad);
            _datos.Actualizar_BDRespaldos(ds);
        }

        public bool Existe(Respaldo entidad)
        {
            if (entidad == null)
                return false;

            var ds = _datos.ObtenerDatos_BDRespaldos();
            return ds.Tables[NombreTabla].AsEnumerable().Any(r => r["Id"].ToString() == entidad.Id.ToString());
        }

        public IList<Respaldo> ObtenerTodos()
        {
            var ds = _datos.ObtenerDatos_BDRespaldos();
            var result = ds.Tables[NombreTabla].AsEnumerable().Select(HidratarObjeto).ToList();
            return result;
        }

        public IList<Respaldo> FiltrarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return ObtenerTodos()
                .Where(r => r.FechaCreacion.Date >= fechaDesde.Date && r.FechaCreacion.Date <= fechaHasta.Date)
                .OrderByDescending(r => r.FechaCreacion)
                .ToList();
        }

        private void AsignarDatos(DataRow dr, Respaldo entidad)
        {
            dr["NombreArchivo"] = entidad.NombreArchivo;
            dr["NombreBD"] = entidad.NombreBD;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["FechaCreacion"] = entidad.FechaCreacion;
            dr["CreadoPor"] = entidad.CreadoPor ?? string.Empty;
            dr["TamanioKB"] = entidad.TamanioKB;
            dr["Tipo"] = entidad.Tipo;
        }

        private Respaldo HidratarObjeto(DataRow rRespaldo)
        {
            return new Respaldo
            {
                Id = Convert.ToInt64(rRespaldo["Id"]),
                NombreArchivo = rRespaldo["NombreArchivo"].ToString(),
                NombreBD = rRespaldo["NombreBD"].ToString(),
                Tipo = rRespaldo["Tipo"].ToString(),
                Descripcion = rRespaldo["Descripcion"].ToString(),
                FechaCreacion = Convert.ToDateTime(rRespaldo["FechaCreacion"]),
                CreadoPor = rRespaldo["CreadoPor"].ToString(),
                TamanioKB = Convert.ToInt64(rRespaldo["TamanioKB"])
            };
        }
        
        
        //--------------------------------------------------------------
        public bool TieneDependencias(Respaldo entidad)
        {
            // respaldos no tienen dependencias
            return false;
        }
        public Respaldo LeerPorId(object id)
        {
            return  null;
        }
        public IList<Respaldo> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            throw new NotImplementedException();
        }
    }
}