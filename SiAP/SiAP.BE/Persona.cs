using System;
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
    }
}
