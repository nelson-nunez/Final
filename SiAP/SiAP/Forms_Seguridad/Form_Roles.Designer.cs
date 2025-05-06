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
            groupBox1 = new GroupBox();
            dataGrid_Roles = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            button_Borrar = new Button();
            button_Guardar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button3 = new Button();
            button2 = new Button();
            label4 = new Label();
            label3 = new Label();
            dataGrid_PermisosDisp = new DataGridView();
            dataGrid_PermisosAsignado = new DataGridView();
            textBox_Desc_Rol = new TextBox();
            textBox_Cod_Rol = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Roles).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_PermisosDisp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid_PermisosAsignado).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGrid_Roles);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(270, 507);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Roles";
            // 
            // dataGrid_Roles
            // 
            dataGrid_Roles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Roles.Location = new Point(6, 22);
            dataGrid_Roles.Name = "dataGrid_Roles";
            dataGrid_Roles.Size = new Size(257, 479);
            dataGrid_Roles.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dataGrid_PermisosDisp);
            groupBox2.Controls.Add(dataGrid_PermisosAsignado);
            groupBox2.Controls.Add(textBox_Desc_Rol);
            groupBox2.Controls.Add(textBox_Cod_Rol);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(288, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(680, 507);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Roles";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(button_Borrar);
            groupBox3.Controls.Add(button_Guardar);
            groupBox3.Controls.Add(button_Limpiar);
            groupBox3.Controls.Add(button_Editar);
            groupBox3.Location = new Point(137, 448);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(391, 53);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            // 
            // button_Borrar
            // 
            button_Borrar.BackColor = Color.IndianRed;
            button_Borrar.Font = new Font("Calibri", 9.75F);
            button_Borrar.Image = Properties.Resources.delete;
            button_Borrar.ImageAlign = ContentAlignment.MiddleLeft;
            button_Borrar.Location = new Point(6, 21);
            button_Borrar.Name = "button_Borrar";
            button_Borrar.Size = new Size(90, 25);
            button_Borrar.TabIndex = 18;
            button_Borrar.Text = "Eliminar";
            button_Borrar.UseVisualStyleBackColor = false;
            button_Borrar.Click += button_Borrar_Click;
            // 
            // button_Guardar
            // 
            button_Guardar.BackColor = Color.DarkSeaGreen;
            button_Guardar.Font = new Font("Calibri", 9.75F);
            button_Guardar.Image = Properties.Resources.save;
            button_Guardar.ImageAlign = ContentAlignment.MiddleLeft;
            button_Guardar.Location = new Point(294, 21);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(90, 25);
            button_Guardar.TabIndex = 21;
            button_Guardar.Text = "Guardar";
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // button_Limpiar
            // 
            button_Limpiar.BackColor = Color.SandyBrown;
            button_Limpiar.Font = new Font("Calibri", 9.75F);
            button_Limpiar.Image = Properties.Resources.clear;
            button_Limpiar.ImageAlign = ContentAlignment.MiddleLeft;
            button_Limpiar.Location = new Point(102, 21);
            button_Limpiar.Name = "button_Limpiar";
            button_Limpiar.Size = new Size(90, 25);
            button_Limpiar.TabIndex = 19;
            button_Limpiar.Text = "Limpiar";
            button_Limpiar.UseVisualStyleBackColor = false;
            button_Limpiar.Click += button_Limpiar_Click;
            // 
            // button_Editar
            // 
            button_Editar.BackColor = SystemColors.ActiveCaption;
            button_Editar.Font = new Font("Calibri", 9.75F);
            button_Editar.Image = Properties.Resources.edit;
            button_Editar.ImageAlign = ContentAlignment.MiddleLeft;
            button_Editar.Location = new Point(198, 21);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(90, 25);
            button_Editar.TabIndex = 20;
            button_Editar.Text = "Editar";
            button_Editar.UseVisualStyleBackColor = false;
            button_Editar.Click += button_Editar_Click;
            // 
            // button3
            // 
            button3.Location = new Point(442, 419);
            button3.Name = "button3";
            button3.Size = new Size(130, 23);
            button3.TabIndex = 10;
            button3.Text = "Asignar Permiso";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(95, 419);
            button2.Name = "button2";
            button2.Size = new Size(127, 23);
            button2.TabIndex = 9;
            button2.Text = "Remover Permiso";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 110);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 7;
            label4.Text = "Permisos Disponibles";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 110);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 6;
            label3.Text = "Permisos Asignados";
            // 
            // dataGrid_PermisosDisp
            // 
            dataGrid_PermisosDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_PermisosDisp.Location = new Point(368, 128);
            dataGrid_PermisosDisp.Name = "dataGrid_PermisosDisp";
            dataGrid_PermisosDisp.Size = new Size(275, 285);
            dataGrid_PermisosDisp.TabIndex = 5;
            // 
            // dataGrid_PermisosAsignado
            // 
            dataGrid_PermisosAsignado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_PermisosAsignado.Location = new Point(26, 128);
            dataGrid_PermisosAsignado.Name = "dataGrid_PermisosAsignado";
            dataGrid_PermisosAsignado.Size = new Size(275, 285);
            dataGrid_PermisosAsignado.TabIndex = 4;
            // 
            // textBox_Desc_Rol
            // 
            textBox_Desc_Rol.Location = new Point(26, 84);
            textBox_Desc_Rol.Name = "textBox_Desc_Rol";
            textBox_Desc_Rol.Size = new Size(393, 23);
            textBox_Desc_Rol.TabIndex = 3;
            // 
            // textBox_Cod_Rol
            // 
            textBox_Cod_Rol.Location = new Point(25, 40);
            textBox_Cod_Rol.Name = "textBox_Cod_Rol";
            textBox_Cod_Rol.Size = new Size(393, 23);
            textBox_Cod_Rol.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 66);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripción del Rol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 22);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Código del Rol";
            // 
            // Form_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(980, 531);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form_Roles";
            Text = "Form_Roles";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_Roles).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_PermisosDisp).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid_PermisosAsignado).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGrid_Roles;
        private GroupBox groupBox2;
        private TextBox textBox_Cod_Rol;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private DataGridView dataGrid_PermisosDisp;
        private DataGridView dataGrid_PermisosAsignado;
        private TextBox textBox_Desc_Rol;
        private Button button3;
        private Button button2;
        private GroupBox groupBox3;
        private Button button_Borrar;
        private Button button_Guardar;
        private Button button_Limpiar;
        private Button button_Editar;
    }
}