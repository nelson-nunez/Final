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
using SiAP.BE.Seguridad;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiAP.UI
{
    public partial class Form_CRUD_Medicos : Form
    {
        #region Vars

        Medico itemSeleccionado = new Medico();
        BLL_Medico _bllMedico;

        #endregion


        public Form_CRUD_Medicos()
        {
            InitializeComponent();
            _bllMedico = BLL_Medico.ObtenerInstancia();
            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
            comboBox_especialidad.DataSource = Especialidad.ObtenerTodas();
            CargarDatos(true);
        }

        #region Buttons

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico
                VerificarDatos();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea crear el Médico?");
                //Asignar
                AsignarDatos();
                _bllMedico.Agregar(itemSeleccionado);
                MessageBox.Show("Se creó el registro con éxito");
                //Si sale bien limpio
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico seleccion
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                VerificarDatos();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea guardar los cambios?");
                //Asignar
                AsignarDatos();
                _bllMedico.Modificar(itemSeleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
                //Si sale bien limpio
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos(true);
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico seleccion
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea eliminar el registro?");
                _bllMedico.Eliminar(itemSeleccionado);
                MessageBox.Show("Se eliminó el registro con éxito");
                //Si sale bien limpio
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        #endregion

        #region Carga de datos

        private void CargarDatos(bool limpiar = false)
        {
            if (limpiar)
            {
                itemSeleccionado = new Medico();
                dataGridView1.DataSource = _bllMedico.ObtenerTodos().ToList();
            }
            textBox_nombre.Text = itemSeleccionado.Nombre;
            textBox_apellido.Text = itemSeleccionado.Apellido;
            textBox_DNI.Text = itemSeleccionado.Dni;
            dateTime_feccha_nac.Value = (itemSeleccionado.FechaNacimiento.Year > 1900) ? itemSeleccionado.FechaNacimiento : DateTime.Today;
            textBox_email.Text = itemSeleccionado.Email;
            textBox_telefono.Text = itemSeleccionado.Telefono;
            textBox_precio.Text = itemSeleccionado.ArancelConsulta.ToString();
            textBox_titulo.Text = itemSeleccionado.Titulo;
            comboBox_especialidad.SelectedItem = itemSeleccionado.Especialidad;

        }

        private void AsignarDatos()
        {
            itemSeleccionado.Nombre = textBox_nombre.Text;
            itemSeleccionado.Apellido = textBox_apellido.Text;
            itemSeleccionado.Dni = textBox_DNI.Text;
            itemSeleccionado.FechaNacimiento = dateTime_feccha_nac.Value;
            itemSeleccionado.Email = textBox_email.Text;
            itemSeleccionado.Telefono = textBox_telefono.Text;
            itemSeleccionado.ArancelConsulta = Convert.ToDecimal(textBox_precio.Text);
            itemSeleccionado.Titulo = textBox_titulo.Text;
            itemSeleccionado.Especialidad = (Especialidad)comboBox_especialidad.SelectedItem;
        }

        private void VerificarDatos()
        {
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_DNI.Text.ValidarSoloNumeros("DNI");
            dateTime_feccha_nac.Value.ValidarMayorEdad("Fecha Nac.");
            textBox_email.Text.ValidarEmail("Email");
            textBox_telefono.Text.ValidarSoloNumeros("Teléfono");
            textBox_titulo.Text.ValidarSoloTexto("Título");
            textBox_precio.Text.ValidarSoloNumeros("Precio");
            var item = comboBox_especialidad.SelectedItem as Especialidad;
            InputsExtensions.OnlySelected(item, "especialidad ");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
            CargarDatos();
        }

        #endregion
    }
}
