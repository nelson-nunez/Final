using System;
using SiAP.BE;
using SiAP.BE.Base;

namespace Policonsultorio.BE
{
    public class Consulta: ClaseBase
    {
        public string Diagnostico { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }
        public string Tratamiento { get; set; }
        public Medico Medico { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
        public List<Receta> Recetas { get; set; }
        public List<Certificado> Certificados { get; set; }


        #region Constructor

        public Consulta()
        {
            Recetas = new List<Receta>();
            Certificados = new List<Certificado>();
            Fecha = DateTime.Now;
        }

        public Consulta(Medico medico, string motivo) : this()
        {
            this.Medico = medico;
            this.Motivo = motivo;
        }

        #endregion

        #region Métodos Principales

        public bool ValidarDatos()
        {
            if (Medico == null)
                return false;

            if (string.IsNullOrWhiteSpace(Motivo))
                return false;

            if (Fecha == default(DateTime))
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"Consulta #{Id} - {Fecha.ToShortDateString()} - {Medico?.Titulo}";
        }

        #endregion
    }
}