using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE.Vistas
{
    public class Vista_Ingresos_Esp: ClaseBase
    {
        public string Especialidad { get; set; }
        public int CantidadTurnos { get; set; }
        public decimal TotalIngresos { get; set; }

    }
}
