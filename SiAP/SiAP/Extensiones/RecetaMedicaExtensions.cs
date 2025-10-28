using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SiAP.BE;
using Policonsultorio.BE;
using PdfSharp.Fonts;

namespace SiAP.Extensions
{
    public static class RecetaMedicaExtensions
    {
        #region Tamaños de fuente estáticos
    
        private static readonly double TamañoTitulo = 16;
        private static readonly double TamañoSubtitulo = 11;
        private static readonly double TamañoNormal = 10;
        private static readonly double TamañoPequeño = 9;

        private static readonly string FamiliaFuente = "Arial";
       
        #endregion

        private static bool _fontResolverConfigurado = false;

        private static void ConfigurarFontResolver()
        {
            if (!_fontResolverConfigurado)
            {
                GlobalFontSettings.FontResolver = new CustomFontResolver();
                _fontResolverConfigurado = true;
            }
        }

        public static string GenerarPDF(this Receta receta, Paciente paciente, Medico medico, string rutaArchivo = null, bool mostrarDialogo = true)
        {
            if (receta == null) throw new ArgumentNullException(nameof(receta));
            if (paciente == null) throw new ArgumentNullException(nameof(paciente));
            if (!receta.ValidarReceta()) throw new InvalidOperationException("La receta no contiene los datos necesarios.");

            // Configurar el FontResolver
            ConfigurarFontResolver();

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = $"Receta médica - {paciente.NombreCompleto}";

            PdfPage page = pdf.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DibujarEncabezado(gfx, page);
            DibujarPaciente(gfx, paciente, receta);
            DibujarMedicamentos(gfx, receta);
            DibujarMedico(gfx, medico);
            DibujarFirma(gfx);

            string ruta = rutaArchivo ?? ObtenerRutaArchivo(paciente, mostrarDialogo);
            if (ruta == null) return null;

            pdf.Save(ruta);
            return ruta;
        }

        public static void GenerarYAbrirPDF(this Receta receta, Paciente paciente, Medico medico)
        {
            try
            {
                string path = receta.GenerarPDF(paciente, medico);
                if (string.IsNullOrEmpty(path)) return;

                if (MessageBox.Show("¿Desea abrir la receta generada?", "Receta Generada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar o abrir la receta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static void DibujarEncabezado(XGraphics gfx, PdfPage page)
        {
            XFont fontTitulo = new XFont(FamiliaFuente, TamañoTitulo, XFontStyleEx.Bold);
            gfx.DrawString("Receta Médica", fontTitulo, XBrushes.Black, new XPoint(230, 50));
        }

        private static void DibujarPaciente(XGraphics gfx, Paciente p, Receta r)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 100;

            gfx.DrawString($"Fecha: {r.Fecha:dd/MM/yyyy}", f, XBrushes.Black, 400, y + 60);

            gfx.DrawString($"Paciente: {p.NombreCompleto}", f, XBrushes.Black, 50, y);
            gfx.DrawString($"DNI: {p.Dni}", f, XBrushes.Black, 50, y + 15);
            gfx.DrawString($"Obra Social: {p.ObraSocial ?? r.Obra_social}", f, XBrushes.Black, 50, y + 30);
            gfx.DrawString($"Plan: {p.Plan ?? r.Plan}", f, XBrushes.Black, 50, y + 45);
            gfx.DrawString($"N° Socio: {p.NumeroSocio}", f, XBrushes.Black, 50, y + 60);
        }

        private static void DibujarMedicamentos(XGraphics gfx, Receta r)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 200;

            gfx.DrawString("Prescripción:", fHeader, XBrushes.Black, 50, y);
            y += 20;

            foreach (var med in r.Medicamentos)
            {
                gfx.DrawString($"• {med.NombreComercial} ({med.NombreMonodroga}) x{med.Cantidad}", f, XBrushes.Black, 60, y);
                y += 18;
            }

            if (!string.IsNullOrWhiteSpace(r.Observaciones))
            {
                y += 10;
                gfx.DrawString($"Observaciones: {r.Observaciones}", f, XBrushes.Black, 50, y);
            }
        }

        private static void DibujarMedico(XGraphics gfx, Medico m)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 600;

            gfx.DrawString($"Médico/a: {m.NombreCompleto}", f, XBrushes.Black, 300, y);
            gfx.DrawString($"Especialidad: {m.Especialidad?.Nombre}", f, XBrushes.Black, 300, y + 15);
            gfx.DrawString($"Matrícula: {m.Persona?.Dni}", f, XBrushes.Black, 300, y + 30);
        }

        private static void DibujarFirma(XGraphics gfx)
        {
            XPen pen = new XPen(XColors.Black, 1);
            XFont f = new XFont(FamiliaFuente, TamañoPequeño, XFontStyleEx.Regular);
            gfx.DrawLine(pen, 300, 670, 500, 670);
            gfx.DrawString("Firma y sello", f, XBrushes.Black, 350, 685);
        }

        private static string ObtenerRutaArchivo(Paciente paciente, bool mostrarDialogo)
        {
            string nombreArchivo = $"Receta_{paciente.Dni}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            if (mostrarDialogo)
            {
                using (var dlg = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = nombreArchivo
                })
                {
                    return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
                }
            }

            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(docs, nombreArchivo);
        }
    }
}