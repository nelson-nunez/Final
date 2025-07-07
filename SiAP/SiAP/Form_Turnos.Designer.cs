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
            label1 = new Label();
            label_titular_agenda = new Label();
            button_sem_siguiente = new Button();
            comboBox1 = new ComboBox();
            button_sem_actual = new Button();
            button_sem_anterior = new Button();
            groupBox_turno = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button_eliminar_turno = new Button();
            button_asignar_turno = new Button();
            button_seleccionar_paciente = new Button();
            label_Paciente = new Label();
            label_estado = new Label();
            label_h_fin = new Label();
            label_h_inicio = new Label();
            label_fecha = new Label();
            label_medico = new Label();
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
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
            dataGridView1.Size = new Size(776, 467);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // treeView1
            // 
            treeView1.HideSelection = false;
            treeView1.Location = new Point(6, 22);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(314, 679);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(groupBox_turno);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 707);
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
            groupBox2.Location = new Point(326, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(878, 562);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Turnos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(310, 26);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 10;
            label1.Text = "Seleccionar Mes/Año";
            // 
            // label_titular_agenda
            // 
            label_titular_agenda.AutoSize = true;
            label_titular_agenda.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titular_agenda.Location = new Point(6, 25);
            label_titular_agenda.Name = "label_titular_agenda";
            label_titular_agenda.Size = new Size(48, 15);
            label_titular_agenda.TabIndex = 4;
            label_titular_agenda.Text = "Agenda";
            // 
            // button_sem_siguiente
            // 
            button_sem_siguiente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_siguiente.Location = new Point(662, 55);
            button_sem_siguiente.Name = "button_sem_siguiente";
            button_sem_siguiente.Size = new Size(120, 25);
            button_sem_siguiente.TabIndex = 8;
            button_sem_siguiente.Text = "Semana Siguiente";
            button_sem_siguiente.UseVisualStyleBackColor = true;
            button_sem_siguiente.Click += button_sem_siguiente_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(436, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button_sem_actual
            // 
            button_sem_actual.BackColor = SystemColors.ActiveCaption;
            button_sem_actual.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_actual.Location = new Point(335, 55);
            button_sem_actual.Name = "button_sem_actual";
            button_sem_actual.Size = new Size(120, 25);
            button_sem_actual.TabIndex = 7;
            button_sem_actual.Text = "Semana Actual";
            button_sem_actual.UseVisualStyleBackColor = false;
            button_sem_actual.Click += button_sem_actual_Click;
            // 
            // button_sem_anterior
            // 
            button_sem_anterior.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_anterior.Location = new Point(6, 55);
            button_sem_anterior.Name = "button_sem_anterior";
            button_sem_anterior.Size = new Size(120, 25);
            button_sem_anterior.TabIndex = 6;
            button_sem_anterior.Text = "Semana Anterior";
            button_sem_anterior.UseVisualStyleBackColor = true;
            button_sem_anterior.Click += button_sem_anterior_Click;
            // 
            // groupBox_turno
            // 
            groupBox_turno.Controls.Add(label5);
            groupBox_turno.Controls.Add(label6);
            groupBox_turno.Controls.Add(label7);
            groupBox_turno.Controls.Add(label2);
            groupBox_turno.Controls.Add(label3);
            groupBox_turno.Controls.Add(label4);
            groupBox_turno.Controls.Add(button_eliminar_turno);
            groupBox_turno.Controls.Add(button_asignar_turno);
            groupBox_turno.Controls.Add(button_seleccionar_paciente);
            groupBox_turno.Controls.Add(label_Paciente);
            groupBox_turno.Controls.Add(label_estado);
            groupBox_turno.Controls.Add(label_h_fin);
            groupBox_turno.Controls.Add(label_h_inicio);
            groupBox_turno.Controls.Add(label_fecha);
            groupBox_turno.Controls.Add(label_medico);
            groupBox_turno.Location = new Point(326, 590);
            groupBox_turno.Name = "groupBox_turno";
            groupBox_turno.Size = new Size(878, 111);
            groupBox_turno.TabIndex = 5;
            groupBox_turno.TabStop = false;
            groupBox_turno.Text = "Turno Seleccionado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(174, 69);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 19;
            label5.Text = "Inicio: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(20, 69);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 18;
            label6.Text = "Fecha: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.Location = new Point(11, 21);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 17;
            label7.Text = "Médico: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 16;
            label2.Text = "Paciente: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(16, 91);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 15;
            label3.Text = "Estado: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(187, 91);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 14;
            label4.Text = "Fin: ";
            // 
            // button_eliminar_turno
            // 
            button_eliminar_turno.BackColor = Color.IndianRed;
            button_eliminar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_eliminar_turno.Location = new Point(808, 31);
            button_eliminar_turno.Name = "button_eliminar_turno";
            button_eliminar_turno.Size = new Size(64, 53);
            button_eliminar_turno.TabIndex = 13;
            button_eliminar_turno.Text = "Eliminar Turno";
            button_eliminar_turno.UseVisualStyleBackColor = false;
            button_eliminar_turno.Click += button_eliminar_turno_Click;
            // 
            // button_asignar_turno
            // 
            button_asignar_turno.BackColor = Color.MediumSeaGreen;
            button_asignar_turno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_asignar_turno.Location = new Point(739, 31);
            button_asignar_turno.Name = "button_asignar_turno";
            button_asignar_turno.Size = new Size(63, 53);
            button_asignar_turno.TabIndex = 12;
            button_asignar_turno.Text = "Asignar Turno";
            button_asignar_turno.UseVisualStyleBackColor = false;
            button_asignar_turno.Click += button_asignar_turno_Click;
            // 
            // button_seleccionar_paciente
            // 
            button_seleccionar_paciente.BackColor = SystemColors.ActiveCaption;
            button_seleccionar_paciente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_seleccionar_paciente.Location = new Point(501, 31);
            button_seleccionar_paciente.Name = "button_seleccionar_paciente";
            button_seleccionar_paciente.Size = new Size(83, 53);
            button_seleccionar_paciente.TabIndex = 11;
            button_seleccionar_paciente.Text = "Seleccionar Paciente";
            button_seleccionar_paciente.UseVisualStyleBackColor = false;
            button_seleccionar_paciente.Click += button_seleccionar_paciente_Click;
            // 
            // label_Paciente
            // 
            label_Paciente.AutoSize = true;
            label_Paciente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_Paciente.Location = new Point(70, 46);
            label_Paciente.Name = "label_Paciente";
            label_Paciente.Size = new Size(27, 15);
            label_Paciente.TabIndex = 5;
            label_Paciente.Text = "____";
            // 
            // label_estado
            // 
            label_estado.AutoSize = true;
            label_estado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_estado.Location = new Point(70, 91);
            label_estado.Name = "label_estado";
            label_estado.Size = new Size(27, 15);
            label_estado.TabIndex = 4;
            label_estado.Text = "____";
            // 
            // label_h_fin
            // 
            label_h_fin.AutoSize = true;
            label_h_fin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_h_fin.Location = new Point(229, 91);
            label_h_fin.Name = "label_h_fin";
            label_h_fin.Size = new Size(27, 15);
            label_h_fin.TabIndex = 3;
            label_h_fin.Text = "____";
            // 
            // label_h_inicio
            // 
            label_h_inicio.AutoSize = true;
            label_h_inicio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_h_inicio.Location = new Point(229, 69);
            label_h_inicio.Name = "label_h_inicio";
            label_h_inicio.Size = new Size(27, 15);
            label_h_inicio.TabIndex = 2;
            label_h_inicio.Text = "____";
            // 
            // label_fecha
            // 
            label_fecha.AutoSize = true;
            label_fecha.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_fecha.Location = new Point(70, 69);
            label_fecha.Name = "label_fecha";
            label_fecha.Size = new Size(27, 15);
            label_fecha.TabIndex = 1;
            label_fecha.Text = "____";
            // 
            // label_medico
            // 
            label_medico.AutoSize = true;
            label_medico.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_medico.Location = new Point(70, 21);
            label_medico.Name = "label_medico";
            label_medico.Size = new Size(27, 15);
            label_medico.TabIndex = 0;
            label_medico.Text = "____";
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(140, 231);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 286);
            uC_Buscar_Paciente1.TabIndex = 11;
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
        private Label label_h_fin;
        private Label label_h_inicio;
        private Label label_fecha;
        private Label label_medico;
        private Label label_estado;
        private Button button_sem_actual;
        private Button button_sem_anterior;
        private GroupBox groupBox2;
        private Label label1;
        private Button button_sem_siguiente;
        private ComboBox comboBox1;
        private Label label_Paciente;
        private Button button_eliminar_turno;
        private Button button_asignar_turno;
        private Button button_seleccionar_paciente;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label2;
        private Label label3;
        private Label label4;
        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
    }
}