using System;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Agenda: ClaseBase
    {
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public long MedicoId { get; set; }
    }
}
