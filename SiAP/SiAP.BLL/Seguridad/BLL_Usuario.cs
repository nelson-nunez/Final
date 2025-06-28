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

            usuario.Password = _encriptacion.Encriptar3DES(usuario.Password);
            _mppUsuario.Agregar(usuario);
            _logger.GenerarLog($"Usuario agregado: {usuario.Username}");
        }

        public void Modificar(Usuario usuario)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);
            if (string.IsNullOrEmpty(usuario.Password))
                usuario.Password = _encriptacion.Encriptar3DES(usuario.Password);
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

        public Usuario Leer(Usuario usuario)
        {
            return _mppUsuario.LeerPorId(usuario.Legajo);
        }

        public bool EsValido(Usuario usuario)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(usuario.Username))
                _mensajeError += "El username es obligatorio. ";

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                _mensajeError += "El nombre es obligatorio. ";

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                _mensajeError += "El apellido es obligatorio. ";

            if (string.IsNullOrWhiteSpace(usuario.Email))
                _mensajeError += "El email es obligatorio. ";

            if (string.IsNullOrWhiteSpace(usuario.Password))
                _mensajeError += "La contraseña es obligatoria. ";

            return string.IsNullOrEmpty(_mensajeError);
        }

        #region Ops especiales
        public bool Ingresar(string username, string password)
        {                    
            Usuario usr = _mppUsuario.LeerPorUsername(username);
            //Busco Usuario
            if (usr == null)
                throw new Exception("Nombre de Usuario o Contraseña incorrectos");
            //Verifico Password 
            //TODO: Sacar lo de admin de pruebas porque lo guarde sin encriptar
            string passEncripted = _encriptacion.Encriptar3DES(password);
            if (!passEncripted.Equals(usr.Password))
                throw new Exception("Nombre de Usuario o Contraseña incorrectos");
            //Activo
            if (!usr.Activo)
                throw new Exception("El usuario está deshabilitado.");
            //Bloqueado
            if (usr.Bloqueado)
                throw new Exception("El usuario está bloqueado, debe contactar al administrador.");
            //Aca otra verificaciones relacionadas a intentos o bloqueos
            //{
            //    if (!usr.FechaUltimoCambioPassword.HasValue)
            //        if (FlagsSeguridad.DiasVigenciaPassword > 0 &&
            //}

            //Si todo Ok, lo asigno a Gestion
            GestionUsuario.UsuarioLogueado= usr;
            return GestionUsuario.UsuarioLogueado != null;
        }


        public void Blanqueo(Usuario usuario)
        {
            if (!EsValido(usuario)) throw new ArgumentException(MensajeError);
            usuario.Password = _encriptacion.Encriptar3DES(usuario.Password);
            _mppUsuario.Modificar(usuario);
            _logger.GenerarLog($"Usuario modificado: {usuario.Username}");
        }

        #endregion

        #region Permisos

        public void AgregarPermiso(Usuario usuario, Permiso permiso)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);

            if (permiso == null)
                throw new ArgumentNullException(nameof(permiso));

            if (usuario.TienePermiso(permiso) || usuario.Permiso != null )
                throw new InvalidOperationException($"El usuario ya tiene asignado el permiso: {permiso.Descripcion}");

            _mppUsuario.AgregarPermiso(usuario, permiso);
            _logger.GenerarLog($"Permiso agregado al usuario {usuario.Username}: {permiso.Descripcion}");
        }

        public void QuitarPermiso(Usuario usuario, Permiso permiso)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);

            if (permiso == null)
                throw new ArgumentNullException(nameof(permiso));

            if (!usuario.TienePermiso(permiso) || usuario.Permiso == null)
                throw new InvalidOperationException($"El usuario no tiene asignado el permiso: {permiso.Descripcion}");

            _mppUsuario.QuitarPermiso(usuario, permiso);
            _logger.GenerarLog($"Permiso removido del usuario {usuario.Username}: {permiso.Descripcion}");
        }
        
        #endregion
    }
}
