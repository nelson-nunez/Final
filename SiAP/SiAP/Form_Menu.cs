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
        private Form_CRUD_Secretario form_secretario;
        private Form_Cobros form_cobros;
        private Form_Agenda form_Agenda;
        private Form_Receta form_receta;
        private Form_DashBoard form_reportes;
        private Form_Respaldos form_respaldos;
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
                MessageBox.Show($"Bienvenido {useractual.Persona.Nombre}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menuStrip1.Visible = true;
                CambiarVisibilidadMenu(menuStrip1.Items, useractual.Permiso.ObtenerPermisos());
                UC_Login.Visible = false;
                toolStrip_logged_User.Text = useractual.Persona.NombreCompleto.ToString();
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
            foreach (ToolStripMenuItem item in dropDownItems.OfType<ToolStripMenuItem>())
            {
                CambiarVisibilidadMenuRecursivo(item, permisosHabilitados);
            }
        }

        private bool CambiarVisibilidadMenuRecursivo(ToolStripMenuItem menuItem, IList<Permiso> permisosHabilitados)
        {
            string tag = menuItem.Tag as string;
            bool tieneHijosVisibles = false;

            if (menuItem.HasDropDownItems)
            {
                foreach (ToolStripMenuItem subItem in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    bool hijoVisible = CambiarVisibilidadMenuRecursivo(subItem, permisosHabilitados);
                    tieneHijosVisibles |= hijoVisible;
                }
            }
            bool esVisible = false;

            if (!string.IsNullOrEmpty(tag))
            {
                // Tags especiales siempre visibles
                if (tag.Equals("TAG") || tag.Equals("EXIT"))
                {
                    esVisible = true;
                }
                // Si tiene permiso habilitado
                else if (permisosHabilitados.Any(p => p.Codigo.Equals(tag, StringComparison.OrdinalIgnoreCase)))
                {
                    esVisible = true;
                }
            }

            if (tieneHijosVisibles)
            {
                esVisible = true;
            }
            menuItem.Visible = esVisible;
            return esVisible;
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

        private void secretariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_secretario);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_users);
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_Roles);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_Agenda);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_turnos);
        }

        private void historialMédicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_historia);
        }

        private void recetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_receta);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_cobros);
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_reportes);
        }

        private void pacientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_paciente);
        }

        private void respaldoDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_respaldos);
        }

        #endregion

    }
}
