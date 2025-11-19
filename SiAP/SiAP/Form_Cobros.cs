using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BE;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.DAL;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiAP.UI
{
    public partial class Form_Cobros : Form
    {
        #region Vars

        BLL_Cobro _bllCobro;
        BLL_Turno _bllTurno;
        Cobro itemSeleccionado;
        private List<string> campos = new List<string> { "Fecha", "HoraInicio", "TipoAtencion", "Estado", "TipoPago", "Monto", "EstadoCobro" };
        //Control
        private UC_Mostrar_Paciente _userControl;
        private Paciente pacienteSeleccionado;

        #endregion

        public Form_Cobros()
        {
            InitializeComponent();
            _bllCobro = BLL_Cobro.ObtenerInstancia();
            _bllTurno = BLL_Turno.ObtenerInstancia();

            _userControl = this.FindUserControl<UC_Mostrar_Paciente>("uC_Mostrar_Paciente1");
            if (_userControl != null)
                _userControl.ShouldUpdate += OnPacienteSeleccionado;

            //Configurar y cargar Grid
            this.Controls.ConfigurarTodosLosGrids();
            LimpiarSeleccion();
        }

        #region Acctions

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            try
            {
                pacienteSeleccionado = _userControl.pacienteSeleccionado;
                LimpiarSeleccion();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificarDatos()
        {
            //textBox_nombre_archivo.Text.ValidarSoloTexto("Nombre");
            //richTextBox_descripcion.Text.ValidarSoloTexto("Descripción");
            //if (string.IsNullOrEmpty(comboBox_NombreBD.SelectedItem as string))
            //    throw new ArgumentException($"Debe seleccionar una BD para continuar.");
        }

        private void LimpiarSeleccion()
        {
            dataGrid_cobros.CargarGrid(campos, _bllTurno.ObtenerTodos().ToList());
            itemSeleccionado = null;
            textBox_creador.Text = GestionUsuario.UsuarioLogueado.Username;
            textBox_fecha.Text = DateTime.Now.ToShortDateString();
            textBox_nombre_archivo.Text = "";
            richTextBox_descripcion.Text = "";
        }

        private void CargarDatos()
        {
            if (pacienteSeleccionado != null)
                dataGrid_cobros.CargarGrid(campos, _bllTurno.BuscarTurnoPorPaciente(pacienteSeleccionado).ToList());

            if (itemSeleccionado != null)
            {
                //textBox_creador.Text = itemSeleccionado.CreadoPor;
                //textBox_fecha.Text = itemSeleccionado.FechaCreacion.ToShortDateString();
                //textBox_nombre_archivo.Text = itemSeleccionado.NombreArchivo;
                //richTextBox_descripcion.Text = itemSeleccionado.Descripcion;
                //comboBox_NombreBD.SelectedItem = itemSeleccionado.NombreBD;
                //comboBox_NombreBD.Enabled = false;
            }
        }

        #endregion
    }
}
