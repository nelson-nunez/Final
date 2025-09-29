namespace SiAP.UI.Forms_Seguridad
{
    partial class UC_Buscar_Paciente
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
            label1 = new Label();
            dataGridView_paciente = new DataGridView();
            label5 = new Label();
            button1 = new Button();
            textBox_Buscar = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_paciente).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonFace;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dataGridView_paciente);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox_Buscar);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 220);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Paciente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(417, 0);
            label1.Name = "label1";
            label1.Size = new Size(24, 25);
            label1.TabIndex = 7;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // dataGridView_paciente
            // 
            dataGridView_paciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_paciente.Location = new Point(6, 69);
            dataGridView_paciente.Name = "dataGridView_paciente";
            dataGridView_paciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_paciente.Size = new Size(418, 141);
            dataGridView_paciente.TabIndex = 6;
            dataGridView_paciente.CellClick += dataGridView1_CellClick;
            dataGridView_paciente.CellContentClick += dataGridView1_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(193, 15);
            label5.TabIndex = 6;
            label5.Text = "Buscar por Nombre, Apellido o DNI";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Image = Properties.Resources.lupa;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(324, 39);
            button1.Name = "button1";
            button1.Size = new Size(100, 24);
            button1.TabIndex = 5;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox_Buscar
            // 
            textBox_Buscar.Location = new Point(6, 39);
            textBox_Buscar.Name = "textBox_Buscar";
            textBox_Buscar.Size = new Size(312, 23);
            textBox_Buscar.TabIndex = 4;
            // 
            // UC_Buscar_Paciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UC_Buscar_Paciente";
            Size = new Size(444, 226);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_paciente).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView_paciente;
        private Label label5;
        private Button button1;
        private TextBox textBox_Buscar;
        private Label label1;
    }
}
