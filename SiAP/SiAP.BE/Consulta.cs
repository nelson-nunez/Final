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

        public void RegistrarConsulta()
        {
            if (!ValidarDatos())
                throw new InvalidOperationException("Datos de consulta incompletos");

            Fecha = DateTime.Now;
        }

        public Receta EmitirReceta()
        {
            var receta = new Receta
            {
                Fecha = DateTime.Now,
                Profesional = this.Medico?.Titulo
            };

            if (Recetas == null)
                Recetas = new List<Receta>();

            Recetas.Add(receta);
            return receta;
        }

        public Certificado EmitirCertificado()
        {
            var certificado = new Certificado
            {
                Fecha = DateTime.Now
            };

            if (Certificados == null)
                Certificados = new List<Certificado>();

            Certificados.Add(certificado);
            return certificado;
        }

        public void AgregarReceta(Receta receta)
        {
            if (receta == null)
                throw new ArgumentNullException(nameof(receta));

            if (Recetas == null)
                Recetas = new List<Receta>();

            Recetas.Add(receta);
        }

        public void AgregarCertificado(Certificado certificado)
        {
            if (certificado == null)
                throw new ArgumentNullException(nameof(certificado));

            if (Certificados == null)
                Certificados = new List<Certificado>();

            Certificados.Add(certificado);
        }

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

        public string ObtenerDetalles()
        {
            return $"Consulta del {Fecha.ToShortDateString()}\n" +
                   $"Médico: {Medico?.Titulo}\n" +
                   $"Motivo: {Motivo}\n" +
                   $"Diagnóstico: {Diagnostico ?? "Sin diagnóstico"}\n" +
                   $"Tratamiento: {Tratamiento ?? "Sin tratamiento"}\n" +
                   $"Recetas emitidas: {Recetas?.Count ?? 0}\n" +
                   $"Certificados emitidos: {Certificados?.Count ?? 0}";
        }

        #endregion

        #region Métodos Override

        public override string ToString()
        {
            return $"Consulta #{Id} - {Fecha.ToShortDateString()} - {Medico?.Titulo}";
        }

        #endregion
    }
}