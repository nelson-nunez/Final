using System.Data;
using System.Globalization;
using ScottPlot;
using SiAP.BE;
using SiAP.BE.Vistas;
using SiAP.BLL;

namespace SiAP.UI
{
    public partial class Form_DashBoard : Form
    {
        #region Vars

        private readonly BLL_Turno _bllTurno;
        private readonly BLL_Factura _bllFactura;
        private readonly BLL_Agenda _bllAgenda;

        #endregion

        #region Constructor
        public Form_DashBoard()
        {
            InitializeComponent();
            _bllTurno = BLL_Turno.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllFactura = BLL_Factura.ObtenerInstancia();

            //Por default para ver algo lindo
            dateTimePicker_desde.Value = DateTime.Now.AddMonths(-5);
            dateTimePicker_hasta.Value = DateTime.Now.AddMonths(1);
            CargarTodo(dateTimePicker_desde.Value.Date, dateTimePicker_hasta.Value.Date);
        }

        #endregion

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

            // Añadir barras usando ScottPlot 4.1.74
            var barPlot = formsPlot_ingresos.Plot.AddBar(valores, posiciones);
            barPlot.FillColor = System.Drawing.Color.Green;
            barPlot.BorderColor = System.Drawing.Color.DarkGreen;

            // Configurar los ticks del eje X
            formsPlot_ingresos.Plot.XTicks(posiciones, etiquetas);

            // Configurar límites
            double xMin = posiciones.First() - 0.5;
            double xMax = posiciones.Last() + 0.5;
            double maxVal = valores.Length > 0 ? valores.Max() : 0;
            double yMax = Math.Max(maxVal * 1.1, 1.0);

            formsPlot_ingresos.Plot.SetAxisLimits(xMin, xMax, 0, yMax);

            // Etiquetas y título
            formsPlot_ingresos.Plot.Title($"Ingresos Mensuales - Periodo: {desde:MMM yyyy} a {hasta:MMM yyyy}");
            formsPlot_ingresos.Plot.YLabel("Monto Total ($)");
            formsPlot_ingresos.Plot.XLabel("Mes");

            // Renderizar
            formsPlot_ingresos.Refresh();
        }

        public void CargarGrafico_IngresosEspecialidad(List<Vista_Ingresos_Esp> ingresosPorEspecialidad)
        {
            // Validaciones básicas
            if (ingresosPorEspecialidad == null || ingresosPorEspecialidad.Count == 0)
            {
                formsPlot_ingresos_especialidad.Plot.Clear();
                formsPlot_ingresos_especialidad.Refresh();
                return;
            }

            // Filtrar items con monto positivo
            var items = ingresosPorEspecialidad
                .Where(x => x.TotalIngresos > 0)
                .OrderByDescending(x => x.TotalIngresos)
                .ToList();

            if (items.Count == 0)
            {
                formsPlot_ingresos_especialidad.Plot.Clear();
                formsPlot_ingresos_especialidad.Refresh();
                return;
            }

            // Preparar datos
            double[] valores = items.Select(x => (double)x.TotalIngresos).ToArray();
            string[] etiquetas = items.Select(x => x.Especialidad ?? "Sin especialidad").ToArray();
            double totalIngresos = valores.Sum();

            // Limpiar y crear pie
            formsPlot_ingresos_especialidad.Plot.Clear();

            // Crear etiquetas más cortas con porcentajes
            string[] etiquetasConPorcentaje = new string[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                double porcentaje = totalIngresos > 0 ? valores[i] / totalIngresos * 100.0 : 0.0;
                string etiquetaCorta = etiquetas[i].Length > 15 ? etiquetas[i].Substring(0, 12) + "..." : etiquetas[i];
                etiquetasConPorcentaje[i] = $"{etiquetaCorta}\n({porcentaje:F1}%)";
            }

            // Añadir gráfico de torta (PIE, sin donut)
            var pie = formsPlot_ingresos_especialidad.Plot.AddPie(valores);
            pie.SliceLabels = etiquetasConPorcentaje;
            pie.ShowLabels = true;
            pie.Explode = true;

            // Asegurar que sea un PIE (no donut)
            pie.DonutSize = 0.0;
            pie.OutlineSize = 0;

            // Reducir tamaño de las fuentes de las etiquetas
            pie.SliceFont.Size = 12; // tamaño más pequeño


            // Colores base (se repetirán si hay más categorías)
            var baseColors = new System.Drawing.Color[]
            {
                System.Drawing.Color.DodgerBlue,
                System.Drawing.Color.Green,
                System.Drawing.Color.Orange,
                System.Drawing.Color.Purple,
                System.Drawing.Color.Red,
                System.Drawing.Color.Teal,
                System.Drawing.Color.Gold,
                System.Drawing.Color.Pink,
                System.Drawing.Color.Brown,
                System.Drawing.Color.Gray
            };

            // Repetir/reciclar colores según la cantidad de slices
            var fillColors = Enumerable.Range(0, valores.Length)
                .Select(i => baseColors[i % baseColors.Length])
                .ToArray();
            pie.SliceFillColors = fillColors;

            // Colores de etiquetas (negro para legibilidad)
            pie.SliceLabelColors = Enumerable.Repeat(System.Drawing.Color.Black, valores.Length).ToArray();

            // Ocultar ejes y grid
            formsPlot_ingresos_especialidad.Plot.Frameless();
            formsPlot_ingresos_especialidad.Plot.Grid(false);

            // Reducir tamaño visual del pie dentro del contenedor:
            // agrandar límites del eje hace que el pie ocupe menos espacio visual
            formsPlot_ingresos_especialidad.Plot.SetAxisLimits(-2.5, 2.5, -2.5, 2.5);

            // Ajustar márgenes internos para "achicar" contenido
            formsPlot_ingresos_especialidad.Plot.Layout(padding: 15);

            // SIN título (removido según lo pedido)

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

            // Filtrar y ordenar
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
            string[] etiquetas = items
                .Select(x => string.IsNullOrWhiteSpace(x.Especialidad) ? "Sin especialidad" : x.Especialidad)
                .ToArray();
            double[] posiciones = Enumerable.Range(0, n).Select(i => (double)i).ToArray();

            // Limpiar gráfico
            formsPlot_especialidades.Plot.Clear();

            // Añadir barras
            var bar = formsPlot_especialidades.Plot.AddBar(valores, posiciones);
            bar.FillColor = System.Drawing.Color.DodgerBlue;
            bar.BorderColor = System.Drawing.Color.DarkBlue;

            // Configurar ticks del eje X
            formsPlot_especialidades.Plot.XTicks(posiciones, etiquetas);

            // Rotar etiquetas si son muchas
            if (n > 6)
            {
                formsPlot_especialidades.Plot.XAxis.TickLabelStyle(rotation: 25);
            }

            // Configurar límites
            double xMin = posiciones.First() - 0.5;
            double xMax = posiciones.Last() + 0.5;
            double maxVal = valores.Length > 0 ? valores.Max() : 0;
            double yMax = Math.Max(maxVal * 1.1, 1.0);

            formsPlot_especialidades.Plot.SetAxisLimits(xMin, xMax, 0, yMax);

            // Etiquetas y título
            formsPlot_especialidades.Plot.YLabel("Cantidad de Turnos");
            formsPlot_especialidades.Plot.Title($"Especialidades ({n}) - Total turnos: {totalTurnos}");

            // Renderizar
            formsPlot_especialidades.Refresh();
        }

        public void CargarGrafico_DisponibilidadOcupacion(List<Turno> turnos, List<Agenda> agendas)
        {
            if (agendas is null || agendas.Count == 0)
            {
                formsPlot_disponibilidad.Plot.Clear();
                formsPlot_disponibilidad.Refresh();
                return;
            }

            int totalAgendas = agendas.Count;
            int turnosOcupados = turnos?.Count ?? 0;
            int disponibles = Math.Max(0, totalAgendas - turnosOcupados);

            double[] valores = new double[] { disponibles, turnosOcupados };

            double porcentaje = totalAgendas == 0 ? 0 : (disponibles * 100.0) / totalAgendas;

            string[] etiquetas = new string[]
            {
                $"Disponibles\n({porcentaje:F1}%)",
                $"Ocupados\n({(100 - porcentaje):F1}%)"
            };

            formsPlot_disponibilidad.Plot.Clear();

            // PIE completo (sin donut)
            var pie = formsPlot_disponibilidad.Plot.AddPie(valores);
            pie.SliceLabels = etiquetas;
            pie.ShowLabels = true;

            // Reducir tamaño de fuente
            pie.SliceFont.Size = 14;

            // Mantener gráfico pequeño
            pie.DonutSize = 0.0;                // 0 = pie normal
            pie.OutlineSize = 0;

            // Colores
            pie.SliceLabelColors = new[]
            {
                System.Drawing.Color.Black,
                System.Drawing.Color.Black
            };

            pie.SliceFillColors = new[]
            {
                System.Drawing.Color.LightGreen,
                System.Drawing.Color.Orange
            };

            // Ocultar ejes
            formsPlot_disponibilidad.Plot.Frameless();
            formsPlot_disponibilidad.Plot.Grid(false);

            // Reducir tamaño visual del pie
            formsPlot_disponibilidad.Plot.SetAxisLimits(-1.8, 1.8, -1.8, 1.8);

            // Ajustar área del gráfico para que quede más chico
            formsPlot_disponibilidad.Plot.Layout(padding: 15);

            // Sin título (removido)
            formsPlot_disponibilidad.Refresh();
        }

        #endregion
    }
}
