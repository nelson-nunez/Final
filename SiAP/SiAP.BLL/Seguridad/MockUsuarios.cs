using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BLL.Seguridad;
using System.Collections.Generic;
using SiAP.BE.Seguridad;

namespace SiAP.Mocks
{
    public static class MockUsuarios
    {
        public static Usuario ObtenerUsuario()
        {
            // Crear instancia de servicios BLL
            var bllUsuario = new BLL_Usuario();
            var rol_Bll = new RolBLL();
            var permiso_Bll = new RolBLL();

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

