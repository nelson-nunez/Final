using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE.Seguridad
{
    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string codigo, string descripcion) : base(codigo, descripcion)
        {
        }

        public override List<Permiso> ObtenerPermisos()
        {
            return new List<Permiso> { this };
        }

        public override void AgregarPermiso(Permiso permiso)
        {
            throw new InvalidOperationException("Un permiso simple no puede contener permisos.");
        }
    }
}
