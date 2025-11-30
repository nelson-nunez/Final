namespace SiAP.UI
{
    partial class Form_DashBoard
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
            formsPlot_especialidades = new ScottPlot.WinForms.FormsPlot();
            groupBox1 = new GroupBox();
            groupBox100 = new GroupBox();
            label8 = new Label();
            label9 = new Label();
            dateTimePicker_desde = new DateTimePicker();
            button_filtrar = new Button();
            dateTimePicker_hasta = new DateTimePicker();
            groupBox5 = new GroupBox();
            formsPlot_ingresos_especialidad = new ScottPlot.WinForms.FormsPlot();
            groupBox4 = new GroupBox();
            formsPlot_disponibilidad = new ScottPlot.WinForms.FormsPlot();
            groupBox3 = new GroupBox();
            formsPlot_ingresos = new ScottPlot.WinForms.FormsPlot();
            groupBox2 = new GroupBox();
            textBox_total_turnos_ingresos = new TextBox();
            label3 = new Label();
            textBox_total_turnos = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox100.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot_especialidades
            // 
            formsPlot_especialidades.DisplayScale = 1F;
            formsPlot_especialidades.Location = new Point(204, 15);
            formsPlot_especialidades.Name = "formsPlot_especialidades";
            formsPlot_especialidades.Size = new Size(472, 239);
            formsPlot_especialidades.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox100);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 707);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estadísticas";
            // 
            // groupBox100
            // 
            groupBox100.Controls.Add(label8);
            groupBox100.Controls.Add(label9);
            groupBox100.Controls.Add(dateTimePicker_desde);
            groupBox100.Controls.Add(button_filtrar);
            groupBox100.Controls.Add(dateTimePicker_hasta);
            groupBox100.Location = new Point(10, 16);
            groupBox100.Name = "groupBox100";
            groupBox100.Size = new Size(672, 61);
            groupBox100.TabIndex = 143;
            groupBox100.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(6, 26);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 123;
            label8.Text = "Desde:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(185, 26);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 125;
            label9.Text = "Hasta:";
            // 
            // dateTimePicker_desde
            // 
            dateTimePicker_desde.Format = DateTimePickerFormat.Short;
            dateTimePicker_desde.Location = new Point(54, 22);
            dateTimePicker_desde.Name = "dateTimePicker_desde";
            dateTimePicker_desde.Size = new Size(125, 23);
            dateTimePicker_desde.TabIndex = 126;
            // 
            // button_filtrar
            // 
            button_filtrar.BackColor = SystemColors.ActiveCaption;
            button_filtrar.Image = Properties.Resources.lupa;
            button_filtrar.ImageAlign = ContentAlignment.MiddleLeft;
            button_filtrar.Location = new Point(507, 22);
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
            dateTimePicker_hasta.Location = new Point(231, 22);
            dateTimePicker_hasta.Name = "dateTimePicker_hasta";
            dateTimePicker_hasta.Size = new Size(125, 23);
            dateTimePicker_hasta.TabIndex = 127;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.WhiteSmoke;
            groupBox5.Controls.Add(formsPlot_ingresos_especialidad);
            groupBox5.Location = new Point(694, 83);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(510, 308);
            groupBox5.TabIndex = 19;
            groupBox5.TabStop = false;
            groupBox5.Text = "Ingresos por Especialidad";
            // 
            // formsPlot_ingresos_especialidad
            // 
            formsPlot_ingresos_especialidad.DisplayScale = 1F;
            formsPlot_ingresos_especialidad.Location = new Point(6, 20);
            formsPlot_ingresos_especialidad.Name = "formsPlot_ingresos_especialidad";
            formsPlot_ingresos_especialidad.Size = new Size(498, 275);
            formsPlot_ingresos_especialidad.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.WhiteSmoke;
            groupBox4.Controls.Add(formsPlot_disponibilidad);
            groupBox4.Location = new Point(694, 397);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(510, 304);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Text = "Disponibilidad vs Ocupación";
            // 
            // formsPlot_disponibilidad
            // 
            formsPlot_disponibilidad.DisplayScale = 1F;
            formsPlot_disponibilidad.Location = new Point(6, 20);
            formsPlot_disponibilidad.Name = "formsPlot_disponibilidad";
            formsPlot_disponibilidad.Size = new Size(498, 278);
            formsPlot_disponibilidad.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.WhiteSmoke;
            groupBox3.Controls.Add(formsPlot_ingresos);
            groupBox3.Location = new Point(0, 83);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(682, 308);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ingresos Mensuales";
            // 
            // formsPlot_ingresos
            // 
            formsPlot_ingresos.DisplayScale = 1F;
            formsPlot_ingresos.Location = new Point(10, 22);
            formsPlot_ingresos.Name = "formsPlot_ingresos";
            formsPlot_ingresos.Size = new Size(666, 273);
            formsPlot_ingresos.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.WhiteSmoke;
            groupBox2.Controls.Add(textBox_total_turnos_ingresos);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox_total_turnos);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(formsPlot_especialidades);
            groupBox2.Location = new Point(6, 397);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(682, 304);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Turnos por Especialidad";
            // 
            // textBox_total_turnos_ingresos
            // 
            textBox_total_turnos_ingresos.Enabled = false;
            textBox_total_turnos_ingresos.Location = new Point(18, 101);
            textBox_total_turnos_ingresos.Name = "textBox_total_turnos_ingresos";
            textBox_total_turnos_ingresos.Size = new Size(180, 23);
            textBox_total_turnos_ingresos.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 83);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 3;
            label3.Text = "Total de Ingresos:";
            // 
            // textBox_total_turnos
            // 
            textBox_total_turnos.Enabled = false;
            textBox_total_turnos.Location = new Point(18, 52);
            textBox_total_turnos.Name = "textBox_total_turnos";
            textBox_total_turnos.Size = new Size(180, 23);
            textBox_total_turnos.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 34);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Total de Turnos:";
            // 
            // Form_DashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_DashBoard";
            Text = "Form_DashBoard";
            groupBox1.ResumeLayout(false);
            groupBox100.ResumeLayout(false);
            groupBox100.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot_especialidades;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ScottPlot.WinForms.FormsPlot formsPlot_ingresos;
        private TextBox textBox_total_turnos_ingresos;
        private Label label3;
        private TextBox textBox_total_turnos;
        private Label label2;
        private GroupBox groupBox4;
        private ScottPlot.WinForms.FormsPlot formsPlot_disponibilidad;
        private GroupBox groupBox5;
        private ScottPlot.WinForms.FormsPlot formsPlot_ingresos_especialidad;
        private GroupBox groupBox100;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePicker_desde;
        private Button button_filtrar;
        private DateTimePicker dateTimePicker_hasta;
    }
}