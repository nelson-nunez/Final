using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Seguridad;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Permiso
    {
        public virtual List<Permiso> ObtenerPermisos(Permiso permiso)
        {
            return permiso.ObtenerPermisos();
        }

        public virtual void AgregarPermiso(Permiso permisoCompuesto, Permiso permisoNuevo)
        {
            permisoCompuesto.AgregarPermiso(permisoNuevo);
        }
    }
}
