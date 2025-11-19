namespace SiAP.UI
{
    partial class Form_Cobros
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
            uC_Mostrar_Paciente1 = new Forms_Seguridad.UC_Mostrar_Paciente();
            dataGrid_cobros = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            textBox_importe_pagar = new TextBox();
            label7 = new Label();
            textBox_pendiente = new TextBox();
            label6 = new Label();
            textBox_monto_total = new TextBox();
            comboBox_tipo_pago = new ComboBox();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox_estado_cobro = new TextBox();
            groupBox2 = new GroupBox();
            textBox_tipo_atencion_turno = new TextBox();
            label3 = new Label();
            textBox_estado_turno = new TextBox();
            label2 = new Label();
            textBox_fecha_turno = new TextBox();
            label30 = new Label();
            textBox_hora_turno = new TextBox();
            label28 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button_reembolsar = new Button();
            button_limpiar = new Button();
            button_guardar_pago = new Button();
            button_imprimir = new Button();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_cobros).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.WhiteSmoke;
            groupBox4.Controls.Add(uC_Mostrar_Paciente1);
            groupBox4.Controls.Add(dataGrid_cobros);
            groupBox4.Controls.Add(groupBox1);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1210, 707);
            groupBox4.TabIndex = 92;
            groupBox4.TabStop = false;
            groupBox4.Text = "Cobros";
            // 
            // uC_Mostrar_Paciente1
            // 
            uC_Mostrar_Paciente1.BackColor = Color.Transparent;
            uC_Mostrar_Paciente1.Location = new Point(6, 22);
            uC_Mostrar_Paciente1.Name = "uC_Mostrar_Paciente1";
            uC_Mostrar_Paciente1.Size = new Size(900, 109);
            uC_Mostrar_Paciente1.TabIndex = 141;
            // 
            // dataGrid_cobros
            // 
            dataGrid_cobros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_cobros.Location = new Point(6, 137);
            dataGrid_cobros.Name = "dataGrid_cobros";
            dataGrid_cobros.Size = new Size(754, 564);
            dataGrid_cobros.TabIndex = 140;
            dataGrid_cobros.CellClick += dataGrid_cobros_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(flowLayoutPanel2);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(766, 143);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 564);
            groupBox1.TabIndex = 139;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cobro Seleccionado";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_importe_pagar);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(textBox_pendiente);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(textBox_monto_total);
            groupBox3.Controls.Add(comboBox_tipo_pago);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(textBox_estado_cobro);
            groupBox3.Location = new Point(8, 191);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(418, 212);
            groupBox3.TabIndex = 149;
            groupBox3.TabStop = false;
            groupBox3.Text = "Información de Pago";
            // 
            // textBox_importe_pagar
            // 
            textBox_importe_pagar.BackColor = Color.FromArgb(230, 255, 230);
            textBox_importe_pagar.Location = new Point(142, 158);
            textBox_importe_pagar.Name = "textBox_importe_pagar";
            textBox_importe_pagar.Size = new Size(228, 23);
            textBox_importe_pagar.TabIndex = 151;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 161);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 150;
            label7.Text = "Importe a Pagar:";
            // 
            // textBox_pendiente
            // 
            textBox_pendiente.Enabled = false;
            textBox_pendiente.Location = new Point(142, 129);
            textBox_pendiente.Name = "textBox_pendiente";
            textBox_pendiente.Size = new Size(228, 23);
            textBox_pendiente.TabIndex = 149;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 132);
            label6.Name = "label6";
            label6.Size = new Size(109, 15);
            label6.TabIndex = 148;
            label6.Text = "Importe Pendiente:";
            // 
            // textBox_monto_total
            // 
            textBox_monto_total.BackColor = Color.FromArgb(255, 192, 192);
            textBox_monto_total.Enabled = false;
            textBox_monto_total.Location = new Point(142, 100);
            textBox_monto_total.Name = "textBox_monto_total";
            textBox_monto_total.Size = new Size(228, 23);
            textBox_monto_total.TabIndex = 143;
            // 
            // comboBox_tipo_pago
            // 
            comboBox_tipo_pago.FormattingEnabled = true;
            comboBox_tipo_pago.Location = new Point(142, 71);
            comboBox_tipo_pago.Name = "comboBox_tipo_pago";
            comboBox_tipo_pago.Size = new Size(228, 23);
            comboBox_tipo_pago.TabIndex = 147;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 103);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 142;
            label1.Text = "Monto Total:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 74);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 146;
            label5.Text = "Tipo de Pago:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 45);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 144;
            label4.Text = "Estado de Cobro:";
            // 
            // textBox_estado_cobro
            // 
            textBox_estado_cobro.Enabled = false;
            textBox_estado_cobro.Location = new Point(142, 42);
            textBox_estado_cobro.Name = "textBox_estado_cobro";
            textBox_estado_cobro.Size = new Size(228, 23);
            textBox_estado_cobro.TabIndex = 145;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox_tipo_atencion_turno);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox_estado_turno);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox_fecha_turno);
            groupBox2.Controls.Add(label30);
            groupBox2.Controls.Add(textBox_hora_turno);
            groupBox2.Controls.Add(label28);
            groupBox2.Location = new Point(8, 33);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(418, 152);
            groupBox2.TabIndex = 148;
            groupBox2.TabStop = false;
            groupBox2.Text = "Turno Seleccionado";
            // 
            // textBox_tipo_atencion_turno
            // 
            textBox_tipo_atencion_turno.Enabled = false;
            textBox_tipo_atencion_turno.Location = new Point(142, 85);
            textBox_tipo_atencion_turno.Name = "textBox_tipo_atencion_turno";
            textBox_tipo_atencion_turno.Size = new Size(236, 23);
            textBox_tipo_atencion_turno.TabIndex = 149;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 88);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 148;
            label3.Text = "Tipo de Atención:";
            // 
            // textBox_estado_turno
            // 
            textBox_estado_turno.Enabled = false;
            textBox_estado_turno.Location = new Point(142, 114);
            textBox_estado_turno.Name = "textBox_estado_turno";
            textBox_estado_turno.Size = new Size(236, 23);
            textBox_estado_turno.TabIndex = 147;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(66, 59);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 146;
            label2.Text = "Hora Inicio:";
            // 
            // textBox_fecha_turno
            // 
            textBox_fecha_turno.Enabled = false;
            textBox_fecha_turno.Location = new Point(142, 27);
            textBox_fecha_turno.Name = "textBox_fecha_turno";
            textBox_fecha_turno.Size = new Size(236, 23);
            textBox_fecha_turno.TabIndex = 145;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(40, 117);
            label30.Name = "label30";
            label30.Size = new Size(98, 15);
            label30.TabIndex = 143;
            label30.Text = "Estado del Turno:";
            // 
            // textBox_hora_turno
            // 
            textBox_hora_turno.Enabled = false;
            textBox_hora_turno.Location = new Point(141, 56);
            textBox_hora_turno.Name = "textBox_hora_turno";
            textBox_hora_turno.Size = new Size(236, 23);
            textBox_hora_turno.TabIndex = 144;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Enabled = false;
            label28.Location = new Point(60, 30);
            label28.Name = "label28";
            label28.Size = new Size(75, 15);
            label28.TabIndex = 142;
            label28.Text = "Fecha Turno:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button_reembolsar);
            flowLayoutPanel2.Controls.Add(button_limpiar);
            flowLayoutPanel2.Controls.Add(button_guardar_pago);
            flowLayoutPanel2.Controls.Add(button_imprimir);
            flowLayoutPanel2.Location = new Point(8, 469);
            flowLayoutPanel2.Margin = new Padding(5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(422, 87);
            flowLayoutPanel2.TabIndex = 129;
            // 
            // button_reembolsar
            // 
            button_reembolsar.BackColor = Color.IndianRed;
            button_reembolsar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_reembolsar.Image = Properties.Resources.reembolso;
            button_reembolsar.ImageAlign = ContentAlignment.MiddleLeft;
            button_reembolsar.Location = new Point(5, 5);
            button_reembolsar.Margin = new Padding(5);
            button_reembolsar.Name = "button_reembolsar";
            button_reembolsar.Size = new Size(115, 30);
            button_reembolsar.TabIndex = 22;
            button_reembolsar.Text = "Reembolsar";
            button_reembolsar.TextAlign = ContentAlignment.MiddleRight;
            button_reembolsar.UseVisualStyleBackColor = false;
            button_reembolsar.Click += button_reembolsar_Click;
            // 
            // button_limpiar
            // 
            button_limpiar.BackColor = Color.SandyBrown;
            button_limpiar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_limpiar.Image = Properties.Resources.clear;
            button_limpiar.ImageAlign = ContentAlignment.MiddleLeft;
            button_limpiar.Location = new Point(130, 5);
            button_limpiar.Margin = new Padding(5);
            button_limpiar.Name = "button_limpiar";
            button_limpiar.Size = new Size(115, 30);
            button_limpiar.TabIndex = 26;
            button_limpiar.Text = "Limpiar";
            button_limpiar.UseVisualStyleBackColor = false;
            button_limpiar.Click += button_limpiar_Click;
            // 
            // button_guardar_pago
            // 
            button_guardar_pago.BackColor = Color.DarkSeaGreen;
            button_guardar_pago.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_guardar_pago.Image = Properties.Resources.pagar;
            button_guardar_pago.ImageAlign = ContentAlignment.MiddleLeft;
            button_guardar_pago.Location = new Point(255, 5);
            button_guardar_pago.Margin = new Padding(5);
            button_guardar_pago.Name = "button_guardar_pago";
            button_guardar_pago.Size = new Size(115, 30);
            button_guardar_pago.TabIndex = 25;
            button_guardar_pago.Text = "Guardar Pago";
            button_guardar_pago.TextAlign = ContentAlignment.MiddleRight;
            button_guardar_pago.UseVisualStyleBackColor = false;
            button_guardar_pago.Click += button_guardar_pago_Click;
            // 
            // button_imprimir
            // 
            button_imprimir.BackColor = SystemColors.ActiveCaption;
            button_imprimir.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_imprimir.Image = Properties.Resources.printer;
            button_imprimir.ImageAlign = ContentAlignment.MiddleLeft;
            button_imprimir.Location = new Point(5, 45);
            button_imprimir.Margin = new Padding(5);
            button_imprimir.Name = "button_imprimir";
            button_imprimir.Size = new Size(125, 30);
            button_imprimir.TabIndex = 24;
            button_imprimir.Text = "Imprimir Factura";
            button_imprimir.TextAlign = ContentAlignment.MiddleRight;
            button_imprimir.UseVisualStyleBackColor = false;
            button_imprimir.Click += button_imprimir_Click;
            // 
            // Form_Cobros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox4);
            Name = "Form_Cobros";
            Text = "Form_Cobros";
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid_cobros).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox4;
        private DataGridView dataGrid_cobros;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button_reembolsar;
        private Button button_limpiar;
        private Button button_guardar_pago;
        private Button button_imprimir;
        private Forms_Seguridad.UC_Mostrar_Paciente uC_Mostrar_Paciente1;
        private TextBox textBox_monto_total;
        private Label label1;
        private Label label5;
        private TextBox textBox_estado_cobro;
        private Label label4;
        private ComboBox comboBox_tipo_pago;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox textBox_tipo_atencion_turno;
        private Label label3;
        private TextBox textBox_estado_turno;
        private Label label2;
        private TextBox textBox_fecha_turno;
        private Label label30;
        private TextBox textBox_hora_turno;
        private Label label28;
        private TextBox textBox_pendiente;
        private Label label6;
        private TextBox textBox_importe_pagar;
        private Label label7;
    }
}