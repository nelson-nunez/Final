using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE.Seguridad
{
    public class Rol : PermisoCompuesto
    {
        public Rol(string codigo, string descripcion) : base(codigo, descripcion)
        {
        }

        public override List<Permiso> ObtenerPermisos()
        {
            var permisos = base.ObtenerPermisos();

            // Eliminar duplicados según el código del permiso
            return permisos
                .GroupBy(p => p.Codigo)
                .Select(g => g.First())
                .ToList();
        }
    }
}
