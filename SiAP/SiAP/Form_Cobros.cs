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
using SiAP.UI.Impresiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiAP.UI
{
    public partial class Form_Cobros : Form
    {
        #region Vars

        BLL_Cobro _bllCobro;
        BLL_Turno _bllTurno;
        BLL_Factura _bllFactura;
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
            _bllFactura = BLL_Factura.ObtenerInstancia();

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
                if (pacienteSeleccionado != null)
                    dataGrid_cobros.CargarGrid(campos, _bllTurno.BuscarTurnoPorPaciente(pacienteSeleccionado).ToList());
                
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            numeric_importe_pago.Value = 0;
            comboBox_tipo_pago.DataSource = MediodePagoHelper.mediosdePago;
            numeric_importe_pago.Enabled = true;

            CargarDatos();
        }

        private void CargarDatos()
        {
            if (itemSeleccionado != null)
            {
                textBox_fecha_turno.Text = itemSeleccionado.Fecha.ToShortDateString();
                textBox_hora_turno.Text = itemSeleccionado.HoraInicio.ToString();
                textBox_tipo_atencion_turno.Text = itemSeleccionado.TipoAtencion;
                textBox_estado_turno.Text = itemSeleccionado.Estado.ToString();
                if (itemSeleccionado.Cobro != null)
                {
                    numeric_importe_pago.Enabled = (itemSeleccionado.MontoRestante <= 0) ? false: true;
                    textBox_estado_cobro.Text = itemSeleccionado.EstadoCobro.ToString();
                    textBox_monto_total.Text = itemSeleccionado.MontoTotal.ToString();
                    textBox_pendiente.Text = itemSeleccionado.MontoRestante.ToString();
                    comboBox_tipo_pago.SelectedItem = itemSeleccionado.Cobro.MediodePago;                    
                    if (itemSeleccionado.EstadoCobro != (EstadoCobro.PagoParcial))
                        comboBox_tipo_pago.Enabled = false;
                }
            }
        }

        #endregion

        #region Buttons

        #endregion
        private void button_reembolsar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un Turno para continuar.");

                InputsExtensions.PedirConfirmacion($"Desea generar el reembolso?");
                _bllCobro.Reembolsar(itemSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_guardar_pago_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un Turno para continuar.");

                InputsExtensions.PedirConfirmacion($"Desea generar el pago?");
                itemSeleccionado.Cobro ??= new Cobro();
                itemSeleccionado.Cobro.MediodePago = (MediodePago)comboBox_tipo_pago.SelectedItem;
                itemSeleccionado.Cobro.Importe = numeric_importe_pago.Value;
                _bllCobro.Pagar(itemSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                LimpiarSeleccion();
            }
        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un Turno para continuar.");
                
                if (itemSeleccionado.Cobro.Estado != EstadoCobro.PagoTotal)
                    throw new Exception("Solo puede imprimir facturas de pagos completados.");

                InputsExtensions.PedirConfirmacion($"Desea imprimir la factura?");
                var factura = _bllFactura.LeerPorCobroId(itemSeleccionado.Cobro.Id);

                if (factura == null)
                    throw new Exception("No existe factura generada para el turno seleccionado.");

                MessageBox.Show("Se guardaron los cambios con éxito");

                var generator = new FacturaPDFGenerator(factura);
                generator.GenerarYAbrirPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGrid_cobros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGrid_cobros.VerificarYRetornarSeleccion<Turno>();

            CargarDatos();
        }
    }
}
