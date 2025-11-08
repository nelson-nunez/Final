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
    public partial class Form_HistoriaClinica : Form
    {
        private readonly BLL_Paciente _bllPacientes;
        private readonly BLL_HistoriaClinica _bllHistoriaClinica;
        private readonly BLL_Consulta _bllConsulta;
        private readonly BLL_Medico _bllMedico;
        private readonly BLL_Receta _bllReceta;
        private readonly BLL_Medicamento _bllMedicamento;

        private Form_CRUD_Pacientes form_paciente;
        private Paciente pacienteSeleccionado;
        private HistoriaClinica historiaClinicaSeleccionada;
        private Consulta consultaSeleccionada;
        private Receta recetaSeleccionada;
        private Medico medicoLoggeado;
        private BindingList<Medicamento> medicamentosSeleccionados;

        public Form_HistoriaClinica()
        {
            InitializeComponent();

            _bllPacientes = BLL_Paciente.ObtenerInstancia();
            _bllHistoriaClinica = BLL_HistoriaClinica.ObtenerInstancia();
            _bllConsulta = BLL_Consulta.ObtenerInstancia();
            _bllMedico = BLL_Medico.ObtenerInstancia();
            _bllReceta = BLL_Receta.ObtenerInstancia();
            _bllMedicamento = BLL_Medicamento.ObtenerInstancia();

            var useractual = GestionUsuario.UsuarioLogueado;
            medicoLoggeado = _bllMedico.LeerPorPersonId((long)useractual.PersonaId);

            medicamentosSeleccionados = new BindingList<Medicamento>();
            ConfigurarDataGridMedicamentos();
        }

        #region Configuración DataGrid medicamentosSeleccionados

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

        #endregion

        #region Selección de Paciente

        private void button_seleccionar_paciente_Click(object sender, EventArgs e)
        {
            try
            {
                //_userControl.Visible = true;
                //_userControl.BringToFront();
                //_userControl.Location = new Point(
                //    (this.ClientSize.Width - _userControl.Width) / 2,
                //    (this.ClientSize.Height - _userControl.Height) / 2
                //);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            try
            {
                //_userControl.Visible = false;
                //pacienteSeleccionado = _userControl.itemSeleccionado;
                CargarDatosPaciente();
                CargarHistoria();
                CargarConsultas();
                CargarArbolRecetas();
                CargarReceta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPaciente()
        {
            if (pacienteSeleccionado == null) return;

            //label_nombre_completo.Text = pacienteSeleccionado.ToString();
            //label_ooss.Text = pacienteSeleccionado.ObraSocial;
            //label_PLAN.Text = pacienteSeleccionado.Plan;
            //label_nro_socio.Text = pacienteSeleccionado.NumeroSocio.ToString();
        }

        #endregion

        #region Historia Clínica

        private void CargarHistoria()
        {
            try
            {
                historiaClinicaSeleccionada = _bllHistoriaClinica.BuscarPorPaciente(pacienteSeleccionado.Id);
                if (historiaClinicaSeleccionada != null)
                    richText_historia_Clinica.Text = historiaClinicaSeleccionada.Descripcion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");
                if (historiaClinicaSeleccionada == null)
                    throw new InvalidOperationException("El paciente no cuenta con Historia Clínica para editar.");

                InputsExtensions.PedirConfirmacion("¿Desea guardar la modificación en la Historia del paciente?");

                historiaClinicaSeleccionada.Descripcion = richText_historia_Clinica.Text;
                _bllHistoriaClinica.Modificar(historiaClinicaSeleccionada);

                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");
                if (historiaClinicaSeleccionada != null)
                    throw new InvalidOperationException("El paciente ya cuenta con Historia Clínica. Use EDITAR.");

                InputsExtensions.PedirConfirmacion("¿Desea guardar lo registrado en la Historia del paciente?");

                historiaClinicaSeleccionada = new HistoriaClinica
                {
                    FechaCreacion = DateTime.Now,
                    Paciente = pacienteSeleccionado,
                    Descripcion = richText_historia_Clinica.Text
                };

                _bllHistoriaClinica.Agregar(historiaClinicaSeleccionada);
                MessageBox.Show("Se guardó la historia clínica con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Consultas

        private void CargarConsultas()
        {
            try
            {
                if (historiaClinicaSeleccionada == null) return;

                var lista = _bllConsulta.BuscarPorHistoriaClinica(historiaClinicaSeleccionada.Id);
                treeView_historia_cli.ArmarArbolConsultas(lista.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView_historia_cli_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                consultaSeleccionada = e.Node?.Tag as Consulta;
                CargarDatosConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosConsulta()
        {
            richTextBox_motivo.Text = consultaSeleccionada?.Motivo ?? "";
            richTextBox_observaciones.Text = consultaSeleccionada?.Observaciones ?? "";
            richTextBox_tratamiento.Text = consultaSeleccionada?.Tratamiento ?? "";
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                consultaSeleccionada = null;
                CargarDatosConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (consultaSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar una consulta para continuar.");

                InputsExtensions.PedirConfirmacion("¿Desea guardar la modificación en la consulta del paciente?");

                consultaSeleccionada.Motivo = richTextBox_motivo.Text;
                consultaSeleccionada.Observaciones = richTextBox_observaciones.Text;
                consultaSeleccionada.Tratamiento = richTextBox_tratamiento.Text;

                _bllConsulta.Modificar(consultaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (consultaSeleccionada != null)
                    throw new InvalidOperationException("Debe limpiar los datos antes de guardar un nuevo registro.");

                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos de la consulta del paciente?");

                consultaSeleccionada = new Consulta
                {
                    Motivo = richTextBox_motivo.Text,
                    Observaciones = richTextBox_observaciones.Text,
                    Tratamiento = richTextBox_tratamiento.Text,
                    HistoriaClinica = historiaClinicaSeleccionada ?? new HistoriaClinica()
                };

                _bllConsulta.Agregar(consultaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarConsultas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Recetas

        private void button_editar_pac_Click(object sender, EventArgs e)
        {
            try
            {
                if (form_paciente == null || form_paciente.IsDisposed)
                {
                    form_paciente = new Form_CRUD_Pacientes
                    {
                        TopLevel = false,
                        MaximizeBox = false,
                        MinimizeBox = false,
                        ControlBox = true,
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        Width = this.ClientSize.Width,
                        Height = this.ClientSize.Height,
                        Location = new Point(0, 0)
                    };
                    this.Controls.Add(form_paciente);
                }
                form_paciente.Show();
                form_paciente.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarArbolRecetas()
        {
            try
            {
                if (historiaClinicaSeleccionada == null) return;

                var lista = _bllConsulta.BuscarPorHistoriaClinica(historiaClinicaSeleccionada.Id);
                treeView_recetas.ArmarArbolRecetas(lista.ToList());
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

                richTextBox_observ.Text = recetaSeleccionada?.Observaciones.ToString();
                textBox_fecha.Text = DateTime.Now.ToShortDateString() ?? "";

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

        private void button_rec_editar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificaciones
                if (recetaSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar una receta para editarla.");
                if (recetaSeleccionada?.Profesional != medicoLoggeado.NombreCompleto)
                    throw new InvalidOperationException("No se puede editar una receta emitida por otro médico.");
                if (medicamentosSeleccionados == null || medicamentosSeleccionados.Count == 0)
                    throw new InvalidOperationException("Debe agregar al menos un medicamento a la receta.");
                //Confirmar
                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos de la receta?");

                recetaSeleccionada.Fecha = DateTime.Now.Date;
                recetaSeleccionada.Observaciones = richTextBox_observ.Text;
                recetaSeleccionada.EsCronica = checkBox_cronico.Checked;
                recetaSeleccionada.Medicamentos = medicamentosSeleccionados.ToList();

                _bllReceta.Modificar(recetaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Recaargo todo
                CargarArbolRecetas();
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
                if (recetaSeleccionada != null)
                    throw new InvalidOperationException("Debe limpiar los datos antes de guardar un nuevo registro.");
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para guardar la receta.");
                if (consultaSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar una consulta para guardar la receta.");
                if (medicamentosSeleccionados == null || medicamentosSeleccionados.Count == 0)
                    throw new InvalidOperationException("Debe agregar al menos un medicamento a la receta.");
                //Confirmar
                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos de la receta?");

                recetaSeleccionada = new Receta
                {
                    Fecha = DateTime.Now.Date,
                    Observaciones = richTextBox_observ.Text,
                    Profesional = medicoLoggeado.NombreCompleto,
                    EsCronica = checkBox_cronico.Checked,
                    Consulta = consultaSeleccionada,
                    Medicamentos = medicamentosSeleccionados.ToList(),

                    Obra_social = pacienteSeleccionado.ObraSocial,
                    Nro_Socio = pacienteSeleccionado.NumeroSocio,
                    Plan = pacienteSeleccionado.Plan,
                };

                _bllReceta.Agregar(recetaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Recaargo todo
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

                var generator = new RecetaPDFGenerator(recetaSeleccionada, pacienteSeleccionado, medicoLoggeado);
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