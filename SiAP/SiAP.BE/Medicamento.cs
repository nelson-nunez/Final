using System;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Medicamento : ClaseBase
    {
        public long RecetaId { get; set; }
        public string NombreComercial { get; set; }
        public string NombreMonodroga { get; set; }
        public int Cantidad { get; set; }
    }
}
