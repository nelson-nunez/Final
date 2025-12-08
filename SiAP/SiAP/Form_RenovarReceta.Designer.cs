namespace SiAP.UI
{
    partial class Form_RenovarReceta
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
            groupBox1 = new GroupBox();
            uC_Mostrar_Paciente1 = new Forms_Seguridad.UC_Mostrar_Paciente();
            groupBox3 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button_rec_limpiar = new Button();
            button_rec_guardar = new Button();
            button_rec_imprimir = new Button();
            groupBox2 = new GroupBox();
            uC_Mostrar_Medico2 = new Forms_Seguridad.UC_Mostrar_Medico();
            label19 = new Label();
            richTextBox_observ_receta = new RichTextBox();
            checkBox_cronico_receta = new CheckBox();
            textBox_fecha_receta = new TextBox();
            label5 = new Label();
            dataGridView_medicamentos = new DataGridView();
            label7 = new Label();
            treeView_recetas = new TreeView();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_medicamentos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(uC_Mostrar_Paciente1);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 715);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Historia Clínica";
            // 
            // uC_Mostrar_Paciente1
            // 
            uC_Mostrar_Paciente1.BackColor = Color.WhiteSmoke;
            uC_Mostrar_Paciente1.Location = new Point(6, 22);
            uC_Mostrar_Paciente1.Name = "uC_Mostrar_Paciente1";
            uC_Mostrar_Paciente1.Size = new Size(715, 110);
            uC_Mostrar_Paciente1.TabIndex = 57;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(flowLayoutPanel3);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(treeView_recetas);
            groupBox3.Location = new Point(6, 138);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1204, 577);
            groupBox3.TabIndex = 58;
            groupBox3.TabStop = false;
            groupBox3.Text = "Recetas";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(button_rec_limpiar);
            flowLayoutPanel3.Controls.Add(button_rec_guardar);
            flowLayoutPanel3.Controls.Add(button_rec_imprimir);
            flowLayoutPanel3.Location = new Point(529, 524);
            flowLayoutPanel3.Margin = new Padding(5);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(312, 35);
            flowLayoutPanel3.TabIndex = 88;
            // 
            // button_rec_limpiar
            // 
            button_rec_limpiar.BackColor = Color.SandyBrown;
            button_rec_limpiar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_limpiar.Image = Properties.Resources.clear;
            button_rec_limpiar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_limpiar.Location = new Point(5, 5);
            button_rec_limpiar.Margin = new Padding(5);
            button_rec_limpiar.Name = "button_rec_limpiar";
            button_rec_limpiar.Size = new Size(77, 27);
            button_rec_limpiar.TabIndex = 23;
            button_rec_limpiar.Text = "Limpiar";
            button_rec_limpiar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_limpiar.UseVisualStyleBackColor = false;
            button_rec_limpiar.Click += button_rec_limpiar_Click;
            // 
            // button_rec_guardar
            // 
            button_rec_guardar.BackColor = Color.DarkSeaGreen;
            button_rec_guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_guardar.Image = Properties.Resources.save;
            button_rec_guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_guardar.Location = new Point(92, 5);
            button_rec_guardar.Margin = new Padding(5);
            button_rec_guardar.Name = "button_rec_guardar";
            button_rec_guardar.Size = new Size(124, 27);
            button_rec_guardar.TabIndex = 25;
            button_rec_guardar.Text = "Renovar Receta";
            button_rec_guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_guardar.UseVisualStyleBackColor = false;
            button_rec_guardar.Click += button_rec_guardar_Click;
            // 
            // button_rec_imprimir
            // 
            button_rec_imprimir.BackColor = Color.Ivory;
            button_rec_imprimir.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_imprimir.Image = Properties.Resources.printer;
            button_rec_imprimir.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_imprimir.Location = new Point(226, 5);
            button_rec_imprimir.Margin = new Padding(5);
            button_rec_imprimir.Name = "button_rec_imprimir";
            button_rec_imprimir.Size = new Size(77, 27);
            button_rec_imprimir.TabIndex = 29;
            button_rec_imprimir.Text = "Imprimir";
            button_rec_imprimir.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_imprimir.UseVisualStyleBackColor = false;
            button_rec_imprimir.Click += button_rec_imprimir_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.WhiteSmoke;
            groupBox2.Controls.Add(uC_Mostrar_Medico2);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(richTextBox_observ_receta);
            groupBox2.Controls.Add(checkBox_cronico_receta);
            groupBox2.Controls.Add(textBox_fecha_receta);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dataGridView_medicamentos);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(375, 24);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(823, 492);
            groupBox2.TabIndex = 87;
            groupBox2.TabStop = false;
            groupBox2.Text = "Receta";
            // 
            // uC_Mostrar_Medico2
            // 
            uC_Mostrar_Medico2.BackColor = Color.WhiteSmoke;
            uC_Mostrar_Medico2.Enabled = false;
            uC_Mostrar_Medico2.Location = new Point(561, 370);
            uC_Mostrar_Medico2.Name = "uC_Mostrar_Medico2";
            uC_Mostrar_Medico2.Size = new Size(251, 116);
            uC_Mostrar_Medico2.TabIndex = 117;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Enabled = false;
            label19.Location = new Point(6, 266);
            label19.Name = "label19";
            label19.Size = new Size(87, 15);
            label19.TabIndex = 116;
            label19.Text = "Observaciones:";
            // 
            // richTextBox_observ_receta
            // 
            richTextBox_observ_receta.Enabled = false;
            richTextBox_observ_receta.Location = new Point(9, 284);
            richTextBox_observ_receta.Name = "richTextBox_observ_receta";
            richTextBox_observ_receta.Size = new Size(803, 80);
            richTextBox_observ_receta.TabIndex = 115;
            richTextBox_observ_receta.Text = "";
            // 
            // checkBox_cronico_receta
            // 
            checkBox_cronico_receta.AutoSize = true;
            checkBox_cronico_receta.CheckAlign = ContentAlignment.MiddleRight;
            checkBox_cronico_receta.Enabled = false;
            checkBox_cronico_receta.Location = new Point(17, 379);
            checkBox_cronico_receta.Name = "checkBox_cronico_receta";
            checkBox_cronico_receta.Size = new Size(83, 19);
            checkBox_cronico_receta.TabIndex = 114;
            checkBox_cronico_receta.Text = "Es crónico:";
            checkBox_cronico_receta.UseVisualStyleBackColor = true;
            // 
            // textBox_fecha_receta
            // 
            textBox_fecha_receta.Enabled = false;
            textBox_fecha_receta.Location = new Point(688, 16);
            textBox_fecha_receta.Name = "textBox_fecha_receta";
            textBox_fecha_receta.Size = new Size(124, 23);
            textBox_fecha_receta.TabIndex = 101;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Location = new Point(596, 19);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 95;
            label5.Text = "Fecha Emisión:";
            // 
            // dataGridView_medicamentos
            // 
            dataGridView_medicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_medicamentos.Enabled = false;
            dataGridView_medicamentos.Location = new Point(9, 67);
            dataGridView_medicamentos.Name = "dataGridView_medicamentos";
            dataGridView_medicamentos.Size = new Size(803, 174);
            dataGridView_medicamentos.TabIndex = 86;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Enabled = false;
            label7.Location = new Point(9, 49);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 51;
            label7.Text = "RP/";
            // 
            // treeView_recetas
            // 
            treeView_recetas.Location = new Point(6, 22);
            treeView_recetas.Name = "treeView_recetas";
            treeView_recetas.Size = new Size(355, 494);
            treeView_recetas.TabIndex = 61;
            treeView_recetas.AfterSelect += treeView_recetas_AfterSelect;
            // 
            // Form_RenovarReceta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_RenovarReceta";
            Text = "Form_RenovarReceta";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_medicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TreeView treeView_recetas;
        private GroupBox groupBox2;
        private DataGridView dataGridView_medicamentos;
        private Label label7;
        private Label label5;
        private TextBox textBox_fecha_receta;
        private CheckBox checkBox_cronico_receta;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button_rec_limpiar;
        private Button button_rec_guardar;
        private Button button_rec_imprimir;
        private Label label19;
        private RichTextBox richTextBox_observ_receta;
        private Forms_Seguridad.UC_Mostrar_Paciente uC_Mostrar_Paciente1;
        private Forms_Seguridad.UC_Mostrar_Medico uC_Mostrar_Medico2;
        private GroupBox groupBox3;
    }
}