using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SiAP.BE.Base;
using SiAP.BE.Seguridad;

namespace SiAP.BE
{
    public class Persona: ClaseBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public Usuario Usuario { get; set; }
        public string NombreCompleto => $"{Apellido}, {Nombre}";

        public static implicit operator Persona?(Medico? v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Persona?(Secretario? v)
        {
            throw new NotImplementedException();
        }
    }
}
