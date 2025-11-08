using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Policonsultorio.BE;
using SiAP.BE;

namespace SiAP.UI.Impresiones
{
    /// <summary>
    /// Generador de PDF específico para certificados médicos
    /// </summary>
    public class CertificadoPDFGenerator : PDFGeneratorBase
    {
        private readonly Certificado _certificado;
        private readonly Paciente _paciente;
        private readonly Medico _medico;

        public CertificadoPDFGenerator(Certificado certificado, Paciente paciente, Medico medico)
        {
            _certificado = certificado ?? throw new ArgumentNullException(nameof(certificado));
            _paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));
            _medico = medico ?? throw new ArgumentNullException(nameof(medico));
        }

        protected override void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(_certificado.Descripcion))
                throw new InvalidOperationException("El certificado debe contener una descripción.");
        }

        protected override string ObtenerTituloPDF()
        {
            return $"Certificado médico - {_paciente.NombreCompleto}";
        }

        protected override string ObtenerNombreArchivo()
        {
            return $"Certificado_{_paciente.Dni}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        }

        protected override void DibujarContenido(XGraphics gfx, PdfPage page)
        {
            DibujarEncabezado(gfx, "Certificado Médico");
            DibujarInformacionPaciente(gfx);
            DibujarDiagnostico(gfx);
            DibujarReposo(gfx);
            DibujarInformacionMedico(gfx);
            DibujarFirma(gfx);
        }

        private void DibujarInformacionPaciente(XGraphics gfx)
        {
            double y = 100;
            DibujarFecha(gfx, _certificado.Fecha, 400, y);
            DibujarDatosPaciente(gfx, _paciente, 50, y);
        }

        private void DibujarDiagnostico(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 200;

            gfx.DrawString("Diagnóstico:", fHeader, XBrushes.Black, 50, y);
            y += 20;

            gfx.DrawString(_certificado.Descripcion, f, XBrushes.Black, 60, y);
        }

        private void DibujarReposo(XGraphics gfx)
        {
            if (_certificado.Observaciones == null)
                return;

            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 300;

            string texto = $"Se indica: {_certificado.Observaciones}";

            gfx.DrawString(texto, f, XBrushes.Black, 50, y);
        }

        private void DibujarInformacionMedico(XGraphics gfx)
        {
            DibujarDatosMedico(gfx, _medico, 300, 600);
        }
    }

    public static class CertificadoMedicoExtensions
    {
        public static string GenerarPDF(this Certificado certificado, Paciente paciente, Medico medico,
            string rutaArchivo = null, bool mostrarDialogo = true)
        {
            var generator = new CertificadoPDFGenerator(certificado, paciente, medico);
            return generator.GenerarPDF(rutaArchivo, mostrarDialogo);
        }

        public static void GenerarYAbrirPDF(this Certificado certificado, Paciente paciente, Medico medico)
        {
            var generator = new CertificadoPDFGenerator(certificado, paciente, medico);
            generator.GenerarYAbrirPDF();
        }
    }
}
