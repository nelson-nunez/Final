using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.MPP.Base;

namespace SiAP.MPP.Seguridad
{
    public class MPP_Rol : IMapper<Rol>
    {
        private IGestorDatos _datos;
        private static MPP_Rol _mppRol = null;

        private MPP_Rol()
        {
            _datos = GestorDatos.ObtenerInstancia();
        }

        public static MPP_Rol ObtenerInstancia()
        {
            return _mppRol != null ? _mppRol : new MPP_Rol();
        }

        public void Agregar(Rol entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Rol"];
            var dr = dt.NewRow();
            dr["Codigo"] = entidad.Codigo;
            dr["Descripcion"] = entidad.Descripcion;
            dt.Rows.Add(dr);
            _datos.Guardar_Datos(ds);
        }

        public void Modificar(Rol entidad, string idAnterior = null)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Rol"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => r["Codigo"].ToString() == idAnterior);
            if (dr == null) throw new Exception("Rol no encontrado");

            dr["Codigo"] = entidad.Codigo;
            dr["Descripcion"] = entidad.Descripcion;
            _datos.Guardar_Datos(ds);
        }

        public void Eliminar(Rol entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Rol"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => r["Codigo"].ToString() == entidad.Codigo);
            if (dr != null) dr.Delete();
            _datos.Guardar_Datos(ds);
        }

        public bool Existe(Rol entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Rol"]
                     .AsEnumerable()
                     .Any(r => r["Codigo"].ToString() == entidad.Codigo);
        }

        public bool TieneDependencias(Rol entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dtUsuarioRol = ds.Tables["UsuarioRol"];
            return dtUsuarioRol.Select($"RolCodigo = '{entidad.Codigo}'").Length > 0;
        }

        public IList<Rol> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Rol"]
                     .AsEnumerable()
                     .Select(HidratarObjeto)
                     .ToList();
        }

        public IList<Rol> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var ds = _datos.Obtener_Datos();
            var tabla = ds.Tables["Rol"];

            if (!tabla.Columns.Contains(campo))
                throw new ArgumentException($"El campo '{campo}' no existe en la tabla Rol.");

            string filtro = $"{campo} LIKE '%{(valor)}%'";
            var rows = tabla.Select(filtro);
            return rows.Select(HidratarObjeto).ToList();
        }

        public Rol LeerPorId(object id)
        {
            var ds = _datos.Obtener_Datos();
            var row = ds.Tables["Rol"]
                        .AsEnumerable()
                        .FirstOrDefault(r => r["Codigo"].ToString() == id.ToString());
            return row != null ? HidratarObjeto(row) : null;
        }

        private Rol HidratarObjeto(DataRow row)
        {
            return new Rol(row["Codigo"].ToString(), row["Descripcion"].ToString());
        }
    }
}
