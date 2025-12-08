using System.ComponentModel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;
using System.Diagnostics;
using Policonsultorio.BE;
using SiAP.BE;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;
using SiAP.UI.Impresiones;

namespace SiAP.UI
{
    public partial class Form_RenovarReceta : Form
    {
        #region Vars

        private readonly BLL_HistoriaClinica _bllHistoria;
        private readonly BLL_Receta _bllReceta;

        private Paciente pacienteSeleccionado;
        private Receta recetaSeleccionada;
        private BindingList<Medicamento> medicamentosSeleccionados = new BindingList<Medicamento>();

        //Control
        private UC_Mostrar_Paciente _userControl;

        #endregion

        #region Constructor
        public Form_RenovarReceta()
        {
            InitializeComponent();
            _bllReceta = BLL_Receta.ObtenerInstancia();
            _bllHistoria = BLL_HistoriaClinica.ObtenerInstancia();

            _userControl = this.FindUserControl<UC_Mostrar_Paciente>("uC_Mostrar_Paciente1");
            if (_userControl != null)
                _userControl.ShouldUpdate += OnPacienteSeleccionado;

            //Grid
            ConfigurarDataGridMedicamentos();
        }

        #endregion

        #region Seleccion Paciente

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            try
            {
                pacienteSeleccionado = _userControl.pacienteSeleccionado;
                recetaSeleccionada = null;
                CargarArbolRecetas();
                CargarReceta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Recetas
        private void ConfigurarDataGridMedicamentos()
        {
            // Inicializamos la lista enlazable si aún no existe
            if (medicamentosSeleccionados == null)
                medicamentosSeleccionados = new BindingList<Medicamento>();

            dataGridView_medicamentos.AllowUserToAddRows = true;
            dataGridView_medicamentos.AllowUserToDeleteRows = true;
            dataGridView_medicamentos.AutoGenerateColumns = false;
            dataGridView_medicamentos.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView_medicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_medicamentos.MultiSelect = false;
            dataGridView_medicamentos.Columns.Clear();

            // Definir columnas manualmente
            dataGridView_medicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreComercial",
                HeaderText = "Nombre Comercial",
                DataPropertyName = "NombreComercial",
                Width = 200
            });

            dataGridView_medicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreMonodroga",
                HeaderText = "Nombre Monodroga",
                DataPropertyName = "NombreMonodroga",
                Width = 200
            });

            dataGridView_medicamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 100
            });

            // Establecemos la fuente de datos enlazable
            dataGridView_medicamentos.DataSource = medicamentosSeleccionados;
        }

        private void CargarArbolRecetas()
        {
            try
            {
                if (pacienteSeleccionado == null)
                    return;

                var historiaClinica = _bllHistoria.BuscarPorPaciente(pacienteSeleccionado.Id);

                // Validación temprana
                if (historiaClinica?.Consultas == null || !historiaClinica.Consultas.Any())
                {
                    treeView_recetas.Nodes.Clear();
                    treeView_recetas.Nodes.Add("No hay consultas registradas");
                    return;
                }

                var consultasConRecetasCronicas = historiaClinica.Consultas
                    .Where(c => c.Recetas != null && c.Recetas.Any(r => r.EsCronica))
                    .Select(c => new Consulta
                    {
                        Id = c.Id,
                        Fecha = c.Fecha,
                        Motivo = c.Motivo,
                        Diagnostico = c.Diagnostico,
                        Tratamiento = c.Tratamiento,
                        Observaciones = c.Observaciones,
                        Medico = c.Medico,
                        HistoriaClinica = c.HistoriaClinica,
                        Recetas = c.Recetas.Where(r => r.EsCronica).ToList(),
                        Certificados = c.Certificados
                    })
                    .ToList();

                if (consultasConRecetasCronicas == null || !consultasConRecetasCronicas.Any())
                {
                    treeView_recetas.Nodes.Clear();
                    treeView_recetas.Nodes.Add("No hay recetas crónicas registradas");
                    return;
                }

                treeView_recetas.ArmarArbolRecetas(consultasConRecetasCronicas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarReceta()
        {
            try
            {
                medicamentosSeleccionados.Clear();
                richTextBox_observ_receta.Text = recetaSeleccionada?.Observaciones ?? string.Empty;
                textBox_fecha_receta.Text = recetaSeleccionada?.Fecha.ToShortDateString() ?? string.Empty;
                checkBox_cronico_receta.Checked = recetaSeleccionada?.EsCronica ?? false;

                if (recetaSeleccionada?.Medicamentos != null)
                {
                    foreach (var med in recetaSeleccionada.Medicamentos)
                    {
                        medicamentosSeleccionados.Add(new Medicamento
                        {
                            NombreComercial = med.NombreComercial,
                            NombreMonodroga = med.NombreMonodroga,
                            Cantidad = med.Cantidad
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView_recetas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.ForeColor != Color.DarkGreen)
                {
                    treeView_recetas.SelectedNode = null;
                    return;
                }
                recetaSeleccionada = e.Node?.Tag as Receta;
                CargarReceta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                recetaSeleccionada = null;
                CargarReceta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificaciones
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para guardar la receta.");
                if (medicamentosSeleccionados == null || medicamentosSeleccionados.Count == 0)
                    throw new InvalidOperationException("Debe agregar al menos un medicamento a la receta.");
                if (recetaSeleccionada.Fecha > DateTime.Now.AddDays(-30))
                    throw new InvalidOperationException("No se puede renovar, la receta se emitió hace menos de 30 días. Puede reimprimirla.");
                                
                //Confirmar
                InputsExtensions.PedirConfirmacion("¿Desea renovar la receta?");

                var nuevareceta = recetaSeleccionada;
                nuevareceta.Id = 0;
                nuevareceta.Fecha = DateTime.Now.Date;

                _bllReceta.Agregar(recetaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Recargo todo
                CargarArbolRecetas();
                recetaSeleccionada = null;
                CargarReceta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para imprimir la receta.");
                if (recetaSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar una receta guardada para imprimirla.");
                if (medicamentosSeleccionados == null || medicamentosSeleccionados.Count == 0)
                    throw new InvalidOperationException("Debe agregar al menos un medicamento a la receta.");

                var generator = new RecetaPDFGenerator(recetaSeleccionada, pacienteSeleccionado, new Medico());
                generator.GenerarYAbrirPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}