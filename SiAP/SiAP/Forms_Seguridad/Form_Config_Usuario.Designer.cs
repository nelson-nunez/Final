namespace SiAP.UI
{
    partial class Form_Config_Usuario
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
            checkBox1 = new CheckBox();
            label2 = new Label();
            textBox_rep_new_pass = new TextBox();
            label1 = new Label();
            textBox_new_pass = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Limpiar = new Button();
            button_Guardar = new Button();
            textBox_old_pass = new TextBox();
            textBox_email = new TextBox();
            label6 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_rep_new_pass);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_new_pass);
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(textBox_old_pass);
            groupBox1.Controls.Add(textBox_email);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 287);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cambiar contraseña";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(35, 211);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(111, 19);
            checkBox1.TabIndex = 33;
            checkBox1.Text = "Mostrar/Ocultar";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 164);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 32;
            label2.Text = "Repetir contraseña nueva: ";
            // 
            // textBox_rep_new_pass
            // 
            textBox_rep_new_pass.Location = new Point(35, 182);
            textBox_rep_new_pass.Name = "textBox_rep_new_pass";
            textBox_rep_new_pass.Size = new Size(292, 23);
            textBox_rep_new_pass.TabIndex = 31;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 120);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 30;
            label1.Text = "Ingresar contraseña nueva: ";
            // 
            // textBox_new_pass
            // 
            textBox_new_pass.Location = new Point(35, 138);
            textBox_new_pass.Name = "textBox_new_pass";
            textBox_new_pass.Size = new Size(292, 23);
            textBox_new_pass.TabIndex = 29;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(103, 248);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(162, 33);
            flowLayoutPanel1.TabIndex = 28;
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
            // button_Guardar
            // 
            button_Guardar.BackColor = Color.DarkSeaGreen;
            button_Guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Guardar.Image = Properties.Resources.save;
            button_Guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_Guardar.Location = new Point(83, 3);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(74, 27);
            button_Guardar.TabIndex = 25;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // textBox_old_pass
            // 
            textBox_old_pass.Location = new Point(35, 93);
            textBox_old_pass.Name = "textBox_old_pass";
            textBox_old_pass.Size = new Size(292, 23);
            textBox_old_pass.TabIndex = 9;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(35, 49);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(292, 23);
            textBox_email.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 31);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 6;
            label6.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 75);
            label5.Name = "label5";
            label5.Size = new Size(151, 15);
            label5.TabIndex = 5;
            label5.Text = "Ingresar contraseña actual: ";
            // 
            // Form_Config_Usuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_Config_Usuario";
            Text = "Form_Config_Usuario";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Limpiar;
        private Button button_Guardar;
        private TextBox textBox_old_pass;
        private TextBox textBox_email;
        private Label label6;
        private Label label5;
        private Label label2;
        private TextBox textBox_rep_new_pass;
        private Label label1;
        private TextBox textBox_new_pass;
        private CheckBox checkBox1;
    }
}