using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
