using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE.Logs
{
    public class Log: ClaseBase
    {
        public Log()
        {

        }

        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Operacion { get; set; }

    }
}
