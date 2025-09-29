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
            uC_BuscarUsuario1 = new Controles.UC_BuscarUsuario();
            groupBox1 = new GroupBox();
            button_Blanqueo = new Button();
            textBox_username = new TextBox();
            label3 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            checkBox1 = new CheckBox();
            textBox_password = new TextBox();
            textBox_email = new TextBox();
            textBox_apellido = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            textBox_nombre = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uC_BuscarUsuario1
            // 
            uC_BuscarUsuario1.Location = new Point(12, 12);
            uC_BuscarUsuario1.Name = "uC_BuscarUsuario1";
            uC_BuscarUsuario1.Size = new Size(442, 345);
            uC_BuscarUsuario1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_Blanqueo);
            groupBox1.Controls.Add(textBox_username);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(textBox_password);
            groupBox1.Controls.Add(textBox_email);
            groupBox1.Controls.Add(textBox_apellido);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_nombre);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(460, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 345);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "ABM Usuarios";
            // 
            // button_Blanqueo
            // 
            button_Blanqueo.BackColor = SystemColors.ActiveCaption;
            button_Blanqueo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Blanqueo.Location = new Point(148, 215);
            button_Blanqueo.Name = "button_Blanqueo";
            button_Blanqueo.Size = new Size(154, 33);
            button_Blanqueo.TabIndex = 31;
            button_Blanqueo.Text = "Blanqueo de Contraseña";
            button_Blanqueo.UseVisualStyleBackColor = false;
            button_Blanqueo.Click += button_Blanqueo_Click;
            // 
            // textBox_username
            // 
            textBox_username.Location = new Point(88, 31);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(298, 23);
            textBox_username.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 34);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 29;
            label3.Text = "Username:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(65, 286);
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
            button_Borrar.TabIndex = 7;
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
            button_Limpiar.TabIndex = 8;
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
            button_Editar.TabIndex = 9;
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
            button_Guardar.TabIndex = 10;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(40, 186);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(60, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Activo";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_password
            // 
            textBox_password.Enabled = false;
            textBox_password.Location = new Point(88, 147);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(298, 23);
            textBox_password.TabIndex = 5;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(88, 118);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(298, 23);
            textBox_email.TabIndex = 4;
            // 
            // textBox_apellido
            // 
            textBox_apellido.Location = new Point(88, 89);
            textBox_apellido.Name = "textBox_apellido";
            textBox_apellido.Size = new Size(298, 23);
            textBox_apellido.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 121);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 6;
            label6.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 150);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 5;
            label5.Text = "Contraseña: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 92);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido: ";
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(88, 60);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(298, 23);
            textBox_nombre.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 63);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre: ";
            // 
            // Form_CRUD_Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Controls.Add(uC_BuscarUsuario1);
            Name = "Form_CRUD_Usuarios";
            Text = "Form_CRUD_Usuarios";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controles.UC_BuscarUsuario uC_BuscarUsuario1;
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
    }
}