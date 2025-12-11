using System;
using SiAP.BE;
using SiAP.BE.Base;

namespace Policonsultorio.BE
{
    public class Receta : ClaseBase
    {
        public DateTime Fecha { get; set; }
        public int Nro_Socio { get; set; }
        public string Obra_social { get; set; }
        public string Observaciones { get; set; }
        public string Plan { get; set; }
        public string Profesional { get; set; }
        public long ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
        public bool EsCronica { get; set; }
        public List<Medicamento> Medicamentos { get; set; }

        public Receta()
        {
            Fecha = DateTime.Now;
            EsCronica = false;
            Medicamentos = new List<Medicamento>();
        }

        public bool ValidarReceta()
        {
            if (string.IsNullOrWhiteSpace(Profesional))
                return false;
            if (Fecha == default(DateTime))
                return false;
            if (Medicamentos == null || Medicamentos.Count == 0)
                return false;
            return true;
        }

        public bool ValidarVigencia()
        {
            int diasVigencia = EsCronica ? 180 : 30;
            return (DateTime.Now - Fecha).Days <= diasVigencia;
        }

    }
}