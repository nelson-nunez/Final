namespace SiAP.UI.Forms_Seguridad
{
    partial class UC_CRUD_Roles
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            label12 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            button1 = new Button();
            label5 = new Label();
            comboBox_roles = new ComboBox();
            treeView_Roles = new TreeView();
            label4 = new Label();
            label_id = new Label();
            textBox_Desc_Rol = new TextBox();
            textBox_Cod_Rol = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(comboBox_roles);
            groupBox2.Controls.Add(treeView_Roles);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label_id);
            groupBox2.Controls.Add(textBox_Desc_Rol);
            groupBox2.Controls.Add(textBox_Cod_Rol);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(332, 342);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Roles";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(8, 82);
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
            button_Borrar.TabIndex = 3;
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
            button_Limpiar.TabIndex = 4;
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
            button_Editar.TabIndex = 5;
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
            button_Guardar.TabIndex = 6;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(138, 324);
            label12.Name = "label12";
            label12.Size = new Size(52, 15);
            label12.TabIndex = 22;
            label12.Text = "---------";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(78, 324);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 21;
            label9.Text = "Nombre:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 324);
            label10.Name = "label10";
            label10.Size = new Size(27, 15);
            label10.TabIndex = 20;
            label10.Text = "----";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 324);
            label11.Name = "label11";
            label11.Size = new Size(24, 15);
            label11.TabIndex = 19;
            label11.Text = "ID: ";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(211, 297);
            button1.Name = "button1";
            button1.Size = new Size(118, 24);
            button1.TabIndex = 9;
            button1.Text = "Asociar/Desasociar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 282);
            label5.Name = "label5";
            label5.Size = new Size(164, 15);
            label5.TabIndex = 17;
            label5.Text = "Asociar/Desasociar a otro Rol:";
            // 
            // comboBox_roles
            // 
            comboBox_roles.FormattingEnabled = true;
            comboBox_roles.Location = new Point(6, 298);
            comboBox_roles.Name = "comboBox_roles";
            comboBox_roles.Size = new Size(199, 23);
            comboBox_roles.TabIndex = 8;
            // 
            // treeView_Roles
            // 
            treeView_Roles.Location = new Point(6, 121);
            treeView_Roles.Name = "treeView_Roles";
            treeView_Roles.Size = new Size(322, 158);
            treeView_Roles.TabIndex = 7;
            treeView_Roles.AfterSelect += treeView_Roles_AfterSelect;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 27);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "Nombre:";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(36, 27);
            label_id.Name = "label_id";
            label_id.Size = new Size(27, 15);
            label_id.TabIndex = 11;
            label_id.Text = "----";
            // 
            // textBox_Desc_Rol
            // 
            textBox_Desc_Rol.Location = new Point(138, 53);
            textBox_Desc_Rol.Name = "textBox_Desc_Rol";
            textBox_Desc_Rol.Size = new Size(190, 23);
            textBox_Desc_Rol.TabIndex = 2;
            // 
            // textBox_Cod_Rol
            // 
            textBox_Cod_Rol.Location = new Point(138, 24);
            textBox_Cod_Rol.Name = "textBox_Cod_Rol";
            textBox_Cod_Rol.Size = new Size(190, 23);
            textBox_Cod_Rol.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 56);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(24, 15);
            label1.TabIndex = 0;
            label1.Text = "ID: ";
            // 
            // UC_CRUD_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "UC_CRUD_Roles";
            Size = new Size(335, 345);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TreeView treeView_Roles;
        private Label label4;
        private Label label_id;
        private TextBox textBox_Desc_Rol;
        private TextBox textBox_Cod_Rol;
        private Label label2;
        private Label label1;
        private Label label5;
        private ComboBox comboBox_roles;
        private Button button1;
        private Label label12;
        private Label label9;
        private Label label10;
        private Label label11;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Borrar;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
    }
}
