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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SiAP.UI.Controles
{
    public partial class uc_Login : UserControl
    {
        BLL_Usuario bllusuario;
        public event EventHandler<EventArgs> LoginSuccess;

        public uc_Login()
        {
            InitializeComponent();
            bllusuario = BLL_Usuario.ObtenerInstancia();
            //Prueba borrar
            email.Text = "prueba";
            password.Text = "prueba";
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //VerificarDatos();
                //var result = bllusuario.Login(email.Text, password.Text);
                //if (result)
                    LoginSuccess?.Invoke(this, new EventArgs());
                //else
                //    MessageBox.Show("Credenciales inválidas", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void VerificarDatos()
        {
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Complete todos los campos para continuar", "Atención");
                return;
            }
        }
    }
}
