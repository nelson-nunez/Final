using SiAP.BE;
using SiAP.BLL;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI
{
    public partial class Form_HistoriaClinica : Form
    {
        BLL_Medico _bllMedicos;
        private Medico _medicoSeleccionado;
        private Paciente _pacienteSeleccionado;
        private readonly UC_Buscar_Paciente _userControl;

        public Form_HistoriaClinica()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            //Ucontrol
            _userControl = this.FindUserControl<UC_Buscar_Paciente>("uC_Buscar_Paciente1");
            _userControl.Visible = false;
            _userControl.ShouldUpdate += OnPacienteSeleccionado;

        }

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            _userControl.Visible = false;
            _pacienteSeleccionado = _userControl.itemSeleccionado;
            ActualizarVistaSegunSeleccion();
        }

        private void ActualizarVistaSegunSeleccion()
        {
            if (_pacienteSeleccionado == null)
                return;
            label_nombre_completo.Text = _pacienteSeleccionado.ToString();
            label_ooss.Text = _pacienteSeleccionado.ObraSocial;
            label_plan_os.Text = _pacienteSeleccionado.Plan;
            label_nro_socio.Text = _pacienteSeleccionado.NumeroSocio.ToString();
        }

        private void button_seleccionar_paciente_Click(object sender, EventArgs e)
        {
            _userControl.Visible = true;
        }
    }
}
