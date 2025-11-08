using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SiAP.BE;
using Policonsultorio.BE;
using PdfSharp.Fonts;

namespace SiAP.UI.Impresiones
{
    public class RecetaPDFGenerator : PDFGeneratorBase
    {
        private readonly Receta _receta;
        private readonly Paciente _paciente;
        private readonly Medico _medico;

        public RecetaPDFGenerator(Receta receta, Paciente paciente, Medico medico)
        {
            _receta = receta ?? throw new ArgumentNullException(nameof(receta));
            _paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));
            _medico = medico ?? throw new ArgumentNullException(nameof(medico));
        }

        protected override void ValidarDatos()
        {
            if (!_receta.ValidarReceta())
                throw new InvalidOperationException("La receta no contiene los datos necesarios.");
        }

        protected override string ObtenerTituloPDF()
        {
            return $"Receta médica - {_paciente.NombreCompleto}";
        }

        protected override string ObtenerNombreArchivo()
        {
            return $"Receta_{_paciente.Dni}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        }

        protected override void DibujarContenido(XGraphics gfx, PdfPage page)
        {
            DibujarEncabezado(gfx, "Receta Médica");
            DibujarInformacionPaciente(gfx);
            DibujarMedicamentos(gfx);
            DibujarInformacionMedico(gfx);
            DibujarFirma(gfx);
        }

        private void DibujarInformacionPaciente(XGraphics gfx)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 100;

            DibujarFecha(gfx, _receta.Fecha, 400, y + 60);

            gfx.DrawString($"Paciente: {_paciente.NombreCompleto}", f, XBrushes.Black, 50, y);
            gfx.DrawString($"DNI: {_paciente.Dni}", f, XBrushes.Black, 50, y + 15);
            gfx.DrawString($"Obra Social: {_paciente.ObraSocial ?? _receta.Obra_social}", f, XBrushes.Black, 50, y + 30);
            gfx.DrawString($"Plan: {_paciente.Plan ?? _receta.Plan}", f, XBrushes.Black, 50, y + 45);
            gfx.DrawString($"N° Socio: {_paciente.NumeroSocio}", f, XBrushes.Black, 50, y + 60);
        }

        private void DibujarMedicamentos(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 200;

            gfx.DrawString("Prescripción:", fHeader, XBrushes.Black, 50, y);
            y += 20;

            foreach (var med in _receta.Medicamentos)
            {
                gfx.DrawString($"• {med.NombreComercial} ({med.NombreMonodroga}) x{med.Cantidad}",
                    f, XBrushes.Black, 60, y);
                y += 18;
            }

            if (!string.IsNullOrWhiteSpace(_receta.Observaciones))
            {
                y += 10;
                gfx.DrawString($"Observaciones: {_receta.Observaciones}", f, XBrushes.Black, 50, y);
            }
        }

        private void DibujarInformacionMedico(XGraphics gfx)
        {
            DibujarDatosMedico(gfx, _medico, 300, 600);
        }
    }
}