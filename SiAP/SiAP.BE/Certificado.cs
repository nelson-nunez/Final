using System;
using SiAP.BE.Base;

namespace Policonsultorio.BE
{
    public class Certificado: ClaseBase
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string TipoCertificado { get; set; }
        public DateTime FechaVigenciaDesde { get; set; }
        public DateTime FechaVigenciaHasta { get; set; }
        public string Profesional { get; set; }
        public Consulta Consulta { get; set; }


        #region Constructor

        public Certificado()
        {
            Fecha = DateTime.Now;
        }

        public Certificado(string tipoCertificado, string descripcion) : this()
        {
            this.TipoCertificado = tipoCertificado;
            this.Descripcion = descripcion;
        }

        #endregion

        #region Métodos Principales

        public void CrearCertificado()
        {
            if (!ValidarCertificado())
                throw new InvalidOperationException("Datos de certificado incompletos");

            Fecha = DateTime.Now;
        }

        public bool ValidarCertificado()
        {
            if (string.IsNullOrWhiteSpace(TipoCertificado))
                return false;

            if (string.IsNullOrWhiteSpace(Descripcion))
                return false;

            if (Fecha == default(DateTime))
                return false;

            return true;
        }

        public void DefinirTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo de certificado no puede estar vacío");

            TipoCertificado = tipo;
        }

        public void EstablecerVigencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaHasta < fechaDesde)
                throw new ArgumentException("La fecha de finalización debe ser posterior a la fecha de inicio");

            FechaVigenciaDesde = fechaDesde;
            FechaVigenciaHasta = fechaHasta;
        }

        public bool EstaVigente()
        {
            if (FechaVigenciaDesde == default(DateTime) || FechaVigenciaHasta == default(DateTime))
                return true;

            DateTime hoy = DateTime.Now.Date;
            return hoy >= FechaVigenciaDesde.Date && hoy <= FechaVigenciaHasta.Date;
        }

        public int ObtenerDiasVigencia()
        {
            if (FechaVigenciaDesde == default(DateTime) || FechaVigenciaHasta == default(DateTime))
                return 0;

            return (FechaVigenciaHasta - FechaVigenciaDesde).Days;
        }

        public string ObtenerDatos()
        {
            string vigencia = "Sin vigencia definida";
            if (FechaVigenciaDesde != default(DateTime) && FechaVigenciaHasta != default(DateTime))
            {
                vigencia = $"Vigente desde {FechaVigenciaDesde.ToShortDateString()} hasta {FechaVigenciaHasta.ToShortDateString()}";
            }

            return $"Certificado: {TipoCertificado}\n" +
                   $"Descripción: {Descripcion}\n" +
                   $"Fecha de emisión: {Fecha.ToShortDateString()}\n" +
                   $"{vigencia}\n" +
                   $"Observaciones: {Observaciones ?? "Sin observaciones"}";
        }

        #endregion

        #region Métodos Override

        public override string ToString()
        {
            return $"Certificado #{Id} - {TipoCertificado} - {Fecha.ToShortDateString()}";
        }

        #endregion
    }
}