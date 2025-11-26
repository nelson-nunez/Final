using System;
using System.Collections.Generic;
using System.Linq;
using SiAP.BE;
using SiAP.BE.Base;

namespace Policonsultorio.BE
{
    public class HistoriaClinica: ClaseBase
    {
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Paciente Paciente { get; set; }
        public List<Consulta> Consultas { get; set; }

        public HistoriaClinica()
        {
            Consultas = new List<Consulta>();
            FechaCreacion = DateTime.Now;
        }
    }
}