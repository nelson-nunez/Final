using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Factura: ClaseBase
    {
        public DateTime FechaEmision { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }  // Ej: Consulta médica
        public EstadoFactura Estado { get; set; }

        public int TurnoId { get; set; }
        public int PacienteId { get; set; }

        public List<Cobro> Cobros { get; set; }
    }
    public enum EstadoFactura
    {
        Emitida,
        Pagada,
        Anulada
    }
}
