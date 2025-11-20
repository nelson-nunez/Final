using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SiAP.BE;

namespace SiAP.UI.Impresiones
{
    /// <summary>
    /// Generador de PDF específico para facturas tipo C
    /// </summary>
    public class FacturaPDFGenerator : PDFGeneratorBase
    {
        private readonly Factura _factura;

        public FacturaPDFGenerator(Factura factura)
        {
            _factura = factura ?? throw new ArgumentNullException(nameof(factura));
        }

        protected override void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(_factura.NumeroFactura))
                throw new InvalidOperationException("La factura debe contener un número.");

            if (_factura.Importe <= 0)
                throw new InvalidOperationException("El importe de la factura debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(_factura.RazonSocialEmisor))
                throw new InvalidOperationException("La factura debe contener la razón social del emisor.");
        }

        protected override string ObtenerTituloPDF()
        {
            return $"Factura {_factura.NumeroFactura}";
        }

        protected override string ObtenerNombreArchivo()
        {
            return $"Factura_{_factura.NumeroFactura.Replace("-", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        }

        protected override void DibujarContenido(XGraphics gfx, PdfPage page)
        {
            DibujarEncabezadoFactura(gfx);
            DibujarDatosEmisor(gfx);
            DibujarDatosReceptor(gfx);
            DibujarDetalleFactura(gfx);
            DibujarTotales(gfx);
            DibujarPieFactura(gfx);
        }

        private void DibujarEncabezadoFactura(XGraphics gfx)
        {
            XFont fTitulo = new XFont(FamiliaFuente, 20, XFontStyleEx.Bold);
            XFont fSubtitulo = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont fNormal = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);

            double y = 50;

            // Tipo de factura con recuadro
            XRect rectTipo = new XRect(450, y, 100, 80);
            gfx.DrawRectangle(XPens.Black, rectTipo);
            gfx.DrawString("FACTURA", fSubtitulo, XBrushes.Black,
                new XRect(450, y + 10, 100, 20), XStringFormats.Center);
            gfx.DrawString("C", fTitulo, XBrushes.Black,
                new XRect(450, y + 35, 100, 30), XStringFormats.Center);

            // Número de factura
            y += 90;
            gfx.DrawString($"N°: {_factura.NumeroFactura}", fSubtitulo, XBrushes.Black, 450, y);

            // Fecha de emisión
            y += 25;
            gfx.DrawString($"Fecha: {_factura.FechaEmision:dd/MM/yyyy}", fNormal, XBrushes.Black, 450, y);
        }

        private void DibujarDatosEmisor(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont fNormal = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);

            double y = 50;

            gfx.DrawString("EMISOR", fHeader, XBrushes.Black, 50, y);
            y += 25;
            gfx.DrawString(_factura.RazonSocialEmisor, fNormal, XBrushes.Black, 50, y);
            y += 20;
            gfx.DrawString($"CUIT: {_factura.CUITEmisor}", fNormal, XBrushes.Black, 50, y);
            y += 20;
            gfx.DrawString($"Domicilio: {_factura.DomicilioEmisor}", fNormal, XBrushes.Black, 50, y);
            y += 20;
            gfx.DrawString($"Punto de Venta: {_factura.PuntoDeVenta:D4}", fNormal, XBrushes.Black, 50, y);
        }

        private void DibujarDatosReceptor(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont fNormal = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);

            double y = 200;

            gfx.DrawString("RECEPTOR", fHeader, XBrushes.Black, 50, y);
            y += 25;
            gfx.DrawString(_factura.RazonSocialReceptor, fNormal, XBrushes.Black, 50, y);
        }

        private void DibujarDetalleFactura(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont fNormal = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);

            double y = 280;
            // Encabezado de la tabla
            gfx.DrawString("DETALLE", fHeader, XBrushes.Black, 50, y);
            y += 30;
            // Línea separadora
            gfx.DrawLine(XPens.Black, 50, y, 550, y);
            y += 15;
            // Encabezados de columnas
            gfx.DrawString("Descripción", fHeader, XBrushes.Black, 50, y);
            gfx.DrawString("Importe", fHeader, XBrushes.Black, 450, y);
            y += 20;
            gfx.DrawLine(XPens.Black, 50, y, 550, y);
            y += 15;

            // Detalle
            gfx.DrawString(_factura.Descripcion ?? "Servicios profesionales", fNormal, XBrushes.Black, 50, y);
            gfx.DrawString($"$ {_factura.Importe:N2}", fNormal, XBrushes.Black, 450, y);
            y += 30;
            gfx.DrawLine(XPens.Black, 50, y, 550, y);
        }

        private void DibujarTotales(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont fNormal = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            XFont fTotal = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);

            double y = 450;

            // Subtotal
            gfx.DrawString("Subtotal:", fNormal, XBrushes.Black, 350, y);
            gfx.DrawString($"$ {_factura.Subtotal:N2}", fNormal, XBrushes.Black, 450, y);
            y += 25;

            // IVA (siempre 0 para Factura C)
            gfx.DrawString("IVA (21%):", fNormal, XBrushes.Black, 350, y);
            gfx.DrawString($"$ {_factura.MontoIVA:N2}", fNormal, XBrushes.Black, 450, y);
            y += 25;

            // Línea separadora
            gfx.DrawLine(XPens.Black, 350, y, 550, y);
            y += 20;

            // Total
            gfx.DrawString("TOTAL:", fTotal, XBrushes.Black, 350, y);
            gfx.DrawString($"$ {_factura.Total:N2}", fTotal, XBrushes.Black, 450, y);
        }

        private void DibujarPieFactura(XGraphics gfx)
        {
            XFont fSmall = new XFont(FamiliaFuente, 8, XFontStyleEx.Italic);
            double y = 750;

            string nota = "FACTURA TIPO C - Documento no válido como crédito fiscal";
            gfx.DrawString(nota, fSmall, XBrushes.Gray,
                new XRect(50, y, 500, 20), XStringFormats.Center);
        }
    }

    public static class FacturaExtensions
    {
        public static string GenerarPDF(this Factura factura,
            string rutaArchivo = null, bool mostrarDialogo = true)
        {
            var generator = new FacturaPDFGenerator(factura);
            return generator.GenerarPDF(rutaArchivo, mostrarDialogo);
        }

        public static void GenerarYAbrirPDF(this Factura factura)
        {
            var generator = new FacturaPDFGenerator(factura);
            generator.GenerarYAbrirPDF();
        }
    }
}
