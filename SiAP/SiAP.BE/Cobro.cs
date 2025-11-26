using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiAP.BE
{
    public class Cobro: ClaseBase
    {
        public DateTime FechaHora { get; set; }
        public MediodePago MediodePago { get; set; }
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
