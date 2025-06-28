using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE
{
    public class Paciente: Persona
    {
        public int PacienteId { get; set; }
        public string ObraSocial { get; set; }
        public string Plan { get; set; }
        public int NumeroSocio { get; set; }
    }
}
