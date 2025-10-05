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
            groupBox2 = new GroupBox();
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
            label4 = new Label();
            richTextBox3 = new RichTextBox();
            label2 = new Label();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
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
            dataGridView1 = new DataGridView();
            listBox1 = new ListBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 707);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Historia Clínica";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(listBox1);
            groupBox2.Controls.Add(uC_Buscar_Paciente1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(richTextBox3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(richTextBox2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Location = new Point(282, 102);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(910, 591);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Historial";
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(97, 72);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 226);
            uC_Buscar_Paciente1.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 313);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 56;
            label4.Text = "Tratamiento";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(6, 331);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(572, 215);
            richTextBox3.TabIndex = 55;
            richTextBox3.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 161);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 54;
            label2.Text = "Observaciones";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(6, 179);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(572, 131);
            richTextBox2.TabIndex = 53;
            richTextBox2.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 52;
            label1.Text = "Motivo";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(6, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(572, 117);
            richTextBox1.TabIndex = 51;
            richTextBox1.Text = "";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(304, 552);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(320, 33);
            flowLayoutPanel1.TabIndex = 29;
            // 
            // button_Borrar
            // 
            button_Borrar.BackColor = Color.IndianRed;
            button_Borrar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Borrar.Image = Properties.Resources.delete;
            button_Borrar.ImageAlign = ContentAlignment.MiddleRight;
            button_Borrar.Location = new Point(3, 3);
            button_Borrar.Name = "button_Borrar";
            button_Borrar.Size = new Size(74, 27);
            button_Borrar.TabIndex = 22;
            button_Borrar.Text = "Eliminar";
            button_Borrar.TextAlign = ContentAlignment.MiddleLeft;
            button_Borrar.UseVisualStyleBackColor = false;
            // 
            // button_Limpiar
            // 
            button_Limpiar.BackColor = Color.SandyBrown;
            button_Limpiar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Limpiar.Image = Properties.Resources.clear;
            button_Limpiar.ImageAlign = ContentAlignment.MiddleRight;
            button_Limpiar.Location = new Point(83, 3);
            button_Limpiar.Name = "button_Limpiar";
            button_Limpiar.Size = new Size(74, 27);
            button_Limpiar.TabIndex = 23;
            button_Limpiar.Text = "Limpiar";
            button_Limpiar.TextAlign = ContentAlignment.MiddleLeft;
            button_Limpiar.UseVisualStyleBackColor = false;
            // 
            // button_Editar
            // 
            button_Editar.BackColor = SystemColors.ActiveCaption;
            button_Editar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Editar.Image = Properties.Resources.edit;
            button_Editar.ImageAlign = ContentAlignment.MiddleRight;
            button_Editar.Location = new Point(163, 3);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(74, 27);
            button_Editar.TabIndex = 24;
            button_Editar.Text = "Editar";
            button_Editar.TextAlign = ContentAlignment.MiddleLeft;
            button_Editar.UseVisualStyleBackColor = false;
            // 
            // button_Guardar
            // 
            button_Guardar.BackColor = Color.DarkSeaGreen;
            button_Guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Guardar.Image = Properties.Resources.save;
            button_Guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_Guardar.Location = new Point(243, 3);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(74, 27);
            button_Guardar.TabIndex = 25;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(254, 599);
            dataGridView1.TabIndex = 30;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(624, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(280, 424);
            listBox1.TabIndex = 57;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(624, 19);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 58;
            label5.Text = "Motivo";
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Borrar;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
        private DataGridView dataGridView1;
        private Label label_nombre_completo;
        private Label label3;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label_nro_socio;
        private Label label_plan_os;
        private Label label_ooss;
        private RichTextBox richTextBox1;
        private Label label4;
        private RichTextBox richTextBox3;
        private Label label2;
        private RichTextBox richTextBox2;
        private Label label1;
        private GroupBox groupBox3;
        private Button button_seleccionar_paciente;
        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
        private Label label5;
        private ListBox listBox1;
    }
}