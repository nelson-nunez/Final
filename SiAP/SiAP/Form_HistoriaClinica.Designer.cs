namespace SiAP.UI
{
    partial class Form_HistoriaClinica
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
            groupBox1 = new GroupBox();
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
            groupBox3 = new GroupBox();
            button_seleccionar_paciente = new Button();
            label_plan_os = new Label();
            label10 = new Label();
            label8 = new Label();
            label9 = new Label();
            label3 = new Label();
            label_nombre_completo = new Label();
            label_ooss = new Label();
            label_nro_socio = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            button4 = new Button();
            label6 = new Label();
            richText_historia_Clinica = new RichTextBox();
            tabPage2 = new TabPage();
            treeView_historia_cli = new TreeView();
            label4 = new Label();
            richTextBox_tratamiento = new RichTextBox();
            label2 = new Label();
            richTextBox_observaciones = new RichTextBox();
            label1 = new Label();
            richTextBox_motivo = new RichTextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            tabPage3 = new TabPage();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPage2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(uC_Buscar_Paciente1);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 715);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Historia Clínica";
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(383, 244);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 226);
            uC_Buscar_Paciente1.TabIndex = 53;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(button_seleccionar_paciente);
            groupBox3.Controls.Add(label_plan_os);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label_nombre_completo);
            groupBox3.Controls.Add(label_ooss);
            groupBox3.Controls.Add(label_nro_socio);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1198, 74);
            groupBox3.TabIndex = 30;
            groupBox3.TabStop = false;
            groupBox3.Text = "Paciente";
            // 
            // button_seleccionar_paciente
            // 
            button_seleccionar_paciente.BackColor = SystemColors.ActiveCaption;
            button_seleccionar_paciente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_seleccionar_paciente.Location = new Point(32, 22);
            button_seleccionar_paciente.Name = "button_seleccionar_paciente";
            button_seleccionar_paciente.Size = new Size(103, 39);
            button_seleccionar_paciente.TabIndex = 12;
            button_seleccionar_paciente.Text = "Buscar Paciente";
            button_seleccionar_paciente.UseVisualStyleBackColor = false;
            button_seleccionar_paciente.Click += button_seleccionar_paciente_Click;
            // 
            // label_plan_os
            // 
            label_plan_os.AutoSize = true;
            label_plan_os.Location = new Point(554, 46);
            label_plan_os.Name = "label_plan_os";
            label_plan_os.Size = new Size(49, 15);
            label_plan_os.TabIndex = 49;
            label_plan_os.Text = "..............";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(160, 22);
            label10.Name = "label10";
            label10.Size = new Size(109, 15);
            label10.TabIndex = 43;
            label10.Text = "Nombre Completo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(227, 46);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 44;
            label8.Text = "OOSS: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(512, 46);
            label9.Name = "label9";
            label9.Size = new Size(36, 15);
            label9.TabIndex = 45;
            label9.Text = "Plan: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(738, 46);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 46;
            label3.Text = "Nro. Socio:";
            // 
            // label_nombre_completo
            // 
            label_nombre_completo.AutoSize = true;
            label_nombre_completo.Location = new Point(276, 22);
            label_nombre_completo.Name = "label_nombre_completo";
            label_nombre_completo.Size = new Size(49, 15);
            label_nombre_completo.TabIndex = 47;
            label_nombre_completo.Text = "..............";
            // 
            // label_ooss
            // 
            label_ooss.AutoSize = true;
            label_ooss.Location = new Point(276, 46);
            label_ooss.Name = "label_ooss";
            label_ooss.Size = new Size(49, 15);
            label_ooss.TabIndex = 48;
            label_ooss.Text = "..............";
            // 
            // label_nro_socio
            // 
            label_nro_socio.AutoSize = true;
            label_nro_socio.Location = new Point(809, 46);
            label_nro_socio.Name = "label_nro_socio";
            label_nro_socio.Size = new Size(49, 15);
            label_nro_socio.TabIndex = 50;
            label_nro_socio.Text = "..............";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(6, 102);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1198, 599);
            tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(flowLayoutPanel2);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(richText_historia_Clinica);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1190, 571);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Historia Clínica";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Location = new Point(508, 532);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(193, 33);
            flowLayoutPanel2.TabIndex = 65;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button1.Image = Properties.Resources.edit;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 26;
            button1.Text = "Editar";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSeaGreen;
            button4.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button4.Image = Properties.Resources.save;
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.Location = new Point(99, 3);
            button4.Name = "button4";
            button4.Size = new Size(90, 27);
            button4.TabIndex = 25;
            button4.Text = "Guardar";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 64;
            label6.Text = "Descripción:";
            // 
            // richText_historia_Clinica
            // 
            richText_historia_Clinica.Location = new Point(6, 37);
            richText_historia_Clinica.Name = "richText_historia_Clinica";
            richText_historia_Clinica.ScrollBars = RichTextBoxScrollBars.Vertical;
            richText_historia_Clinica.Size = new Size(1178, 489);
            richText_historia_Clinica.TabIndex = 63;
            richText_historia_Clinica.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.WhiteSmoke;
            tabPage2.Controls.Add(treeView_historia_cli);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(richTextBox_tratamiento);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(richTextBox_observaciones);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(richTextBox_motivo);
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1190, 571);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Consultas";
            // 
            // treeView_historia_cli
            // 
            treeView_historia_cli.Location = new Point(6, 14);
            treeView_historia_cli.Name = "treeView_historia_cli";
            treeView_historia_cli.Size = new Size(229, 510);
            treeView_historia_cli.TabIndex = 60;
            treeView_historia_cli.AfterSelect += treeView_historia_cli_AfterSelect;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(250, 356);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 66;
            label4.Text = "Tratamiento";
            // 
            // richTextBox_tratamiento
            // 
            richTextBox_tratamiento.Location = new Point(250, 374);
            richTextBox_tratamiento.Name = "richTextBox_tratamiento";
            richTextBox_tratamiento.Size = new Size(934, 150);
            richTextBox_tratamiento.TabIndex = 65;
            richTextBox_tratamiento.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 185);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 64;
            label2.Text = "Observaciones";
            // 
            // richTextBox_observaciones
            // 
            richTextBox_observaciones.Location = new Point(250, 203);
            richTextBox_observaciones.Name = "richTextBox_observaciones";
            richTextBox_observaciones.Size = new Size(934, 150);
            richTextBox_observaciones.TabIndex = 63;
            richTextBox_observaciones.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 14);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 62;
            label1.Text = "Motivo";
            // 
            // richTextBox_motivo
            // 
            richTextBox_motivo.Location = new Point(250, 32);
            richTextBox_motivo.Name = "richTextBox_motivo";
            richTextBox_motivo.Size = new Size(934, 150);
            richTextBox_motivo.TabIndex = 61;
            richTextBox_motivo.Text = "";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(491, 530);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(245, 33);
            flowLayoutPanel1.TabIndex = 59;
            // 
            // button_Limpiar
            // 
            button_Limpiar.BackColor = Color.SandyBrown;
            button_Limpiar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Limpiar.Image = Properties.Resources.clear;
            button_Limpiar.ImageAlign = ContentAlignment.MiddleRight;
            button_Limpiar.Location = new Point(3, 3);
            button_Limpiar.Name = "button_Limpiar";
            button_Limpiar.Size = new Size(74, 27);
            button_Limpiar.TabIndex = 23;
            button_Limpiar.Text = "Limpiar";
            button_Limpiar.TextAlign = ContentAlignment.MiddleLeft;
            button_Limpiar.UseVisualStyleBackColor = false;
            button_Limpiar.Click += button_Limpiar_Click;
            // 
            // button_Editar
            // 
            button_Editar.BackColor = SystemColors.ActiveCaption;
            button_Editar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Editar.Image = Properties.Resources.edit;
            button_Editar.ImageAlign = ContentAlignment.MiddleRight;
            button_Editar.Location = new Point(83, 3);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(74, 27);
            button_Editar.TabIndex = 24;
            button_Editar.Text = "Editar";
            button_Editar.TextAlign = ContentAlignment.MiddleLeft;
            button_Editar.UseVisualStyleBackColor = false;
            button_Editar.Click += button_Editar_Click;
            // 
            // button_Guardar
            // 
            button_Guardar.BackColor = Color.DarkSeaGreen;
            button_Guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Guardar.Image = Properties.Resources.save;
            button_Guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_Guardar.Location = new Point(163, 3);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(74, 27);
            button_Guardar.TabIndex = 25;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.WhiteSmoke;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1190, 571);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Recetas";
            // 
            // Form_HistoriaClinica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_HistoriaClinica";
            Text = "Form_HistoriaClinica";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label_nombre_completo;
        private Label label3;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label_nro_socio;
        private Label label_plan_os;
        private Label label_ooss;
        private GroupBox groupBox3;
        private Button button_seleccionar_paciente;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView treeView_historia_cli;
        private Label label4;
        private RichTextBox richTextBox_tratamiento;
        private Label label2;
        private RichTextBox richTextBox_observaciones;
        private Label label1;
        private RichTextBox richTextBox_motivo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
        private TabPage tabPage3;
        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button4;
        private Label label6;
        private RichTextBox richText_historia_Clinica;
        private Button button1;
    }
}