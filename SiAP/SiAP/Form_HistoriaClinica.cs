using Policonsultorio.BE;
using SiAP.BE;
using SiAP.BE.Seguridad;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI
{
    public partial class Form_HistoriaClinica : Form
    {
        BLL_Paciente _bllPacientes;
        BLL_HistoriaClinica _bllHistoriaClinica;
        BLL_Consulta _bllConsulta;

        private readonly UC_Buscar_Paciente _userControl;

        Medico medicoSeleccionado;
        Paciente pacienteSeleccionado;
        HistoriaClinica historiaClinicaSeleccionada;
        Consulta consultaSeleccionada;
        Usuario useractual;

        public Form_HistoriaClinica()
        {
            InitializeComponent();

            _bllPacientes = BLL_Paciente.ObtenerInstancia();
            _bllHistoriaClinica = BLL_HistoriaClinica.ObtenerInstancia();
            _bllConsulta = BLL_Consulta.ObtenerInstancia();
            //Ucontrol
            _userControl = this.FindUserControl<UC_Buscar_Paciente>("uC_Buscar_Paciente1");
            _userControl.Visible = false;
            _userControl.ShouldUpdate += OnPacienteSeleccionado;
            useractual = GestionUsuario.UsuarioLogueado;
        }

        #region Seleccion de Paciente

        private void button_seleccionar_paciente_Click(object sender, EventArgs e)
        {
            _userControl.Visible = true;
        }

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            _userControl.Visible = false;
            pacienteSeleccionado = _userControl.itemSeleccionado;
            CargarDatosPaciente();
            CargarHistoria();
            CargarConsultas();
        }

        private void CargarDatosPaciente()
        {
            if (pacienteSeleccionado == null)
                return;
            label_nombre_completo.Text = pacienteSeleccionado.ToString();
            label_ooss.Text = pacienteSeleccionado.ObraSocial;
            label_plan_os.Text = pacienteSeleccionado.Plan;
            label_nro_socio.Text = pacienteSeleccionado.NumeroSocio.ToString();
        }

        #endregion

        #region HistoriaClinica

        private void CargarHistoria()
        {
            historiaClinicaSeleccionada = _bllHistoriaClinica.BuscarPorPaciente(pacienteSeleccionado.Id);
            if (historiaClinicaSeleccionada != null)
                richText_historia_Clinica.Text = historiaClinicaSeleccionada.Descripcion;
        }

        //Editar
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifico
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");
                if (historiaClinicaSeleccionada == null)
                    throw new InvalidOperationException("El paciente no cuenta con Historia Clínica para editar. Guarde una nueva.");
                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea guardar la modificación en la Historia del paciente?");
                //Asigno
                historiaClinicaSeleccionada.Descripcion = richText_historia_Clinica.Text;

                _bllHistoriaClinica.Modificar(historiaClinicaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Guardar
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifico
                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");
                if (historiaClinicaSeleccionada != null)
                    throw new InvalidOperationException("El paciente ya cuenta con Historia Clínica seleccione EDITAR para modificarla.");
                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea guardar lo registrado en la Historia del paciente?");
                //Asigno
                historiaClinicaSeleccionada = new HistoriaClinica();
                historiaClinicaSeleccionada.FechaCreacion = DateTime.Now;
                historiaClinicaSeleccionada.Paciente = pacienteSeleccionado;
                historiaClinicaSeleccionada.Descripcion = richText_historia_Clinica.Text;

                _bllHistoriaClinica.Agregar(historiaClinicaSeleccionada);
                MessageBox.Show("Se guardó la hisotira clínica con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (historiaClinicaSeleccionada == null)
                return;

            var lista = _bllConsulta.BuscarPorHistoriaClinica(historiaClinicaSeleccionada.Id);
            treeView_historia_cli.ArmarArbolConsultas(lista.ToList());
        }
        private void treeView_historia_cli_AfterSelect(object sender, TreeViewEventArgs e)
        {
            consultaSeleccionada = e.Node?.Tag as Consulta;
            CargarDatosConsulta();
        }

        private void CargarDatosConsulta()
        {
            richTextBox_motivo.Text = consultaSeleccionada?.Motivo ?? "";
            richTextBox_observaciones.Text = consultaSeleccionada?.Observaciones ?? "";
            richTextBox_tratamiento.Text = consultaSeleccionada?.Tratamiento ?? "";
        }


        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            consultaSeleccionada = null;
            CargarDatosConsulta();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifico
                if (consultaSeleccionada == null)
                    throw new InvalidOperationException("Debe seleccionar una consulta para continuar.");
                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea guardar la modificación en la consulta del paciente?");
                //Asigno
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
                // Verifico
                if (consultaSeleccionada != null)
                    throw new InvalidOperationException("Debe limpiar los datos seleccionados antes de guardar un nuevo registro.");
                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea guardar los datos de la consulta del paciente?");
                //Asigno
                consultaSeleccionada = new Consulta();
                consultaSeleccionada.Motivo = richTextBox_motivo.Text;
                consultaSeleccionada.Observaciones = richTextBox_observaciones.Text;
                consultaSeleccionada.Tratamiento = richTextBox_tratamiento.Text;
                consultaSeleccionada.HistoriaClinica = historiaClinicaSeleccionada ?? new HistoriaClinica();

                _bllConsulta.Agregar(consultaSeleccionada);
                MessageBox.Show("Se guardaron los cambios con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CargarConsultas();
            }
        }


        #endregion
    }
}
