using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace Policonsultorio.BE
{
    public class Receta: ClaseBase
    {
        public DateTime Fecha { get; set; }
        public string Medicamentos { get; set; }
        public int Nro_Socio { get; set; }
        public string Obra_social { get; set; }
        public string Observaciones { get; set; }
        public string Plan { get; set; }
        public string Profesional { get; set; }
        public Consulta Consulta { get; set; }
        public bool EsCronica { get; set; }


        #region Constructor

        public Receta()
        {
            Fecha = DateTime.Now;
            EsCronica = false;
        }

        public Receta(string medicamentos, string profesional) : this()
        {
            this.Medicamentos = medicamentos;
            this.Profesional = profesional;
        }

        #endregion

        #region Métodos Principales

        public void CrearReceta()
        {
            if (!ValidarReceta())
                throw new InvalidOperationException("Datos de receta incompletos");

            Fecha = DateTime.Now;
        }

        public bool ValidarReceta()
        {
            if (string.IsNullOrWhiteSpace(Medicamentos))
                return false;

            if (string.IsNullOrWhiteSpace(Profesional))
                return false;

            if (Fecha == default(DateTime))
                return false;

            return true;
        }

        public Receta RenovarReceta()
        {
            if (!EsCronica)
                throw new InvalidOperationException("Solo se pueden renovar recetas crónicas");

            var recetaRenovada = new Receta
            {
                Medicamentos = this.Medicamentos,
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

        public void MarcarComoCronica()
        {
            EsCronica = true;
        }

        public bool ValidarVigencia()
        {
            int diasVigencia = EsCronica ? 180 : 30;
            return (DateTime.Now - Fecha).Days <= diasVigencia;
        }

        public void AgregarMedicamento(string medicamento, string dosis)
        {
            if (string.IsNullOrWhiteSpace(medicamento))
                throw new ArgumentException("El medicamento no puede estar vacío");

            string nuevoMedicamento = $"{medicamento} - {dosis}";

            if (string.IsNullOrWhiteSpace(Medicamentos))
                Medicamentos = nuevoMedicamento;
            else
                Medicamentos += "\n" + nuevoMedicamento;
        }

        public List<string> ObtenerMedicamentos()
        {
            if (string.IsNullOrWhiteSpace(Medicamentos))
                return new List<string>();

            return new List<string>(Medicamentos.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
        }

        #endregion

        #region Métodos Override

        public override string ToString()
        {
            return $"Receta #{Id} - {Fecha.ToShortDateString()} - {Profesional}";
        }

        #endregion
    }
}
