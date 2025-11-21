using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SiAP.BE;
using SiAP.UI.Impresiones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiAP.Services.PDF
{
    public class TurnosPDFGenerator : PDFGeneratorBase
    {
        private readonly List<Turno> _turnos;
        private readonly Medico _medico;
        private readonly DateTime _fecha;

        public TurnosPDFGenerator(List<Turno> turnos)
        {
            _turnos = turnos ?? throw new ArgumentNullException(nameof(turnos));
            if (_turnos.Count == 0)
                throw new ArgumentException("La lista de turnos no puede estar vacía.", nameof(turnos));
            _medico = _turnos.First().Medico ?? throw new InvalidOperationException("Los turnos deben tener información del médico.");
            _fecha = _turnos.First().Fecha;
        }

        protected override void ValidarDatos()
        {
            if (_turnos == null || _turnos.Count == 0)
                throw new InvalidOperationException("Debe haber al menos un turno para generar el PDF.");
            if (_turnos.Any(t => t.Medico == null))
                throw new InvalidOperationException("Todos los turnos deben tener información del médico.");
            if (_turnos.Any(t => t.Paciente == null))
                throw new InvalidOperationException("Todos los turnos deben tener información del paciente.");
        }

        protected override string ObtenerTituloPDF()
        {
            return $"Agenda de Turnos - Dr/a. {_medico.NombreCompleto}";
        }

        protected override string ObtenerNombreArchivo()
        {
            return $"Turnos_{_medico.Persona.Apellido}_{_fecha:yyyyMMdd}.pdf";
        }

        protected override void DibujarContenido(XGraphics gfx, PdfPage page)
        {
            DibujarEncabezado(gfx, "Agenda de Turnos");
            DibujarInformacionMedico(gfx);
            DibujarTurnos(gfx);
            DibujarResumen(gfx);
        }

        private void DibujarInformacionMedico(XGraphics gfx)
        {
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 100;

            DibujarFecha(gfx, _fecha, 400, y + 45);

            gfx.DrawString($"Profesional: Dr/a. {_medico.NombreCompleto}", f, XBrushes.Black, 50, y);
            gfx.DrawString($"Titulo: {_medico.Titulo}", f, XBrushes.Black, 50, y + 15);
            gfx.DrawString($"Especialidad: {_medico.Especialidad}", f, XBrushes.Black, 50, y + 30);
            gfx.DrawString($"Teléfono: {_medico.Telefono}", f, XBrushes.Black, 50, y + 45);
        }

        private void DibujarTurnos(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 200;

            gfx.DrawString("Turnos del día:", fHeader, XBrushes.Black, 50, y);
            y += 20;

            var turnosOrdenados = _turnos.OrderBy(t => t.HoraInicio).ToList();

            foreach (var turno in turnosOrdenados)
            {
                XBrush colorEstado = ObtenerColorEstado(turno.Estado);
                string estado = $"[{turno.Estado}]";

                gfx.DrawString($"• {turno.HoraInicio:hh\\:mm} - {turno.Paciente.NombreCompleto} (DNI: {turno.Paciente.Dni}) {estado}",
                    f, colorEstado, 60, y);
                y += 18;

                if (!string.IsNullOrWhiteSpace(turno.TipoAtencion))
                {
                    gfx.DrawString($"  Tipo: {turno.TipoAtencion}", f, XBrushes.Gray, 70, y);
                    y += 15;
                }
            }
        }

        private void DibujarResumen(XGraphics gfx)
        {
            XFont fHeader = new XFont(FamiliaFuente, TamañoSubtitulo, XFontStyleEx.Bold);
            XFont f = new XFont(FamiliaFuente, TamañoNormal, XFontStyleEx.Regular);
            double y = 200 + (_turnos.Count * 33) + 30;

            gfx.DrawString("Resumen:", fHeader, XBrushes.Black, 50, y);
            y += 20;

            var totalTurnos = _turnos.Count;
            var confirmados = _turnos.Count(t => t.Estado == EstadoTurno.Confirmado);
            var asignados = _turnos.Count(t => t.Estado == EstadoTurno.Asignado);
            var cancelados = _turnos.Count(t => t.Estado == EstadoTurno.Cancelado);
            var atendidos = _turnos.Count(t => t.Estado == EstadoTurno.Atendido);
            var ausentes = _turnos.Count(t => t.Estado == EstadoTurno.Ausente);

            gfx.DrawString($"Total de turnos: {totalTurnos}", f, XBrushes.Black, 60, y);
            y += 18;

            if (asignados > 0)
            {
                gfx.DrawString($"• Asignados: {asignados}", f, XBrushes.Orange, 60, y);
                y += 15;
            }

            if (confirmados > 0)
            {
                gfx.DrawString($"• Confirmados: {confirmados}", f, XBrushes.Green, 60, y);
                y += 15;
            }

            if (atendidos > 0)
            {
                gfx.DrawString($"• Atendidos: {atendidos}", f, XBrushes.Blue, 60, y);
                y += 15;
            }

            if (ausentes > 0)
            {
                gfx.DrawString($"• Ausentes: {ausentes}", f, XBrushes.DarkRed, 60, y);
                y += 15;
            }

            if (cancelados > 0)
            {
                gfx.DrawString($"• Cancelados: {cancelados}", f, XBrushes.Red, 60, y);
            }
        }

        private XBrush ObtenerColorEstado(EstadoTurno estado)
        {
            return estado switch
            {
                EstadoTurno.Asignado => XBrushes.Orange,
                EstadoTurno.Confirmado => XBrushes.Green,
                EstadoTurno.Cancelado => XBrushes.Red,
                EstadoTurno.Atendido => XBrushes.Blue,
                EstadoTurno.Ausente => XBrushes.DarkRed,
                _ => XBrushes.Black
            };
        }
    }
}