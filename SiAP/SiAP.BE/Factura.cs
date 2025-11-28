using System;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Factura : ClaseBase
    {
        //Emisor
        public string RazonSocialEmisor { get; set; }
        public string CUITEmisor { get; set; }
        public string DomicilioEmisor { get; set; }
        public int PuntoDeVenta { get; set; }
        //Receptor
        public string RazonSocialReceptor { get; set; }
        //Factura
        public DateTime FechaEmision { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }
        public EstadoFactura Estado { get; set; }
        public long CobroId { get; set; }

        // Factura C - Sin IVA
        public decimal Subtotal => Importe;
        public decimal MontoIVA => 0;
        public decimal Total => Importe;
    }

    public enum EstadoFactura
    {
        Emitida,
        Anulada
    }
}

