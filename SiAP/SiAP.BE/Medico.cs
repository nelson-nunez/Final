using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.BE
{
    public class Medico: Persona
    {      
        public string Titulo { get; set; }


        public Especialidad Especialidad { get; set; }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre} - {Especialidad.Nombre}";
        }
    }
}
