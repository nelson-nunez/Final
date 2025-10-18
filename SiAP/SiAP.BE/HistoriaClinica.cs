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


        #region Constructor

        public HistoriaClinica()
        {
            Consultas = new List<Consulta>();
            FechaCreacion = DateTime.Now;
        }

        public HistoriaClinica(Paciente paciente) : this()
        {
            this.Paciente = paciente;
        }

        #endregion

        #region Métodos Principales

        public void AgregarConsulta(Consulta consulta)
        {
            if (consulta == null)
                throw new ArgumentNullException(nameof(consulta), "La consulta no puede ser nula");

            if (Consultas == null)
                Consultas = new List<Consulta>();

            Consultas.Add(consulta);
        }

        public List<Consulta> ObtenerHistorialCompleto()
        {
            if (Consultas == null || Consultas.Count == 0)
                return new List<Consulta>();

            return Consultas.OrderByDescending(c => c.Fecha).ToList();
        }

        public Consulta ObtenerUltimaConsulta()
        {
            if (Consultas == null || Consultas.Count == 0)
                return null;

            return Consultas.OrderByDescending(c => c.Fecha).FirstOrDefault();
        }

        public List<Consulta> BuscarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (Consultas == null || Consultas.Count == 0)
                return new List<Consulta>();

            return Consultas
                .Where(c => c.Fecha >= fechaDesde && c.Fecha <= fechaHasta)
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        public List<Consulta> BuscarPorDiagnostico(string diagnostico)
        {
            if (string.IsNullOrWhiteSpace(diagnostico) || Consultas == null)
                return new List<Consulta>();

            return Consultas
                .Where(c => c.Diagnostico != null &&
                           c.Diagnostico.ToLower().Contains(diagnostico.ToLower()))
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        public List<Receta> ObtenerTodasLasRecetas()
        {
            if (Consultas == null || Consultas.Count == 0)
                return new List<Receta>();

            var recetas = new List<Receta>();
            foreach (var consulta in Consultas)
            {
                if (consulta.Recetas != null && consulta.Recetas.Count > 0)
                {
                    recetas.AddRange(consulta.Recetas);
                }
            }

            return recetas.OrderByDescending(r => r.Fecha).ToList();
        }

        public List<Certificado> ObtenerTodosLosCertificados()
        {
            if (Consultas == null || Consultas.Count == 0)
                return new List<Certificado>();

            var certificados = new List<Certificado>();
            foreach (var consulta in Consultas)
            {
                if (consulta.Certificados != null && consulta.Certificados.Count > 0)
                {
                    certificados.AddRange(consulta.Certificados);
                }
            }

            return certificados.OrderByDescending(c => c.Fecha).ToList();
        }

        public bool ValidarDatos()
        {
            if (Paciente == null)
                return false;

            if (FechaCreacion == default(DateTime))
                return false;

            return true;
        }

        public string ObtenerResumen()
        {
            int totalConsultas = Consultas?.Count ?? 0;
            int totalRecetas = ObtenerTodasLasRecetas().Count;
            int totalCertificados = ObtenerTodosLosCertificados().Count;
            DateTime? ultimaConsulta = ObtenerUltimaConsulta()?.Fecha;

            return $"Historia Clínica - Paciente: {Paciente?.Nombre} {Paciente?.Apellido}\n" +
                   $"Total de Consultas: {totalConsultas}\n" +
                   $"Total de Recetas: {totalRecetas}\n" +
                   $"Total de Certificados: {totalCertificados}\n" +
                   $"Última Consulta: {(ultimaConsulta.HasValue ? ultimaConsulta.Value.ToShortDateString() : "Sin consultas")}";
        }

        #endregion

        #region Métodos Override

        public override string ToString()
        {
            return $"Historia Clínica #{Id} - Paciente: {Paciente?.Apellido}, {Paciente?.Nombre}";
        }

        #endregion
    }
}