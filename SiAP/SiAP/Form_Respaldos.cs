using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BE.Seguridad;
using SiAP.BE;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using SiAP.DAL;

namespace SiAP.UI
{
    public partial class Form_Respaldos : Form
    {
        #region Vars

        BLL_Respaldo _bllRespaldo;
        Respaldo itemSeleccionado;
        private List<string> campos = new List<string> { "NombreArchivo", "NombreBD", "FechaCreacion", "Tipo", "CreadoPor", "TamanioKB" };

        #endregion


        public Form_Respaldos()
        {
            InitializeComponent();
            _bllRespaldo = BLL_Respaldo.ObtenerInstancia();
            comboBox_NombreBD.DataSource = ReferenciasBD.Todos();

            //Configurar y cargar Grid
            this.Controls.ConfigurarTodosLosGrids();
            LimpiarSeleccion();
        }

        private void dataGrid_respaldos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGrid_respaldos.VerificarYRetornarSeleccion<Respaldo>();
            CargarDatos();
        }

        #region Buttons

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un Respaldo para continuar.");

                InputsExtensions.PedirConfirmacion($"Desea eliminar el Respaldo '{itemSeleccionado.NombreArchivo}'?");
                _bllRespaldo.Eliminar(itemSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarSeleccion();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDatos();
                itemSeleccionado = new Respaldo();
                itemSeleccionado.NombreArchivo = textBox_nombre_archivo.Text;
                itemSeleccionado.Descripcion = richTextBox_descripcion.Text;
                itemSeleccionado.NombreBD = (string)comboBox_NombreBD.SelectedItem;

                InputsExtensions.PedirConfirmacion($"Desea crear el Respaldo '{itemSeleccionado.NombreArchivo}'?");
                _bllRespaldo.Agregar(itemSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }

        }

        private void button_restaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un Respaldo para continuar.");

                InputsExtensions.PedirConfirmacion($"Desea restaurar el Respaldo '{itemSeleccionado.NombreArchivo}'?");
                _bllRespaldo.RestaurarRespaldo(itemSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        private void button_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarSeleccion();
                var listafiltrada = _bllRespaldo.FiltrarPorFecha(dateTimePicker_desde.Value, dateTimePicker_hasta.Value).ToList();
                dataGrid_respaldos.CargarGrid(campos, listafiltrada);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarSeleccion();
        }

        #endregion

        #region Acctions

        private void VerificarDatos()
        {
            textBox_nombre_archivo.Text.ValidarSoloTexto("Nombre");
            richTextBox_descripcion.Text.ValidarSoloTexto("Descripción");
            if (string.IsNullOrEmpty(comboBox_NombreBD.SelectedItem as string))
                throw new ArgumentException($"Debe seleccionar una BD para continuar.");
        }

        private void LimpiarSeleccion()
        {
            itemSeleccionado = null;
            textBox_creador.Text = GestionUsuario.UsuarioLogueado.Username;
            textBox_fecha.Text = DateTime.Now.ToShortDateString();
            textBox_nombre_archivo.Text = "";
            richTextBox_descripcion.Text = "";
            comboBox_NombreBD.Enabled = true;
            comboBox_NombreBD.DataSource = ReferenciasBD.Todos();
            dataGrid_respaldos.CargarGrid(campos, _bllRespaldo.ObtenerTodos().ToList());
        }

        private void CargarDatos()
        {
            if (itemSeleccionado != null)
            {
                textBox_creador.Text = itemSeleccionado.CreadoPor;
                textBox_fecha.Text = itemSeleccionado.FechaCreacion.ToShortDateString();
                textBox_nombre_archivo.Text = itemSeleccionado.NombreArchivo;
                richTextBox_descripcion.Text = itemSeleccionado.Descripcion;
                comboBox_NombreBD.SelectedItem = itemSeleccionado.NombreBD;
                comboBox_NombreBD.Enabled = false;
            }
        }

        #endregion



    }
}
