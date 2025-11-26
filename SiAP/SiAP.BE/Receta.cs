using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Receta RenovarReceta()
        {
            if (!EsCronica)
                throw new InvalidOperationException("Solo se pueden renovar recetas crónicas");

            var recetaRenovada = new Receta
            {
                Medicamentos = new List<Medicamento>(this.Medicamentos.Select(m => new Medicamento
                {
                    NombreComercial = m.NombreComercial,
                    NombreMonodroga = m.NombreMonodroga,
                    Cantidad = m.Cantidad
                })),
                Profesional = this.Profesional,
                Obra_social = this.Obra_social,
                Nro_Socio = this.Nro_Socio,
                Plan = this.Plan,
                Observaciones = "Renovación de receta crónica",
                EsCronica = true,
                Fecha = DateTime.Now
            };
            return recetaRenovada;
        }

        public bool ValidarVigencia()
        {
            int diasVigencia = EsCronica ? 180 : 30;
            return (DateTime.Now - Fecha).Days <= diasVigencia;
        }

    }
}