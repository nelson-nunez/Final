using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using SiAP.BE;
using SiAP.BLL;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_DashBoard : Form
    {
        private DateTime _fechaSeleccionada;
        private readonly BLL_Turno _bllTurno;
        private readonly BLL_Agenda _bllAgenda;

        public Form_DashBoard()
        {
            InitializeComponent();
            _bllTurno = BLL_Turno.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            comboBox1.CargarMesesRelativos();
        }

        public void CargarTodo()
        {
            CargarGrafico_Especialidades();
            CargarGrafico_Ingresos();
            CargarGrafico_DisponibilidadOcupacion();
            CargarGrafico_IngresosEspecialidad();
        }

        public void CargarGrafico_Especialidades()
        {
            // Traer turnos del mes seleccionado
            var turnos = _bllTurno.BuscarTurnodelMes(_fechaSeleccionada);

            textBox_total_turnos.Text = turnos.Count().ToString();
            textBox_total_turnos_ingresos.Text = turnos.Select(x => x.MontoTotal).Sum().ToString();
            // Control vacío
            if (turnos is null || turnos.Count == 0)
            {
                formsPlot_especialidades.Plot.Clear();
                formsPlot_especialidades.Plot.Title("Sin datos disponibles");
                formsPlot_especialidades.Refresh();
                return;
            }

            // Agrupar turnos por especialidad
            var grupos = turnos
                .Where(t => t.Medico?.Especialidad is not null)
                .GroupBy(t => t.Medico.Especialidad.Nombre)
                .Select(g => new { Especialidad = g.Key, Cantidad = g.Count() })
                .OrderBy(x => x.Especialidad)
                .ToList();

            double[] valores = grupos.Select(g => (double)g.Cantidad).ToArray();
            string[] etiquetas = grupos.Select(g => g.Especialidad).ToArray();

            // Limpiar gráfico
            formsPlot_especialidades.Plot.Clear();
            // Crear barras
            var barras = formsPlot_especialidades.Plot.Add.Bars(valores);
            // Configurar etiquetas del eje X
            Tick[] ticks = new Tick[etiquetas.Length];
            for (int i = 0; i < etiquetas.Length; i++)
            {
                ticks[i] = new Tick(i, etiquetas[i]);
            }
            formsPlot_especialidades.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            // Rotar etiquetas si son muchas o muy largas (opcional)
            formsPlot_especialidades.Plot.Axes.Bottom.TickLabelStyle.Rotation = 20;
            formsPlot_especialidades.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleLeft;

            // Configurar títulos y etiquetas
            formsPlot_especialidades.Plot.Axes.Left.Label.Text = "Cantidad de Turnos";
            // Asegurar que el eje Y arranca en cero
            formsPlot_especialidades.Plot.Axes.SetLimitsY(0, 0);
            // Renderizar
            formsPlot_especialidades.Refresh();
        }

        public void CargarGrafico_Ingresos()
        {
            // Traer todos los turnos del año seleccionado
            var turnosAnio = _bllTurno.BuscarTurnosdelAño(_fechaSeleccionada);
            // Control vacío
            if (turnosAnio is null || turnosAnio.Count == 0)
            {
                formsPlot_ingresos.Plot.Clear();
                formsPlot_ingresos.Plot.Title("Sin datos disponibles");
                formsPlot_ingresos.Refresh();
                return;
            }
            // Agrupar turnos por mes y sumar MontoTotal
            var ingresosPorMes = turnosAnio
                .Where(t => t.Cobro != null && t.Cobro.MontoTotal > 0)
                .GroupBy(t => t.Fecha.Month) // Agrupar por mes
                .Select(g => new
                {
                    Mes = g.Key,
                    MontoTotal = g.Sum(t => (double)t.Cobro.MontoTotal)
                })
                .OrderBy(x => x.Mes)
                .ToList();
            // Crear arrays para todos los meses (1-12)
            double[] valores = new double[12];
            string[] meses = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun",
                             "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            // Llenar valores con los montos correspondientes
            foreach (var ingreso in ingresosPorMes)
            {
                valores[ingreso.Mes - 1] = ingreso.MontoTotal;
            }
            // Limpiar gráfico
            formsPlot_ingresos.Plot.Clear();
            // Crear barras
            var barras = formsPlot_ingresos.Plot.Add.Bars(valores);
            // Configurar color de las barras (opcional)
            foreach (var barra in barras.Bars)
            {
                barra.FillColor = ScottPlot.Colors.Green;
            }
            // Configurar etiquetas del eje X (meses)
            Tick[] ticks = new Tick[12];
            for (int i = 0; i < 12; i++)
            {
                ticks[i] = new Tick(i, meses[i]);
            }
            formsPlot_ingresos.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            // Configurar títulos y etiquetas
            formsPlot_ingresos.Plot.Title($"Ingresos Mensuales - Año {_fechaSeleccionada.Year}");
            formsPlot_ingresos.Plot.Axes.Left.Label.Text = "Monto Total ($)";
            formsPlot_ingresos.Plot.Axes.Bottom.Label.Text = "Mes";
            // Asegurar que el eje Y arranca en cero
            formsPlot_ingresos.Plot.Axes.SetLimitsY(0, 0);
            // Renderizar
            formsPlot_ingresos.Refresh();
        }

        public void CargarGrafico_DisponibilidadOcupacion()
        {
            // Traer todas las agendas del mes seleccionado
            var agendas = _bllAgenda.BuscarAgendasdelMes(_fechaSeleccionada);
            // Traer todos los turnos del mes seleccionado
            var turnos = _bllTurno.BuscarTurnodelMes(_fechaSeleccionada);
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

            // Configurar etiquetas de las porciones
            pie.Slices[0].Label = $"Disponibles\n{disponibles} ({CalcularPorcentaje(disponibles, totalAgendas):F1}%)";
            pie.Slices[0].FillColor = ScottPlot.Colors.LightGreen;
            pie.Slices[0].LabelStyle.FontSize = 12;
            pie.Slices[0].LabelStyle.Bold = true;
            pie.Slices[1].Label = $"Ocupados\n{turnosOcupados} ({CalcularPorcentaje(turnosOcupados, totalAgendas):F1}%)";
            pie.Slices[1].FillColor = ScottPlot.Colors.Orange;
            pie.Slices[1].LabelStyle.FontSize = 12;
            pie.Slices[1].LabelStyle.Bold = true;

            // Configurar el estilo del pie
            pie.ExplodeFraction = 0.05;
            pie.SliceLabelDistance = 1.3;
            // Configurar título
            formsPlot_disponibilidad.Plot.Title($"Disponibilidad vs Ocupación - {_fechaSeleccionada:MMMM yyyy}");
            // Ocultar ejes
            formsPlot_disponibilidad.Plot.Axes.Frameless();
            // Ajustar layout para centrar el gráfico
            formsPlot_disponibilidad.Plot.Layout.Frameless();
            // Ocultar cuadrícula
            formsPlot_disponibilidad.Plot.Grid.IsVisible = false;
            // Renderizar
            formsPlot_disponibilidad.Refresh();
        }

        // Método auxiliar para calcular porcentajes
        private double CalcularPorcentaje(int valor, int total)
        {
            if (total == 0) return 0;
            return (valor * 100.0) / total;
        }

        public void CargarGrafico_IngresosEspecialidad()
        {
            var turnos = _bllTurno.BuscarTurnodelMes(_fechaSeleccionada);

            // Control vacío
            if (turnos is null || turnos.Count == 0)
            {
                formsPlot_ingresos_especialidad.Plot.Clear();
                formsPlot_ingresos_especialidad.Plot.Title("Sin datos disponibles");
                formsPlot_ingresos_especialidad.Refresh();
                return;
            }
            // Agrupar turnos por especialidad y sumar MontoTotal
            var ingresosPorEspecialidad = turnos
                .Where(t => t.Medico?.Especialidad != null && t.Cobro != null && t.Cobro.MontoTotal > 0)
                .GroupBy(t => t.Medico.Especialidad.Nombre)
                .Select(g => new
                {
                    Especialidad = g.Key,
                    MontoTotal = g.Sum(t => (double)t.Cobro.MontoTotal)
                })
                .OrderByDescending(x => x.MontoTotal) // Ordenar por mayor ingreso
                .ToList();

            if (ingresosPorEspecialidad.Count == 0)
            {
                formsPlot_ingresos_especialidad.Plot.Clear();
                formsPlot_ingresos_especialidad.Plot.Title("Sin ingresos registrados");
                formsPlot_ingresos_especialidad.Refresh();
                return;
            }

            double[] valores = ingresosPorEspecialidad.Select(x => x.MontoTotal).ToArray();
            string[] etiquetas = ingresosPorEspecialidad.Select(x => x.Especialidad).ToArray();
            double totalIngresos = valores.Sum();

            // Limpiar gráfico
            formsPlot_ingresos_especialidad.Plot.Clear();
            // Crear gráfico de torta
            var pie = formsPlot_ingresos_especialidad.Plot.Add.Pie(valores);
            // Configurar colores y etiquetas de las porciones
            ScottPlot.Color[] colores = new[]
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

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                double monto = valores[i];
                double porcentaje = (monto / totalIngresos) * 100;

                pie.Slices[i].Label = $"{etiquetas[i]}\n${monto:N0}\n({porcentaje:F1}%)";
                pie.Slices[i].FillColor = colores[i % colores.Length];
                pie.Slices[i].LabelStyle.FontSize = 11;
                pie.Slices[i].LabelStyle.Bold = true;
                pie.Slices[i].LabelStyle.ForeColor = ScottPlot.Colors.Black;
            }

            // Configurar el estilo del pie
            pie.ExplodeFraction = 0.05;
            pie.SliceLabelDistance = 1.3;
            formsPlot_ingresos_especialidad.Plot.Title($"Ingresos por Especialidad - {_fechaSeleccionada:MMMM yyyy}\nTotal: ${totalIngresos:N0}");
            formsPlot_ingresos_especialidad.Plot.Axes.Frameless();
            formsPlot_ingresos_especialidad.Plot.Layout.Frameless();
            formsPlot_ingresos_especialidad.Plot.Grid.IsVisible = false;
            // Renderizar
            formsPlot_ingresos_especialidad.Refresh();
        }

        #region Acciones

        private void button_mes_actual_Click(object sender, EventArgs e)
        {
            _fechaSeleccionada = DateTime.Now;
            CargarTodo();
        }

        private void button_historico_Click(object sender, EventArgs e)
        {
            _fechaSeleccionada = DateTime.MinValue;
            CargarTodo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is DateTime fecha)
            {
                _fechaSeleccionada = fecha;
                CargarTodo();
            }
        }
        #endregion
    }
}
