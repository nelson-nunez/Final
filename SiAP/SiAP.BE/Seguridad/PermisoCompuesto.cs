using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE.Seguridad
{
    public class PermisoCompuesto : Permiso
    {
        protected List<Permiso> _permisos;

        public PermisoCompuesto(string codigo) : base(codigo)
        {
            _permisos = new List<Permiso>();
        }

        public override void AgregarPermiso(Permiso permiso)
        {
            _permisos.Add(permiso);
        }

        public override List<Permiso> ObtenerPermisos()
        {
            return _permisos;
        }
    }
}
