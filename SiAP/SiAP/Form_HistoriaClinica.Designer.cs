namespace SiAP.UI
{
    partial class Form_HistoriaClinica
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            button4 = new Button();
            label6 = new Label();
            richText_historia_Clinica = new RichTextBox();
            tabPage2 = new TabPage();
            treeView_historia_cli = new TreeView();
            label4 = new Label();
            richTextBox_tratamiento = new RichTextBox();
            label2 = new Label();
            richTextBox_observaciones = new RichTextBox();
            label1 = new Label();
            richTextBox_motivo = new RichTextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Limpiar = new Button();
            button_Editar = new Button();
            button_Guardar = new Button();
            tabPage3 = new TabPage();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button_rec_limpiar = new Button();
            button_rec_editar = new Button();
            button_rec_guardar = new Button();
            button_rec_imprimir = new Button();
            groupBox2 = new GroupBox();
            uC_Mostrar_Medico2 = new Forms_Seguridad.UC_Mostrar_Medico();
            label19 = new Label();
            richTextBox_observ = new RichTextBox();
            checkBox_cronico = new CheckBox();
            textBox_fecha = new TextBox();
            label5 = new Label();
            dataGridView_medicamentos = new DataGridView();
            label7 = new Label();
            treeView_recetas = new TreeView();
            tabPage4 = new TabPage();
            treeView1 = new TreeView();
            flowLayoutPanel4 = new FlowLayoutPanel();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            groupBox4 = new GroupBox();
            label32 = new Label();
            richTextBox2 = new RichTextBox();
            label21 = new Label();
            richTextBox1 = new RichTextBox();
            textBox6 = new TextBox();
            label27 = new Label();
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
            uC_Mostrar_Medico1 = new Forms_Seguridad.UC_Mostrar_Medico();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPage2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabPage3.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_medicamentos).BeginInit();
            tabPage4.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(uC_Mostrar_Paciente1);
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Controls.Add(uC_Buscar_Paciente1);
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
            uC_Mostrar_Paciente1.Size = new Size(900, 110);
            uC_Mostrar_Paciente1.TabIndex = 57;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(6, 138);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1198, 571);
            tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(flowLayoutPanel2);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(richText_historia_Clinica);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1190, 543);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Historia Clínica";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Location = new Point(500, 504);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(193, 33);
            flowLayoutPanel2.TabIndex = 65;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button1.Image = Properties.Resources.edit;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 26;
            button1.Text = "Editar";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSeaGreen;
            button4.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button4.Image = Properties.Resources.save;
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.Location = new Point(99, 3);
            button4.Name = "button4";
            button4.Size = new Size(90, 27);
            button4.TabIndex = 25;
            button4.Text = "Guardar";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 64;
            label6.Text = "Detalles HHCC:";
            // 
            // richText_historia_Clinica
            // 
            richText_historia_Clinica.Location = new Point(6, 37);
            richText_historia_Clinica.Name = "richText_historia_Clinica";
            richText_historia_Clinica.ScrollBars = RichTextBoxScrollBars.Vertical;
            richText_historia_Clinica.Size = new Size(1178, 461);
            richText_historia_Clinica.TabIndex = 63;
            richText_historia_Clinica.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.WhiteSmoke;
            tabPage2.Controls.Add(treeView_historia_cli);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(richTextBox_tratamiento);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(richTextBox_observaciones);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(richTextBox_motivo);
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1190, 543);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Consultas";
            // 
            // treeView_historia_cli
            // 
            treeView_historia_cli.Location = new Point(6, 14);
            treeView_historia_cli.Name = "treeView_historia_cli";
            treeView_historia_cli.Size = new Size(229, 484);
            treeView_historia_cli.TabIndex = 60;
            treeView_historia_cli.AfterSelect += treeView_historia_cli_AfterSelect;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(250, 356);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 66;
            label4.Text = "Tratamiento";
            // 
            // richTextBox_tratamiento
            // 
            richTextBox_tratamiento.Location = new Point(253, 374);
            richTextBox_tratamiento.Name = "richTextBox_tratamiento";
            richTextBox_tratamiento.Size = new Size(934, 124);
            richTextBox_tratamiento.TabIndex = 65;
            richTextBox_tratamiento.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 185);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 64;
            label2.Text = "Observaciones";
            // 
            // richTextBox_observaciones
            // 
            richTextBox_observaciones.Location = new Point(250, 203);
            richTextBox_observaciones.Name = "richTextBox_observaciones";
            richTextBox_observaciones.Size = new Size(934, 150);
            richTextBox_observaciones.TabIndex = 63;
            richTextBox_observaciones.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 14);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 62;
            label1.Text = "Motivo";
            // 
            // richTextBox_motivo
            // 
            richTextBox_motivo.Location = new Point(250, 32);
            richTextBox_motivo.Name = "richTextBox_motivo";
            richTextBox_motivo.Size = new Size(934, 150);
            richTextBox_motivo.TabIndex = 61;
            richTextBox_motivo.Text = "";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Limpiar);
            flowLayoutPanel1.Controls.Add(button_Editar);
            flowLayoutPanel1.Controls.Add(button_Guardar);
            flowLayoutPanel1.Location = new Point(595, 504);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(245, 33);
            flowLayoutPanel1.TabIndex = 59;
            // 
            // button_Limpiar
            // 
            button_Limpiar.BackColor = Color.SandyBrown;
            button_Limpiar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Limpiar.Image = Properties.Resources.clear;
            button_Limpiar.ImageAlign = ContentAlignment.MiddleRight;
            button_Limpiar.Location = new Point(3, 3);
            button_Limpiar.Name = "button_Limpiar";
            button_Limpiar.Size = new Size(74, 27);
            button_Limpiar.TabIndex = 23;
            button_Limpiar.Text = "Limpiar";
            button_Limpiar.TextAlign = ContentAlignment.MiddleLeft;
            button_Limpiar.UseVisualStyleBackColor = false;
            button_Limpiar.Click += button_Limpiar_Click;
            // 
            // button_Editar
            // 
            button_Editar.BackColor = SystemColors.ActiveCaption;
            button_Editar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Editar.Image = Properties.Resources.edit;
            button_Editar.ImageAlign = ContentAlignment.MiddleRight;
            button_Editar.Location = new Point(83, 3);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(74, 27);
            button_Editar.TabIndex = 24;
            button_Editar.Text = "Editar";
            button_Editar.TextAlign = ContentAlignment.MiddleLeft;
            button_Editar.UseVisualStyleBackColor = false;
            button_Editar.Click += button_Editar_Click;
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
            button_Guardar.TabIndex = 25;
            button_Guardar.Text = "Guardar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            button_Guardar.Click += button_Guardar_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.WhiteSmoke;
            tabPage3.Controls.Add(flowLayoutPanel3);
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(treeView_recetas);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1190, 543);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Recetas";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(button_rec_limpiar);
            flowLayoutPanel3.Controls.Add(button_rec_editar);
            flowLayoutPanel3.Controls.Add(button_rec_guardar);
            flowLayoutPanel3.Controls.Add(button_rec_imprimir);
            flowLayoutPanel3.Location = new Point(584, 503);
            flowLayoutPanel3.Margin = new Padding(5);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(350, 35);
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
            // button_rec_editar
            // 
            button_rec_editar.BackColor = SystemColors.ActiveCaption;
            button_rec_editar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_editar.Image = Properties.Resources.edit;
            button_rec_editar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_editar.Location = new Point(92, 5);
            button_rec_editar.Margin = new Padding(5);
            button_rec_editar.Name = "button_rec_editar";
            button_rec_editar.Size = new Size(77, 27);
            button_rec_editar.TabIndex = 24;
            button_rec_editar.Text = "Editar";
            button_rec_editar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_editar.UseVisualStyleBackColor = false;
            button_rec_editar.Click += button_rec_editar_Click;
            // 
            // button_rec_guardar
            // 
            button_rec_guardar.BackColor = Color.DarkSeaGreen;
            button_rec_guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_guardar.Image = Properties.Resources.save;
            button_rec_guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_guardar.Location = new Point(179, 5);
            button_rec_guardar.Margin = new Padding(5);
            button_rec_guardar.Name = "button_rec_guardar";
            button_rec_guardar.Size = new Size(77, 27);
            button_rec_guardar.TabIndex = 25;
            button_rec_guardar.Text = "Guardar";
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
            button_rec_imprimir.Location = new Point(266, 5);
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
            groupBox2.Controls.Add(richTextBox_observ);
            groupBox2.Controls.Add(checkBox_cronico);
            groupBox2.Controls.Add(textBox_fecha);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dataGridView_medicamentos);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(364, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(823, 492);
            groupBox2.TabIndex = 87;
            groupBox2.TabStop = false;
            groupBox2.Text = "Receta";
            // 
            // uC_Mostrar_Medico2
            // 
            uC_Mostrar_Medico2.BackColor = Color.WhiteSmoke;
            uC_Mostrar_Medico2.Location = new Point(561, 370);
            uC_Mostrar_Medico2.Name = "uC_Mostrar_Medico2";
            uC_Mostrar_Medico2.Size = new Size(251, 116);
            uC_Mostrar_Medico2.TabIndex = 117;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 266);
            label19.Name = "label19";
            label19.Size = new Size(87, 15);
            label19.TabIndex = 116;
            label19.Text = "Observaciones:";
            // 
            // richTextBox_observ
            // 
            richTextBox_observ.Location = new Point(9, 284);
            richTextBox_observ.Name = "richTextBox_observ";
            richTextBox_observ.Size = new Size(803, 80);
            richTextBox_observ.TabIndex = 115;
            richTextBox_observ.Text = "";
            // 
            // checkBox_cronico
            // 
            checkBox_cronico.AutoSize = true;
            checkBox_cronico.CheckAlign = ContentAlignment.MiddleRight;
            checkBox_cronico.Location = new Point(17, 379);
            checkBox_cronico.Name = "checkBox_cronico";
            checkBox_cronico.Size = new Size(83, 19);
            checkBox_cronico.TabIndex = 114;
            checkBox_cronico.Text = "Es crónico:";
            checkBox_cronico.UseVisualStyleBackColor = true;
            // 
            // textBox_fecha
            // 
            textBox_fecha.Enabled = false;
            textBox_fecha.Location = new Point(688, 16);
            textBox_fecha.Name = "textBox_fecha";
            textBox_fecha.Size = new Size(124, 23);
            textBox_fecha.TabIndex = 101;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(596, 19);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 95;
            label5.Text = "Fecha Emisión:";
            // 
            // dataGridView_medicamentos
            // 
            dataGridView_medicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_medicamentos.Location = new Point(9, 67);
            dataGridView_medicamentos.Name = "dataGridView_medicamentos";
            dataGridView_medicamentos.Size = new Size(803, 174);
            dataGridView_medicamentos.TabIndex = 86;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 49);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 51;
            label7.Text = "RP/";
            // 
            // treeView_recetas
            // 
            treeView_recetas.Location = new Point(3, 3);
            treeView_recetas.Name = "treeView_recetas";
            treeView_recetas.Size = new Size(355, 494);
            treeView_recetas.TabIndex = 61;
            treeView_recetas.AfterSelect += treeView_recetas_AfterSelect;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.WhiteSmoke;
            tabPage4.Controls.Add(treeView1);
            tabPage4.Controls.Add(flowLayoutPanel4);
            tabPage4.Controls.Add(groupBox4);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1190, 543);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Certificados";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(355, 492);
            treeView1.TabIndex = 90;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(button3);
            flowLayoutPanel4.Controls.Add(button5);
            flowLayoutPanel4.Controls.Add(button6);
            flowLayoutPanel4.Controls.Add(button7);
            flowLayoutPanel4.Location = new Point(606, 503);
            flowLayoutPanel4.Margin = new Padding(5);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(350, 35);
            flowLayoutPanel4.TabIndex = 89;
            // 
            // button3
            // 
            button3.BackColor = Color.SandyBrown;
            button3.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button3.Image = Properties.Resources.clear;
            button3.ImageAlign = ContentAlignment.MiddleRight;
            button3.Location = new Point(5, 5);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(77, 27);
            button3.TabIndex = 23;
            button3.Text = "Limpiar";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaption;
            button5.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button5.Image = Properties.Resources.edit;
            button5.ImageAlign = ContentAlignment.MiddleRight;
            button5.Location = new Point(92, 5);
            button5.Margin = new Padding(5);
            button5.Name = "button5";
            button5.Size = new Size(77, 27);
            button5.TabIndex = 24;
            button5.Text = "Editar";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.DarkSeaGreen;
            button6.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button6.Image = Properties.Resources.save;
            button6.ImageAlign = ContentAlignment.MiddleRight;
            button6.Location = new Point(179, 5);
            button6.Margin = new Padding(5);
            button6.Name = "button6";
            button6.Size = new Size(77, 27);
            button6.TabIndex = 25;
            button6.Text = "Guardar";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.Ivory;
            button7.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button7.Image = Properties.Resources.printer;
            button7.ImageAlign = ContentAlignment.MiddleRight;
            button7.Location = new Point(266, 5);
            button7.Margin = new Padding(5);
            button7.Name = "button7";
            button7.Size = new Size(77, 27);
            button7.TabIndex = 29;
            button7.Text = "Imprimir";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.WhiteSmoke;
            groupBox4.Controls.Add(uC_Mostrar_Medico1);
            groupBox4.Controls.Add(label32);
            groupBox4.Controls.Add(richTextBox2);
            groupBox4.Controls.Add(label21);
            groupBox4.Controls.Add(richTextBox1);
            groupBox4.Controls.Add(textBox6);
            groupBox4.Controls.Add(label27);
            groupBox4.Location = new Point(364, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(823, 492);
            groupBox4.TabIndex = 88;
            groupBox4.TabStop = false;
            groupBox4.Text = "Certificado Med.";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(9, 44);
            label32.Name = "label32";
            label32.Size = new Size(54, 15);
            label32.TabIndex = 118;
            label32.Text = "Certifico:";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(9, 62);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(803, 163);
            richTextBox2.TabIndex = 117;
            richTextBox2.Text = "";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(9, 238);
            label21.Name = "label21";
            label21.Size = new Size(87, 15);
            label21.TabIndex = 116;
            label21.Text = "Observaciones:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(9, 256);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(803, 108);
            richTextBox1.TabIndex = 115;
            richTextBox1.Text = "";
            // 
            // textBox6
            // 
            textBox6.Enabled = false;
            textBox6.Location = new Point(688, 16);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(124, 23);
            textBox6.TabIndex = 101;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Enabled = false;
            label27.Location = new Point(596, 19);
            label27.Name = "label27";
            label27.Size = new Size(86, 15);
            label27.TabIndex = 95;
            label27.Text = "Fecha Emisión:";
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(383, 244);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 226);
            uC_Buscar_Paciente1.TabIndex = 56;
            // 
            // uC_Mostrar_Medico1
            // 
            uC_Mostrar_Medico1.BackColor = Color.WhiteSmoke;
            uC_Mostrar_Medico1.Location = new Point(561, 370);
            uC_Mostrar_Medico1.Name = "uC_Mostrar_Medico1";
            uC_Mostrar_Medico1.Size = new Size(251, 116);
            uC_Mostrar_Medico1.TabIndex = 119;
            // 
            // Form_HistoriaClinica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_HistoriaClinica";
            Text = "Form_HistoriaClinica";
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_medicamentos).EndInit();
            tabPage4.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView treeView_historia_cli;
        private Label label4;
        private RichTextBox richTextBox_tratamiento;
        private Label label2;
        private RichTextBox richTextBox_observaciones;
        private Label label1;
        private RichTextBox richTextBox_motivo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Limpiar;
        private Button button_Editar;
        private Button button_Guardar;
        private TabPage tabPage3;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button4;
        private Label label6;
        private RichTextBox richText_historia_Clinica;
        private Button button1;
        private TreeView treeView_recetas;
        private GroupBox groupBox2;
        private DataGridView dataGridView_medicamentos;
        private Label label7;
        private Label label5;
        private TextBox textBox6;
        private TextBox textBox_fecha;
        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
        private CheckBox checkBox_cronico;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button_rec_limpiar;
        private Button button_rec_editar;
        private Button button_rec_guardar;
        private Button button_rec_imprimir;
        private Label label19;
        private RichTextBox richTextBox_observ;
        private TabPage tabPage4;
        private GroupBox groupBox4;
        private Label label21;
        private RichTextBox richTextBox1;
        private Label label27;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button button3;
        private Button button5;
        private Button button6;
        private Button button7;
        private TreeView treeView1;
        private Label label32;
        private RichTextBox richTextBox2;
        private Forms_Seguridad.UC_Mostrar_Paciente uC_Mostrar_Paciente1;
        private Forms_Seguridad.UC_Mostrar_Medico uC_Mostrar_Medico2;
        private Forms_Seguridad.UC_Mostrar_Medico uC_Mostrar_Medico1;
    }
}