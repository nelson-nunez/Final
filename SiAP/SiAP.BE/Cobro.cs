using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Cobro: ClaseBase
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoPago { get; set; }
        public decimal Monto { get; set; }
        public EstadoCobro Estado { get; set; }

        public int FacturaId { get; set; }
        public int FormaPagoId { get; set; }
    }

    public enum EstadoCobro
    {
        Registrado,
        Confirmado,
        Rechazado
    }
}
