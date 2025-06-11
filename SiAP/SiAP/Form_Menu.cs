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
using SiAP.UI.Controles;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI
{
    public partial class Form_Menu : Form
    {
        //Formularios
        private Form_Turnos form_turnos;
        private Form_HistoriaClinica form_historia;
        private Form_Roles form_Roles;
        //Componentes
        private UC_Login UC_Login;

        public Form_Menu()
        {
            InitializeComponent();
            // Hacer que esta ventana sea un contenedor MDI
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true; // Opcional: dejar como true si querés permitir minimizar
            this.StartPosition = FormStartPosition.CenterScreen; // Opcional: centrar al abrir

            // Cambiar el color de fondo del formulario
            Controls.OfType<MdiClient>().FirstOrDefault()!.BackColor = BackColor = Color.WhiteSmoke;

            // Ocultar el menú hasta que se inicie sesión correctamente
            menuStrip1.Visible = false;
            MostrarLogin();
        }

        #region Login
        private void MostrarLogin()
        {
            // Crear y centrar el UC_Login
            UC_Login = new UC_Login();
            UC_Login.Anchor = AnchorStyles.None;
            UC_Login.Left = (this.ClientSize.Width - UC_Login.Width) / 2;
            UC_Login.Top = (this.ClientSize.Height - UC_Login.Height) / 2;
            this.Controls.Add(UC_Login);
            UC_Login.LoginSuccess += UC_Login_LoginSuccess;
        }

        private void UC_Login_LoginSuccess(object sender, EventArgs e)
        {
            var useractual = GestionUsuario.UsuarioLogueado;
            if (useractual != null)
            {
                MessageBox.Show($"Bienvenido", "Atención");
                menuStrip1.Visible = true;
                CambiarVisibilidadMenu(menuStrip1.Items, useractual.Permiso.ObtenerPermisos());
                UC_Login.Visible = false;
            }

            UC_Login.LoginSuccess -= UC_Login_LoginSuccess;
        }
     
        private void Uc_Logout()
        {
            //deslogearlo
            menuStrip1.Visible = false;
            MostrarLogin();
        }

        #endregion

        #region MenuStrip en base a permisos

        public void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, IList<Permiso> permisosHabilitados)
        {
            //Variable utilizada para mostrar/ocultar items del menu que no tienen hijos visibles
            bool tieneVisibles = false;
            CambiarVisibilidadMenu(dropDownItems, ref tieneVisibles, permisosHabilitados);
        }

        public void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, ref bool tieneVisibles, IList<Permiso> permisosHabilitados)
        {
            foreach (object obj in dropDownItems)
            {
                ToolStripMenuItem subMenu = obj as ToolStripMenuItem;
                if (subMenu != null)
                {
                    if (subMenu.HasDropDown)
                    {
                        tieneVisibles = false;
                        CambiarVisibilidadMenu(subMenu.DropDownItems, ref tieneVisibles, permisosHabilitados);
                    }
                    bool visible = false;
                    string tag = subMenu.Tag as string;
                    if (!string.IsNullOrEmpty(tag) && (tag.Equals("TAG") || permisosHabilitados.Any(p => p.Codigo.Equals(tag))))
                    {
                        visible = true;
                        tieneVisibles = true;
                    }

                    if (string.IsNullOrWhiteSpace(tag) && tieneVisibles)
                        subMenu.Visible = true;
                    else
                        subMenu.Visible = visible;
                }
            }
        }

        #endregion

        #region Abrir y Cerrar TODO

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
            Uc_Logout();
        }

        #endregion

        #region Abrir Item Menu
        private void AbrirForm_Turnos(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_turnos);
        }

        private void AbrirForm_Historia(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_historia);
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_Roles);

        }
        #endregion

    }
}
