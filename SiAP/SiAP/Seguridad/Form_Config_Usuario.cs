using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.BLL.Base;
using SiAP.BLL.Seguridad;
using SiAP.UI.Controles;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_Config_Usuario : Form
    {
        BLL_Usuario _bllUsuario;
        Usuario useractual = new Usuario();
        private IEncriptacion _encriptacion;
        bool mostrar = false;
        public Form_Config_Usuario()
        {
            InitializeComponent();
            _bllUsuario = BLL_Usuario.ObtenerInstancia();
            _encriptacion = new Encriptador();
            
            textBox_old_pass.UseSystemPasswordChar = true;
            textBox_new_pass.UseSystemPasswordChar = true;
            textBox_rep_new_pass.UseSystemPasswordChar = true;
            checkBox1.Text = mostrar ? "Ocultar contraseña" : "Mostrar contraseña";
            CargarDatos();
        }

        private void CargarDatos()
        {
            useractual = GestionUsuario.UsuarioLogueado;
            textBox_email.Text = useractual.Persona.Email;
            textBox_old_pass.Text = "";
            textBox_new_pass.Text = "";
            textBox_rep_new_pass.Text = "";
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar
                textBox_email.Text.ValidarEmail("Email");
                textBox_old_pass.Text.ValidarPassword("Contraseña actual");
                textBox_new_pass.Text.ValidarPassword("Nueva Contraseña");
                textBox_rep_new_pass.Text.ValidarPassword("Repetir Nueva Contraseña");
                if (textBox_old_pass.Text != _encriptacion.Desencriptar3DES(useractual.Password))
                    throw new Exception("La contraseña actual no coincide con la registrada. Intente nuevamente.");
                if (textBox_new_pass.Text != textBox_rep_new_pass.Text)
                    throw new Exception("Las contraseñas nuevas no coinciden. Intente nuevamente.");

                InputsExtensions.PedirConfirmacion("Desea guardar los cambios?");

                //Asignar
                useractual.Persona.Email = textBox_email.Text;
                useractual.Password = _encriptacion.Encriptar3DES(textBox_rep_new_pass.Text);

                _bllUsuario.Modificar(useractual);
                MessageBox.Show("Se guardaron los cambios con éxito");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mostrar = checkBox1.Checked;
            textBox_old_pass.UseSystemPasswordChar = !mostrar;
            textBox_new_pass.UseSystemPasswordChar = !mostrar;
            textBox_rep_new_pass.UseSystemPasswordChar = !mostrar;
            checkBox1.Text = mostrar ? "Ocultar contraseña" : "Mostrar contraseña";
        }
    }
}
