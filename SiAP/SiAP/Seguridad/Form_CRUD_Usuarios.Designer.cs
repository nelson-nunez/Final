namespace SiAP.UI.Forms_Seguridad
{
    partial class Form_CRUD_Usuarios
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
            groupBox3 = new GroupBox();
            textBox_ocupacion = new TextBox();
            label4 = new Label();
            label1 = new Label();
            textBox_nombre = new TextBox();
            button_Blanqueo = new Button();
            label2 = new Label();
            textBox_username = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label6 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            textBox_apellido = new TextBox();
            checkBox1 = new CheckBox();
            textBox_email = new TextBox();
            textBox_password = new TextBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            textBox_email_personal = new TextBox();
            label7 = new Label();
            comboBox_ocupacion = new ComboBox();
            dataGridView1 = new DataGridView();
            label8 = new Label();
            button1 = new Button();
            textBox_nombre_personal = new TextBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 707);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "ABM Usuarios";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_ocupacion);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(textBox_nombre);
            groupBox3.Controls.Add(button_Blanqueo);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(textBox_username);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(flowLayoutPanel1);
            groupBox3.Controls.Add(textBox_apellido);
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(textBox_email);
            groupBox3.Controls.Add(textBox_password);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(549, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(523, 531);
            groupBox3.TabIndex = 35;
            groupBox3.TabStop = false;
            groupBox3.Text = "Usuario";
            // 
            // textBox_ocupacion
            // 
            textBox_ocupacion.Enabled = false;
            textBox_ocupacion.Location = new Point(141, 41);
            textBox_ocupacion.Name = "textBox_ocupacion";
            textBox_ocupacion.Size = new Size(298, 23);
            textBox_ocupacion.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 44);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 34;
            label4.Text = "Ocupación:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 102);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre: ";
            // 
            // textBox_nombre
            // 
            textBox_nombre.Enabled = false;
            textBox_nombre.Location = new Point(141, 99);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(298, 23);
            textBox_nombre.TabIndex = 8;
            // 
            // button_Blanqueo
            // 
            button_Blanqueo.BackColor = SystemColors.ActiveCaption;
            button_Blanqueo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Blanqueo.Location = new Point(188, 414);
            button_Blanqueo.Name = "button_Blanqueo";
            button_Blanqueo.Size = new Size(154, 33);
            button_Blanqueo.TabIndex = 13;
            button_Blanqueo.Text = "Blanqueo de Contraseña";
            button_Blanqueo.UseVisualStyleBackColor = false;
            button_Blanqueo.Click += button_Blanqueo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 131);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido: ";
            // 
            // textBox_username
            // 
            textBox_username.Enabled = false;
            textBox_username.Location = new Point(141, 70);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(298, 23);
            textBox_username.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 189);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 5;
            label5.Text = "Contraseña: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 73);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 29;
            label3.Text = "Username:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(93, 160);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 6;
            label6.Text = "Email: ";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(105, 485);
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
            button_Borrar.TabIndex = 14;
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
            button_Limpiar.TabIndex = 15;
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
            button_Editar.TabIndex = 16;
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
            button_Guardar.TabIndex = 17;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // textBox_apellido
            // 
            textBox_apellido.Enabled = false;
            textBox_apellido.Location = new Point(141, 128);
            textBox_apellido.Name = "textBox_apellido";
            textBox_apellido.Size = new Size(298, 23);
            textBox_apellido.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(93, 226);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(60, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Activo";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_email
            // 
            textBox_email.Enabled = false;
            textBox_email.Location = new Point(141, 157);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(298, 23);
            textBox_email.TabIndex = 10;
            // 
            // textBox_password
            // 
            textBox_password.Enabled = false;
            textBox_password.Location = new Point(141, 186);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(298, 23);
            textBox_password.TabIndex = 11;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(textBox_email_personal);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(comboBox_ocupacion);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox_nombre_personal);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(6, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(523, 531);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "Personal";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 97);
            label9.Name = "label9";
            label9.Size = new Size(107, 15);
            label9.TabIndex = 10;
            label9.Text = "Correo Electrónico:";
            // 
            // textBox_email_personal
            // 
            textBox_email_personal.Location = new Point(132, 94);
            textBox_email_personal.Name = "textBox_email_personal";
            textBox_email_personal.Size = new Size(385, 23);
            textBox_email_personal.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 68);
            label7.Name = "label7";
            label7.Size = new Size(111, 15);
            label7.TabIndex = 8;
            label7.Text = "Nombre o Apellido:";
            // 
            // comboBox_ocupacion
            // 
            comboBox_ocupacion.FormattingEnabled = true;
            comboBox_ocupacion.Location = new Point(132, 36);
            comboBox_ocupacion.Name = "comboBox_ocupacion";
            comboBox_ocupacion.Size = new Size(385, 23);
            comboBox_ocupacion.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 167);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(511, 358);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(58, 39);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 6;
            label8.Text = "Ocupación:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(173, 135);
            button1.Name = "button1";
            button1.Size = new Size(165, 24);
            button1.TabIndex = 4;
            button1.Text = "Filtrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox_nombre_personal
            // 
            textBox_nombre_personal.Location = new Point(132, 65);
            textBox_nombre_personal.Name = "textBox_nombre_personal";
            textBox_nombre_personal.Size = new Size(385, 23);
            textBox_nombre_personal.TabIndex = 2;
            // 
            // Form_CRUD_Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_CRUD_Usuarios";
            Text = "Form_CRUD_Usuarios";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private TextBox textBox_nombre;
        private Label label1;
        private Label label2;
        private Label label6;
        private Label label5;
        private TextBox textBox_apellido;
        private TextBox textBox_password;
        private TextBox textBox_email;
        private CheckBox checkBox1;
        private TextBox textBox_username;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Borrar;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
        private Button button_Blanqueo;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label label8;
        private Button button1;
        private TextBox textBox_nombre_personal;
        private TextBox textBox_ocupacion;
        private Label label4;
        private Label label7;
        private ComboBox comboBox_ocupacion;
        private GroupBox groupBox3;
        private Label label9;
        private TextBox textBox_email_personal;
    }
}