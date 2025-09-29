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
        private Form_CRUD_Usuarios form_users;
        private Form_Config_Usuario form_config_user;
        private Form_CRUD_Medicos form_medic;
        private Form_CRUD_Pacientes form_paciente;
        private Form_Cobros form_cobros;
        private Form_Agenda form_Agenda;
        //Componentes
        private UC_Login UC_Login;

        public Form_Menu()
        {
            InitializeComponent();
            // Hacer que esta ventana sea un contenedor MDI
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
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
                MessageBox.Show($"Bienvenido {useractual.Nombre}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (!string.IsNullOrEmpty(tag) && (tag.Equals("TAG") || permisosHabilitados.Any(p => p.Codigo.Equals(tag))) || tag.Equals("EXIT"))
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
                nuevoFormulario.StartPosition = FormStartPosition.Manual;
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

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_users);
        }
        private void miCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_config_user);
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_medic);
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_paciente);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_cobros);
        }

        #endregion

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_Agenda);            
        }
    }
}
