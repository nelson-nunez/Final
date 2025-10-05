using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using System.Xml.Serialization;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Medico : ClaseBase
    {
        public string Titulo { get; set; }
        public Especialidad Especialidad { get; set; }
        public decimal ArancelConsulta { get; set; }
        
        // Persona
        public long PersonaId { get; set; }
        public Persona Persona { get; set; }
        // Expongo props
        public string Nombre => Persona?.Nombre ?? "";
        public string Apellido => Persona?.Apellido ?? "";
        public string Dni => Persona?.Dni ?? "";
        public DateTime FechaNacimiento => Persona?.FechaNacimiento ?? DateTime.MinValue;
        public string Email => Persona?.Email ?? "";
        public string Telefono => Persona?.Telefono ?? "";
        public string NombreCompleto => Persona?.NombreCompleto ?? "";


        public override string ToString()
        {
            return $"{Persona?.Apellido}, {Persona?.Nombre} - {Especialidad?.Nombre ?? "Sin especialidad"}";
        }
    }
}
