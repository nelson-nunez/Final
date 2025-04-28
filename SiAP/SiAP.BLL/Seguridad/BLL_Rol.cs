using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Seguridad;

namespace SiAP.BLL.Seguridad
{
    public class RolBLL : BLL_Permiso
    {
        public Rol CrearRol(string codigo, string descripcion)
        {
            return new Rol(codigo, descripcion);
        }

        public void AgregarPermisoARol(Rol rol, Permiso permiso)
        {
            rol.AgregarPermiso(permiso);
        }

        public List<Permiso> ObtenerPermisosDeRol(Rol rol)
        {
            return rol.ObtenerPermisos();
        }
    }
}
