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
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            rolesToolStripMenuItem = new ToolStripMenuItem();
            médicosToolStripMenuItem = new ToolStripMenuItem();
            pacientesToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            historialMédicoToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { administradorToolStripMenuItem, turnosToolStripMenuItem, historialMédicoToolStripMenuItem, salirToolStripMenuItem, toolStripMenuItem1, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1238, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // administradorToolStripMenuItem
            // 
            administradorToolStripMenuItem.BackColor = Color.Gainsboro;
            administradorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCuentaToolStripMenuItem, usuariosToolStripMenuItem, rolesToolStripMenuItem, médicosToolStripMenuItem, pacientesToolStripMenuItem });
            administradorToolStripMenuItem.Image = Properties.Resources.hogar;
            administradorToolStripMenuItem.Margin = new Padding(2);
            administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            administradorToolStripMenuItem.Size = new Size(70, 22);
            administradorToolStripMenuItem.Tag = "TAG001";
            administradorToolStripMenuItem.Text = "Inicio";
            // 
            // miCuentaToolStripMenuItem
            // 
            miCuentaToolStripMenuItem.Image = Properties.Resources.usuario;
            miCuentaToolStripMenuItem.Name = "miCuentaToolStripMenuItem";
            miCuentaToolStripMenuItem.Size = new Size(140, 22);
            miCuentaToolStripMenuItem.Tag = "TAG002";
            miCuentaToolStripMenuItem.Text = "Mi Cuenta";
            miCuentaToolStripMenuItem.Click += miCuentaToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Image = Properties.Resources.nueva_cuenta;
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(140, 22);
            usuariosToolStripMenuItem.Tag = "TAG003";
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // rolesToolStripMenuItem
            // 
            rolesToolStripMenuItem.Image = Properties.Resources.configuracion_del_usuario;
            rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            rolesToolStripMenuItem.Size = new Size(140, 22);
            rolesToolStripMenuItem.Tag = "TAG004";
            rolesToolStripMenuItem.Text = "Permisos";
            rolesToolStripMenuItem.Click += rolesToolStripMenuItem_Click;
            // 
            // médicosToolStripMenuItem
            // 
            médicosToolStripMenuItem.Image = Properties.Resources.medica;
            médicosToolStripMenuItem.Name = "médicosToolStripMenuItem";
            médicosToolStripMenuItem.Size = new Size(140, 22);
            médicosToolStripMenuItem.Tag = "TAG005";
            médicosToolStripMenuItem.Text = "Médicos";
            médicosToolStripMenuItem.Click += médicosToolStripMenuItem_Click;
            // 
            // pacientesToolStripMenuItem
            // 
            pacientesToolStripMenuItem.Image = Properties.Resources.paciente;
            pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            pacientesToolStripMenuItem.Size = new Size(140, 22);
            pacientesToolStripMenuItem.Tag = "TAG006";
            pacientesToolStripMenuItem.Text = "Pacientes";
            pacientesToolStripMenuItem.Click += pacientesToolStripMenuItem_Click;
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.BackColor = Color.Gainsboro;
            turnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            turnosToolStripMenuItem.Image = Properties.Resources.calendario;
            turnosToolStripMenuItem.Margin = new Padding(2);
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(77, 22);
            turnosToolStripMenuItem.Tag = "TAG006";
            turnosToolStripMenuItem.Text = "Turnos";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Image = Properties.Resources.calendario;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(199, 22);
            toolStripMenuItem2.Tag = "TAG010";
            toolStripMenuItem2.Text = "Agenda Médica";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Image = Properties.Resources.calendario;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(199, 22);
            toolStripMenuItem3.Tag = "TAG007";
            toolStripMenuItem3.Text = "Turnos de Pacientes";
            toolStripMenuItem3.Click += AbrirForm_Turnos;
            // 
            // historialMédicoToolStripMenuItem
            // 
            historialMédicoToolStripMenuItem.BackColor = Color.Gainsboro;
            historialMédicoToolStripMenuItem.Image = Properties.Resources.reporte;
            historialMédicoToolStripMenuItem.Margin = new Padding(2);
            historialMédicoToolStripMenuItem.Name = "historialMédicoToolStripMenuItem";
            historialMédicoToolStripMenuItem.Size = new Size(138, 22);
            historialMédicoToolStripMenuItem.Tag = "TAG008";
            historialMédicoToolStripMenuItem.Text = "Historial Médico";
            historialMédicoToolStripMenuItem.Click += AbrirForm_Historia;
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
            toolStripMenuItem1.Tag = "TAG011";
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
            reportesToolStripMenuItem.Tag = "TAG009";
            reportesToolStripMenuItem.Text = "Reportes";
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
        private ToolStripMenuItem miCuentaToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem rolesToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem historialMédicoToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem médicosToolStripMenuItem;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
    }
}