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
        public Respaldo()
        {
            FechaCreacion = DateTime.Now;
        }

        public string NombreArchivo { get; set; }
        public string NombreBD { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public long TamanioKB { get; set; }


        public override string ToString()
        {
            return $"{NombreArchivo} - {FechaCreacion:dd/MM/yyyy HH:mm}";
        }
    }
    public static class TipoRespaldo
    {
        public const string Backup = "Backup";
        public const string Restore = "Restore";
    }
}
