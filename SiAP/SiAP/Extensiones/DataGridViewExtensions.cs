using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BE;

namespace SiAP.UI.Extensiones
{
    public static class DataGridViewExtensions
    {
        #region Métodos Generales

        public static T VerificarYRetornarSeleccion<T>(this DataGridView grid) where T : class
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid), "El DataGridView no puede ser nulo.");
            if (grid.Rows.Count == 0)
                throw new Exception("El DataGridView está vacío.");
            if (grid.SelectedRows.Count <= 0)
                throw new Exception("Debe seleccionar un elemento para continuar.");
            if (grid.SelectedRows[0].DataBoundItem == null)
                throw new Exception("No se ha vinculado ningún elemento a la fila seleccionada.");

            return grid.SelectedRows[0].DataBoundItem as T;
        }

        public static void ConfigurarTodosLosGrids(this Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is DataGridView dgv)
                {
                    dgv.ConfigurarGrids();
                }
                else if (control.HasChildren)
                {
                    ConfigurarTodosLosGrids(control.Controls);
                }
            }
        }

        public static void ConfigurarGrids(this DataGridView dataGridView)
        {
            dataGridView.MultiSelect = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var fuente = new Font("Calibri", 8);
            var fuenteBold = new Font("Calibri", 8, FontStyle.Bold);

            dataGridView.DefaultCellStyle.Font = fuente;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = fuenteBold;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.RowsDefaultCellStyle.Font = fuente;
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
        }

        public static void CargarGrid<T>(this DataGridView dataGridView, List<string> campos, List<T> listaDeItems)
        {
            dataGridView.Columns.Clear();
            foreach (var field in campos)
            {
                var columna = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = field,
                    HeaderText = field,
                    Name = field
                };
                dataGridView.Columns.Add(columna);
            }
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = null;
            dataGridView.DataSource = listaDeItems;
            dataGridView.AutoResizeColumns();
        }

        public static void CargarGrids<T>(this DataGridView dataGridView, List<KeyValuePair<string, string>> campos, List<T> listaDeItems)
        {
            dataGridView.Columns.Clear();
            foreach (var field in campos)
            {
                var columna = new DataGridViewTextBoxColumn
                {
                    HeaderText = field.Value,
                    DataPropertyName = field.Key,
                    Name = field.Key
                };
                dataGridView.Columns.Add(columna);
            }
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = null;
            dataGridView.DataSource = listaDeItems;
            dataGridView.AutoResizeColumns();
        }

        #endregion
    }

    public static class AgendaExtensions
    {
        #region Configuración de Agenda/Turnos

        private static void ConfigurarEstiloCalendario(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            var fuente = new Font("Calibri", 8);
            var fuenteBold = new Font("Calibri", 8, FontStyle.Bold);

            grid.DefaultCellStyle.Font = fuente;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = fuenteBold;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.RowsDefaultCellStyle.Font = fuente;
            grid.RowsDefaultCellStyle.ForeColor = Color.Black;

            grid.ReadOnly = grid.AllowUserToAddRows = grid.AllowUserToDeleteRows =
            grid.AllowUserToResizeRows = grid.AllowUserToResizeColumns = grid.AllowUserToOrderColumns =
            grid.RowHeadersVisible = grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = grid.ColumnHeadersDefaultCellStyle.BackColor;
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = grid.RowHeadersDefaultCellStyle.BackColor;
        }

        private static DateTime ObtenerInicioSemana(DateTime fecha)
        {
            var diasDesdeLunes = (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;
            if (diasDesdeLunes < 0)
                diasDesdeLunes += 7;
            return fecha.Date.AddDays(-diasDesdeLunes);
        }

        private static void CrearColumnasSemana(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Columns.Add("", "");

            var diasSemana = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                                 DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };

            foreach (var dia in diasSemana)
            {
                var nombreDia = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dia);
                grid.Columns.Add(dia.ToString(), char.ToUpper(nombreDia[0]) + nombreDia.Substring(1));
            }
        }

        private static void CrearFilaFechas(DataGridView grid, DateTime inicioSemana)
        {
            var filaFechas = new DataGridViewRow();
            filaFechas.CreateCells(grid);
            filaFechas.ReadOnly = true;
            filaFechas.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            filaFechas.Cells[0].Value = "Horario/Fecha";

            for (int i = 0; i < 7; i++)
            {
                var fecha = inicioSemana.AddDays(i);
                filaFechas.Cells[i + 1].Value = fecha.ToShortDateString();
                filaFechas.Cells[i + 1].ReadOnly = true;
                filaFechas.Cells[i + 1].Style.BackColor = Color.WhiteSmoke;
            }

            grid.Rows.Add(filaFechas);
        }

        private static void CrearFilasHorarios(DataGridView grid, TimeSpan horaInicio, TimeSpan horaFin, IList<Agenda> agendas, IList<Turno> turnos, TipoVistaCalendario tipoVista)
        {
            for (var hora = horaInicio; hora < horaFin; hora = hora.Add(TimeSpan.FromHours(1)))
            {
                var fila = new DataGridViewRow();
                fila.CreateCells(grid);

                // Celda de horario
                fila.Cells[0].Value = $"{hora:hh\\:mm} - {hora.Add(TimeSpan.FromHours(1)):hh\\:mm}";
                fila.Cells[0].ReadOnly = true;
                fila.Cells[0].Style.BackColor = Color.WhiteSmoke;

                // Celdas para cada día de la semana
                for (int i = 0; i < 7; i++)
                {
                    var diaSemanaDeLaColumna = (DayOfWeek)((i + 1) % 7);
                    var agenda = agendas?.FirstOrDefault(a => a.Fecha.DayOfWeek == diaSemanaDeLaColumna && a.HoraInicio == hora);
                    var turno = turnos?.FirstOrDefault(t => t.AgendaId == agenda?.Id);

                    ConfigurarCeldaCalendario(fila.Cells[i + 1], agenda, turno, tipoVista);
                }

                grid.Rows.Add(fila);
            }
        }

        private static void ConfigurarCeldaCalendario(DataGridViewCell celda, Agenda agenda, Turno turno, TipoVistaCalendario tipoVista)
        {
            celda.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Variables auxiliares para estilos
            Color backColor, selBackColor, foreColor, selForeColor;
            object valor;
            bool readOnly = false;

            if (agenda == null)
            {
                // Sin agenda
                valor = "✗";
                readOnly = true;
                backColor = Color.FromArgb(255, 235, 235);
                selBackColor = Color.FromArgb(255, 180, 180);
                foreColor = Color.FromArgb(180, 60, 60);
                selForeColor = Color.FromArgb(120, 30, 30);
            }
            else if (turno != null)
            {
                // Turno asignado
                valor = turno.Estado;
                celda.Tag = agenda;
                backColor = Color.FromArgb(220, 240, 255);
                selBackColor = Color.FromArgb(100, 180, 255);
                foreColor = Color.FromArgb(20, 80, 120);
                selForeColor = Color.White;
            }
            else
            {
                // Agenda disponible
                valor = "✔";
                celda.Tag = agenda;
                backColor = Color.FromArgb(240, 240, 240);
                selBackColor = Color.FromArgb(120, 200, 120);
                foreColor = Color.FromArgb(80, 120, 80);
                selForeColor = Color.White;
            }

            // Asignación común
            celda.Value = valor;
            celda.ReadOnly = readOnly;
            celda.Style.BackColor = backColor;
            celda.Style.SelectionBackColor = selBackColor;
            celda.Style.ForeColor = foreColor;
            celda.Style.SelectionForeColor = selForeColor;
        }

        private static void DeshabilitarOrdenamiento(DataGridView grid)
        {
            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        #endregion

        #region Turnos

        public static void CargarAgenda(this DataGridView grid, IList<Agenda> agendas, IList<Turno> turnos, DateTime fechaSeleccionada)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            ConfigurarEstiloCalendario(grid);
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;

            var inicioSemana = ObtenerInicioSemana(fechaSeleccionada);
            var horaInicio = TimeSpan.FromHours(8);
            var horaFin = TimeSpan.FromHours(20);

            CrearColumnasSemana(grid);
            CrearFilaFechas(grid, inicioSemana);
            CrearFilasHorarios(grid, horaInicio, horaFin, agendas, turnos, TipoVistaCalendario.Turnos);
            DeshabilitarOrdenamiento(grid);
        }

        public static Turno ObtenerTurnoSeleccionado(this DataGridView grid)
        {
            return grid.CurrentCell.Tag as Turno;
        }

        #endregion

        #region Agenda Médica

        public static void CargarAgendaMedica(this DataGridView grid, IList<Agenda> agendas, IList<Turno> turnos, DateTime fechaSeleccionada)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            ConfigurarEstiloCalendario(grid);
            grid.MultiSelect = true;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;

            var inicioSemana = ObtenerInicioSemana(fechaSeleccionada);
            var horaInicio = TimeSpan.FromHours(8);
            var horaFin = TimeSpan.FromHours(20);

            CrearColumnasSemana(grid);
            CrearFilaFechas(grid, inicioSemana);
            CrearFilasHorarios(grid, horaInicio, horaFin, agendas, turnos, TipoVistaCalendario.AgendaMedica);
            DeshabilitarOrdenamiento(grid);
        }

        public static Agenda ObtenerAgendaSeleccionada(this DataGridView grid)
        {
            return grid.CurrentCell.Tag as Agenda;
        }
        #endregion

        #region Enums Internos

        private enum TipoVistaCalendario
        {
            Turnos,
            AgendaMedica
        }

        #endregion
    }

}
