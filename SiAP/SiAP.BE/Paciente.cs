using System;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Paciente: ClaseBase
    {
        public string ObraSocial { get; set; }
        public string Plan { get; set; }
        public int NumeroSocio { get; set; }


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
            return $"{Persona?.Apellido}, {Persona?.Nombre} - {Persona?.Dni}";
        }
    }
}
