namespace SiAP.UI.Controles
{
    partial class UC_BuscarUsuario
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
            checkBox1 = new CheckBox();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            textBox_ConstraseñaSeleccionada = new TextBox();
            textBox_NombreSeleccionado = new TextBox();
            label5 = new Label();
            button1 = new Button();
            textBox_Buscar = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox_ConstraseñaSeleccionada);
            groupBox1.Controls.Add(textBox_NombreSeleccionado);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox_Buscar);
            groupBox1.Location = new Point(3, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 342);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Usuario";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(324, 307);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Descifrar/Cifrar";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(418, 201);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 307);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 10;
            label7.Text = "Contraseña:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 279);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 9;
            label6.Text = "Nombre:";
            // 
            // textBox_ConstraseñaSeleccionada
            // 
            textBox_ConstraseñaSeleccionada.Enabled = false;
            textBox_ConstraseñaSeleccionada.Location = new Point(82, 305);
            textBox_ConstraseñaSeleccionada.Name = "textBox_ConstraseñaSeleccionada";
            textBox_ConstraseñaSeleccionada.Size = new Size(236, 23);
            textBox_ConstraseñaSeleccionada.TabIndex = 8;
            textBox_ConstraseñaSeleccionada.Text = "5";
            textBox_ConstraseñaSeleccionada.TextChanged += textBox_ConstraseñaSeleccionada_TextChanged;
            // 
            // textBox_NombreSeleccionado
            // 
            textBox_NombreSeleccionado.Enabled = false;
            textBox_NombreSeleccionado.Location = new Point(82, 276);
            textBox_NombreSeleccionado.Name = "textBox_NombreSeleccionado";
            textBox_NombreSeleccionado.Size = new Size(342, 23);
            textBox_NombreSeleccionado.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(155, 15);
            label5.TabIndex = 6;
            label5.Text = "Buscar por Nombre/Usuario";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(324, 39);
            button1.Name = "button1";
            button1.Size = new Size(100, 24);
            button1.TabIndex = 2;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox_Buscar
            // 
            textBox_Buscar.Location = new Point(6, 39);
            textBox_Buscar.Name = "textBox_Buscar";
            textBox_Buscar.Size = new Size(312, 23);
            textBox_Buscar.TabIndex = 1;
            // 
            // UC_BuscarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UC_BuscarUsuario";
            Size = new Size(442, 345);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private DataGridView dataGridView1;
        private Label label7;
        private Label label6;
        private TextBox textBox_ConstraseñaSeleccionada;
        private TextBox textBox_NombreSeleccionado;
        private Label label5;
        private Button button1;
        private TextBox textBox_Buscar;
    }
}
