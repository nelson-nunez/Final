using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Respaldo : ClaseBase
    {
        public string NombreArchivo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public long TamanioKB { get; set; }

        public Respaldo()
        {
            FechaCreacion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{NombreArchivo} - {FechaCreacion:dd/MM/yyyy HH:mm}";
        }
    }
}
