using System;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Cobro: ClaseBase
    {
        public DateTime FechaHora { get; set; }
        public MediodePago? MediodePago { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoAcumulado { get; set; }
        public decimal Importe { get; set; }
        public EstadoCobro Estado { get; set; }       
        public long TurnoId { get; set; }
        public decimal MontoRestante
        {
            get
            {
                var restante = (MontoTotal - MontoAcumulado) > 0 ? (MontoTotal - MontoAcumulado) : 0;
                return restante;
            }            
        }

    }


    public enum MediodePago
    {
        Efectivo,
        Credito,
        Debito,
        BilleteraVirtual,
        sinInformar
    }
    public static class MediodePagoHelper
    {
        public static List<MediodePago> mediosdePago => Enum.GetValues(typeof(MediodePago)).Cast<MediodePago>().ToList();
    }

    public enum EstadoCobro
    {
        PagoParcial,
        Reembolsado,
        PagoTotal
    }

    public static class EstadoCobroHelper
    {
        public static List<string> Estados => Enum.GetNames(typeof(EstadoCobro)).ToList();
    }
}
