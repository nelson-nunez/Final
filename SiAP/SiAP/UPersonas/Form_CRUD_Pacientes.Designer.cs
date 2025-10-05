namespace SiAP.UI
{
    partial class Form_CRUD_Pacientes
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
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            numeric_nro_socio = new NumericUpDown();
            label3 = new Label();
            textBox_plan = new TextBox();
            textBox_DNI = new TextBox();
            label9 = new Label();
            textBox_ooss = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dateTime_feccha_nac = new DateTimePicker();
            label4 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            textBox_telefono = new TextBox();
            textBox_email = new TextBox();
            textBox_apellido = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            textBox_nombre = new TextBox();
            label1 = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_nro_socio).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(764, 450);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pacientes";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(752, 422);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numeric_nro_socio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox_plan);
            groupBox1.Controls.Add(textBox_DNI);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBox_ooss);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dateTime_feccha_nac);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(textBox_telefono);
            groupBox1.Controls.Add(textBox_email);
            groupBox1.Controls.Add(textBox_apellido);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_nombre);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(782, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(440, 450);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "ABM";
            // 
            // numeric_nro_socio
            // 
            numeric_nro_socio.Location = new Point(101, 265);
            numeric_nro_socio.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numeric_nro_socio.Name = "numeric_nro_socio";
            numeric_nro_socio.Size = new Size(298, 23);
            numeric_nro_socio.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 268);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 42;
            label3.Text = "Nro. Socio:";
            // 
            // textBox_plan
            // 
            textBox_plan.Location = new Point(101, 236);
            textBox_plan.Name = "textBox_plan";
            textBox_plan.Size = new Size(298, 23);
            textBox_plan.TabIndex = 8;
            // 
            // textBox_DNI
            // 
            textBox_DNI.Location = new Point(101, 91);
            textBox_DNI.Name = "textBox_DNI";
            textBox_DNI.Size = new Size(298, 23);
            textBox_DNI.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(59, 239);
            label9.Name = "label9";
            label9.Size = new Size(36, 15);
            label9.TabIndex = 39;
            label9.Text = "Plan: ";
            // 
            // textBox_ooss
            // 
            textBox_ooss.Location = new Point(101, 207);
            textBox_ooss.Name = "textBox_ooss";
            textBox_ooss.Size = new Size(298, 23);
            textBox_ooss.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(52, 210);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 36;
            label8.Text = "OOSS: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 126);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 34;
            label7.Text = "Fecha Nac.:";
            // 
            // dateTime_feccha_nac
            // 
            dateTime_feccha_nac.Format = DateTimePickerFormat.Short;
            dateTime_feccha_nac.Location = new Point(101, 120);
            dateTime_feccha_nac.Name = "dateTime_feccha_nac";
            dateTime_feccha_nac.Size = new Size(298, 23);
            dateTime_feccha_nac.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 93);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 31;
            label4.Text = "DNI: ";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(49, 399);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(320, 33);
            flowLayoutPanel1.TabIndex = 28;
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
            button_Borrar.TabIndex = 10;
            button_Borrar.Text = "Eliminar";
            button_Borrar.TextAlign = ContentAlignment.MiddleLeft;
            button_Borrar.UseVisualStyleBackColor = false;
            button_Borrar.Click += button_Borrar_Click;
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
            button_Limpiar.TabIndex = 11;
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
            button_Editar.Location = new Point(163, 3);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(74, 27);
            button_Editar.TabIndex = 12;
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
            button_Guardar.Location = new Point(243, 3);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(74, 27);
            button_Guardar.TabIndex = 13;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // textBox_telefono
            // 
            textBox_telefono.Location = new Point(101, 178);
            textBox_telefono.Name = "textBox_telefono";
            textBox_telefono.Size = new Size(298, 23);
            textBox_telefono.TabIndex = 6;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(101, 149);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(298, 23);
            textBox_email.TabIndex = 5;
            // 
            // textBox_apellido
            // 
            textBox_apellido.Location = new Point(101, 62);
            textBox_apellido.Name = "textBox_apellido";
            textBox_apellido.Size = new Size(298, 23);
            textBox_apellido.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 152);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 6;
            label6.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 181);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 5;
            label5.Text = "Teléfono:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 65);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido: ";
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(101, 33);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(298, 23);
            textBox_nombre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 36);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre: ";
            // 
            // Form_CRUD_Pacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Form_CRUD_Pacientes";
            Text = "Form_CRUD_Pacientes";
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_nro_socio).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private TextBox textBox_DNI;
        private Label label9;
        private TextBox textBox_ooss;
        private Label label8;
        private Label label7;
        private DateTimePicker dateTime_feccha_nac;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Borrar;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
        private TextBox textBox_telefono;
        private TextBox textBox_email;
        private TextBox textBox_apellido;
        private Label label6;
        private Label label5;
        private Label label2;
        private TextBox textBox_nombre;
        private Label label1;
        private NumericUpDown numeric_nro_socio;
        private Label label3;
        private TextBox textBox_plan;
    }
}