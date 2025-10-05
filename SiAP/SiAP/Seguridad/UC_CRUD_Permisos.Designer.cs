namespace SiAP.UI.Forms_Seguridad
{
    partial class UC_CRUD_Permisos
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
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            comboBox1 = new ComboBox();
            treeView_Permisos = new TreeView();
            uC_Guardar_h2 = new Controles.UC_Guardar_H();
            label5 = new Label();
            label_id = new Label();
            textBox_Descripcion = new TextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(treeView_Permisos);
            groupBox1.Controls.Add(uC_Guardar_h2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label_id);
            groupBox1.Controls.Add(textBox_Descripcion);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(332, 344);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permisos";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(6, 82);
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(138, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(185, 23);
            comboBox1.TabIndex = 1;
            // 
            // treeView_Permisos
            // 
            treeView_Permisos.Location = new Point(11, 121);
            treeView_Permisos.Name = "treeView_Permisos";
            treeView_Permisos.Size = new Size(312, 207);
            treeView_Permisos.TabIndex = 14;
            treeView_Permisos.AfterSelect += treeView_Permisos_AfterSelect;
            // 
            // uC_Guardar_h2
            // 
            uC_Guardar_h2.Location = new Point(6, 82);
            uC_Guardar_h2.Name = "uC_Guardar_h2";
            uC_Guardar_h2.Size = new Size(317, 33);
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
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(36, 27);
            label_id.Name = "label_id";
            label_id.Size = new Size(27, 15);
            label_id.TabIndex = 11;
            label_id.Text = "----";
            // 
            // textBox_Descripcion
            // 
            textBox_Descripcion.Location = new Point(138, 53);
            textBox_Descripcion.Name = "textBox_Descripcion";
            textBox_Descripcion.Size = new Size(185, 23);
            textBox_Descripcion.TabIndex = 2;
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
            // UC_CRUD_Permisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UC_CRUD_Permisos";
            Size = new Size(335, 345);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private TreeView treeView_Permisos;
        private Controles.UC_Guardar_H uC_Guardar_h2;
        private Label label5;
        private Label label_id;
        private TextBox textBox_Descripcion;
        private Label label7;
        private Label label8;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Borrar;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
    }
}
