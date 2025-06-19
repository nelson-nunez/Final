using System.Data;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP.Seguridad
{
    public class MPP_Usuario : IMapper<Usuario>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Usuario _instancia;
        private static MPP_Permiso _instanciaPermiso;

        private MPP_Usuario()
        {
            _datos = AccesoXML.ObtenerInstancia();
            _instanciaPermiso = MPP_Permiso.ObtenerInstancia();
        }

        public static MPP_Usuario ObtenerInstancia()
        {
            return _instancia ??= new MPP_Usuario();
        }

        public void Agregar(Usuario entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];

            if (Existe(entidad)) 
                return;

            var dr = dt.NewRow();
            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Legajo"] = entidad.Legajo ?? (object)DBNull.Value;
            dr["Username"] = entidad.Username;
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Email"] = entidad.Email;
            dr["Password"] = entidad.Password;
            dr["Bloqueado"] = entidad.Bloqueado;
            dr["Activo"] = entidad.Activo;
            dr["FechaUltimoCambioPassword"] = entidad.FechaUltimoCambioPassword ?? (object)DBNull.Value;
            dr["PalabraClave"] = entidad.PalabraClave ?? string.Empty;
            dr["RespuestaClave"] = entidad.RespuestaClave ?? string.Empty;
            
            dt.Rows.Add(dr);

            GuardarPermisosUsuario(entidad, ds);
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Usuario entidad, string idAnterior = null)
        {
            if (entidad == null || string.IsNullOrWhiteSpace(idAnterior))
                throw new ArgumentException("Usuario o ID anterior inválido.");

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => r["Id"].ToString() == idAnterior);

            if (dr == null)
                throw new Exception("Usuario no encontrado.");

            dr["Legajo"] = entidad.Legajo ?? (object)DBNull.Value;
            dr["Username"] = entidad.Username;
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Email"] = entidad.Email;
            dr["Password"] = entidad.Password;
            dr["Bloqueado"] = entidad.Bloqueado;
            dr["Activo"] = entidad.Activo;
            dr["FechaUltimoCambioPassword"] = entidad.FechaUltimoCambioPassword ?? (object)DBNull.Value;
            dr["PalabraClave"] = entidad.PalabraClave ?? string.Empty;
            dr["RespuestaClave"] = entidad.RespuestaClave ?? string.Empty;

            // Actualizar permisos
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];
            var relaciones = dtUsuarioPermiso.Select($"UsuarioId = '{idAnterior}'");
            foreach (var rel in relaciones) rel.Delete();

            GuardarPermisosUsuario(entidad, ds);
            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Usuario entidad)
        {
            if (entidad == null) throw new ArgumentNullException(nameof(entidad));

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();

            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];
            var relaciones = dtUsuarioPermiso.Select($"UsuarioId = '{entidad.Id}'");
            foreach (var rel in relaciones) rel.Delete();

            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Usuario entidad)
        {
            if (entidad == null) return false;

            var ds = _datos.Obtener_Datos();
            return ds.Tables["Usuario"].AsEnumerable()
                     .Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Usuario entidad)
        {
            if (entidad == null) return false;

            var ds = _datos.Obtener_Datos();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];
            var relaciones = dtUsuarioPermiso.Select($"UsuarioId = '{entidad.Id}'");

            return relaciones.Any();
        }

        public IList<Usuario> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];
            return dt.AsEnumerable()
                     .Select(r => HidratarObjeto(r, ds))
                     .ToList();
        }

        public IList<Usuario> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var usuarios = ObtenerTodos();

            if (!incluirInactivos)
                usuarios = usuarios.Where(u => u.Activo).ToList();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return usuarios;

            return campo.ToLower() switch
            {
                "id" => usuarios.Where(u => u.Id == Convert.ToInt64(valor)).ToList(),
                "username" => usuarios.Where(u => u.Username.Contains(valor)).ToList(),
                "nombre" => usuarios.Where(u => u.Nombre.Contains(valor)).ToList(),
                "apellido" => usuarios.Where(u => u.Apellido.Contains(valor)).ToList(),
                "email" => usuarios.Where(u => u.Email.Contains(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Usuario LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(u => u.Id == Convert.ToInt64(id.ToString()));
        }

        public Usuario LeerPorUsername(string username)
        {
            var ds = _datos.Obtener_Datos();
            var row = ds.Tables["Usuario"]
                        .AsEnumerable()
                        .FirstOrDefault(dr => dr["Username"].ToString() == username);

            return row != null ? HidratarObjeto(row, ds) : null;
        }

        private Usuario HidratarObjeto(DataRow r, DataSet ds)
        {
            var usuario = new Usuario
            {
                Id = Convert.ToInt64(r["Id"]),
                Legajo = r["Legajo"] != DBNull.Value ? Convert.ToInt32(r["Legajo"]) : (int?)null,
                Username = r["Username"].ToString(),
                Nombre = r["Nombre"].ToString(),
                Apellido = r["Apellido"].ToString(),
                Email = r["Email"].ToString(),
                Password = r["Password"].ToString(),
                Bloqueado = Convert.ToBoolean(r["Bloqueado"]),
                Activo = Convert.ToBoolean(r["Activo"]),
                FechaUltimoCambioPassword = r["FechaUltimoCambioPassword"] != DBNull.Value ? Convert.ToDateTime(r["FechaUltimoCambioPassword"]) : (DateTime?)null,
                PalabraClave = r["PalabraClave"].ToString(),
                RespuestaClave = r["RespuestaClave"].ToString()
            };

            var permisos = _instanciaPermiso.ObtenerTodos().ToDictionary(p => p.Id);
            var dtRelacion = ds.Tables["UsuarioPermiso"];
            var relaciones = dtRelacion.Select($"UsuarioId = '{usuario.Id}'");

            foreach (var rel in relaciones)
            {
                //aca quede buscando los permissos que los trae sin id o nose como estan manbeados
                var codigo = Convert.ToInt64(rel["PermisoId"].ToString());
                var permiso = permisos.FirstOrDefault(x => x.Value.Id == codigo).Value;
                if (permiso!=null && permiso is PermisoCompuesto compuesto)
                {
                    usuario.Permiso = compuesto;
                }
            }

            return usuario;
        }

        private void GuardarPermisosUsuario(Usuario entidad, DataSet ds)
        {
            if (entidad.Permiso is not PermisoCompuesto compuesto) return;

            var dt = ds.Tables["UsuarioPermiso"];
            var dr = dt.NewRow();
            dr["UsuarioId"] = entidad.Id;
            dr["PermisoId"] = compuesto.Codigo;
            dt.Rows.Add(dr);
        }

    }
}

