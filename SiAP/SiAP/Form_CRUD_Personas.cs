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
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiAP.UI
{
    public partial class Form_CRUD_Personas : Form
    {
        public Form_CRUD_Personas()
        {
            InitializeComponent();

            comboBox_tipo.DataSource = TiposPersonas.ObtenerTodos();
            comboBox_especialidad.DataSource = EspecialidadesMedicas.ObtenerTodos();
        }

        #region Buttons

        private void button_Guardar_Click(object sender, EventArgs e)
        {

        }

        private void button_Editar_Click(object sender, EventArgs e)
        {

        }
        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_nombre.Text = string.Empty;
            textBox_apellido.Text = string.Empty;
            numeric_DNI.Value = 0;
            dateTime_feccha_nac.Value = DateTime.Now;
            textBox_email.Text = string.Empty;
            textBox_telefono.Text = string.Empty;
            textBox_titulo.Text = string.Empty;
            textBox_OOSS.Text = string.Empty;
            textBox_plan.Text = string.Empty;
            numeric_nro_socio.Value = 0;
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                InputsExtensions.PedirConfirmacion("Desea crear el Permiso?");
                //Verificar

                //_bllPermiso.Agregar(itemSeleccionado);
                MessageBox.Show("Se creó el permiso con éxito");
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

        private void CargarDatos()
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
