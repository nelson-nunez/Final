using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Seguridad;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.MPP.Seguridad;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Usuario : IBLL<Usuario>
    {
        private readonly MPP_Usuario _mppUsuario;
        private static BLL_Usuario _instancia;
        private readonly ILogger _logger;

        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Usuario()
        {
            _mppUsuario = MPP_Usuario.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
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

            _mppUsuario.Agregar(usuario);
            _logger.GenerarLog($"Usuario agregado: {usuario.Logon}");
        }

        public void Modificar(Usuario usuario, string legajoAnterior = null)
        {
            if (!EsValido(usuario))
                throw new ArgumentException(MensajeError);

            _mppUsuario.Modificar(usuario, legajoAnterior);
            _logger.GenerarLog($"Usuario modificado: {usuario.Logon}");
        }

        public void Eliminar(Usuario usuario)
        {
            if (_mppUsuario.TieneDependencias(usuario))
                throw new InvalidOperationException("El usuario tiene dependencias y no puede eliminarse.");

            _mppUsuario.Eliminar(usuario);
            _logger.GenerarLog($"Usuario eliminado: {usuario.Logon}");
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

            if (usuario.Legajo == null || usuario.Legajo <= 0)
                _mensajeError += "El legajo debe ser un número válido. ";

            if (string.IsNullOrWhiteSpace(usuario.Logon))
                _mensajeError += "El logon es obligatorio. ";

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

        public void AsignarRol(Usuario usuario, Rol rol)
        {
            if (usuario == null || rol == null)
                throw new ArgumentNullException("Usuario o Rol no pueden ser nulos.");

            if (!usuario.Roles.Any(r => r.Codigo == rol.Codigo))
            {
                usuario.Roles.Add(rol);
                _mppUsuario.Modificar(usuario, usuario.Legajo.ToString()); // Persistimos el cambio
                _logger.GenerarLog($"Rol '{rol.Codigo}' asignado al usuario '{usuario.Logon}'");
            }
            else
            {
                _logger.GenerarLog($"El usuario '{usuario.Logon}' ya tiene asignado el rol '{rol.Codigo}'");
            }
        }

        public void DesasignarRol(Usuario usuario, Rol rol)
        {
            if (usuario == null || rol == null)
                throw new ArgumentNullException("Usuario o Rol no pueden ser nulos.");

            var rolAsignado = usuario.Roles.FirstOrDefault(r => r.Codigo == rol.Codigo);
            if (rolAsignado != null)
            {
                usuario.Roles.Remove(rolAsignado);
                _mppUsuario.Modificar(usuario, usuario.Legajo.ToString()); // Persistimos el cambio
                _logger.GenerarLog($"Rol '{rol.Codigo}' desasignado del usuario '{usuario.Logon}'");
            }
            else
            {
                _logger.GenerarLog($"El usuario '{usuario.Logon}' no tiene asignado el rol '{rol.Codigo}'");
            }
        }


        //------------------------
        public static Usuario ObtenerUsuario()
        {
            // Crear el Rol de Administrador
            var rolAdministrador = new Rol("ADMIN", "Rol de Administrador del sistema");

            // Crear permisos
            var permisoInicio = new PermisoSimple("TAG001", "Acceso a Inicio");
            var permisoModificarClave = new PermisoSimple("TAG002", "Modificar Clave");
            var permisoUsuarios = new PermisoSimple("TAG003", "Gestión de Usuarios");
            var permisoRoles = new PermisoSimple("TAG004", "Gestión de Roles");
            var permisoPermisos = new PermisoSimple("TAG005", "Gestión de Permisos");

            // Asignar permisos al rol
            rolAdministrador.AgregarPermiso(permisoInicio);
            rolAdministrador.AgregarPermiso(permisoModificarClave);
            rolAdministrador.AgregarPermiso(permisoUsuarios);
            rolAdministrador.AgregarPermiso(permisoRoles);
            rolAdministrador.AgregarPermiso(permisoPermisos);

            // Crear usuario Admin
            var admin = new Usuario(
                legajo: 1,
                logon: "admin",
                nombre: "Admin",
                apellido: "Principal",
                email: "admin@policonsultorio.com",
                password: "admin"
            );

            // Asignar el rol de Administrador al usuario Admin
            admin.Roles.Add(rolAdministrador);

            // Activar el usuario y asegurarse que no esté bloqueado
            admin.Activo = true;
            admin.Bloqueado = false;

            return admin;
        }
    }
}
