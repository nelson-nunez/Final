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
        #region Vars

        private readonly BLL_Paciente _bllPacientes;
        private readonly BLL_HistoriaClinica _bllHistoriaClinica;
        private readonly BLL_Consulta _bllConsulta;
        private readonly BLL_Medico _bllMedico;
        private readonly BLL_Receta _bllReceta;
        private readonly BLL_Medicamento _bllMedicamento;
        private readonly BLL_Certificado _bllCertificado;

        private Paciente pacienteSeleccionado;
        private HistoriaClinica historiaClinicaSeleccionada;
        private Consulta consultaSeleccionada;
        private Receta recetaSeleccionada;
        private Certificado certificadoSeleccionada;
        private Medico medicoLoggeado;
        private BindingList<Medicamento> medicamentosSeleccionados = new BindingList<Medicamento>();

        //Control
        private UC_Mostrar_Paciente _userControl;

        #endregion

        public Form_HistoriaClinica()
        {
            InitializeComponent();

            _bllPacientes = BLL_Paciente.ObtenerInstancia();
            _bllHistoriaClinica = BLL_HistoriaClinica.ObtenerInstancia();
            _bllConsulta = BLL_Consulta.ObtenerInstancia();
            _bllMedico = BLL_Medico.ObtenerInstancia();
            _bllReceta = BLL_Receta.ObtenerInstancia();
            _bllMedicamento = BLL_Medicamento.ObtenerInstancia();
            _bllCertificado = BLL_Certificado.ObtenerInstancia();

            //Componentes
            var useractual = GestionUsuario.UsuarioLogueado;
            medicoLoggeado = _bllMedico.LeerPorPersonId((long)useractual.PersonaId);
            _userControl = this.FindUserControl<UC_Mostrar_Paciente>("uC_Mostrar_Paciente1");
            if (_userControl != null)
                _userControl.ShouldUpdate += OnPacienteSeleccionado;

            //Grid
            ConfigurarDataGridMedicamentos();
            CargarTiposenCombo();
        }

        #region Sseleccion Paciente

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            try
            {
                pacienteSeleccionado = _userControl.pacienteSeleccionado;
                CargarHistoria();
                CargarConsultas();
                CargarArbolRecetas();
                CargarReceta();

                CargarArbolCertificados();
                CargarCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            richTextBox_motivo_consulta.Text = consultaSeleccionada?.Motivo ?? "";
            richTextBox_observaciones_consulta.Text = consultaSeleccionada?.Observaciones ?? "";
            richTextBox_tratamiento_consulta.Text = consultaSeleccionada?.Tratamiento ?? "";
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

                consultaSeleccionada.Motivo = richTextBox_motivo_consulta.Text;
                consultaSeleccionada.Observaciones = richTextBox_observaciones_consulta.Text;
                consultaSeleccionada.Tratamiento = richTextBox_tratamiento_consulta.Text;

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
                    Motivo = richTextBox_motivo_consulta.Text,
                    Observaciones = richTextBox_observaciones_consulta.Text,
                    Tratamiento = richTextBox_tratamiento_consulta.Text,
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
                recetaSeleccionada.Observaciones = richTextBox_observ_receta.Text;
                recetaSeleccionada.EsCronica = checkBox_cronico_receta.Checked;
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
                if (consultaSeleccionada == null || consultaSeleccionada?.Medico.Id != medicoLoggeado.Id)
                    throw new InvalidOperationException("Debe seleccionar una consulta propia para guardar la receta.");
                if (medicamentosSeleccionados == null || medicamentosSeleccionados.Count == 0)
                    throw new InvalidOperationException("Debe agregar al menos un medicamento a la receta.");
                //Confirmar
                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos de la receta?");

                recetaSeleccionada = new Receta
                {
                    Fecha = DateTime.Now.Date,
                    Observaciones = richTextBox_observ_receta.Text,
                    Profesional = medicoLoggeado.NombreCompleto,
                    EsCronica = checkBox_cronico_receta.Checked,
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

        #region Certificados
        
        private void treeView_certificados_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.ForeColor != Color.DarkGreen)
                {
                    treeView_certificados.SelectedNode = null;
                    return;
                }
                certificadoSeleccionada = e.Node?.Tag as Certificado;
                CargarCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposenCombo()
        {
            comboBox_tipo_certificado.Items.Clear();
            comboBox_tipo_certificado.DataSource = TipoCertificados.ObtenerTodos();
            comboBox_tipo_certificado.SelectedItem = TipoCertificados.ObtenerTodos().FirstOrDefault();
        }

        private void CargarArbolCertificados()
        {
            try
            {
                if (historiaClinicaSeleccionada == null) return;

                var lista = _bllConsulta.BuscarPorHistoriaClinica(historiaClinicaSeleccionada.Id);
                treeView_certificados.ArmarArbolCertificados(lista.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCertificado()
        {
            try
            {
                if (certificadoSeleccionada != null)
                {
                    textBox_fecha_certif.Text = certificadoSeleccionada?.Fecha.ToShortDateString();
                    richTextBox_observaciones_certif.Text = certificadoSeleccionada?.Observaciones;
                    richTextBox_descrip_certificado.Text = certificadoSeleccionada?.Descripcion;
                    var tiposelecc = TipoCertificados.ObtenerTodos().ToList().FirstOrDefault(x => x == certificadoSeleccionada?.TipoCertificado);
                    comboBox_tipo_certificado.SelectedItem = tiposelecc;
                    dateTimePicker_desde.Value = certificadoSeleccionada.FechaVigenciaDesde;
                    dateTimePicker_hasta.Value = certificadoSeleccionada.FechaVigenciaHasta;
                }
                else
                {
                    comboBox_tipo_certificado.SelectedItem = TipoCertificados.ObtenerTodos().FirstOrDefault();
                    textBox_fecha_certif.Text = string.Empty;
                    richTextBox_observaciones_certif.Text = string.Empty;
                    richTextBox_descrip_certificado.Text = string.Empty;
                    dateTimePicker_desde.Value = DateTime.Now;
                    dateTimePicker_hasta.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView_Certificado_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.ForeColor != Color.DarkGreen)
                {
                    treeView_certificados.SelectedNode = null;
                    return;
                }
                certificadoSeleccionada = e.Node?.Tag as Certificado;
                CargarCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_limpiar_CertificadoClick(object sender, EventArgs e)
        {
            try
            {
                certificadoSeleccionada = null;
                CargarCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_editar_CertificadoClick(object sender, EventArgs e)
        {
            try
            {
                //Verificaciones
                if (certificadoSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar un certificado para editarla.");
                if (certificadoSeleccionada?.Profesional != medicoLoggeado.NombreCompleto)
                    throw new InvalidOperationException("No se puede editar un certificado emitido por otro médico.");

                //Confirmar
                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos del certificado?");

                certificadoSeleccionada.Fecha = DateTime.Now.Date;
                certificadoSeleccionada.Observaciones = richTextBox_observaciones_certif.Text;
                certificadoSeleccionada.Descripcion = richTextBox_descrip_certificado.Text;
                certificadoSeleccionada.TipoCertificado = comboBox_tipo_certificado.SelectedItem.ToString();
                certificadoSeleccionada.FechaVigenciaDesde = dateTimePicker_desde.Value;
                certificadoSeleccionada.FechaVigenciaHasta = dateTimePicker_hasta.Value;

                _bllCertificado.Modificar(certificadoSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Recaargo todo
                certificadoSeleccionada = null;
                CargarArbolCertificados();
                CargarCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_guardar_CertificadoClick(object sender, EventArgs e)
        {
            try
            {
                //Verificaciones
                if (certificadoSeleccionada != null)
                    throw new InvalidOperationException("Debe limpiar los datos antes de guardar un nuevo registro.");
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para guardar el certificado.");
                if (consultaSeleccionada == null || consultaSeleccionada?.Medico.Id != medicoLoggeado.Id)
                    throw new InvalidOperationException("Debe seleccionar una consulta propia para guardar el certificado.");
                if (comboBox_tipo_certificado.SelectedItem == null)
                    throw new InvalidOperationException("Debe seleccionar un tipo de certificado.");
                if (dateTimePicker_desde.Value > dateTimePicker_hasta.Value)
                    throw new InvalidOperationException("La fecha de Vigencia 'hasta' debe ser mayor a fecha 'desde'.");

                //Confirmar
                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos del certificado?");

                certificadoSeleccionada = new Certificado
                {
                    Fecha = DateTime.Now.Date,
                    Observaciones = richTextBox_observaciones_certif.Text,
                    Descripcion = richTextBox_descrip_certificado.Text,
                    TipoCertificado = comboBox_tipo_certificado.SelectedItem.ToString(),
                    FechaVigenciaDesde = dateTimePicker_desde.Value,
                    FechaVigenciaHasta = dateTimePicker_hasta.Value,
                    Consulta = consultaSeleccionada,
                    Profesional = medicoLoggeado.NombreCompleto,
                };

                _bllCertificado.Agregar(certificadoSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Recaargo todo
                certificadoSeleccionada = null;
                CargarArbolCertificados();
                CargarCertificado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_rec_imprimir_CertificadoClick(object sender, EventArgs e)
        {
            try
            {
                // Validar
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para imprimir el certificado.");
                if (certificadoSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar un certificado para imprimir.");

                var generator = new CertificadoPDFGenerator(certificadoSeleccionada, pacienteSeleccionado, medicoLoggeado);
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