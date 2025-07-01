using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE
{
    public class Medico: Persona
    {
        //Matricula
        public int MedicoId { get; set; }
        public string Titulo { get; set; }

        public Especialidad Especialidad { get; set; }

        public override string ToString()
        {
            return $"{MedicoId} - {Nombre} - {Apellido}";
        }
    }
}
