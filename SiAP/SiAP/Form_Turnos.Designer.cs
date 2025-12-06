namespace SiAP.UI
{
    partial class Form_Turnos
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
            dataGridView1 = new DataGridView();
            treeView1 = new TreeView();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            label8 = new Label();
            label9 = new Label();
            dateTimePicker_desde = new DateTimePicker();
            dateTimePicker_hasta = new DateTimePicker();
            button_imprimir = new Button();
            uC_Mostrar_Paciente1 = new Forms_Seguridad.UC_Mostrar_Paciente();
            groupBox2 = new GroupBox();
            label10_prop_agenda = new Label();
            label1 = new Label();
            button_sem_siguiente = new Button();
            comboBox1 = new ComboBox();
            button_sem_actual = new Button();
            button_sem_anterior = new Button();
            groupBox_turno = new GroupBox();
            button_cancelar_turno = new Button();
            button_marcar_ausencia = new Button();
            button_marcar_asistencia = new Button();
            textBox_hora_fin = new TextBox();
            textBox_hora_inicio = new TextBox();
            textBox_fecha = new TextBox();
            textBox_estado = new TextBox();
            textBox_medico = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label3 = new Label();
            label4 = new Label();
            button_eliminar_turno = new Button();
            button_asignar_turno = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox_turno.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(866, 405);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // treeView1
            // 
            treeView1.HideSelection = false;
            treeView1.Location = new Point(6, 22);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(314, 485);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(uC_Mostrar_Paciente1);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(groupBox_turno);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 715);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reservar Turno";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_medico);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(textBox_estado);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(textBox_fecha);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(textBox_hora_inicio);
            groupBox3.Controls.Add(textBox_hora_fin);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(715, 513);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(489, 109);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Turno Seleccionado";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(11, 28);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 128;
            label8.Text = "Desde:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(14, 57);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 129;
            label9.Text = "Hasta:";
            // 
            // dateTimePicker_desde
            // 
            dateTimePicker_desde.Format = DateTimePickerFormat.Short;
            dateTimePicker_desde.Location = new Point(60, 22);
            dateTimePicker_desde.Name = "dateTimePicker_desde";
            dateTimePicker_desde.Size = new Size(90, 23);
            dateTimePicker_desde.TabIndex = 130;
            // 
            // dateTimePicker_hasta
            // 
            dateTimePicker_hasta.Format = DateTimePickerFormat.Short;
            dateTimePicker_hasta.Location = new Point(60, 51);
            dateTimePicker_hasta.Name = "dateTimePicker_hasta";
            dateTimePicker_hasta.Size = new Size(90, 23);
            dateTimePicker_hasta.TabIndex = 131;
            // 
            // button_imprimir
            // 
            button_imprimir.BackColor = SystemColors.ActiveCaption;
            button_imprimir.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_imprimir.Image = Properties.Resources.printer;
            button_imprimir.ImageAlign = ContentAlignment.MiddleLeft;
            button_imprimir.Location = new Point(158, 22);
            button_imprimir.Margin = new Padding(5);
            button_imprimir.Name = "button_imprimir";
            button_imprimir.Size = new Size(119, 52);
            button_imprimir.TabIndex = 27;
            button_imprimir.Text = "Imprimir Turnos";
            button_imprimir.TextAlign = ContentAlignment.MiddleRight;
            button_imprimir.UseVisualStyleBackColor = false;
            button_imprimir.Click += button_imprimir_Click;
            // 
            // uC_Mostrar_Paciente1
            // 
            uC_Mostrar_Paciente1.BackColor = Color.Transparent;
            uC_Mostrar_Paciente1.Location = new Point(0, 513);
            uC_Mostrar_Paciente1.Name = "uC_Mostrar_Paciente1";
            uC_Mostrar_Paciente1.Size = new Size(709, 109);
            uC_Mostrar_Paciente1.TabIndex = 11;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10_prop_agenda);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button_sem_siguiente);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(button_sem_actual);
            groupBox2.Controls.Add(button_sem_anterior);
            groupBox2.Location = new Point(326, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(878, 493);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Turnos";
            // 
            // label10_prop_agenda
            // 
            label10_prop_agenda.AutoSize = true;
            label10_prop_agenda.Location = new Point(6, 25);
            label10_prop_agenda.Name = "label10_prop_agenda";
            label10_prop_agenda.Size = new Size(51, 15);
            label10_prop_agenda.TabIndex = 12;
            label10_prop_agenda.Text = "Agenda:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(386, 25);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 10;
            label1.Text = "Seleccionar Mes/Año";
            // 
            // button_sem_siguiente
            // 
            button_sem_siguiente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_siguiente.Location = new Point(752, 51);
            button_sem_siguiente.Name = "button_sem_siguiente";
            button_sem_siguiente.Size = new Size(120, 25);
            button_sem_siguiente.TabIndex = 5;
            button_sem_siguiente.Text = "Semana Siguiente";
            button_sem_siguiente.UseVisualStyleBackColor = true;
            button_sem_siguiente.Click += button_sem_siguiente_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(512, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button_sem_actual
            // 
            button_sem_actual.BackColor = SystemColors.ActiveCaption;
            button_sem_actual.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_actual.Location = new Point(385, 51);
            button_sem_actual.Name = "button_sem_actual";
            button_sem_actual.Size = new Size(120, 25);
            button_sem_actual.TabIndex = 4;
            button_sem_actual.Text = "Semana Actual";
            button_sem_actual.UseVisualStyleBackColor = false;
            button_sem_actual.Click += button_mes_actual_Click;
            // 
            // button_sem_anterior
            // 
            button_sem_anterior.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_anterior.Location = new Point(6, 51);
            button_sem_anterior.Name = "button_sem_anterior";
            button_sem_anterior.Size = new Size(120, 25);
            button_sem_anterior.TabIndex = 3;
            button_sem_anterior.Text = "Semana Anterior";
            button_sem_anterior.UseVisualStyleBackColor = true;
            button_sem_anterior.Click += button_sem_anterior_Click;
            // 
            // groupBox_turno
            // 
            groupBox_turno.Controls.Add(label8);
            groupBox_turno.Controls.Add(button_cancelar_turno);
            groupBox_turno.Controls.Add(label9);
            groupBox_turno.Controls.Add(button_marcar_ausencia);
            groupBox_turno.Controls.Add(dateTimePicker_desde);
            groupBox_turno.Controls.Add(dateTimePicker_hasta);
            groupBox_turno.Controls.Add(button_marcar_asistencia);
            groupBox_turno.Controls.Add(button_imprimir);
            groupBox_turno.Controls.Add(button_eliminar_turno);
            groupBox_turno.Controls.Add(button_asignar_turno);
            groupBox_turno.Location = new Point(6, 628);
            groupBox_turno.Name = "groupBox_turno";
            groupBox_turno.Size = new Size(1198, 81);
            groupBox_turno.TabIndex = 5;
            groupBox_turno.TabStop = false;
            groupBox_turno.Text = "Acciones";
            // 
            // button_cancelar_turno
            // 
            button_cancelar_turno.BackColor = Color.LightSalmon;
            button_cancelar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_cancelar_turno.Location = new Point(659, 35);
            button_cancelar_turno.Name = "button_cancelar_turno";
            button_cancelar_turno.Size = new Size(140, 27);
            button_cancelar_turno.TabIndex = 30;
            button_cancelar_turno.Text = "Cancelar Turno";
            button_cancelar_turno.UseVisualStyleBackColor = false;
            button_cancelar_turno.Click += button_cancelar_turno_Click;
            // 
            // button_marcar_ausencia
            // 
            button_marcar_ausencia.BackColor = Color.DarkGray;
            button_marcar_ausencia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_marcar_ausencia.Location = new Point(511, 35);
            button_marcar_ausencia.Name = "button_marcar_ausencia";
            button_marcar_ausencia.Size = new Size(140, 27);
            button_marcar_ausencia.TabIndex = 29;
            button_marcar_ausencia.Text = "Marcar Ausencia";
            button_marcar_ausencia.UseVisualStyleBackColor = false;
            button_marcar_ausencia.Click += button_marcar_ausencia_Click;
            // 
            // button_marcar_asistencia
            // 
            button_marcar_asistencia.BackColor = SystemColors.ActiveCaption;
            button_marcar_asistencia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_marcar_asistencia.Location = new Point(365, 35);
            button_marcar_asistencia.Name = "button_marcar_asistencia";
            button_marcar_asistencia.Size = new Size(140, 27);
            button_marcar_asistencia.TabIndex = 28;
            button_marcar_asistencia.Text = "Marcar Asistencia";
            button_marcar_asistencia.UseVisualStyleBackColor = false;
            button_marcar_asistencia.Click += button_marcar_asistencia_Click;
            // 
            // textBox_hora_fin
            // 
            textBox_hora_fin.BackColor = Color.WhiteSmoke;
            textBox_hora_fin.Enabled = false;
            textBox_hora_fin.Location = new Point(314, 75);
            textBox_hora_fin.Name = "textBox_hora_fin";
            textBox_hora_fin.Size = new Size(157, 23);
            textBox_hora_fin.TabIndex = 26;
            // 
            // textBox_hora_inicio
            // 
            textBox_hora_inicio.BackColor = Color.WhiteSmoke;
            textBox_hora_inicio.Enabled = false;
            textBox_hora_inicio.Location = new Point(84, 77);
            textBox_hora_inicio.Name = "textBox_hora_inicio";
            textBox_hora_inicio.Size = new Size(119, 23);
            textBox_hora_inicio.TabIndex = 25;
            // 
            // textBox_fecha
            // 
            textBox_fecha.BackColor = Color.WhiteSmoke;
            textBox_fecha.Enabled = false;
            textBox_fecha.Location = new Point(84, 48);
            textBox_fecha.Name = "textBox_fecha";
            textBox_fecha.Size = new Size(119, 23);
            textBox_fecha.TabIndex = 24;
            // 
            // textBox_estado
            // 
            textBox_estado.BackColor = Color.WhiteSmoke;
            textBox_estado.Enabled = false;
            textBox_estado.Location = new Point(314, 48);
            textBox_estado.Name = "textBox_estado";
            textBox_estado.Size = new Size(157, 23);
            textBox_estado.TabIndex = 23;
            // 
            // textBox_medico
            // 
            textBox_medico.BackColor = Color.WhiteSmoke;
            textBox_medico.Enabled = false;
            textBox_medico.Location = new Point(84, 19);
            textBox_medico.Name = "textBox_medico";
            textBox_medico.Size = new Size(387, 23);
            textBox_medico.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(6, 80);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 19;
            label5.Text = "Hora Inicio: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(34, 51);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 18;
            label6.Text = "Fecha: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.Location = new Point(25, 22);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 17;
            label7.Text = "Médico: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(209, 51);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 15;
            label3.Text = "Estado del turno: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(250, 78);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 14;
            label4.Text = "Hora Fin: ";
            // 
            // button_eliminar_turno
            // 
            button_eliminar_turno.BackColor = Color.IndianRed;
            button_eliminar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_eliminar_turno.Location = new Point(1039, 31);
            button_eliminar_turno.Name = "button_eliminar_turno";
            button_eliminar_turno.Size = new Size(141, 35);
            button_eliminar_turno.TabIndex = 9;
            button_eliminar_turno.Text = "Eliminar Turno";
            button_eliminar_turno.UseVisualStyleBackColor = false;
            button_eliminar_turno.Click += button_eliminar_turno_Click;
            // 
            // button_asignar_turno
            // 
            button_asignar_turno.BackColor = Color.DarkSeaGreen;
            button_asignar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_asignar_turno.Location = new Point(876, 31);
            button_asignar_turno.Name = "button_asignar_turno";
            button_asignar_turno.Size = new Size(141, 35);
            button_asignar_turno.TabIndex = 10;
            button_asignar_turno.Text = "Asignar Turno";
            button_asignar_turno.UseVisualStyleBackColor = false;
            button_asignar_turno.Click += button_asignar_turno_Click;
            // 
            // Form_Turnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_Turnos";
            Text = "Form_Turnos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox_turno.ResumeLayout(false);
            groupBox_turno.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private TreeView treeView1;
        private GroupBox groupBox1;
        private GroupBox groupBox_turno;
        private Button button_sem_actual;
        private Button button_sem_anterior;
        private GroupBox groupBox2;
        private Label label1;
        private Button button_sem_siguiente;
        private ComboBox comboBox1;
        private Button button_eliminar_turno;
        private Button button_asignar_turno;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label3;
        private Label label4;
        private TextBox textBox_hora_fin;
        private TextBox textBox_hora_inicio;
        private TextBox textBox_fecha;
        private TextBox textBox_estado;
        private TextBox textBox_medico;
        private Button button_imprimir;
        private Button button_marcar_ausencia;
        private Button button_marcar_asistencia;
        private Button button_cancelar_turno;
        private MonthCalendar monthCalendar1;
        private Forms_Seguridad.UC_Mostrar_Paciente uC_Mostrar_Paciente1;
        private GroupBox groupBox3;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePicker_desde;
        private DateTimePicker dateTimePicker_hasta;
        private Label label10_prop_agenda;
    }
}