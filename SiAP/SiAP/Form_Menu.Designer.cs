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
            miCuentaToolStripMenuItem = new ToolStripMenuItem();
            aBMPersonalToolStripMenuItem = new ToolStripMenuItem();
            médicosToolStripMenuItem = new ToolStripMenuItem();
            secretariosToolStripMenuItem = new ToolStripMenuItem();
            pacientesToolStripMenuItem = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            rolesToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            historialMédicoToolStripMenuItem = new ToolStripMenuItem();
            historialMédicoToolStripMenuItem1 = new ToolStripMenuItem();
            recetasToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.GrayText;
            menuStrip1.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { administradorToolStripMenuItem, aBMPersonalToolStripMenuItem, permisosToolStripMenuItem, turnosToolStripMenuItem, historialMédicoToolStripMenuItem, salirToolStripMenuItem, toolStripMenuItem1, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1238, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // administradorToolStripMenuItem
            // 
            administradorToolStripMenuItem.BackColor = Color.Gainsboro;
            administradorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCuentaToolStripMenuItem });
            administradorToolStripMenuItem.Image = Properties.Resources.hogar;
            administradorToolStripMenuItem.Margin = new Padding(2);
            administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            administradorToolStripMenuItem.Size = new Size(70, 22);
            administradorToolStripMenuItem.Tag = "";
            administradorToolStripMenuItem.Text = "Inicio";
            // 
            // miCuentaToolStripMenuItem
            // 
            miCuentaToolStripMenuItem.Image = Properties.Resources.usuario;
            miCuentaToolStripMenuItem.Name = "miCuentaToolStripMenuItem";
            miCuentaToolStripMenuItem.Size = new Size(180, 22);
            miCuentaToolStripMenuItem.Tag = "TAG01";
            miCuentaToolStripMenuItem.Text = "Mi Cuenta";
            miCuentaToolStripMenuItem.Click += miCuentaToolStripMenuItem_Click;
            // 
            // aBMPersonalToolStripMenuItem
            // 
            aBMPersonalToolStripMenuItem.BackColor = Color.Gainsboro;
            aBMPersonalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { médicosToolStripMenuItem, secretariosToolStripMenuItem, pacientesToolStripMenuItem });
            aBMPersonalToolStripMenuItem.Margin = new Padding(2);
            aBMPersonalToolStripMenuItem.Name = "aBMPersonalToolStripMenuItem";
            aBMPersonalToolStripMenuItem.Size = new Size(107, 22);
            aBMPersonalToolStripMenuItem.Text = "ABM Personal";
            // 
            // médicosToolStripMenuItem
            // 
            médicosToolStripMenuItem.Image = Properties.Resources.medica;
            médicosToolStripMenuItem.Name = "médicosToolStripMenuItem";
            médicosToolStripMenuItem.Size = new Size(180, 22);
            médicosToolStripMenuItem.Tag = "TAG02";
            médicosToolStripMenuItem.Text = "Médicos";
            médicosToolStripMenuItem.Click += médicosToolStripMenuItem_Click;
            // 
            // secretariosToolStripMenuItem
            // 
            secretariosToolStripMenuItem.Image = Properties.Resources.calendario;
            secretariosToolStripMenuItem.Name = "secretariosToolStripMenuItem";
            secretariosToolStripMenuItem.Size = new Size(180, 22);
            secretariosToolStripMenuItem.Tag = "TAG03";
            secretariosToolStripMenuItem.Text = "Secretarios";
            secretariosToolStripMenuItem.Click += secretariosToolStripMenuItem_Click;
            // 
            // pacientesToolStripMenuItem
            // 
            pacientesToolStripMenuItem.Image = Properties.Resources.paciente;
            pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            pacientesToolStripMenuItem.Size = new Size(180, 22);
            pacientesToolStripMenuItem.Tag = "TAG04";
            pacientesToolStripMenuItem.Text = "Pacientes";
            pacientesToolStripMenuItem.Click += pacientesToolStripMenuItem_Click;
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.BackColor = Color.Gainsboro;
            permisosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, rolesToolStripMenuItem });
            permisosToolStripMenuItem.Margin = new Padding(2);
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(77, 22);
            permisosToolStripMenuItem.Text = "Permisos";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Image = Properties.Resources.nueva_cuenta;
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(180, 22);
            usuariosToolStripMenuItem.Tag = "TAG05";
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // rolesToolStripMenuItem
            // 
            rolesToolStripMenuItem.Image = Properties.Resources.configuracion_del_usuario;
            rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            rolesToolStripMenuItem.Size = new Size(180, 22);
            rolesToolStripMenuItem.Tag = "TAG06";
            rolesToolStripMenuItem.Text = "Permisos";
            rolesToolStripMenuItem.Click += rolesToolStripMenuItem_Click;
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.BackColor = Color.Gainsboro;
            turnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            turnosToolStripMenuItem.Image = Properties.Resources.calendario;
            turnosToolStripMenuItem.Margin = new Padding(2);
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(77, 22);
            turnosToolStripMenuItem.Tag = "";
            turnosToolStripMenuItem.Text = "Turnos";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Image = Properties.Resources.calendario;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(199, 22);
            toolStripMenuItem2.Tag = "TAG07";
            toolStripMenuItem2.Text = "Agenda Médica";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Image = Properties.Resources.calendario;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(199, 22);
            toolStripMenuItem3.Tag = "TAG08";
            toolStripMenuItem3.Text = "Turnos de Pacientes";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // historialMédicoToolStripMenuItem
            // 
            historialMédicoToolStripMenuItem.BackColor = Color.Gainsboro;
            historialMédicoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { historialMédicoToolStripMenuItem1, recetasToolStripMenuItem });
            historialMédicoToolStripMenuItem.Image = Properties.Resources.reporte;
            historialMédicoToolStripMenuItem.Margin = new Padding(2);
            historialMédicoToolStripMenuItem.Name = "historialMédicoToolStripMenuItem";
            historialMédicoToolStripMenuItem.Size = new Size(96, 22);
            historialMédicoToolStripMenuItem.Tag = "";
            historialMédicoToolStripMenuItem.Text = "Pacientes";
            // 
            // historialMédicoToolStripMenuItem1
            // 
            historialMédicoToolStripMenuItem1.Image = Properties.Resources.reporte;
            historialMédicoToolStripMenuItem1.Name = "historialMédicoToolStripMenuItem1";
            historialMédicoToolStripMenuItem1.Size = new Size(180, 22);
            historialMédicoToolStripMenuItem1.Tag = "TAG09";
            historialMédicoToolStripMenuItem1.Text = "Historial Médico";
            historialMédicoToolStripMenuItem1.Click += historialMédicoToolStripMenuItem1_Click;
            // 
            // recetasToolStripMenuItem
            // 
            recetasToolStripMenuItem.Image = Properties.Resources.reporte;
            recetasToolStripMenuItem.Name = "recetasToolStripMenuItem";
            recetasToolStripMenuItem.Size = new Size(180, 22);
            recetasToolStripMenuItem.Tag = "TAG10";
            recetasToolStripMenuItem.Text = "Recetas";
            recetasToolStripMenuItem.Click += recetasToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            salirToolStripMenuItem.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salirToolStripMenuItem.Image = Properties.Resources.cerrar;
            salirToolStripMenuItem.Margin = new Padding(0, 0, 10, 0);
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(63, 26);
            salirToolStripMenuItem.Tag = "EXIT";
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += CerrarTodosLosFormulariosHijos;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.Gainsboro;
            toolStripMenuItem1.Image = Properties.Resources.pagar;
            toolStripMenuItem1.Margin = new Padding(2);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(79, 22);
            toolStripMenuItem1.Tag = "TAG11";
            toolStripMenuItem1.Text = "Cobros";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.BackColor = Color.Gainsboro;
            reportesToolStripMenuItem.Image = Properties.Resources.analitica;
            reportesToolStripMenuItem.Margin = new Padding(2);
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(92, 22);
            reportesToolStripMenuItem.Tag = "TAG12";
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.logo;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1238, 765);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "Form_Menu";
            Text = "Sistema de Administración de Policonsultorios";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem administradorToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem historialMédicoToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem aBMPersonalToolStripMenuItem;
        private ToolStripMenuItem médicosToolStripMenuItem;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem rolesToolStripMenuItem;
        private ToolStripMenuItem secretariosToolStripMenuItem;
        private ToolStripMenuItem miCuentaToolStripMenuItem;
        private ToolStripMenuItem historialMédicoToolStripMenuItem1;
        private ToolStripMenuItem recetasToolStripMenuItem;
    }
}