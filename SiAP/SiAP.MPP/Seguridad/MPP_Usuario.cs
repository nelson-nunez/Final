using System.Data;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.MPP.Base;

namespace SiAP.MPP.Seguridad
{
    public class MPP_Usuario : MapperBase<Usuario>, IMapper<Usuario>
    {
        private static MPP_Usuario _instancia;
        private static MPP_Permiso _instanciaPermiso;
        private static MPP_Persona _instanciaPersona;
        protected override string NombreTabla => "Usuario";

        private MPP_Usuario() : base()
        {
            _instanciaPermiso = MPP_Permiso.ObtenerInstancia();
            _instanciaPersona = MPP_Persona.ObtenerInstancia();
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

            // Usar método de la base para agregar
            AgregarEntidad(entidad, AsignarDatosUsuario);

            // Guardar permisos después de agregar
            var ds = _datos.ObtenerDatos_BDSiAP();
            GuardarPermisosUsuario(entidad, ds);
            _datos.Actualizar_BDSiAP(ds);
        }

        public void Modificar(Usuario entidad)
        {
            // Usar método de la base para modificar
            ModificarEntidad(entidad, AsignarDatosUsuario);

            // Actualizar permisos
            var ds = _datos.ObtenerDatos_BDSiAP();
            ActualizarPermisos(entidad, ds);
            _datos.Actualizar_BDSiAP(ds);
        }

        public void Eliminar(Usuario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.ObtenerDatos_BDSiAP();

            // Eliminar permisos antes de eliminar usuario
            EliminarPermisosUsuario(entidad.Id, ds);

            // Usar método de la base para eliminar
            EliminarEntidad(entidad);
        }

        #endregion

        #region Búsquedas

        public bool Existe(Usuario entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Usuario entidad)
        {
            if (entidad == null) return false;
            return TieneDependenciasEnTabla(entidad.Id, "UsuarioPermiso", "UsuarioId");
        }

        public IList<Usuario> ObtenerTodos()
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var lista = ds.Tables[NombreTabla].AsEnumerable().Select(r => HidratarObjeto(r, ds)).ToList();
            return lista;
        }

        public Usuario LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(u => u.Id == Convert.ToInt64(id));
        }

        public Usuario BuscarPorIdPersona(long personId)
        {
            var result = ObtenerTodos().FirstOrDefault(u => u.PersonaId == Convert.ToInt64(personId));
            return result;
        }

        public Usuario LeerPorUsername(string username)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var row = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(dr => dr["Username"].ToString().Equals(username, StringComparison.OrdinalIgnoreCase));

            return row != null ? HidratarObjeto(row, ds) : null;
        }

        #endregion

        #region Permisos

        private void GuardarPermisosUsuario(Usuario entidad, DataSet ds)
        {
            // Verificar que la lista de permisos no sea null o vacía
            if (entidad.Permisos == null || entidad.Permisos.Count == 0) return;

            var dt = ds.Tables["UsuarioPermiso"];

            // Iterar sobre todos los permisos del usuario
            foreach (var permiso in entidad.Permisos)
            {
                var dr = dt.NewRow();
                dr["UsuarioId"] = entidad.Id;
                dr["PermisoId"] = permiso.Id;
                dt.Rows.Add(dr);
            }
        }

        public void AgregarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || usuario.Id == 0)
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null || permiso.Id == 0)
                throw new ArgumentException("Permiso inválido.");

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];

            // Verificar si ya existe la relación
            var existeRelacion = dtUsuarioPermiso.AsEnumerable().Any(r =>
                Convert.ToInt64(r["UsuarioId"]) == usuario.Id &&
                Convert.ToInt64(r["PermisoId"]) == permiso.Id);

            if (existeRelacion)
                throw new InvalidOperationException("La relación usuario-permiso ya existe.");

            // Agregar nueva relación
            var nuevaFila = dtUsuarioPermiso.NewRow();
            nuevaFila["UsuarioId"] = usuario.Id;
            nuevaFila["PermisoId"] = permiso.Id;
            dtUsuarioPermiso.Rows.Add(nuevaFila);

            _datos.Actualizar_BDSiAP(ds);
        }

        public void QuitarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || usuario.Id == 0)
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null || permiso.Id == 0)
                throw new ArgumentException("Permiso inválido.");

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];

            // Buscar y eliminar la relación
            var relacion = dtUsuarioPermiso.AsEnumerable().FirstOrDefault(r =>
                Convert.ToInt64(r["UsuarioId"]) == usuario.Id &&
                Convert.ToInt64(r["PermisoId"]) == permiso.Id);

            if (relacion == null)
                throw new InvalidOperationException("La relación usuario-permiso no existe.");

            relacion.Delete();
            _datos.Actualizar_BDSiAP(ds);
        }

        #endregion

        #region Auxiliares

        private void AsignarDatosUsuario(DataRow dr, Usuario entidad)
        {
            dr["Username"] = entidad.Username;
            dr["Password"] = entidad.Password;
            dr["Bloqueado"] = entidad.Bloqueado;
            dr["Activo"] = entidad.Activo;
            dr["FechaUltimoCambioPassword"] = entidad.FechaUltimoCambioPassword ?? (object)DBNull.Value;
            dr["PalabraClave"] = entidad.PalabraClave ?? string.Empty;
            dr["RespuestaClave"] = entidad.RespuestaClave ?? string.Empty;
            dr["PersonaId"] = entidad.PersonaId;
        }

        private Usuario HidratarObjeto(DataRow r, DataSet ds)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = r["Id"] != DBNull.Value ? Convert.ToInt64(r["Id"]) : 0,
                    Username = r["Username"]?.ToString() ?? string.Empty,
                    Password = r["Password"]?.ToString() ?? string.Empty,
                    Bloqueado = r["Bloqueado"] != DBNull.Value && Convert.ToBoolean(r["Bloqueado"]),
                    Activo = r["Activo"] != DBNull.Value && Convert.ToBoolean(r["Activo"]),
                    FechaUltimoCambioPassword = r["FechaUltimoCambioPassword"] != DBNull.Value ? Convert.ToDateTime(r["FechaUltimoCambioPassword"]) : null,
                    PalabraClave = r["PalabraClave"]?.ToString() ?? string.Empty,
                    RespuestaClave = r["RespuestaClave"]?.ToString() ?? string.Empty,
                    PersonaId = r["PersonaId"] != DBNull.Value ? Convert.ToInt64(r["PersonaId"]) : 0,
                    Permisos = new List<Permiso>() // Inicializar la lista
                };

                CargarPersonaCompleta(usuario);
                CargarPermisosUsuario(usuario, ds);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al hidratar el objeto Usuario: {ex.Message}", ex);
            }
        }

        private void CargarPersonaCompleta(Usuario usuario)
        {
            if (usuario.PersonaId.HasValue && usuario.PersonaId.Value > 0)
                usuario.Persona = _instanciaPersona.LeerPorIdSinUsuario(usuario.PersonaId.Value);
        }

        private void CargarPermisosUsuario(Usuario usuario, DataSet ds)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            var permisos = _instanciaPermiso.ObtenerTodos().ToDictionary(p => p.Id);
            var dtrelaciones = ds.Tables["UsuarioPermiso"];
            var relaciones = dtrelaciones.AsEnumerable().Where(r => Convert.ToInt64(r["UsuarioId"]) == usuario.Id);

            foreach (var rel in relaciones)
            {
                var permisoId = Convert.ToInt64(rel["PermisoId"]);

                if (permisos.TryGetValue(permisoId, out var permiso))
                {
                    usuario.Permisos.Add(permiso);
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
            var relaciones = ds.Tables["UsuarioPermiso"].Select($"UsuarioId = '{usuarioId}'");
            foreach (var rel in relaciones)
                rel.Delete();
        }

        #endregion
    }
}