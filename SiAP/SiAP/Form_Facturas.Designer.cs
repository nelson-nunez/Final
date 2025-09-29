namespace SiAP.UI
{
    partial class Form_Facturas
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
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            textBox_paciente_seleccionado = new TextBox();
            richTextBox_descripcion = new RichTextBox();
            label8 = new Label();
            label7 = new Label();
            textBox_turno = new TextBox();
            label6 = new Label();
            textBox_estado = new TextBox();
            label5 = new Label();
            textBox_importe = new TextBox();
            label4 = new Label();
            textBox_nro_factura = new TextBox();
            label3 = new Label();
            textBox_fecha_emision = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(12, 12);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 226);
            uC_Buscar_Paciente1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Location = new Point(462, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 294);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pagos y Devoluciones";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(textBox_paciente_seleccionado);
            groupBox2.Controls.Add(richTextBox_descripcion);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox_turno);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox_estado);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox_importe);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox_nro_factura);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox_fecha_emision);
            groupBox2.Location = new Point(396, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(358, 274);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalles";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(37, 37);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 14;
            label9.Text = "Paciente:";
            // 
            // textBox_paciente_seleccionado
            // 
            textBox_paciente_seleccionado.Location = new Point(98, 34);
            textBox_paciente_seleccionado.Name = "textBox_paciente_seleccionado";
            textBox_paciente_seleccionado.Size = new Size(254, 23);
            textBox_paciente_seleccionado.TabIndex = 13;
            // 
            // richTextBox_descripcion
            // 
            richTextBox_descripcion.Location = new Point(98, 180);
            richTextBox_descripcion.Name = "richTextBox_descripcion";
            richTextBox_descripcion.Size = new Size(254, 89);
            richTextBox_descripcion.TabIndex = 12;
            richTextBox_descripcion.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 183);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 11;
            label8.Text = "Descripción:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 154);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 9;
            label7.Text = "Turno: ";
            // 
            // textBox_turno
            // 
            textBox_turno.Location = new Point(98, 150);
            textBox_turno.Name = "textBox_turno";
            textBox_turno.Size = new Size(254, 23);
            textBox_turno.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(209, 95);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 7;
            label6.Text = "Estado:";
            // 
            // textBox_estado
            // 
            textBox_estado.Location = new Point(260, 92);
            textBox_estado.Name = "textBox_estado";
            textBox_estado.Size = new Size(92, 23);
            textBox_estado.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 124);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 5;
            label5.Text = "Importe: ";
            // 
            // textBox_importe
            // 
            textBox_importe.Location = new Point(98, 121);
            textBox_importe.Name = "textBox_importe";
            textBox_importe.Size = new Size(254, 23);
            textBox_importe.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 95);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Nro. factura:";
            // 
            // textBox_nro_factura
            // 
            textBox_nro_factura.Location = new Point(98, 92);
            textBox_nro_factura.Name = "textBox_nro_factura";
            textBox_nro_factura.Size = new Size(105, 23);
            textBox_nro_factura.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 66);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 1;
            label3.Text = "Fecha Emisión:";
            // 
            // textBox_fecha_emision
            // 
            textBox_fecha_emision.Location = new Point(98, 63);
            textBox_fecha_emision.Name = "textBox_fecha_emision";
            textBox_fecha_emision.Size = new Size(254, 23);
            textBox_fecha_emision.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(384, 234);
            dataGridView1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 31);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Hasta: ";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(225, 25);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(102, 23);
            dateTimePicker2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 31);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Desde: ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(57, 25);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(102, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // Form_Facturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Controls.Add(uC_Buscar_Paciente1);
            Name = "Form_Facturas";
            Text = "Form_Facturas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label9;
        private TextBox textBox_paciente_seleccionado;
        private RichTextBox richTextBox_descripcion;
        private Label label8;
        private Label label7;
        private TextBox textBox_turno;
        private Label label6;
        private TextBox textBox_estado;
        private Label label5;
        private TextBox textBox_importe;
        private Label label4;
        private TextBox textBox_nro_factura;
        private Label label3;
        private TextBox textBox_fecha_emision;
        private DataGridView dataGridView1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
    }
}