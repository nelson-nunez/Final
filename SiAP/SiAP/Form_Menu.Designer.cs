namespace SiAP.UI
{
    partial class Form_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            administradorToolStripMenuItem = new ToolStripMenuItem();
            cToolStripMenuItem = new ToolStripMenuItem();
            miCuentaToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            rolesToolStripMenuItem = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            historialMédicoToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { administradorToolStripMenuItem, turnosToolStripMenuItem, historialMédicoToolStripMenuItem, reportesToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1284, 26);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // administradorToolStripMenuItem
            // 
            administradorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cToolStripMenuItem, miCuentaToolStripMenuItem, usuariosToolStripMenuItem, rolesToolStripMenuItem, permisosToolStripMenuItem });
            administradorToolStripMenuItem.Image = Properties.Resources.hogar;
            administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            administradorToolStripMenuItem.Size = new Size(70, 22);
            administradorToolStripMenuItem.Tag = "TAG001";
            administradorToolStripMenuItem.Text = "Inicio";
            // 
            // cToolStripMenuItem
            // 
            cToolStripMenuItem.Image = Properties.Resources.contrasena;
            cToolStripMenuItem.Name = "cToolStripMenuItem";
            cToolStripMenuItem.Size = new Size(172, 22);
            cToolStripMenuItem.Tag = "TAG002";
            cToolStripMenuItem.Text = "Modificar Clave";
            // 
            // miCuentaToolStripMenuItem
            // 
            miCuentaToolStripMenuItem.Image = Properties.Resources.usuario;
            miCuentaToolStripMenuItem.Name = "miCuentaToolStripMenuItem";
            miCuentaToolStripMenuItem.Size = new Size(172, 22);
            miCuentaToolStripMenuItem.Tag = "TAG003";
            miCuentaToolStripMenuItem.Text = "Mi Cuenta";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Image = Properties.Resources.nueva_cuenta;
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(172, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // rolesToolStripMenuItem
            // 
            rolesToolStripMenuItem.Image = Properties.Resources.configuracion_del_usuario;
            rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            rolesToolStripMenuItem.Size = new Size(172, 22);
            rolesToolStripMenuItem.Tag = "TAG004";
            rolesToolStripMenuItem.Text = "Roles";
            rolesToolStripMenuItem.Click += rolesToolStripMenuItem_Click;
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.Image = Properties.Resources.proteger;
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(172, 22);
            permisosToolStripMenuItem.Tag = "TAG005";
            permisosToolStripMenuItem.Text = "Permisos";
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.Image = Properties.Resources.calendario;
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(77, 22);
            turnosToolStripMenuItem.Tag = "TAG006";
            turnosToolStripMenuItem.Text = "Turnos";
            turnosToolStripMenuItem.Click += AbrirForm_Turnos;
            // 
            // historialMédicoToolStripMenuItem
            // 
            historialMédicoToolStripMenuItem.Image = Properties.Resources.reporte;
            historialMédicoToolStripMenuItem.Name = "historialMédicoToolStripMenuItem";
            historialMédicoToolStripMenuItem.Size = new Size(138, 22);
            historialMédicoToolStripMenuItem.Tag = "TAG007";
            historialMédicoToolStripMenuItem.Text = "Historial Médico";
            historialMédicoToolStripMenuItem.Click += AbrirForm_Historia;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Image = Properties.Resources.analitica;
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(92, 22);
            reportesToolStripMenuItem.Tag = "TAG008";
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            salirToolStripMenuItem.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salirToolStripMenuItem.Image = Properties.Resources.cerrar;
            salirToolStripMenuItem.Margin = new Padding(0, 0, 10, 0);
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(63, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += CerrarTodosLosFormulariosHijos;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.logo;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1284, 761);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "Form_Menu";
            Text = "Form_Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem administradorToolStripMenuItem;
        private ToolStripMenuItem cToolStripMenuItem;
        private ToolStripMenuItem miCuentaToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private ToolStripMenuItem rolesToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem historialMédicoToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}