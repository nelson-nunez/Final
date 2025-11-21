using System.Reflection;
using System.Reflection.Emit;
using System.Text.Json;
using SiAP.BE.Seguridad;
using SiAP.BLL.Seguridad;
using SiAP.UI.Controles;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI
{
    public partial class Form_Menu : Form
    {
        #region Vars

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
        private Form_DashBoard form_reportes;
        private Form_Respaldos form_respaldos;
        //Componentes
        private UC_Login UC_Login;

        private string jsonMenus;
        #endregion

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
                CrearMenu();
                MessageBox.Show($"Bienvenido {useractual.Persona.Nombre}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var permisos = useractual.Permisos?.SelectMany(p => p.ObtenerPermisos()).ToList();
                CambiarVisibilidadMenu(menuStrip1.Items, permisos);
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
            //Cambie porque no me actulizaba en cambios en otrs forms
            // Cerrar y liberar el form. 
            if (formulario != null && !formulario.IsDisposed)
            {
                formulario.Close();
                formulario.Dispose();
            }
            T nuevoFormulario = new T();
            nuevoFormulario.MdiParent = this;
            nuevoFormulario.ControlBox = false;
            nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
            nuevoFormulario.StartPosition = FormStartPosition.Manual;
            formulario = nuevoFormulario;
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


        //pruebaaaa
        public string SerializarMenuItems(MenuStrip menu)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyProperties = true,
                IncludeFields = true
            };

            List<string> lista = new();

            foreach (ToolStripItem item in menu.Items)
            {
                string json = JsonSerializer.Serialize(item, options);
                lista.Add(json);
            }

            // Devuelve un JSON con todos los items serializados individualmente
            return "[" + string.Join(",", lista) + "]";
        }

        #region CREAR MENU

        private void CrearMenu()
        {
            // Crear el MenuStrip
            menuStrip1 = new MenuStrip();
            menuStrip1.Dock = DockStyle.Top;
            menuStrip1.BackColor = Color.DimGray;
            menuStrip1.Padding = new Padding(6, 2, 0, 2);
            menuStrip1.ImageScalingSize = new Size(16, 16);
            menuStrip1.Font = new Font("Calibri", 11.25F, FontStyle.Bold);

            // ===== DEFINIR ESTRUCTURA DE MENÚS PRINCIPALES =====
            var menuesPrincipales = new[]
            {
                new { Item = new ToolStripMenuItem("Inicio"), Name = "administradorToolStripMenuItem", Tag = "TAG01", Image = Properties.Resources.hogar, Handler = (EventHandler)null },
                new { Item = new ToolStripMenuItem("Personal"), Name = "aBMPersonalToolStripMenuItem", Tag = "TAG03", Image = Properties.Resources.usuario, Handler = (EventHandler)null },
                new { Item = new ToolStripMenuItem("Turnos"), Name = "turnosToolStripMenuItem", Tag = "TAG06", Image = Properties.Resources.calendario, Handler = (EventHandler)null },
                new { Item = new ToolStripMenuItem("Pacientes"), Name = "historialMédicoToolStripMenuItem", Tag = "TAG09", Image = Properties.Resources.reporte, Handler = (EventHandler)null },
                new { Item = new ToolStripMenuItem("Cobros"), Name = "toolStripMenuItem1", Tag = "TAG12", Image = Properties.Resources.pagar, Handler = (EventHandler)toolStripMenuItem1_Click },
                new { Item = new ToolStripMenuItem("Reportes"), Name = "reportesToolStripMenuItem", Tag = "TAG13", Image = Properties.Resources.analitica, Handler = (EventHandler)reportesToolStripMenuItem_Click },
                new { Item = new ToolStripMenuItem("SISTEMA"), Name = "permisosToolStripMenuItem", Tag = "TAG14", Image = Properties.Resources.proteger, Handler = (EventHandler)null }
            };

            // Aplicar propiedades comunes a menús principales
            foreach (var menu in menuesPrincipales)
            {
                menu.Item.Name = menu.Name;
                menu.Item.Tag = menu.Tag;
                menu.Item.Margin = new Padding(2);
                menu.Item.Padding = new Padding(4, 0, 4, 0);
                menu.Item.BackColor = Color.Gainsboro;
                menu.Item.ForeColor = Color.Black;
                menu.Item.Image = menu.Image;
                menu.Item.ImageAlign = ContentAlignment.MiddleLeft;
                menu.Item.TextImageRelation = TextImageRelation.ImageBeforeText;
                if (menu.Handler != null) menu.Item.Click += menu.Handler;
            }

            // ===== DEFINIR TODOS LOS SUBITEMS =====
            var todosLosSubitems = new[]
            {
                // Menú Inicio
                new[]
                {
                    new { Item = new ToolStripMenuItem("Mi Cuenta"), Name = "miCuentaToolStripMenuItem", Tag = "TAG02", Handler = (EventHandler)miCuentaToolStripMenuItem_Click, Image = Properties.Resources.usuario }
                },
                // Menú Personal
                new[]
                {
                    new { Item = new ToolStripMenuItem("Médicos"), Name = "médicosToolStripMenuItem", Tag = "TAG04", Handler = (EventHandler)médicosToolStripMenuItem_Click, Image = Properties.Resources.medica },
                    new { Item = new ToolStripMenuItem("Secretarios"), Name = "secretariosToolStripMenuItem", Tag = "TAG05", Handler = (EventHandler)secretariosToolStripMenuItem_Click, Image = Properties.Resources.calendario }
                },
                // Menú Turnos
                new[]
                {
                    new { Item = new ToolStripMenuItem("Agenda Médica"), Name = "toolStripMenuItem2", Tag = "TAG07", Handler = (EventHandler)toolStripMenuItem2_Click, Image = Properties.Resources.calendario },
                    new { Item = new ToolStripMenuItem("Turnos de Pacientes"), Name = "toolStripMenuItem3", Tag = "TAG08", Handler = (EventHandler)toolStripMenuItem3_Click, Image = Properties.Resources.calendario }
                },
                // Menú Pacientes
                new[]
                {
                    new { Item = new ToolStripMenuItem("Alta Pacientes"), Name = "pacientesToolStripMenuItem", Tag = "TAG10", Handler = (EventHandler)pacientesToolStripMenuItem_Click_1, Image = Properties.Resources.paciente },
                    new { Item = new ToolStripMenuItem("Historial y Consultas"), Name = "historialMédicoToolStripMenuItem1", Tag = "TAG11", Handler = (EventHandler)historialMédicoToolStripMenuItem1_Click, Image = Properties.Resources.reporte }
                },
                Array.Empty<dynamic>(), // Cobros (sin subitems)
                Array.Empty<dynamic>(), // Reportes (sin subitems)
                // Menú Sistema
                new[]
                {
                    new { Item = new ToolStripMenuItem("Usuarios"), Name = "usuariosToolStripMenuItem", Tag = "TAG15", Handler = (EventHandler)usuariosToolStripMenuItem_Click, Image = Properties.Resources.configuracion_del_usuario },
                    new { Item = new ToolStripMenuItem("Permisos"), Name = "rolesToolStripMenuItem", Tag = "TAG16", Handler = (EventHandler)rolesToolStripMenuItem_Click, Image = Properties.Resources.configuracion_del_usuario },
                    new { Item = new ToolStripMenuItem("Respaldo de Datos"), Name = "respaldoDeDatosToolStripMenuItem", Tag = "TAG17", Handler = (EventHandler)respaldoDeDatosToolStripMenuItem_Click, Image = Properties.Resources.guardar }
                }
            };

            // Aplicar propiedades comunes a todos los subitems
            for (int i = 0; i < todosLosSubitems.Length; i++)
            {
                foreach (var subitem in todosLosSubitems[i])
                {
                    subitem.Item.Name = subitem.Name;
                    subitem.Item.Tag = subitem.Tag;
                    subitem.Item.Margin = new Padding(0);
                    subitem.Item.Padding = new Padding(0, 1, 0, 1);
                    subitem.Item.BackColor = Color.Transparent;
                    subitem.Item.ForeColor = Color.Black;
                    subitem.Item.Click += subitem.Handler;
                    subitem.Item.Image = subitem.Image;
                    subitem.Item.ImageAlign = ContentAlignment.MiddleLeft;
                    subitem.Item.TextImageRelation = TextImageRelation.ImageBeforeText;

                    menuesPrincipales[i].Item.DropDownItems.Add(subitem.Item);
                }
            }

            // ===== MENÚS ESPECIALES (derecha) =====
            var menuSalir = new ToolStripMenuItem("Salir")
            {
                Name = "salirToolStripMenuItem",
                Tag = "EXIT",
                Alignment = ToolStripItemAlignment.Right,
                Margin = new Padding(0, 0, 10, 0),
                Padding = new Padding(4, 0, 4, 0),
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Image = Properties.Resources.cerrar,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            menuSalir.Click += CerrarTodosLosFormulariosHijos;

            var menuUsuario = new ToolStripMenuItem(GestionUsuario.UsuarioLogueado.Username)
            {
                Name = "toolStrip_logged_User",
                Tag = "EXIT",
                Alignment = ToolStripItemAlignment.Right,
                Margin = new Padding(0, 0, 5, 0),
                Padding = new Padding(4, 0, 4, 0),
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Image = Properties.Resources.usuario,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };

            // Agregar todos los menús al MenuStrip
            menuStrip1.Items.AddRange(menuesPrincipales.Select(m => m.Item).ToArray());
            menuStrip1.Items.Add(menuSalir);
            menuStrip1.Items.Add(menuUsuario);

            // Agregar el MenuStrip al formulario
            this.Controls.Add(menuStrip1);
            this.MainMenuStrip = menuStrip1;
        }

        #endregion

        //#region PRUEBASSSSSSSSSSSSSSSSSSSSSSSS

        //private void CrearMenu()
        //{
        //    // Crear el MenuStrip
        //    menuStrip1 = new MenuStrip();
        //    menuStrip1.Dock = DockStyle.Top;
        //    menuStrip1.BackColor = Color.DimGray;
        //    menuStrip1.Padding = new Padding(6, 2, 0, 2);
        //    menuStrip1.ImageScalingSize = new Size(16, 16);
        //    menuStrip1.Font = new Font("Calibri", 11.25F, FontStyle.Bold);

        //    // ===== DEFINIR ESTRUCTURA DE MENÚS PRINCIPALES =====
        //    var menuesPrincipales = new[]
        //    {
        //        new { Item = new ToolStripMenuItem("Inicio"), Name = "administradorToolStripMenuItem", Tag = "TAG01", Image = Properties.Resources.hogar, Handler = (EventHandler)null },
        //        new { Item = new ToolStripMenuItem("Personal"), Name = "aBMPersonalToolStripMenuItem", Tag = "TAG03", Image = Properties.Resources.usuario, Handler = (EventHandler)null },
        //        new { Item = new ToolStripMenuItem("Turnos"), Name = "turnosToolStripMenuItem", Tag = "TAG06", Image = Properties.Resources.calendario, Handler = (EventHandler)null },
        //        new { Item = new ToolStripMenuItem("Pacientes"), Name = "historialMédicoToolStripMenuItem", Tag = "TAG09", Image = Properties.Resources.reporte, Handler = (EventHandler)null },
        //        new { Item = new ToolStripMenuItem("Cobros"), Name = "toolStripMenuItem1", Tag = "TAG12", Image = Properties.Resources.pagar, Handler = (EventHandler)toolStripMenuItem1_Click },
        //        new { Item = new ToolStripMenuItem("Reportes"), Name = "reportesToolStripMenuItem", Tag = "TAG13", Image = Properties.Resources.analitica, Handler = (EventHandler)reportesToolStripMenuItem_Click },
        //        new { Item = new ToolStripMenuItem("SISTEMA"), Name = "permisosToolStripMenuItem", Tag = "TAG14", Image = Properties.Resources.proteger, Handler = (EventHandler)null }
        //    };

        //    // Aplicar propiedades comunes a menús principales
        //    foreach (var menu in menuesPrincipales)
        //    {
        //        menu.Item.Name = menu.Name;
        //        menu.Item.Tag = menu.Tag;
        //        menu.Item.Margin = new Padding(2);
        //        menu.Item.Padding = new Padding(4, 0, 4, 0);
        //        menu.Item.BackColor = Color.Gainsboro;
        //        menu.Item.ForeColor = Color.Black;
        //        menu.Item.Image = menu.Image;
        //        menu.Item.ImageAlign = ContentAlignment.MiddleLeft;
        //        menu.Item.TextImageRelation = TextImageRelation.ImageBeforeText;

        //        // Asignar el evento si existe
        //        if (menu.Handler != null)
        //        {
        //            menu.Item.Click += menu.Handler;
        //        }
        //    }

        //    // ===== MENÚ INICIO - Subitems =====
        //    var subitemsInicio = new[]
        //    {
        //        new { Item = new ToolStripMenuItem("Mi Cuenta"), Name = "miCuentaToolStripMenuItem", Tag = "TAG02", Handler = (EventHandler)miCuentaToolStripMenuItem_Click, Image = Properties.Resources.usuario }
        //    };

        //    // ===== MENÚ PERSONAL - Subitems =====
        //    var subitemsPersonal = new[]
        //    {
        //        new { Item = new ToolStripMenuItem("Médicos"), Name = "médicosToolStripMenuItem", Tag = "TAG04", Handler = (EventHandler)médicosToolStripMenuItem_Click, Image = Properties.Resources.medica },
        //        new { Item = new ToolStripMenuItem("Secretarios"), Name = "secretariosToolStripMenuItem", Tag = "TAG05", Handler = (EventHandler)secretariosToolStripMenuItem_Click, Image = Properties.Resources.calendario }
        //    };

        //    // ===== MENÚ TURNOS - Subitems =====
        //    var subitemsTurnos = new[]
        //    {
        //        new { Item = new ToolStripMenuItem("Agenda Médica"), Name = "toolStripMenuItem2", Tag = "TAG07", Handler = (EventHandler)toolStripMenuItem2_Click, Image = Properties.Resources.calendario },
        //        new { Item = new ToolStripMenuItem("Turnos de Pacientes"), Name = "toolStripMenuItem3", Tag = "TAG08", Handler = (EventHandler)toolStripMenuItem3_Click, Image = Properties.Resources.calendario }
        //    };

        //    // ===== MENÚ PACIENTES - Subitems =====
        //    var subitemsPacientes = new[]
        //    {
        //        new { Item = new ToolStripMenuItem("Alta Pacientes"), Name = "pacientesToolStripMenuItem", Tag = "TAG10", Handler = (EventHandler)pacientesToolStripMenuItem_Click_1, Image = Properties.Resources.paciente },
        //        new { Item = new ToolStripMenuItem("Historial y Consultas"), Name = "historialMédicoToolStripMenuItem1", Tag = "TAG11", Handler = (EventHandler)historialMédicoToolStripMenuItem1_Click, Image = Properties.Resources.reporte }
        //    };

        //    // ===== MENÚ SISTEMA - Subitems =====
        //    var subitemsSistema = new[]
        //    {
        //        new { Item = new ToolStripMenuItem("Usuarios"), Name = "usuariosToolStripMenuItem", Tag = "TAG15", Handler = (EventHandler)usuariosToolStripMenuItem_Click, Image = Properties.Resources.configuracion_del_usuario },
        //        new { Item = new ToolStripMenuItem("Permisos"), Name = "rolesToolStripMenuItem", Tag = "TAG16", Handler = (EventHandler)rolesToolStripMenuItem_Click, Image = Properties.Resources.configuracion_del_usuario },
        //        new { Item = new ToolStripMenuItem("Respaldo de Datos"), Name = "respaldoDeDatosToolStripMenuItem", Tag = "TAG17", Handler = (EventHandler)respaldoDeDatosToolStripMenuItem_Click, Image = Properties.Resources.guardar }
        //    };

        //    // Agrupar todos los subitems - TODOS deben tener las mismas propiedades
        //    var todosLosSubitems = new[]
        //    {
        //        subitemsInicio,
        //        subitemsPersonal,
        //        subitemsTurnos,
        //        subitemsPacientes,
        //        Array.Empty<dynamic>(), // Cobros (sin subitems)
        //        Array.Empty<dynamic>(), // Reportes (sin subitems)
        //        subitemsSistema
        //    };

        //    // Aplicar propiedades comunes a todos los subitems y asignar handlers
        //    for (int i = 0; i < todosLosSubitems.Length; i++)
        //    {
        //        if (todosLosSubitems[i].Length > 0) // Verificar que tenga elementos
        //        {
        //            foreach (var subitem in todosLosSubitems[i])
        //            {
        //                if (subitem.Item != null)
        //                {
        //                    subitem.Item.Name = subitem.Name;
        //                    subitem.Item.Tag = subitem.Tag;
        //                    subitem.Item.Margin = new Padding(0);
        //                    subitem.Item.Padding = new Padding(0, 1, 0, 1);
        //                    subitem.Item.BackColor = Color.Transparent;
        //                    subitem.Item.ForeColor = Color.Black;
        //                    subitem.Item.Click += subitem.Handler;
        //                    subitem.Item.Image = subitem.Image;
        //                    subitem.Item.ImageAlign = ContentAlignment.MiddleLeft;
        //                    subitem.Item.TextImageRelation = TextImageRelation.ImageBeforeText;

        //                    // Agregar al menú principal correspondiente
        //                    menuesPrincipales[i].Item.DropDownItems.Add(subitem.Item);
        //                }
        //            }
        //        }
        //    }

        //    // Aplicar propiedades comunes a todos los subitems y asignar handlers
        //    for (int i = 0; i < todosLosSubitems.Length; i++)
        //    {
        //        foreach (var subitem in todosLosSubitems[i])
        //        {
        //            if (subitem.Item != null)
        //            {
        //                subitem.Item.Name = subitem.Name;
        //                subitem.Item.Tag = subitem.Tag;
        //                subitem.Item.Margin = new Padding(0);
        //                subitem.Item.Padding = new Padding(0, 1, 0, 1);
        //                subitem.Item.BackColor = Color.Transparent;
        //                subitem.Item.ForeColor = Color.Black;
        //                subitem.Item.Click += subitem.Handler;
        //                subitem.Item.Image = subitem.Image;
        //                subitem.Item.ImageAlign = ContentAlignment.MiddleLeft;
        //                subitem.Item.TextImageRelation = TextImageRelation.ImageBeforeText;

        //                // Agregar al menú principal correspondiente
        //                menuesPrincipales[i].Item.DropDownItems.Add(subitem.Item);
        //            }
        //        }
        //    }

        //    // ===== MENÚS ESPECIALES (derecha) =====
        //    var menuUsuario = new ToolStripMenuItem(GestionUsuario.UsuarioLogueado.Username);
        //    menuUsuario.Name = "toolStrip_logged_User";
        //    menuUsuario.Tag = "EXIT";
        //    menuUsuario.Alignment = ToolStripItemAlignment.Right;
        //    menuUsuario.Margin = new Padding(0, 0, 5, 0);
        //    menuUsuario.Padding = new Padding(4, 0, 4, 0);
        //    menuUsuario.BackColor = Color.Transparent;
        //    menuUsuario.ForeColor = Color.Black;
        //    menuUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        //    menuUsuario.Image = Properties.Resources.usuario;
        //    menuUsuario.ImageAlign = ContentAlignment.MiddleLeft;
        //    menuUsuario.TextImageRelation = TextImageRelation.ImageBeforeText;

        //    var menuSalir = new ToolStripMenuItem("Salir");
        //    menuSalir.Name = "salirToolStripMenuItem";
        //    menuSalir.Tag = "EXIT";
        //    menuSalir.Click += CerrarTodosLosFormulariosHijos;
        //    menuSalir.Alignment = ToolStripItemAlignment.Right;
        //    menuSalir.Margin = new Padding(0, 0, 10, 0);
        //    menuSalir.Padding = new Padding(4, 0, 4, 0);
        //    menuSalir.BackColor = Color.Transparent;
        //    menuSalir.ForeColor = Color.Black;
        //    menuSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        //    menuSalir.Image = Properties.Resources.cerrar;
        //    menuSalir.ImageAlign = ContentAlignment.MiddleLeft;
        //    menuSalir.TextImageRelation = TextImageRelation.ImageBeforeText;

        //    // Agregar todos los menús al MenuStrip
        //    menuStrip1.Items.AddRange(menuesPrincipales.Select(m => m.Item).ToArray());
        //    menuStrip1.Items.Add(menuSalir);
        //    menuStrip1.Items.Add(menuUsuario);

        //    // Agregar el MenuStrip al formulario
        //    this.Controls.Add(menuStrip1);
        //    this.MainMenuStrip = menuStrip1;
        //}

        //#endregion
    }
}
