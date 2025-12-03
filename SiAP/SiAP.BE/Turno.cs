using System;
using SiAP.BE.Base;

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
        public Medico Medico { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public long? AgendaId { get; set; }
        public long? CobroId { get; set; }
        public Cobro Cobro { get; set; }

        public decimal MontoTotal => (decimal)(Cobro?.MontoTotal ?? 0);
        public MediodePago MediodePago => (MediodePago)(Cobro?.MediodePago);
        public decimal MontoRestante => (decimal)(Cobro?.MontoRestante ?? 0);
        public EstadoCobro EstadoCobro => (EstadoCobro)(Cobro?.Estado ?? 0);
        public string NombrePaciente => Paciente?.ToString();

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
