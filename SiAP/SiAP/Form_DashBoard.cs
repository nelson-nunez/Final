using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Colormaps;
using SiAP.BE;
using SiAP.BE.Vistas;
using SiAP.BLL;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_DashBoard : Form
    {
        #region Vars

        private readonly BLL_Turno _bllTurno;
        private readonly BLL_Factura _bllFactura;
        private readonly BLL_Agenda _bllAgenda;

        #endregion

        public Form_DashBoard()
        {
            InitializeComponent();
            _bllTurno = BLL_Turno.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllFactura = BLL_Factura.ObtenerInstancia();

            //Por default para ver algo lindo
            dateTimePicker_desde.Value = DateTime.Now.AddYears(-1);
            CargarTodo(dateTimePicker_desde.Value.Date, dateTimePicker_hasta.Value.Date);
        }

        #region Methods

        private void button_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                var desde = dateTimePicker_desde.Value.Date;
                var hasta = dateTimePicker_hasta.Value.Date;

                // 'Hasta' debe ser estrictamente mayor que 'Desde'
                if (hasta <= desde)
                    throw new InvalidOperationException("La fecha 'Hasta' debe ser mayor a la fecha 'Desde'.");

                // El período no puede exceder 12 meses
                if (hasta > desde.AddMonths(12))
                    throw new InvalidOperationException("El período seleccionado no puede exceder 12 meses.");

                CargarTodo(desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarTodo(DateTime fecha_Desde, DateTime fecha_Hasta)
        {
            //1
            var turnosAnio = _bllFactura.BuscarporRango(fecha_Desde, fecha_Hasta).ToList();
            CargarGrafico_Ingresos(turnosAnio, fecha_Desde, fecha_Hasta);
            //2
            var turnos_por_esp = _bllTurno.BuscarVistaporRango(fecha_Desde, fecha_Hasta).ToList();
            CargarGrafico_IngresosEspecialidad(turnos_por_esp);
            //3
            CargarGrafico_Especialidades(turnos_por_esp);
            //4
            var turnos_disp = _bllTurno.BuscarporRango(fecha_Desde, fecha_Hasta).ToList();
            var agendas_disp = _bllAgenda.BuscarporRango(fecha_Desde, fecha_Hasta).ToList();
            CargarGrafico_DisponibilidadOcupacion(turnos_disp, agendas_disp);
        }


        public void CargarGrafico_Ingresos(List<Factura> turnosAnio, DateTime fecha_Desde, DateTime fecha_Hasta)
        {
            var desde = fecha_Desde.Date;
            var hasta = fecha_Hasta.Date;
            if (desde > hasta) return;

            // Control vacío
            if (turnosAnio is null || turnosAnio.Count == 0)
            {
                formsPlot_ingresos.Plot.Clear();
                formsPlot_ingresos.Plot.Title("Sin datos disponibles");
                formsPlot_ingresos.Refresh();
                return;
            }

            // Lista de meses entre desde y hasta
            var mesesLista = new List<DateTime>();
            for (var m = new DateTime(desde.Year, desde.Month, 1);
                 m <= new DateTime(hasta.Year, hasta.Month, 1);
                 m = m.AddMonths(1))
                mesesLista.Add(m);

            if (mesesLista.Count == 0)
            {
                formsPlot_ingresos.Plot.Clear();
                formsPlot_ingresos.Plot.Title("Sin datos en el período");
                formsPlot_ingresos.Refresh();
                return;
            }

            // Agrupar por año+mes y sumar Totales dentro del rango
            var ingresosPorMes = turnosAnio
                .Where(t => t.Total != null && t.Total > 0
                            && t.FechaEmision.Date >= desde
                            && t.FechaEmision.Date <= hasta)
                .GroupBy(t => new { t.FechaEmision.Year, t.FechaEmision.Month })
                .ToDictionary(g => (g.Key.Year, g.Key.Month), g => g.Sum(t => (double)t.Total));

            int n = mesesLista.Count;
            double[] valores = new double[n];
            string[] etiquetas = new string[n];
            double[] posiciones = new double[n]; 
            var cultura = new CultureInfo("es-ES");

            for (int i = 0; i < n; i++)
            {
                var m = mesesLista[i];
                etiquetas[i] = m.ToString("MMM", cultura); 
                ingresosPorMes.TryGetValue((m.Year, m.Month), out double monto);
                valores[i] = monto;
                posiciones[i] = i; 
            }

            // Limpiar gráfico
            formsPlot_ingresos.Plot.Clear();

            // Añadir barras usando (positions, values)
            var barPlot = formsPlot_ingresos.Plot.Add.Bars(posiciones, valores);

            // Si querés colorear todas igual (o individualmente)
            for (int i = 0; i < barPlot.Bars.Count; i++)
                barPlot.Bars[i].FillColor = ScottPlot.Colors.Green;

            // Quitar padding inferior si querés que ocupen todo el área
            formsPlot_ingresos.Plot.Axes.Margins(bottom: 0);

            // Ticks del eje X en las mismas posiciones que las barras
            Tick[] ticks = new Tick[n];
            for (int i = 0; i < n; i++)
                ticks[i] = new Tick(posiciones[i], etiquetas[i]);

            formsPlot_ingresos.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            double xMin = posiciones.First() - 0.5;
            double xMax = posiciones.Last() + 0.5;

            double maxVal = valores.Length > 0 ? valores.Max() : 0;
            double yMax = Math.Max(maxVal * 1.1, 1.0); // 10% de margen, mínimo 1

            formsPlot_ingresos.Plot.Axes.SetLimits(xMin, xMax, 0, yMax);

            // Etiquetas y título
            formsPlot_ingresos.Plot.Title($"Ingresos Mensuales - Periodo: {desde:MMM yyyy} a {hasta:MMM yyyy}");
            formsPlot_ingresos.Plot.Axes.Left.Label.Text = "Monto Total ($)";
            formsPlot_ingresos.Plot.Axes.Bottom.Label.Text = "Mes";

            // Renderizar
            formsPlot_ingresos.Refresh();
        }
        public void CargarGrafico_IngresosEspecialidad(List<Vista_Ingresos_Esp> ingresosPorEspecialidad)
        {
            // Validaciones básicas
            if (ingresosPorEspecialidad == null || ingresosPorEspecialidad.Count == 0)
            {
                formsPlot_ingresos_especialidad.Plot.Clear();
                formsPlot_ingresos_especialidad.Plot.Title("Sin datos disponibles");
                formsPlot_ingresos_especialidad.Refresh();
                return;
            }

            // Filtrar items con monto positivo
            var items = ingresosPorEspecialidad.Where(x => x.TotalIngresos > 0).OrderByDescending(x => x.TotalIngresos).ToList();

            if (items.Count == 0)
            {
                formsPlot_ingresos_especialidad.Plot.Clear();
                formsPlot_ingresos_especialidad.Plot.Title("Sin ingresos registrados");
                formsPlot_ingresos_especialidad.Refresh();
                return;
            }

            // Preparar datos
            double[] valores = items.Select(x => (double)x.TotalIngresos).ToArray();
            string[] etiquetas = items.Select(x => x.Especialidad ?? "Sin especialidad").ToArray();
            int[] cantidades = items.Select(x => x.CantidadTurnos).ToArray();
            double totalIngresos = valores.Sum();

            // Limpiar y crear pie
            formsPlot_ingresos_especialidad.Plot.Clear();
            var pie = formsPlot_ingresos_especialidad.Plot.Add.Pie(valores);

            // Colores reutilizables (se repiten si hay más categorías)
            var palette = new[]
            {
                ScottPlot.Colors.DodgerBlue,
                ScottPlot.Colors.Green,
                ScottPlot.Colors.Orange,
                ScottPlot.Colors.Purple,
                ScottPlot.Colors.Red,
                ScottPlot.Colors.Teal,
                ScottPlot.Colors.Gold,
                ScottPlot.Colors.Pink,
                ScottPlot.Colors.Brown,
                ScottPlot.Colors.Gray
            };

            // Etiquetas y estilo de slices
            for (int i = 0; i < pie.Slices.Count && i < valores.Length; i++)
            {
                double monto = valores[i];
                double porcentaje = totalIngresos > 0 ? monto / totalIngresos * 100.0 : 0.0;
                pie.Slices[i].Label = $"{etiquetas[i]}\n{cantidades[i]} turnos\n${monto:N0} ({porcentaje:F1}%)";
                pie.Slices[i].FillColor = palette[i % palette.Length];
                pie.Slices[i].LabelStyle.FontSize = 11;
                pie.Slices[i].LabelStyle.Bold = true;
                pie.Slices[i].LabelStyle.ForeColor = ScottPlot.Colors.Black;
            }

            // Estética del pie
            pie.ExplodeFraction = 0.05;
            pie.SliceLabelDistance = 1.2;

            // Layout limpio
            formsPlot_ingresos_especialidad.Plot.Axes.Frameless();
            formsPlot_ingresos_especialidad.Plot.Layout.Frameless();
            formsPlot_ingresos_especialidad.Plot.Grid.IsVisible = false;

            // Título con total
            formsPlot_ingresos_especialidad.Plot.Title($"Ingresos por Especialidad — Total: ${totalIngresos:N0}");

            // Renderizar
            formsPlot_ingresos_especialidad.Refresh();
        }
        public void CargarGrafico_Especialidades(List<Vista_Ingresos_Esp> ingresosPorEspecialidad)
        {
            // Totales en los textboxes
            int totalTurnos = ingresosPorEspecialidad?.Sum(x => x.CantidadTurnos) ?? 0;
            decimal totalIngresos = ingresosPorEspecialidad?.Sum(x => x.TotalIngresos) ?? 0m;

            textBox_total_turnos.Text = totalTurnos.ToString();
            textBox_total_turnos_ingresos.Text = totalIngresos.ToString("N2");

            // Control vacío
            if (ingresosPorEspecialidad == null || ingresosPorEspecialidad.Count == 0)
            {
                formsPlot_especialidades.Plot.Clear();
                formsPlot_especialidades.Plot.Title("Sin datos disponibles");
                formsPlot_especialidades.Refresh();
                return;
            }

            // Filtrar y ordenar (evitar nulos en la etiqueta)
            var items = ingresosPorEspecialidad
                .Where(x => x.CantidadTurnos > 0)
                .OrderBy(x => string.IsNullOrWhiteSpace(x.Especialidad) ? "" : x.Especialidad)
                .ToList();

            if (items.Count == 0)
            {
                formsPlot_especialidades.Plot.Clear();
                formsPlot_especialidades.Plot.Title("Sin turnos registrados");
                formsPlot_especialidades.Refresh();
                return;
            }

            int n = items.Count;
            double[] valores = items.Select(x => (double)x.CantidadTurnos).ToArray();
            string[] etiquetas = items.Select(x => string.IsNullOrWhiteSpace(x.Especialidad) ? "Sin especialidad" : x.Especialidad).ToArray();
            double[] posiciones = Enumerable.Range(0, n).Select(i => (double)i).ToArray();

            // Limpiar gráfico
            formsPlot_especialidades.Plot.Clear();

            // Añadir barras (positions, values)
            var bar = formsPlot_especialidades.Plot.Add.Bars(posiciones, valores);

            // Opcional: colorear todas las barras (o personalizar)
            for (int i = 0; i < bar.Bars.Count; i++)
                bar.Bars[i].FillColor = ScottPlot.Colors.DodgerBlue;

            // Ticks en las mismas posiciones
            Tick[] ticks = new Tick[n];
            for (int i = 0; i < n; i++)
                ticks[i] = new Tick(posiciones[i], etiquetas[i]);

            formsPlot_especialidades.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // Rotar etiquetas si son muchas o largas
            formsPlot_especialidades.Plot.Axes.Bottom.TickLabelStyle.Rotation = n > 6 ? 25 : 0;
            formsPlot_especialidades.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleLeft;

            // Forzar límites X para que las barras ocupen todo el ancho
            double xMin = posiciones.First() - 0.5;
            double xMax = posiciones.Last() + 0.5;

            // Calcular límite Y con margen
            double maxVal = valores.Length > 0 ? valores.Max() : 0;
            double yMax = Math.Max(maxVal * 1.1, 1.0);

            formsPlot_especialidades.Plot.Axes.SetLimits(xMin, xMax, 0, yMax);
            formsPlot_especialidades.Plot.Axes.Margins(bottom: 0.05);

            // Etiquetas y título
            formsPlot_especialidades.Plot.Axes.Left.Label.Text = "Cantidad de Turnos";
            formsPlot_especialidades.Plot.Title($"Especialidades ({n}) - Total turnos: {totalTurnos}");

            // Renderizar
            formsPlot_especialidades.Refresh();
        }
        public void CargarGrafico_DisponibilidadOcupacion(List<Turno> turnos, List<Agenda> agendas)
        {
            // Control vacío
            if (agendas is null || agendas.Count == 0)
            {
                formsPlot_disponibilidad.Plot.Clear();
                formsPlot_disponibilidad.Plot.Title("Sin datos disponibles");
                formsPlot_disponibilidad.Refresh();
                return;
            }
            // Calcular totales
            int totalAgendas = agendas.Count;
            int turnosOcupados = (turnos != null) ? turnos.Count : 0;
            int disponibles = totalAgendas - turnosOcupados;
            if (disponibles < 0) disponibles = 0;

            double[] valores = new double[] { disponibles, turnosOcupados };
            string[] etiquetas = new string[] { "Disponibles", "Ocupados" };
            // Limpiar gráfico
            formsPlot_disponibilidad.Plot.Clear();
            // Crear gráfico de torta
            var pie = formsPlot_disponibilidad.Plot.Add.Pie(valores);

            double porcentaje = 0;
            if (totalAgendas == 0)
                porcentaje = 0;
            else
                porcentaje = (disponibles * 100.0) / totalAgendas;


            // Configurar etiquetas de las porciones
            pie.Slices[0].Label = $"Disponibles\n{disponibles} ({porcentaje:F1}%)";
            pie.Slices[0].FillColor = ScottPlot.Colors.LightGreen;
            pie.Slices[0].LabelStyle.FontSize = 12;
            pie.Slices[0].LabelStyle.Bold = true;
            pie.Slices[1].Label = $"Ocupados\n{turnosOcupados} ({porcentaje:F1}%)";
            pie.Slices[1].FillColor = ScottPlot.Colors.Orange;
            pie.Slices[1].LabelStyle.FontSize = 12;
            pie.Slices[1].LabelStyle.Bold = true;

            // Configurar el estilo del pie
            pie.ExplodeFraction = 0.05;
            pie.SliceLabelDistance = 1.3;
            // Configurar título
            //formsPlot_disponibilidad.Plot.Title($"Disponibilidad vs Ocupación - {_fechaSeleccionada:MMMM yyyy}");
            // Ocultar ejes
            formsPlot_disponibilidad.Plot.Axes.Frameless();
            // Ajustar layout para centrar el gráfico
            formsPlot_disponibilidad.Plot.Layout.Frameless();
            // Ocultar cuadrícula
            formsPlot_disponibilidad.Plot.Grid.IsVisible = false;
            // Renderizar
            formsPlot_disponibilidad.Refresh();
        }
        #endregion
    }
}
