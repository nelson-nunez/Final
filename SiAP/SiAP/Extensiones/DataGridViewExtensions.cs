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
        public class CeldaAgenda
        {
            public Agenda Agenda { get; set; }
            public Turno Turno { get; set; }

            public CeldaAgenda(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, Agenda agenda = null, Turno turno = null)
            {
                // Si no existe agenda, crear una placeholder con MedicoId = 0
                Agenda = agenda ?? new Agenda
                {
                    Id = 0,
                    MedicoId = 0,
                    Fecha = fecha,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin
                };

                // Si no existe turno, crear un placeholder vacío
                Turno = turno ?? new Turno
                {
                    Id = 0,
                    AgendaId = Agenda.Id,
                    Estado = EstadoTurno.Cancelado,
                };
            }

            public bool TieneAgenda => Agenda.MedicoId != 0;
            public bool TieneTurno => Turno.Id != 0;
        }

        #region Configuración de Grid

        private static void ConfigurarEstiloCalendario(DataGridView grid, bool multiSelect)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            var fuente = new Font("Calibri", 8);
            var fuenteBold = new Font("Calibri", 8, FontStyle.Bold);

            grid.DefaultCellStyle.Font = fuente;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = fuenteBold;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            grid.ReadOnly = grid.AllowUserToAddRows = grid.AllowUserToDeleteRows = grid.AllowUserToResizeRows = grid.AllowUserToResizeColumns = grid.AllowUserToOrderColumns = grid.RowHeadersVisible = grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.MultiSelect = multiSelect;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;

            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = grid.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private static DateTime ObtenerInicioSemana(DateTime fecha)
        {
            var diasDesdeLunes = ((int)fecha.DayOfWeek + 6) % 7;
            return fecha.Date.AddDays(-diasDesdeLunes);
        }

        private static void CrearColumnasSemana(DataGridView grid)
        {
            grid.Columns.Add("Horario", "");

            var diasSemana = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                                 DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };

            foreach (var dia in diasSemana)
            {
                var nombreDia = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dia);
                grid.Columns.Add(dia.ToString(), char.ToUpper(nombreDia[0]) + nombreDia.Substring(1));
            }

            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private static void CrearFilaFechas(DataGridView grid, DateTime inicioSemana)
        {
            var filaFechas = new DataGridViewRow();
            filaFechas.CreateCells(grid);
            filaFechas.Cells[0].Value = "Horario/Fecha";
            filaFechas.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            filaFechas.ReadOnly = true;

            for (int i = 0; i < 7; i++)
            {
                filaFechas.Cells[i + 1].Value = inicioSemana.AddDays(i).ToShortDateString();
                filaFechas.Cells[i + 1].Style.BackColor = Color.WhiteSmoke;
            }

            grid.Rows.Add(filaFechas);
        }

        private static void CrearFilasHorarios(DataGridView grid, DateTime inicioSemana, TimeSpan horaInicio, TimeSpan horaFin, IList<Agenda> agendas, IList<Turno> turnos)
        {
            for (var hora = ConfiguracionCalendario.HoraInicio; hora < ConfiguracionCalendario.HoraFin; hora = hora.Add(ConfiguracionCalendario.BloqueHorarioMinimo))
            {
                var fila = new DataGridViewRow();
                fila.CreateCells(grid);

                // Celda de horario
                var horaFinal = hora.Add(ConfiguracionCalendario.BloqueHorarioMinimo);
                fila.Cells[0].Value = $"{hora:hh\\:mm} - {horaFinal:hh\\:mm}";
                fila.Cells[0].ReadOnly = true;
                fila.Cells[0].Style.BackColor = Color.WhiteSmoke;

                // Celdas para cada día
                for (int i = 0; i < 7; i++)
                {
                    var fecha = inicioSemana.AddDays(i);
                    var agenda = agendas?.FirstOrDefault(a => a.Fecha.Date == fecha.Date && a.HoraInicio == hora);
                    var turno = turnos?.FirstOrDefault(t => t.AgendaId == agenda?.Id);
                    //Aca le meto toda la data --------------------------------------------------------------------------------------------------------------------------
                    var celdaData = new CeldaAgenda(fecha, hora, horaFinal, agenda, turno);
                    ConfigurarCelda(fila.Cells[i + 1], celdaData);
                }

                grid.Rows.Add(fila);
            }
        }

        private static void ConfigurarCelda(DataGridViewCell celda, CeldaAgenda data)
        {
            celda.Tag = data;
            celda.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (!data.TieneAgenda)
            {
                // Sin agenda disponible
                celda.Value = "✗";
                celda.ReadOnly = true;
                celda.Style.BackColor = Color.FromArgb(255, 235, 235);
                celda.Style.SelectionBackColor = Color.FromArgb(255, 180, 180);
                celda.Style.ForeColor = Color.FromArgb(180, 60, 60);
                celda.Style.SelectionForeColor = Color.FromArgb(120, 30, 30);
            }
            else if (data.TieneTurno)
            {
                // Turno asignado
                celda.Value = data.Turno.Estado;
                celda.Style.BackColor = Color.FromArgb(220, 240, 255);
                celda.Style.SelectionBackColor = Color.FromArgb(100, 180, 255);
                celda.Style.ForeColor = Color.FromArgb(20, 80, 120);
                celda.Style.SelectionForeColor = Color.White;
            }
            else
            {
                // Agenda disponible
                celda.Value = "✔";
                celda.Style.BackColor = Color.FromArgb(240, 240, 240);
                celda.Style.SelectionBackColor = Color.FromArgb(120, 200, 120);
                celda.Style.ForeColor = Color.FromArgb(80, 120, 80);
                celda.Style.SelectionForeColor = Color.White;
            }
        }

        #endregion

        #region Métodos Públicos

        public static void CargarAgenda(this DataGridView grid, IList<Agenda> agendas, IList<Turno> turnos, DateTime fechaSeleccionada)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            ConfigurarEstiloCalendario(grid, multiSelect: false);
            var inicioSemana = ObtenerInicioSemana(fechaSeleccionada);

            CrearColumnasSemana(grid);
            CrearFilaFechas(grid, inicioSemana);
            CrearFilasHorarios(grid, inicioSemana, TimeSpan.FromHours(8), TimeSpan.FromHours(20), agendas, turnos);
        }

        public static void CargarAgendaMedica(this DataGridView grid, IList<Agenda> agendas, IList<Turno> turnos, DateTime fechaSeleccionada)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            ConfigurarEstiloCalendario(grid, multiSelect: true);
            var inicioSemana = ObtenerInicioSemana(fechaSeleccionada);

            CrearColumnasSemana(grid);
            CrearFilaFechas(grid, inicioSemana);
            CrearFilasHorarios(grid, inicioSemana, TimeSpan.FromHours(8),
                TimeSpan.FromHours(20), agendas, turnos);
        }

        public static CeldaAgenda ObtenerCeldaSeleccionada(this DataGridView grid)
        {
            return grid.CurrentCell?.Tag as CeldaAgenda;
        }

        public static Agenda ObtenerAgendaSeleccionada(this DataGridView grid)
        {
            return ObtenerCeldaSeleccionada(grid)?.Agenda;
        }

        public static Turno ObtenerTurnoSeleccionado(this DataGridView grid)
        {
            return ObtenerCeldaSeleccionada(grid)?.Turno;
        }

        public static List<CeldaAgenda> ObtenerCeldasSeleccionadas(this DataGridView grid)
        {
            var lista = grid.SelectedCells.Cast<DataGridViewCell>().Select(c => c.Tag as CeldaAgenda).Where(c => c != null).ToList();
            return lista;
        }

        #endregion
    }
}
