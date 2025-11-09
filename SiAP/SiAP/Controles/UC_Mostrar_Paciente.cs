using System.ComponentModel;
using SiAP.BE;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class UC_Mostrar_Paciente : UserControl
    {
        private UC_Buscar_Paciente _userControl;
        public Paciente pacienteSeleccionado;
        private Form_CRUD_Pacientes form_paciente;
        private Panel _panelOverlay;
        public event EventHandler<EventArgs> ShouldUpdate;

        public UC_Mostrar_Paciente()
        {
            InitializeComponent();

            // NO ejecutar código en modo diseño
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            try
            {
                _userControl = this.FindUserControl<UC_Buscar_Paciente>("uC_Buscar_Paciente1");

                if (_userControl != null)
                {
                    _userControl.Visible = false;
                    _userControl.ShouldUpdate += OnPacienteSeleccionado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            try
            {
                if (_userControl == null) return;
                OcultarUserControlEnFormPadre();
                pacienteSeleccionado = _userControl.itemSeleccionado;
                CargarDatosPaciente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPaciente()
        {
            if (pacienteSeleccionado == null) return;

            textBox_nombre_completo.Text = pacienteSeleccionado.ToString();
            textBox_DNI.Text = pacienteSeleccionado.Dni.ToString();
            textBox_ooss.Text = pacienteSeleccionado.ObraSocial;
            textBox_plan.Text = pacienteSeleccionado.Plan;
            textBox_nro_socio.Text = pacienteSeleccionado.NumeroSocio.ToString();
            //Invoco porque se selecciono algo
            ShouldUpdate?.Invoke(null, new EventArgs());
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userControl == null)
                {
                    MessageBox.Show("El control de búsqueda no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MostrarUserControlEnFormPadre();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_MostrarEditar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarFormPacientesEnFormPadre();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos Auxiliares

        private Form ObtenerFormPadre()
        {
            Control control = this;
            while (control != null)
            {
                if (control is Form form)
                    return form;
                control = control.Parent;
            }
            return null;
        }

        private void MostrarUserControlEnFormPadre()
        {
            var formPadre = ObtenerFormPadre();
            if (formPadre == null) return;

            _userControl.Parent = formPadre;
            CentrarControl(_userControl, formPadre);
            _userControl.Visible = true;
            _userControl.BringToFront();
        }

        private void OcultarUserControlEnFormPadre()
        {
            _userControl.Visible = false;
            _userControl.Parent = this;
        }

        private void MostrarFormPacientesEnFormPadre()
        {
            var formPadre = ObtenerFormPadre();
            if (formPadre == null) return;

            if (form_paciente == null || form_paciente.IsDisposed)
            {
                form_paciente = new Form_CRUD_Pacientes
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    StartPosition = FormStartPosition.Manual,
                    ControlBox = true
                };

                form_paciente.FormClosed += (s, e) => form_paciente = null;
                formPadre.Controls.Add(form_paciente);
            }

            CentrarControl(form_paciente, formPadre);
            form_paciente.Show();
            form_paciente.BringToFront();
        }

        private void CentrarControl(Control control, Form formPadre)
        {
            control.Width = Math.Min(control.Width, formPadre.ClientSize.Width);
            control.Height = Math.Min(control.Height, formPadre.ClientSize.Height);
            control.Location = new Point(
                (formPadre.ClientSize.Width - control.Width) / 2,
                (formPadre.ClientSize.Height - control.Height) / 2
            );
        }

        #endregion
    }
}
