using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE_Vistas
{
    public class VistaLog
    {
        public VistaLog()
        {

        }

        public virtual Guid? ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Operacion { get; set; }
    }
}
