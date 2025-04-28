using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.UI.Controles;

namespace SiAP.UI
{
    public partial class Form_Menu : Form
    {
        //Formularios
        private Form_Turnos form_turnos;
        private Form_HistoriaClinica form_historia;
        //Componentes
        private uc_Login uc_login;

        public Form_Menu()
        {
            InitializeComponent();
            // Hacer que esta ventana sea un contenedor MDI
            this.IsMdiContainer = true;

            // Cambiar el color de fondo del formulario
            Controls.OfType<MdiClient>().FirstOrDefault()!.BackColor = BackColor = Color.WhiteSmoke;

            // Ocultar el menú hasta que se inicie sesión correctamente
            menuStrip1.Visible = false;

            MostrarLogin();
        }

        private void MostrarLogin()
        {
            // Crear y centrar el UC_Login
            uc_login = new uc_Login();
            uc_login.Anchor = AnchorStyles.None;
            uc_login.Left = (this.ClientSize.Width - uc_login.Width) / 2;
            uc_login.Top = (this.ClientSize.Height - uc_login.Height) / 2;
            this.Controls.Add(uc_login);
            uc_login.LoginSuccess += Uc_Login_LoginSuccess;
        }

        private void Uc_Login_LoginSuccess(object sender, EventArgs e)
        {
            MessageBox.Show($"Bienvenido", "Atención");
            menuStrip1.Visible = true;
            uc_login.Visible = false;
        }

        private void AbrirFormGeneral<T>(ref T formulario) where T : Form, new()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                T nuevoFormulario = new T();
                //Dentro del padre
                nuevoFormulario.MdiParent = this;
                //Sin controles de cerrar
                nuevoFormulario.ControlBox = false;
                //Sin bordes
                nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
                // Establecer la ubicación centrada
                nuevoFormulario.StartPosition = FormStartPosition.CenterScreen;
                formulario = nuevoFormulario;
            }

            formulario.Show();
            formulario.BringToFront();
        }
        private void CerrarTodosLosFormulariosHijos(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
            MostrarLogin();
        }

        private void AbrirForm_Turnos(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_turnos);
        }
        private void AbrirForm_Historia(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_historia);
        }

    }
}
