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
                // Crear el backup físico en el sistema de archivos
                _datos.CrearBackup(entidad.NombreArchivo);

                // Registrar el backup en la tabla
                AgregarEntidad(entidad, AsignarDatos);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el respaldo: {ex.Message}", ex);
            }
        }

        public void Modificar(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            try
            {
                // Eliminar el backup físico del sistema de archivos
                _datos.EliminarBackup(entidad.NombreArchivo);

                // Eliminar el registro de la tabla
                EliminarEntidad(entidad);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el respaldo: {ex.Message}", ex);
            }
        }

        public bool Existe(Respaldo entidad)
        {
            if (entidad == null)
                return false;

            var ds = _datos.ObtenerDatos_BDSiAP();
            return ds.Tables[NombreTabla].AsEnumerable().Any(r => r["NombreArchivo"].ToString() == entidad.NombreArchivo);
        }

        public bool TieneDependencias(Respaldo entidad)
        {
            // respaldos no tienen dependencias
            return false;
        }

        public IList<Respaldo> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Respaldo LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Respaldo> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var respaldos = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return respaldos;

            return campo.ToLower() switch
            {
                "id" => BuscarPorCampo(respaldos, campo, valor, r => r.Id),
                "nombrearchivo" => BuscarPorCampo(respaldos, campo, valor, r => r.NombreArchivo),
                "descripcion" => BuscarPorCampo(respaldos, campo, valor, r => r.Descripcion),
                "creadopor" => BuscarPorCampo(respaldos, campo, valor, r => r.CreadoPor),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Respaldo LeerPorNombreArchivo(string nombreArchivo)
        {
            if (string.IsNullOrWhiteSpace(nombreArchivo))
                return null;

            return ObtenerTodos().FirstOrDefault(r => r.NombreArchivo.Equals(nombreArchivo, StringComparison.OrdinalIgnoreCase));
        }

        public void RestaurarRespaldo(Respaldo entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (!Existe(entidad))
                throw new Exception("El respaldo no existe en el sistema.");

            try
            {
                _datos.RestaurarBackup(entidad.NombreArchivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar el respaldo: {ex.Message}", ex);
            }
        }

        public IList<Respaldo> ObtenerRespaldosRecientes(int cantidad = 10)
        {
            return ObtenerTodos()
                .OrderByDescending(r => r.FechaCreacion)
                .Take(cantidad)
                .ToList();
        }

        public IList<Respaldo> FiltrarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return ObtenerTodos()
                .Where(r => r.FechaCreacion >= fechaDesde && r.FechaCreacion <= fechaHasta)
                .OrderByDescending(r => r.FechaCreacion)
                .ToList();
        }

        private void AsignarDatos(DataRow dr, Respaldo entidad)
        {
            dr["NombreArchivo"] = entidad.NombreArchivo;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["FechaCreacion"] = entidad.FechaCreacion;
            dr["CreadoPor"] = entidad.CreadoPor ?? string.Empty;
            dr["TamanioKB"] = entidad.TamanioKB;
        }

        private Respaldo HidratarObjeto(DataRow rRespaldo)
        {
            return new Respaldo
            {
                Id = Convert.ToInt64(rRespaldo["Id"]),
                NombreArchivo = rRespaldo["NombreArchivo"].ToString(),
                Descripcion = rRespaldo["Descripcion"].ToString(),
                FechaCreacion = Convert.ToDateTime(rRespaldo["FechaCreacion"]),
                CreadoPor = rRespaldo["CreadoPor"].ToString(),
                TamanioKB = Convert.ToInt64(rRespaldo["TamanioKB"])
            };
        }
    }
}