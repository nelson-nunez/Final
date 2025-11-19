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
        Turno itemSeleccionado;
        private List<string> campos = new List<string> { "Fecha", "HoraInicio", "Estado", "TipoAtencion", "MediodePago", "MontoTotal", "MontoRestante", "EstadoCobro" };
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
            //Combo
            comboBox_tipo_pago.DataSource = MediodePagoHelper.mediosdePago;

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
            textBox_fecha_turno.Text = "";
            textBox_hora_turno.Text = "";
            textBox_tipo_atencion_turno.Text = "";
            textBox_estado_turno.Text = "";
            textBox_estado_cobro.Text = "";
            textBox_monto_total.Text = "";
            textBox_pendiente.Text = "";
            
            comboBox_tipo_pago.SelectedItem = MediodePagoHelper.mediosdePago;
            textBox_importe_pagar.Enabled = true;
        }

        private void CargarDatos()
        {
            if (pacienteSeleccionado != null)
                dataGrid_cobros.CargarGrid(campos, _bllTurno.BuscarTurnoPorPaciente(pacienteSeleccionado).ToList());

            if (itemSeleccionado != null)
            {
                textBox_fecha_turno.Text = itemSeleccionado.Fecha.ToShortDateString();
                textBox_hora_turno.Text = itemSeleccionado.HoraInicio.ToString();
                textBox_tipo_atencion_turno.Text = itemSeleccionado.TipoAtencion;
                textBox_estado_turno.Text = itemSeleccionado.Estado.ToString();
                if (itemSeleccionado.Cobro != null)
                {
                    textBox_importe_pagar.Enabled = (itemSeleccionado.MontoRestante <= 0) ? false: true;
                    textBox_estado_cobro.Text = itemSeleccionado.EstadoCobro.ToString();
                    textBox_monto_total.Text = itemSeleccionado.MontoTotal.ToString();
                    textBox_pendiente.Text = itemSeleccionado.MontoRestante.ToString();
                    
                    comboBox_tipo_pago.SelectedItem = itemSeleccionado.MediodePago.ToString();
                }
            }
        }

        #endregion

        #region Buttons

        #endregion
        private void button_reembolsar_Click(object sender, EventArgs e)
        {
            //Fecha
            //HoraInicio
            //HoraFin
            //TipoAtencion
            //Estado
            //Cobro
            //MediodePago
            //Monto
            //EstadoCobro
            //
            ////-
            //FechaHora
            //MediodePago
            //Monto
            //Estado

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {

        }

        private void button_guardar_pago_Click(object sender, EventArgs e)
        {

        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid_cobros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGrid_cobros.VerificarYRetornarSeleccion<Turno>();

            CargarDatos();
        }
    }
}
