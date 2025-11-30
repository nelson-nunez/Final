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

        public override string ToString()
        {
            return $"Certificado #{Id} - {TipoCertificado} - {Fecha.ToShortDateString()}";
        }

        #endregion
    }
}