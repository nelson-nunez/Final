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
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_CRUD_Pacientes : Form
    {
        #region Variables

        Paciente itemSeleccionado = new Paciente();
        BLL_Paciente _bllPaciente;

        #endregion

        public Form_CRUD_Pacientes()
        {
            InitializeComponent();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();
            this.Controls.ConfigurarTodosLosGrids();
            CargarDatos(true);
        }

        #region Botones

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDatos();
                InputsExtensions.PedirConfirmacion("¿Desea guardar el paciente?");
                AsignarDatos();
                _bllPaciente.Agregar(itemSeleccionado);
                MessageBox.Show("Paciente creado correctamente.");
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
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Paciente>();
                VerificarDatos();
                InputsExtensions.PedirConfirmacion("¿Desea modificar el paciente?");
                AsignarDatos();
                _bllPaciente.Modificar(itemSeleccionado);
                MessageBox.Show("Paciente actualizado correctamente.");
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Paciente>();
                InputsExtensions.PedirConfirmacion("¿Desea eliminar el paciente?");
                _bllPaciente.Eliminar(itemSeleccionado);
                MessageBox.Show("Paciente eliminado correctamente.");
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

        #endregion

        #region Lógica de formulario

        private void CargarDatos(bool limpiar = false)
        {
            if (limpiar)
            {
                itemSeleccionado = new Paciente();
                dataGridView1.DataSource = _bllPaciente.ObtenerTodos().ToList();
            }

            textBox_nombre.Text = itemSeleccionado.Nombre;
            textBox_apellido.Text = itemSeleccionado.Apellido;
            textBox_DNI.Text = itemSeleccionado.Dni;
            dateTime_feccha_nac.Value = (itemSeleccionado.FechaNacimiento.Year > 1900) ? itemSeleccionado.FechaNacimiento : DateTime.Today;
            textBox_email.Text = itemSeleccionado.Email;
            textBox_telefono.Text = itemSeleccionado.Telefono;
            textBox_ooss.Text = itemSeleccionado.ObraSocial;
            textBox_plan.Text = itemSeleccionado.Plan;
            numeric_nro_socio.Value = itemSeleccionado.NumeroSocio;
        }

        private void AsignarDatos()
        {
            itemSeleccionado.Nombre = textBox_nombre.Text;
            itemSeleccionado.Apellido = textBox_apellido.Text;
            itemSeleccionado.Dni = textBox_DNI.Text;
            itemSeleccionado.FechaNacimiento = dateTime_feccha_nac.Value;
            itemSeleccionado.Email = textBox_email.Text;
            itemSeleccionado.Telefono = textBox_telefono.Text;
            itemSeleccionado.ObraSocial = textBox_ooss.Text;
            itemSeleccionado.Plan = textBox_plan.Text;
            itemSeleccionado.NumeroSocio = (int)numeric_nro_socio.Value;
        }

        private void VerificarDatos()
        {
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_DNI.Text.ValidarSoloNumeros("DNI");
            dateTime_feccha_nac.Value.ValidarMayorEdad("Fecha Nac.");
            textBox_email.Text.ValidarEmail("Email");
            textBox_telefono.Text.ValidarSoloNumeros("Teléfono");
            textBox_ooss.Text.ValidarSoloTexto("Obra Social");
            textBox_plan.Text.Validar("Plan");
            numeric_nro_socio.Value.ValidarSoloNumeros("Número de Socio");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Paciente>();
            CargarDatos();
        }

        #endregion
    }
}
