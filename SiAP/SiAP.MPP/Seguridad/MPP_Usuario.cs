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

        #region ABM
   
        public void Agregar(Usuario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];
            var dr = dt.NewRow();

            AsignarDatosUsuario(dr, entidad);
            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dt.Rows.Add(dr);

            GuardarPermisosUsuario(entidad, ds);
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Usuario entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Usuario"].AsEnumerable().FirstOrDefault(r => r["Id"].ToString() == entidad.Id.ToString())
                    ?? throw new Exception("Usuario no encontrado.");

            AsignarDatosUsuario(dr, entidad);
            ActualizarPermisos(entidad, ds);
            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Usuario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Usuario"].AsEnumerable()
                       .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();

            EliminarPermisosUsuario(entidad.Id, ds);
            _datos.Actualizar_BD(ds);
        }

        #endregion

        #region Busquedas

        public bool Existe(Usuario entidad)
        {
            if (entidad == null) return false;

            var ds = _datos.Obtener_Datos();
            return ds.Tables["Usuario"].AsEnumerable().Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Usuario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            if (entidad == null) return false;

            var ds = _datos.Obtener_Datos();
            return ds.Tables["UsuarioPermiso"].Select($"UsuarioId = '{entidad.Id}'").Any();
        }

        public IList<Usuario> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Usuario"].AsEnumerable().Select(r => HidratarObjeto(r, ds)).ToList();
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

        #endregion
        
        #region Permisos

        private void GuardarPermisosUsuario(Usuario entidad, DataSet ds)
        {
            if (entidad.Permiso is not PermisoCompuesto compuesto) return;

            var dt = ds.Tables["UsuarioPermiso"];
            var dr = dt.NewRow();
            dr["UsuarioId"] = entidad.Id;
            dr["PermisoId"] = compuesto.Id;
            dt.Rows.Add(dr);
        }

        public void AgregarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(usuario.Legajo.ToString()))
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null || string.IsNullOrWhiteSpace(permiso.Codigo))
                throw new ArgumentException("Permiso inválido.");

            var ds = _datos.Obtener_Datos();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];

            // Verificar si ya existe la relación
            var existeRelacion = dtUsuarioPermiso.AsEnumerable()
                .Any(r => r["UsuarioId"].ToString() == usuario.Legajo.ToString() &&
                          r["PermisoId"].ToString() == permiso.Codigo);

            if (existeRelacion)
                throw new InvalidOperationException("La relación usuario-permiso ya existe.");

            // Agregar nueva relación
            var nuevaFila = dtUsuarioPermiso.NewRow();
            nuevaFila["UsuarioId"] = usuario.Legajo;
            nuevaFila["PermisoId"] = permiso.Codigo;
            dtUsuarioPermiso.Rows.Add(nuevaFila);

            _datos.Actualizar_BD(ds);
        }

        public void QuitarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(usuario.Legajo.ToString()))
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null || string.IsNullOrWhiteSpace(permiso.Codigo))
                throw new ArgumentException("Permiso inválido.");

            var ds = _datos.Obtener_Datos();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];

            // Buscar y eliminar la relación
            var relacion = dtUsuarioPermiso.AsEnumerable()
                .FirstOrDefault(r => r["UsuarioId"].ToString() == usuario.Legajo.ToString() &&
                                    r["PermisoId"].ToString() == permiso.Codigo);

            if (relacion == null)
                throw new InvalidOperationException("La relación usuario-permiso no existe.");

            relacion.Delete();
            _datos.Actualizar_BD(ds);
        }
        
        #endregion

        #region Auxiliares
        
        private void AsignarDatosUsuario(DataRow dr, Usuario entidad)
        {
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
        }

        private Usuario HidratarObjeto(DataRow r, DataSet ds)
        {
            var usuario = new Usuario
            {
                Id = Convert.ToInt64(r["Id"]),
                Legajo = r["Legajo"] != DBNull.Value ? Convert.ToInt32(r["Legajo"]) : null,
                Username = r["Username"].ToString(),
                Nombre = r["Nombre"].ToString(),
                Apellido = r["Apellido"].ToString(),
                Email = r["Email"].ToString(),
                Password = r["Password"].ToString(),
                Bloqueado = Convert.ToBoolean(r["Bloqueado"]),
                Activo = Convert.ToBoolean(r["Activo"]),
                FechaUltimoCambioPassword = r["FechaUltimoCambioPassword"] != DBNull.Value ?
                                           Convert.ToDateTime(r["FechaUltimoCambioPassword"]) : null,
                PalabraClave = r["PalabraClave"].ToString(),
                RespuestaClave = r["RespuestaClave"].ToString()
            };

            CargarPermisosUsuario(usuario, ds);
            return usuario;
        }

        private void CargarPermisosUsuario(Usuario usuario, DataSet ds)
        {
            var permisos = _instanciaPermiso.ObtenerTodos().ToDictionary(p => p.Id);
            var relaciones = ds.Tables["UsuarioPermiso"].Select($"UsuarioId = '{usuario.Id}'");

            foreach (var rel in relaciones)
            {
                var permisoId = Convert.ToInt64(rel["PermisoId"]);
                if (permisos.TryGetValue(permisoId, out var permiso) && permiso is PermisoCompuesto compuesto)
                {
                    usuario.Permiso = compuesto;
                    break; // Solo uno por usuario según la lógica actual
                }
            }
        }

        private void ActualizarPermisos(Usuario entidad, DataSet ds)
        {
            EliminarPermisosUsuario(entidad.Id, ds);
            GuardarPermisosUsuario(entidad, ds);
        }

        private void EliminarPermisosUsuario(long usuarioId, DataSet ds)
        {
            try
            {
                var relaciones = ds.Tables["UsuarioPermiso"].Select($"UsuarioId = '{usuarioId}'");
                foreach (var rel in relaciones) rel.Delete();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}

