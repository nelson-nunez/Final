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
                    // Método de extensión o método estático
                    dgv.ConfigurarGrids(); 
                }
                else if (control.HasChildren)
                {
                    // Recursividad para layouts anidados
                    ConfigurarTodosLosGrids(control.Controls); 
                }
            }
        }
        
        public static void ConfigurarGrids(this DataGridView dataGridView)
        {
            dataGridView.MultiSelect = false;
            // Deshabilitar edición en el DataGridView
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically; // Evita edición directa
            dataGridView.ReadOnly = true; // Hacer todo el DataGridView de solo lectura
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Configurar estilos
            dataGridView.DefaultCellStyle.Font = new Font("Calibri", 8);
            dataGridView.DefaultCellStyle.ForeColor = Color.Black; // Establecer el color del texto
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 8, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Establecer el color del texto en las cabeceras
            dataGridView.RowsDefaultCellStyle.Font = new Font("Calibri", 8);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black; // Establecer el color del texto en las filas
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

        #region TURNOS

        public static void CargarEstiloTurnero(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            var fuente = new Font("Calibri", 8);
            var fuenteBold = new Font("Calibri", 8, FontStyle.Bold);
            var colorBlancoHumo = Color.WhiteSmoke;

            grid.DefaultCellStyle.Font = fuente;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = fuenteBold;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.RowsDefaultCellStyle.Font = fuente;
            grid.RowsDefaultCellStyle.ForeColor = Color.Black;

            grid.ReadOnly = grid.MultiSelect = grid.AllowUserToAddRows = grid.AllowUserToDeleteRows =
            grid.AllowUserToResizeRows = grid.AllowUserToResizeColumns = grid.AllowUserToOrderColumns =
            grid.RowHeadersVisible = grid.EnableHeadersVisualStyles = false;

            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = grid.ColumnHeadersDefaultCellStyle.BackColor;
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = grid.RowHeadersDefaultCellStyle.BackColor;
        }

        public static void CargarAgenda(this DataGridView grid, IList<Agenda> agendas, IList<Turno> turnos, DateTime fechaSeleccionada)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));
            CargarEstiloTurnero(grid);

            // Configurar rango de semana y horarios
            var diasDesdeLunes = (int)fechaSeleccionada.DayOfWeek - (int)DayOfWeek.Monday;
            if (diasDesdeLunes < 0) 
                diasDesdeLunes += 7;
            var inicioSemana = fechaSeleccionada.Date.AddDays(-diasDesdeLunes);
            var horaInicio = TimeSpan.FromHours(8);
            var horaFin = TimeSpan.FromHours(20);

            // Crear estructura del grid
            CrearColumnas(grid);
            CrearFilaFechas(grid, inicioSemana);
            CrearFilasHorarios(grid, horaInicio, horaFin, agendas, turnos);
            //Impedir sort
            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private static void CrearColumnas(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Columns.Add("", "");
            var diasSemana = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };

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

        private static void CrearFilasHorarios(DataGridView grid, TimeSpan horaInicio, TimeSpan horaFin, IList<Agenda> agendas, IList<Turno> turnos)
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
                    var diaSemanaDeLaColumna = (DayOfWeek)((i + 1) % 7); // Ajustar índice para DayOfWeek
                    var agenda = agendas?.FirstOrDefault(a => a.Fecha.DayOfWeek == diaSemanaDeLaColumna && a.HoraInicio == hora);
                    var turno = turnos?.FirstOrDefault(t => t.AgendaId == agenda?.Id);

                    ConfigurarCeldaAgenda(fila.Cells[i + 1], agenda, turno);
                }

                grid.Rows.Add(fila);
            }
        }

        private static void ConfigurarCeldaAgenda(DataGridViewCell celda, Agenda agenda, Turno turno)
        {
            celda.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (agenda != null)
            {
                if (turno != null)
                {
                    // Turno asignado
                    celda.Value = "Asignado";
                    celda.Tag = agenda;
                    celda.Style.BackColor = Color.LightBlue;
                    celda.Style.SelectionBackColor = Color.LightBlue;
                }
                else
                {
                    // Agenda disponible
                    celda.Value = "✔";
                    celda.Tag = agenda;
                    celda.Style.BackColor = Color.LightGray;
                    celda.Style.SelectionBackColor = Color.LightGray;
                }
            }
            else
            {
                // Sin agenda
                celda.Value = "✗";
                celda.ReadOnly = true;
                celda.Style.BackColor = Color.LightCoral;
                celda.Style.SelectionBackColor = Color.LightCoral;
                celda.Style.ForeColor = Color.DarkRed;
            }
        }

        public static Agenda ObtenerAgendaSeleccionada(this DataGridView grid)
        {
            if (grid?.CurrentCell == null)
                throw new InvalidOperationException("Debe seleccionar una celda para continuar.");

            return grid.CurrentCell.Tag as Agenda
                    ?? throw new InvalidOperationException("La celda seleccionada no contiene una agenda válida.");
        }
        
        #endregion
    }
}
