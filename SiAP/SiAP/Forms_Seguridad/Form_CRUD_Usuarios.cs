using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BE.Seguridad;
using SiAP.BLL.Seguridad;
using SiAP.UI.Controles;
using SiAP.UI.Extensiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class Form_CRUD_Usuarios : Form
    {
        #region Vars

        BLL_Usuario _bllUsuario;

        UC_BuscarUsuario userControl;

        #endregion


        public Form_CRUD_Usuarios()
        {
            InitializeComponent();

            _bllUsuario = BLL_Usuario.ObtenerInstancia();
            userControl = this.FindUserControl<UC_BuscarUsuario>("uC_BuscarUsuario1");
            userControl.ShouldUpdate += ShouldUpdate;
        }

        private void ShouldUpdate(object? sender, EventArgs e)
        {
            CargarDatos();
        }

        #region Buttons

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar
                if (userControl.itemSeleccionado == null || userControl.itemSeleccionado.Id == 0)
                    throw new Exception("Seleccione un usuario antes de continuar");

                InputsExtensions.PedirConfirmacion($"Desea eliminar el usuario '{userControl.itemSeleccionado.Username}'?");
                _bllUsuario.Eliminar(userControl.itemSeleccionado);
                MessageBox.Show("Se eliminó el usuario con éxito");
                userControl.Limpiar();
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

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                userControl.Limpiar();
                CargarDatos();
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
                //Verificar
                if (userControl.itemSeleccionado == null || userControl.itemSeleccionado.Id == 0)
                    throw new Exception("Seleccione un usuario antes de continuar");
                VerificarDatos();
                InputsExtensions.PedirConfirmacion($"Desea modificar el usuario '{userControl.itemSeleccionado.Username}'?");
                //Valores
                userControl.itemSeleccionado.Username = textBox_username.Text;
                userControl.itemSeleccionado.Nombre = textBox_nombre.Text;
                userControl.itemSeleccionado.Apellido = textBox_apellido.Text;
                userControl.itemSeleccionado.Email = textBox_email.Text;
                userControl.itemSeleccionado.Activo = checkBox1.Checked;

                _bllUsuario.Modificar(userControl.itemSeleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
                userControl.Limpiar();
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

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar
                if (userControl.itemSeleccionado.Id != 0)
                    throw new Exception("Limpie la selección antes de continuar");
                VerificarDatos();
                InputsExtensions.PedirConfirmacion($"Desea guardar el usuario '{userControl.itemSeleccionado.Username}'?");
                //Valores
                userControl.itemSeleccionado.Username = textBox_username.Text;
                userControl.itemSeleccionado.Nombre = textBox_nombre.Text;
                userControl.itemSeleccionado.Apellido = textBox_apellido.Text;
                userControl.itemSeleccionado.Email = textBox_email.Text;
                userControl.itemSeleccionado.Activo = checkBox1.Checked;
                _bllUsuario.Agregar(userControl.itemSeleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
                userControl.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Blanqueo_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar
                if (userControl.itemSeleccionado == null || userControl.itemSeleccionado.Id == 0)
                    throw new Exception("Seleccione un usuario antes de continuar");
                VerificarDatos();
                InputsExtensions.PedirConfirmacion($"Desea blanquear la contraseña del usuario: '{userControl.itemSeleccionado.Username}'?");
                userControl.itemSeleccionado.Password = "Cambiar_" + textBox_email.Text;
                _bllUsuario.Blanqueo(userControl.itemSeleccionado);
                MessageBox.Show("Se blanqueó la contraseña con éxito");
                userControl.Limpiar();
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
            //Valores
            textBox_username.Text = userControl.itemSeleccionado.Username;
            textBox_nombre.Text = userControl.itemSeleccionado.Nombre;
            textBox_apellido.Text = userControl.itemSeleccionado.Apellido;
            textBox_password.Text = userControl.itemSeleccionado.Password;
            textBox_email.Text = userControl.itemSeleccionado.Email;
            checkBox1.Checked = userControl.itemSeleccionado.Activo;
        }

        private void VerificarDatos()
        {
            textBox_username.Text.ValidarSoloTexto("Username");
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_email.Text.ValidarEmail("Email");
            checkBox1.Checked.Validar("Activo");
        }

        #endregion

    }
}
