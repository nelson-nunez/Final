using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiAP.BE
{
    public class Turno : ClaseBase
    {
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string TipoAtencion { get; set; }
        public EstadoTurno Estado { get; set; }
        public long MedicoId { get; set; }
        public long PacienteId { get; set; }
        public long? AgendaId { get; set; }
        public long? CobroId { get; set; }
        public Cobro Cobro { get; set; }

         public string TipoPago => Cobro?.TipoPago ?? "";
         public decimal Monto => (decimal)(Cobro?.Monto);
         public EstadoCobro EstadoCobro => (EstadoCobro)(Cobro?.Estado);
    }

    public enum EstadoTurno
    {
        Asignado,
        Confirmado,
        Cancelado,
        Atendido,
        Ausente
    }
}
