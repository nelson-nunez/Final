using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE.Seguridad
{
    public class Rol : PermisoCompuesto
    {
        public Rol(string codigo, string descripcion) : base(codigo)
        {
            this.Descripcion = descripcion;
        }
    }
}
