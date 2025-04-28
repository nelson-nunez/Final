using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Seguridad;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Usuario
    {
        public Usuario CrearUsuario(int legajo, string logon, string nombre, string apellido, string email, string password)
        {
            return new Usuario(legajo, logon, nombre, apellido, email, password);
        }

        public void AsignarRolAUsuario(Usuario usuario, Rol rol)
        {
            if (!usuario.Roles.Contains(rol))
            {
                usuario.Roles.Add(rol);
            }
        }

        public void RemoverRolDeUsuario(Usuario usuario, Rol rol)
        {
            if (usuario.Roles.Contains(rol))
            {
                usuario.Roles.Remove(rol);
            }
        }

        public bool UsuarioTienePermiso(Usuario usuario, string codigoPermiso)
        {
            return usuario.TienePermiso(codigoPermiso);
        }

        public void BloquearUsuario(Usuario usuario)
        {
            usuario.Bloqueado = true;
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            usuario.Bloqueado = false;
        }

        public void CambiarEstadoUsuario(Usuario usuario, bool activo)
        {
            usuario.Activo = activo;
        }
    }
}
