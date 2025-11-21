namespace SiAP.UI
{
    partial class Form_Agenda
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Borrar = new Button();
            button_Limpiar = new Button();
            button_Guardar = new Button();
            label1 = new Label();
            label_titular_agenda = new Label();
            button_sem_siguiente = new Button();
            comboBox1 = new ComboBox();
            button_sem_actual = new Button();
            button_sem_anterior = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 22;
            dataGridView1.Size = new Size(782, 550);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // treeView1
            // 
            treeView1.HideSelection = false;
            treeView1.Location = new Point(6, 22);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(314, 679);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 707);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agenda Médica";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label_titular_agenda);
            groupBox2.Controls.Add(button_sem_siguiente);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(button_sem_actual);
            groupBox2.Controls.Add(button_sem_anterior);
            groupBox2.Location = new Point(326, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(794, 687);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 8.25F);
            label5.Location = new Point(6, 658);
            label5.Name = "label5";
            label5.Size = new Size(154, 14);
            label5.TabIndex = 33;
            label5.Text = "Azul: Horario y turno asignado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 8.25F);
            label4.Location = new Point(6, 643);
            label4.Name = "label4";
            label4.Size = new Size(166, 14);
            label4.TabIndex = 32;
            label4.Text = "Gris: Ya existe horario agendado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 8.25F);
            label3.Location = new Point(6, 628);
            label3.Name = "label3";
            label3.Size = new Size(152, 14);
            label3.TabIndex = 31;
            label3.Text = "Rojo: No hay horario asignado";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Borrar);
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(278, 640);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(244, 33);
            flowLayoutPanel1.TabIndex = 29;
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
            button_Borrar.TabIndex = 7;
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
            button_Limpiar.TabIndex = 8;
            button_Limpiar.Text = "Limpiar";
            button_Limpiar.TextAlign = ContentAlignment.MiddleLeft;
            button_Limpiar.UseVisualStyleBackColor = false;
            button_Limpiar.Click += button_Limpiar_Click;
            // 
            // button_Guardar
            // 
            button_Guardar.BackColor = Color.DarkSeaGreen;
            button_Guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Guardar.Image = Properties.Resources.save;
            button_Guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_Guardar.Location = new Point(163, 3);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(74, 27);
            button_Guardar.TabIndex = 9;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(315, 19);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 10;
            label1.Text = "Seleccionar Mes/Año";
            // 
            // label_titular_agenda
            // 
            label_titular_agenda.AutoSize = true;
            label_titular_agenda.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titular_agenda.Location = new Point(11, 18);
            label_titular_agenda.Name = "label_titular_agenda";
            label_titular_agenda.Size = new Size(48, 15);
            label_titular_agenda.TabIndex = 4;
            label_titular_agenda.Text = "Agenda";
            // 
            // button_sem_siguiente
            // 
            button_sem_siguiente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_siguiente.Location = new Point(668, 44);
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
            comboBox1.Location = new Point(441, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button_sem_actual
            // 
            button_sem_actual.BackColor = SystemColors.ActiveCaption;
            button_sem_actual.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_sem_actual.Location = new Point(335, 44);
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
            button_sem_anterior.Location = new Point(6, 44);
            button_sem_anterior.Name = "button_sem_anterior";
            button_sem_anterior.Size = new Size(120, 25);
            button_sem_anterior.TabIndex = 3;
            button_sem_anterior.Text = "Semana Anterior";
            button_sem_anterior.UseVisualStyleBackColor = true;
            button_sem_anterior.Click += button_sem_anterior_Click;
            // 
            // Form_Agenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_Agenda";
            Text = "Form_Agenda";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private TreeView treeView1;
        private GroupBox groupBox1;
        private Label label_titular_agenda;
        private Button button_sem_actual;
        private Button button_sem_anterior;
        private GroupBox groupBox2;
        private Label label1;
        private Button button_sem_siguiente;
        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Borrar;
        private Button button_Limpiar;
        private Button button_Guardar;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}