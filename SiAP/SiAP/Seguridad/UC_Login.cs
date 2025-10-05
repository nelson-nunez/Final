using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BLL.Seguridad;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SiAP.UI.Controles
{
    public partial class UC_Login : UserControl
    {
        BLL_Usuario bllusuario;
        public event EventHandler<EventArgs> LoginSuccess;

        public UC_Login()
        {
            InitializeComponent();
            bllusuario = BLL_Usuario.ObtenerInstancia();
            //Prueba borrar
            password.UseSystemPasswordChar = true;
            email.Text = "admin";
            password.Text = "admin";
        }

        private void VerificarDatos()
        {
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Complete todos los campos para continuar", "Atención");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDatos();
                var result = bllusuario.Ingresar(email.Text, password.Text);
                if (result)
                    LoginSuccess?.Invoke(this, new EventArgs());
                else
                    MessageBox.Show("Credenciales inválidas", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }
    }
}
