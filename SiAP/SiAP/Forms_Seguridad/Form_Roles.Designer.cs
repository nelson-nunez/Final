namespace SiAP.UI.Forms_Seguridad
{
    partial class Form_Roles
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
            uC_buscarUsuario1 = new Controles.UC_buscarUsuario();
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            treeView_Permisos = new TreeView();
            uC_Guardar_h2 = new Controles.UC_Guardar_H();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            uC_cruD_Roles1 = new UC_CRUD_Roles();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // uC_buscarUsuario1
            // 
            uC_buscarUsuario1.Location = new Point(12, 12);
            uC_buscarUsuario1.Name = "uC_buscarUsuario1";
            uC_buscarUsuario1.Size = new Size(442, 260);
            uC_buscarUsuario1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(treeView_Permisos);
            groupBox1.Controls.Add(uC_Guardar_h2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(878, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(329, 344);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permisos";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(138, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 23);
            comboBox1.TabIndex = 15;
            // 
            // treeView_Permisos
            // 
            treeView_Permisos.Location = new Point(6, 121);
            treeView_Permisos.Name = "treeView_Permisos";
            treeView_Permisos.Size = new Size(312, 207);
            treeView_Permisos.TabIndex = 14;
            // 
            // uC_Guardar_h2
            // 
            uC_Guardar_h2.Location = new Point(6, 82);
            uC_Guardar_h2.Name = "uC_Guardar_h2";
            uC_Guardar_h2.Size = new Size(312, 33);
            uC_Guardar_h2.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(78, 27);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 12;
            label5.Text = "Menú:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 27);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 11;
            label6.Text = "----";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(138, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 23);
            textBox1.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 56);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 1;
            label7.Text = "Descripción:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 27);
            label8.Name = "label8";
            label8.Size = new Size(24, 15);
            label8.TabIndex = 0;
            label8.Text = "ID: ";
            // 
            // uC_cruD_Roles1
            // 
            uC_cruD_Roles1.Location = new Point(460, 12);
            uC_cruD_Roles1.Name = "uC_cruD_Roles1";
            uC_cruD_Roles1.Size = new Size(354, 481);
            uC_cruD_Roles1.TabIndex = 7;
            // 
            // Form_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1280, 731);
            Controls.Add(uC_cruD_Roles1);
            Controls.Add(groupBox1);
            Controls.Add(uC_buscarUsuario1);
            Name = "Form_Roles";
            Text = "Form_Roles";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Controles.UC_buscarUsuario uC_buscarUsuario1;
        private GroupBox groupBox1;
        private TreeView treeView_Permisos;
        private Controles.UC_Guardar_H uC_Guardar_h2;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private Label label8;
        private ComboBox comboBox1;
        private UC_CRUD_Roles uC_cruD_Roles1;
    }
}