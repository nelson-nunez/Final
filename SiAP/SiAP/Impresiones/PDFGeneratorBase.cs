using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using SiAP.BE;

namespace SiAP.UI.Impresiones
{
    /// <summary>
    /// Clase base abstracta para la generación de documentos PDF
    /// </summary>
    public abstract class PDFGeneratorBase
    {
        #region Vars

        protected static readonly double TamañoTitulo = 16;
        protected static readonly double TamañoSubtitulo = 11;
        protected static readonly double TamañoNormal = 10;
        protected static readonly double TamañoPequeño = 9;
        protected static readonly string FamiliaFuente = "Arial";

        private static bool _fontResolverConfigurado = false;
        
        #endregion

        #region Métodos 

        protected static void ConfigurarFontResolver()
        {
            if (!_fontResolverConfigurado)
            {
                GlobalFontSettings.FontResolver = new CustomFontResolver();
                _fontResolverConfigurado = true;
            }
        }

        public string GenerarPDF(string rutaArchivo = null, bool mostrarDialogo = true)
        {
            ValidarDatos();
            ConfigurarFontResolver();

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = ObtenerTituloPDF();

            PdfPage page = pdf.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DibujarContenido(gfx, page);

            string ruta = rutaArchivo ?? ObtenerRutaArchivo(mostrarDialogo);
            if (ruta == null) return null;

            pdf.Save(ruta);
            return ruta;
        }

        public void GenerarYAbrirPDF()
        {
            try
            {
                string path = GenerarPDF();
                if (string.IsNullOrEmpty(path)) return;

                if (MessageBox.Show(
                    $"¿Desea abrir el documento generado?",
                    "Documento Generado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar o abrir el documento: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private string ObtenerRutaArchivo(bool mostrarDialogo)
        {
            string nombreArchivo = ObtenerNombreArchivo();

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

        #endregion

        #region Métodos abstractos - Deben implementarse en clases derivadas

        protected abstract void ValidarDatos();

        protected abstract string ObtenerTituloPDF();

        protected abstract string ObtenerNombreArchivo();

        protected abstract void DibujarContenido(XGraphics gfx, PdfPage page);

        #endregion

        #region Métodos protegidos - Utilidades comunes

        protected void DibujarEncabezado(XGraphics gfx, string titulo, double y = 50)
        {
            XFont fontTitulo = new XFont(FamiliaFuente, TamañoTitulo, XFontStyleEx.Bold);
            gfx.DrawString(titulo, fontTitulo, XBrushes.Black, new XPoint(230, y));
        }

        protected void DibujarFirma(XGraphics gfx, double x = 300, double y = 670, string texto = "Firma y sello")
        {
            XPen pen = new XPen(XColors.Black, 1);
            XFont f = new XFont(FamiliaFuente, TamañoPequeño, XFontStyleEx.Regular);
            gfx.DrawLine(pen, x, y, x + 200, y);
            gfx.DrawString(texto, f, XBrushes.Black, x + 50, y + 15);
        }

        protected void DibujarDatosPaciente(XGraphics gfx, Paciente paciente, double x, double y)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);

            gfx.DrawString($"Paciente: {paciente.NombreCompleto}", f, XBrushes.Black, x, y);
            gfx.DrawString($"DNI: {paciente.Dni}", f, XBrushes.Black, x, y + 15);

            if (!string.IsNullOrWhiteSpace(paciente.ObraSocial))
                gfx.DrawString($"Obra Social: {paciente.ObraSocial}", f, XBrushes.Black, x, y + 30);
        }

        protected void DibujarDatosMedico(XGraphics gfx, Medico medico, double x, double y)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);

            gfx.DrawString($"Médico/a: {medico.NombreCompleto}", f, XBrushes.Black, x, y);

            if (medico.Especialidad != null)
                gfx.DrawString($"Especialidad: {medico.Especialidad.Nombre}", f, XBrushes.Black, x, y + 15);

            if (medico.Persona?.Dni != null)
                gfx.DrawString($"Matrícula: {medico.Persona.Dni}", f, XBrushes.Black, x, y + 30);
        }

        protected void DibujarFecha(XGraphics gfx, DateTime fecha, double x, double y)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            gfx.DrawString($"Fecha: {fecha:dd/MM/yyyy}", f, XBrushes.Black, x, y);
        }

        #endregion


    }
}