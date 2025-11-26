namespace SiAP.UI
{
    partial class Form_Respaldos
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
            groupBox4 = new GroupBox();
            button1 = new Button();
            dataGrid_respaldos = new DataGridView();
            groupBox1 = new GroupBox();
            label3 = new Label();
            comboBox_NombreBD = new ComboBox();
            richTextBox_descripcion = new RichTextBox();
            textBox_nombre_archivo = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button_eliminar = new Button();
            button2 = new Button();
            button_guardar = new Button();
            button_restaurar = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox_creador = new TextBox();
            label30 = new Label();
            textBox_fecha = new TextBox();
            label28 = new Label();
            button_filtrar = new Button();
            dateTimePicker_hasta = new DateTimePicker();
            dateTimePicker_desde = new DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            groupBox100 = new GroupBox();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_respaldos).BeginInit();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox100.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.WhiteSmoke;
            groupBox4.Controls.Add(groupBox100);
            groupBox4.Controls.Add(dataGrid_respaldos);
            groupBox4.Controls.Add(groupBox1);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1210, 707);
            groupBox4.TabIndex = 91;
            groupBox4.TabStop = false;
            groupBox4.Text = "Respaldos:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Image = Properties.Resources.lupa;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(418, 37);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 141;
            button1.Text = "Ver todos";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGrid_respaldos
            // 
            dataGrid_respaldos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_respaldos.Location = new Point(6, 95);
            dataGrid_respaldos.Name = "dataGrid_respaldos";
            dataGrid_respaldos.Size = new Size(556, 606);
            dataGrid_respaldos.TabIndex = 140;
            dataGrid_respaldos.CellClick += dataGrid_respaldos_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBox_NombreBD);
            groupBox1.Controls.Add(richTextBox_descripcion);
            groupBox1.Controls.Add(textBox_nombre_archivo);
            groupBox1.Controls.Add(flowLayoutPanel2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_creador);
            groupBox1.Controls.Add(label30);
            groupBox1.Controls.Add(textBox_fecha);
            groupBox1.Controls.Add(label28);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(568, 95);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(589, 606);
            groupBox1.TabIndex = 139;
            groupBox1.TabStop = false;
            groupBox1.Text = "Respaldo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 103);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 140;
            label3.Text = "Base de Datos:";
            // 
            // comboBox_NombreBD
            // 
            comboBox_NombreBD.FormattingEnabled = true;
            comboBox_NombreBD.Location = new Point(117, 100);
            comboBox_NombreBD.Name = "comboBox_NombreBD";
            comboBox_NombreBD.Size = new Size(359, 23);
            comboBox_NombreBD.TabIndex = 139;
            // 
            // richTextBox_descripcion
            // 
            richTextBox_descripcion.Location = new Point(117, 158);
            richTextBox_descripcion.Name = "richTextBox_descripcion";
            richTextBox_descripcion.Size = new Size(359, 176);
            richTextBox_descripcion.TabIndex = 92;
            richTextBox_descripcion.Text = "";
            // 
            // textBox_nombre_archivo
            // 
            textBox_nombre_archivo.Location = new Point(117, 129);
            textBox_nombre_archivo.Name = "textBox_nombre_archivo";
            textBox_nombre_archivo.Size = new Size(359, 23);
            textBox_nombre_archivo.TabIndex = 138;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button_eliminar);
            flowLayoutPanel2.Controls.Add(button2);
            flowLayoutPanel2.Controls.Add(button_guardar);
            flowLayoutPanel2.Controls.Add(button_restaurar);
            flowLayoutPanel2.Location = new Point(8, 557);
            flowLayoutPanel2.Margin = new Padding(5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(573, 41);
            flowLayoutPanel2.TabIndex = 129;
            // 
            // button_eliminar
            // 
            button_eliminar.BackColor = Color.IndianRed;
            button_eliminar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_eliminar.Image = Properties.Resources.delete;
            button_eliminar.ImageAlign = ContentAlignment.MiddleLeft;
            button_eliminar.Location = new Point(5, 5);
            button_eliminar.Margin = new Padding(5);
            button_eliminar.Name = "button_eliminar";
            button_eliminar.Size = new Size(130, 30);
            button_eliminar.TabIndex = 22;
            button_eliminar.Text = "Eliminar  Respaldo";
            button_eliminar.TextAlign = ContentAlignment.MiddleRight;
            button_eliminar.UseVisualStyleBackColor = false;
            button_eliminar.Click += button_eliminar_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SandyBrown;
            button2.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button2.Image = Properties.Resources.clear;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(145, 5);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(130, 30);
            button2.TabIndex = 26;
            button2.Text = "Limpiar";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button_guardar
            // 
            button_guardar.BackColor = Color.DarkSeaGreen;
            button_guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_guardar.Image = Properties.Resources.save;
            button_guardar.ImageAlign = ContentAlignment.MiddleLeft;
            button_guardar.Location = new Point(285, 5);
            button_guardar.Margin = new Padding(5);
            button_guardar.Name = "button_guardar";
            button_guardar.Size = new Size(130, 30);
            button_guardar.TabIndex = 25;
            button_guardar.Text = "Guardar Nuevo";
            button_guardar.TextAlign = ContentAlignment.MiddleRight;
            button_guardar.UseVisualStyleBackColor = false;
            button_guardar.Click += button_guardar_Click;
            // 
            // button_restaurar
            // 
            button_restaurar.BackColor = SystemColors.ActiveCaption;
            button_restaurar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_restaurar.Image = Properties.Resources.respaldo_3_;
            button_restaurar.ImageAlign = ContentAlignment.MiddleLeft;
            button_restaurar.Location = new Point(425, 5);
            button_restaurar.Margin = new Padding(5);
            button_restaurar.Name = "button_restaurar";
            button_restaurar.Size = new Size(140, 30);
            button_restaurar.TabIndex = 24;
            button_restaurar.Text = "Restaurar Respaldo";
            button_restaurar.TextAlign = ContentAlignment.MiddleRight;
            button_restaurar.UseVisualStyleBackColor = false;
            button_restaurar.Click += button_restaurar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(20, 74);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 137;
            label2.Text = "Fecha Creación:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 158);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 93;
            label1.Text = "Descripcion:";
            // 
            // textBox_creador
            // 
            textBox_creador.Enabled = false;
            textBox_creador.Location = new Point(117, 42);
            textBox_creador.Name = "textBox_creador";
            textBox_creador.Size = new Size(359, 23);
            textBox_creador.TabIndex = 136;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(12, 132);
            label30.Name = "label30";
            label30.Size = new Size(98, 15);
            label30.TabIndex = 132;
            label30.Text = "Nombre Archivo:";
            // 
            // textBox_fecha
            // 
            textBox_fecha.Enabled = false;
            textBox_fecha.Location = new Point(117, 71);
            textBox_fecha.Name = "textBox_fecha";
            textBox_fecha.Size = new Size(359, 23);
            textBox_fecha.TabIndex = 133;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Enabled = false;
            label28.Location = new Point(42, 45);
            label28.Name = "label28";
            label28.Size = new Size(68, 15);
            label28.TabIndex = 131;
            label28.Text = "Creado por:";
            // 
            // button_filtrar
            // 
            button_filtrar.BackColor = SystemColors.ActiveCaption;
            button_filtrar.Image = Properties.Resources.lupa;
            button_filtrar.ImageAlign = ContentAlignment.MiddleLeft;
            button_filtrar.Location = new Point(280, 37);
            button_filtrar.Name = "button_filtrar";
            button_filtrar.Size = new Size(120, 23);
            button_filtrar.TabIndex = 130;
            button_filtrar.Text = "Filtrar";
            button_filtrar.UseVisualStyleBackColor = false;
            button_filtrar.Click += button_filtrar_Click;
            // 
            // dateTimePicker_hasta
            // 
            dateTimePicker_hasta.Format = DateTimePickerFormat.Short;
            dateTimePicker_hasta.Location = new Point(135, 37);
            dateTimePicker_hasta.Name = "dateTimePicker_hasta";
            dateTimePicker_hasta.Size = new Size(120, 23);
            dateTimePicker_hasta.TabIndex = 127;
            // 
            // dateTimePicker_desde
            // 
            dateTimePicker_desde.Format = DateTimePickerFormat.Short;
            dateTimePicker_desde.Location = new Point(6, 37);
            dateTimePicker_desde.Name = "dateTimePicker_desde";
            dateTimePicker_desde.Size = new Size(120, 23);
            dateTimePicker_desde.TabIndex = 126;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(135, 19);
            label9.Name = "label9";
            label9.Size = new Size(89, 15);
            label9.TabIndex = 125;
            label9.Text = "Vigencia Hasta:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(6, 19);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 123;
            label8.Text = "Vigencia desde:";
            // 
            // groupBox100
            // 
            groupBox100.Controls.Add(button1);
            groupBox100.Controls.Add(label8);
            groupBox100.Controls.Add(label9);
            groupBox100.Controls.Add(dateTimePicker_desde);
            groupBox100.Controls.Add(button_filtrar);
            groupBox100.Controls.Add(dateTimePicker_hasta);
            groupBox100.Location = new Point(6, 22);
            groupBox100.Name = "groupBox100";
            groupBox100.Size = new Size(556, 67);
            groupBox100.TabIndex = 142;
            groupBox100.TabStop = false;
            // 
            // Form_Respaldos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox4);
            Name = "Form_Respaldos";
            Text = "Form_Respaldos";
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_respaldos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            groupBox100.ResumeLayout(false);
            groupBox100.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox4;
        private DateTimePicker dateTimePicker_hasta;
        private DateTimePicker dateTimePicker_desde;
        private Label label9;
        private Label label8;
        private Button button_filtrar;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button_eliminar;
        private Button button_guardar;
        private Button button_restaurar;
        private Label label1;
        private RichTextBox richTextBox_descripcion;
        private TextBox textBox_creador;
        private TextBox textBox_fecha;
        private Label label28;
        private Label label30;
        private GroupBox groupBox1;
        private DataGridView dataGrid_respaldos;
        private TextBox textBox_nombre_archivo;
        private Label label2;
        private Label label3;
        private ComboBox comboBox_NombreBD;
        private Button button2;
        private Button button1;
        private GroupBox groupBox100;
    }
}