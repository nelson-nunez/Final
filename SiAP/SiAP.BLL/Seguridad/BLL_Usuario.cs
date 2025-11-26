using SiAP.BE.Seguridad;
using SiAP.Abstracciones;
using SiAP.BLL.Base;
using SiAP.MPP.Seguridad;
using SiAP.BLL.Logs;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Usuario : IBLL<Usuario>
    {
        private readonly MPP_Usuario _mppUsuario;
        private static BLL_Usuario _instancia;
        private readonly ILogger _logger;
        private IEncriptacion _encriptacion;

        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Usuario()
        {
            _mppUsuario = MPP_Usuario.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
            _encriptacion = new Encriptador();
        }

        public static BLL_Usuario ObtenerInstancia()
        {
            return _instancia ??= new BLL_Usuario();
        }

        public void Agregar(Usuario usuario)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);

            if (_mppUsuario.Existe(usuario))
                throw new InvalidOperationException("El usuario ya existe.");

            // Pass inicial es Cambiar_username
            usuario.Password = _encriptacion.Encriptar3DES("Cambiar_" + usuario.Username);

            // Inicializar la lista de permisos si es null
            usuario.Permisos ??= new List<Permiso>();

            _mppUsuario.Agregar(usuario);
            _logger.GenerarLog($"Usuario agregado: {usuario.Username}");
        }

        public void Modificar(Usuario usuario)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);

            _mppUsuario.Modificar(usuario);
            _logger.GenerarLog($"Usuario modificado: {usuario.Username}");
        }

        public void Eliminar(Usuario usuario)
        {
            if (_mppUsuario.TieneDependencias(usuario))
                throw new InvalidOperationException("El usuario tiene dependencias y no puede eliminarse.");

            _mppUsuario.Eliminar(usuario);
            _logger.GenerarLog($"Usuario eliminado: {usuario.Username}");
        }

        public IList<Usuario> ObtenerTodos()
        {
            return _mppUsuario.ObtenerTodos();
        }

        public Usuario Leer(long usuarioId)
        {
            return _mppUsuario.LeerPorId(usuarioId);
        }

        public Usuario BuscarPorIdPersona(long personaId)
        {
            return _mppUsuario.BuscarPorIdPersona(personaId);
        }

        public bool EsValido(Usuario usuario)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(usuario.Username))
                _mensajeError += "El username es obligatorio. ";

            if (string.IsNullOrWhiteSpace(usuario.Password))
                _mensajeError += "La contraseña es obligatoria. ";

            return string.IsNullOrEmpty(_mensajeError);
        }

        #region Ops especiales

        public bool Ingresar(string username, string password)
        {
            Usuario usr = _mppUsuario.LeerPorUsername(username);

            // Busco Usuario
            if (usr == null)
                throw new Exception("Nombre de Usuario o Contraseña incorrectos");

            // Verifico Password 
            string passEncripted = _encriptacion.Encriptar3DES(password);
            if (!passEncripted.Equals(usr.Password))
                throw new Exception("Nombre de Usuario o Contraseña incorrectos");

            // Activo
            if (!usr.Activo)
                throw new Exception("El usuario está deshabilitado.");

            // Bloqueado
            if (usr.Bloqueado)
                throw new Exception("El usuario está bloqueado, debe contactar al administrador.");

            // Aca otra verificaciones relacionadas a intentos o bloqueos
            // {
            //     if (!usr.FechaUltimoCambioPassword.HasValue)
            //         if (FlagsSeguridad.DiasVigenciaPassword > 0 &&
            // }

            // Si todo Ok, lo asigno a Gestion
            GestionUsuario.UsuarioLogueado = usr;
            return GestionUsuario.UsuarioLogueado != null;
        }

        public void Blanqueo(Usuario usuario)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);

            usuario.Password = _encriptacion.Encriptar3DES(usuario.Password);
            _mppUsuario.Modificar(usuario);
            _logger.GenerarLog($"Contraseña blanqueada para usuario: {usuario.Username}");
        }

        #endregion

        #region Permisos

        public void AgregarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || usuario.Id == 0)
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null)
                throw new ArgumentNullException(nameof(permiso));

            // Verificar que el usuario no tenga ya el permiso
            if (usuario.Permisos != null && usuario.Permisos.Any(p => p.Id == permiso.Id))
                throw new InvalidOperationException($"El usuario ya tiene el permiso: {permiso.Descripcion}");

            _mppUsuario.AgregarPermiso(usuario, permiso);
            _logger.GenerarLog($"Permiso agregado al usuario {usuario.Username}: {permiso.Descripcion}");
        }

        public void QuitarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || usuario.Id == 0)
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null)
                throw new ArgumentNullException(nameof(permiso));

            // Verificar que el usuario tenga el permiso
            if (usuario.Permisos == null || !usuario.Permisos.Any(p => p.Id == permiso.Id))
                throw new InvalidOperationException($"El usuario no tiene el permiso: {permiso.Descripcion}");

            _mppUsuario.QuitarPermiso(usuario, permiso);
            _logger.GenerarLog($"Permiso removido del usuario {usuario.Username}: {permiso.Descripcion}");
        }

        #endregion
    }
}
