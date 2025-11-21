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
            groupBox2 = new GroupBox();
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
            label1 = new Label();
            label_titular_agenda = new Label();
            button_sem_siguiente = new Button();
            comboBox1 = new ComboBox();
            button_sem_actual = new Button();
            button_sem_anterior = new Button();
            groupBox_turno = new GroupBox();
            textBox_hora_fin = new TextBox();
            textBox_hora_inicio = new TextBox();
            textBox_fecha = new TextBox();
            textBox_estado = new TextBox();
            textBox_paciente = new TextBox();
            textBox_medico = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label3 = new Label();
            label4 = new Label();
            button_eliminar_turno = new Button();
            button_asignar_turno = new Button();
            button_seleccionar_paciente = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox_turno.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(866, 495);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // treeView1
            // 
            treeView1.HideSelection = false;
            treeView1.Location = new Point(6, 22);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(314, 571);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBox1
            // 
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
            // groupBox2
            // 
            groupBox2.Controls.Add(uC_Buscar_Paciente1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label_titular_agenda);
            groupBox2.Controls.Add(button_sem_siguiente);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(button_sem_actual);
            groupBox2.Controls.Add(button_sem_anterior);
            groupBox2.Location = new Point(326, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(878, 587);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Turnos";
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.BackColor = Color.DarkGray;
            uC_Buscar_Paciente1.Location = new Point(93, 164);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(442, 228);
            uC_Buscar_Paciente1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(284, 19);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 10;
            label1.Text = "Seleccionar Mes/Año";
            // 
            // label_titular_agenda
            // 
            label_titular_agenda.AutoSize = true;
            label_titular_agenda.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titular_agenda.Location = new Point(6, 19);
            label_titular_agenda.Name = "label_titular_agenda";
            label_titular_agenda.Size = new Size(48, 15);
            label_titular_agenda.TabIndex = 4;
            label_titular_agenda.Text = "Agenda";
            // 
            // button_sem_siguiente
            // 
            button_sem_siguiente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_siguiente.Location = new Point(752, 55);
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
            comboBox1.Location = new Point(410, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button_sem_actual
            // 
            button_sem_actual.BackColor = SystemColors.ActiveCaption;
            button_sem_actual.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_actual.Location = new Point(381, 55);
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
            button_sem_anterior.Location = new Point(6, 55);
            button_sem_anterior.Name = "button_sem_anterior";
            button_sem_anterior.Size = new Size(120, 25);
            button_sem_anterior.TabIndex = 3;
            button_sem_anterior.Text = "Semana Anterior";
            button_sem_anterior.UseVisualStyleBackColor = true;
            button_sem_anterior.Click += button_sem_anterior_Click;
            // 
            // groupBox_turno
            // 
            groupBox_turno.Controls.Add(textBox_hora_fin);
            groupBox_turno.Controls.Add(textBox_hora_inicio);
            groupBox_turno.Controls.Add(textBox_fecha);
            groupBox_turno.Controls.Add(textBox_estado);
            groupBox_turno.Controls.Add(textBox_paciente);
            groupBox_turno.Controls.Add(textBox_medico);
            groupBox_turno.Controls.Add(label5);
            groupBox_turno.Controls.Add(label6);
            groupBox_turno.Controls.Add(label7);
            groupBox_turno.Controls.Add(label3);
            groupBox_turno.Controls.Add(label4);
            groupBox_turno.Controls.Add(button_eliminar_turno);
            groupBox_turno.Controls.Add(button_asignar_turno);
            groupBox_turno.Controls.Add(button_seleccionar_paciente);
            groupBox_turno.Location = new Point(6, 599);
            groupBox_turno.Name = "groupBox_turno";
            groupBox_turno.Size = new Size(1198, 110);
            groupBox_turno.TabIndex = 5;
            groupBox_turno.TabStop = false;
            groupBox_turno.Text = "Turno Seleccionado";
            // 
            // textBox_hora_fin
            // 
            textBox_hora_fin.BackColor = Color.WhiteSmoke;
            textBox_hora_fin.Enabled = false;
            textBox_hora_fin.Location = new Point(427, 82);
            textBox_hora_fin.Name = "textBox_hora_fin";
            textBox_hora_fin.Size = new Size(119, 23);
            textBox_hora_fin.TabIndex = 26;
            // 
            // textBox_hora_inicio
            // 
            textBox_hora_inicio.BackColor = Color.WhiteSmoke;
            textBox_hora_inicio.Enabled = false;
            textBox_hora_inicio.Location = new Point(427, 53);
            textBox_hora_inicio.Name = "textBox_hora_inicio";
            textBox_hora_inicio.Size = new Size(119, 23);
            textBox_hora_inicio.TabIndex = 25;
            // 
            // textBox_fecha
            // 
            textBox_fecha.BackColor = Color.WhiteSmoke;
            textBox_fecha.Enabled = false;
            textBox_fecha.Location = new Point(427, 24);
            textBox_fecha.Name = "textBox_fecha";
            textBox_fecha.Size = new Size(119, 23);
            textBox_fecha.TabIndex = 24;
            // 
            // textBox_estado
            // 
            textBox_estado.BackColor = Color.WhiteSmoke;
            textBox_estado.Enabled = false;
            textBox_estado.Location = new Point(115, 82);
            textBox_estado.Name = "textBox_estado";
            textBox_estado.Size = new Size(219, 23);
            textBox_estado.TabIndex = 23;
            // 
            // textBox_paciente
            // 
            textBox_paciente.BackColor = Color.WhiteSmoke;
            textBox_paciente.Enabled = false;
            textBox_paciente.Location = new Point(115, 53);
            textBox_paciente.Name = "textBox_paciente";
            textBox_paciente.Size = new Size(219, 23);
            textBox_paciente.TabIndex = 22;
            // 
            // textBox_medico
            // 
            textBox_medico.BackColor = Color.WhiteSmoke;
            textBox_medico.Enabled = false;
            textBox_medico.Location = new Point(115, 25);
            textBox_medico.Name = "textBox_medico";
            textBox_medico.Size = new Size(219, 23);
            textBox_medico.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(349, 57);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 19;
            label5.Text = "Hora Inicio: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(377, 28);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 18;
            label6.Text = "Fecha: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.Location = new Point(56, 28);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 17;
            label7.Text = "Médico: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(61, 85);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 15;
            label3.Text = "Estado: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(363, 85);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 14;
            label4.Text = "Hora Fin: ";
            // 
            // button_eliminar_turno
            // 
            button_eliminar_turno.BackColor = Color.IndianRed;
            button_eliminar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_eliminar_turno.Location = new Point(1077, 20);
            button_eliminar_turno.Name = "button_eliminar_turno";
            button_eliminar_turno.Size = new Size(115, 40);
            button_eliminar_turno.TabIndex = 9;
            button_eliminar_turno.Text = "Eliminar Turno";
            button_eliminar_turno.UseVisualStyleBackColor = false;
            button_eliminar_turno.Click += button_eliminar_turno_Click;
            // 
            // button_asignar_turno
            // 
            button_asignar_turno.BackColor = Color.MediumSeaGreen;
            button_asignar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_asignar_turno.Location = new Point(1077, 64);
            button_asignar_turno.Name = "button_asignar_turno";
            button_asignar_turno.Size = new Size(115, 40);
            button_asignar_turno.TabIndex = 10;
            button_asignar_turno.Text = "Asignar Turno";
            button_asignar_turno.UseVisualStyleBackColor = false;
            button_asignar_turno.Click += button_asignar_turno_Click;
            // 
            // button_seleccionar_paciente
            // 
            button_seleccionar_paciente.BackColor = SystemColors.ActiveCaption;
            button_seleccionar_paciente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_seleccionar_paciente.Location = new Point(6, 52);
            button_seleccionar_paciente.Name = "button_seleccionar_paciente";
            button_seleccionar_paciente.Size = new Size(103, 23);
            button_seleccionar_paciente.TabIndex = 7;
            button_seleccionar_paciente.Text = "Buscar Paciente";
            button_seleccionar_paciente.UseVisualStyleBackColor = false;
            button_seleccionar_paciente.Click += button_seleccionar_paciente_Click;
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
        private Label label_titular_agenda;
        private GroupBox groupBox_turno;
        private Button button_sem_actual;
        private Button button_sem_anterior;
        private GroupBox groupBox2;
        private Label label1;
        private Button button_sem_siguiente;
        private ComboBox comboBox1;
        private Button button_eliminar_turno;
        private Button button_asignar_turno;
        private Button button_seleccionar_paciente;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label3;
        private Label label4;
        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
        private TextBox textBox_hora_fin;
        private TextBox textBox_hora_inicio;
        private TextBox textBox_fecha;
        private TextBox textBox_estado;
        private TextBox textBox_paciente;
        private TextBox textBox_medico;
    }
}