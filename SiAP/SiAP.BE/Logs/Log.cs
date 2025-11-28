using System;
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
