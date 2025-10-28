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
            groupBox3 = new GroupBox();
            label_PLAN = new Label();
            label20 = new Label();
            button_seleccionar_paciente = new Button();
            label_nro_socio = new Label();
            label10 = new Label();
            label8 = new Label();
            label9 = new Label();
            label_nombre_completo = new Label();
            label_ooss = new Label();
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
            groupBox2 = new GroupBox();
            checkBox_cronico = new CheckBox();
            textBox_nom_pac = new TextBox();
            textBox_dni_pac = new TextBox();
            label18 = new Label();
            textBox_esp_med = new TextBox();
            label12 = new Label();
            textBox_mat_med = new TextBox();
            textBox_nombre_med = new TextBox();
            label16 = new Label();
            label17 = new Label();
            label11 = new Label();
            textBox_fecha = new TextBox();
            textBox_plan_pac = new TextBox();
            textBox_nrosoc_pac = new TextBox();
            textBox_oss_pac = new TextBox();
            label5 = new Label();
            button_editar_pac = new Button();
            label13 = new Label();
            label3 = new Label();
            label14 = new Label();
            label15 = new Label();
            dataGridView_medicamentos = new DataGridView();
            label7 = new Label();
            treeView_recetas = new TreeView();
            uC_Buscar_Paciente1 = new Forms_Seguridad.UC_Buscar_Paciente();
            button_rec_imprimir = new Button();
            button_rec_guardar = new Button();
            button_rec_editar = new Button();
            button_rec_limpiar = new Button();
            button_rec_eliminar = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label19 = new Label();
            richTextBox_observ = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPage2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_medicamentos).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
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
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(label_PLAN);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(button_seleccionar_paciente);
            groupBox3.Controls.Add(label_nro_socio);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label_nombre_completo);
            groupBox3.Controls.Add(label_ooss);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1198, 55);
            groupBox3.TabIndex = 30;
            groupBox3.TabStop = false;
            groupBox3.Text = "Paciente";
            // 
            // label_PLAN
            // 
            label_PLAN.AutoSize = true;
            label_PLAN.Location = new Point(800, 22);
            label_PLAN.Name = "label_PLAN";
            label_PLAN.Size = new Size(49, 15);
            label_PLAN.TabIndex = 51;
            label_PLAN.Text = "..............";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(758, 22);
            label20.Name = "label20";
            label20.Size = new Size(36, 15);
            label20.TabIndex = 50;
            label20.Text = "Plan: ";
            // 
            // button_seleccionar_paciente
            // 
            button_seleccionar_paciente.BackColor = SystemColors.ActiveCaption;
            button_seleccionar_paciente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_seleccionar_paciente.Location = new Point(29, 16);
            button_seleccionar_paciente.Name = "button_seleccionar_paciente";
            button_seleccionar_paciente.Size = new Size(103, 26);
            button_seleccionar_paciente.TabIndex = 12;
            button_seleccionar_paciente.Text = "Buscar Paciente";
            button_seleccionar_paciente.UseVisualStyleBackColor = false;
            button_seleccionar_paciente.Click += button_seleccionar_paciente_Click;
            // 
            // label_nro_socio
            // 
            label_nro_socio.AutoSize = true;
            label_nro_socio.Location = new Point(1040, 22);
            label_nro_socio.Name = "label_nro_socio";
            label_nro_socio.Size = new Size(49, 15);
            label_nro_socio.TabIndex = 49;
            label_nro_socio.Text = "..............";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(160, 22);
            label10.Name = "label10";
            label10.Size = new Size(109, 15);
            label10.TabIndex = 43;
            label10.Text = "Nombre Completo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(500, 22);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 44;
            label8.Text = "OOSS: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(977, 22);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 45;
            label9.Text = "N° Socio:";
            // 
            // label_nombre_completo
            // 
            label_nombre_completo.AutoSize = true;
            label_nombre_completo.Location = new Point(276, 22);
            label_nombre_completo.Name = "label_nombre_completo";
            label_nombre_completo.Size = new Size(49, 15);
            label_nombre_completo.TabIndex = 47;
            label_nombre_completo.Text = "..............";
            // 
            // label_ooss
            // 
            label_ooss.AutoSize = true;
            label_ooss.Location = new Point(552, 22);
            label_ooss.Name = "label_ooss";
            label_ooss.Size = new Size(49, 15);
            label_ooss.TabIndex = 48;
            label_ooss.Text = "..............";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(6, 83);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1198, 626);
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
            tabPage1.Size = new Size(1190, 598);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Historia Clínica";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Location = new Point(508, 532);
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
            label6.Size = new Size(73, 15);
            label6.TabIndex = 64;
            label6.Text = "Descripción:";
            // 
            // richText_historia_Clinica
            // 
            richText_historia_Clinica.Location = new Point(6, 37);
            richText_historia_Clinica.Name = "richText_historia_Clinica";
            richText_historia_Clinica.ScrollBars = RichTextBoxScrollBars.Vertical;
            richText_historia_Clinica.Size = new Size(1178, 489);
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
            tabPage2.Size = new Size(1190, 598);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Consultas";
            // 
            // treeView_historia_cli
            // 
            treeView_historia_cli.Location = new Point(6, 14);
            treeView_historia_cli.Name = "treeView_historia_cli";
            treeView_historia_cli.Size = new Size(229, 510);
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
            richTextBox_tratamiento.Location = new Point(250, 374);
            richTextBox_tratamiento.Name = "richTextBox_tratamiento";
            richTextBox_tratamiento.Size = new Size(934, 150);
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
            flowLayoutPanel1.Location = new Point(491, 530);
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
            tabPage3.Size = new Size(1190, 598);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Recetas";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(richTextBox_observ);
            groupBox2.Controls.Add(checkBox_cronico);
            groupBox2.Controls.Add(textBox_nom_pac);
            groupBox2.Controls.Add(textBox_dni_pac);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(textBox_esp_med);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(textBox_mat_med);
            groupBox2.Controls.Add(textBox_nombre_med);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(textBox_fecha);
            groupBox2.Controls.Add(textBox_plan_pac);
            groupBox2.Controls.Add(textBox_nrosoc_pac);
            groupBox2.Controls.Add(textBox_oss_pac);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(button_editar_pac);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(dataGridView_medicamentos);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(364, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(823, 543);
            groupBox2.TabIndex = 87;
            groupBox2.TabStop = false;
            groupBox2.Text = "Receta";
            // 
            // checkBox_cronico
            // 
            checkBox_cronico.AutoSize = true;
            checkBox_cronico.CheckAlign = ContentAlignment.MiddleRight;
            checkBox_cronico.Location = new Point(17, 441);
            checkBox_cronico.Name = "checkBox_cronico";
            checkBox_cronico.Size = new Size(83, 19);
            checkBox_cronico.TabIndex = 114;
            checkBox_cronico.Text = "Es crónico:";
            checkBox_cronico.UseVisualStyleBackColor = true;
            // 
            // textBox_nom_pac
            // 
            textBox_nom_pac.Location = new Point(89, 42);
            textBox_nom_pac.Name = "textBox_nom_pac";
            textBox_nom_pac.Size = new Size(286, 23);
            textBox_nom_pac.TabIndex = 112;
            // 
            // textBox_dni_pac
            // 
            textBox_dni_pac.Location = new Point(422, 42);
            textBox_dni_pac.Name = "textBox_dni_pac";
            textBox_dni_pac.Size = new Size(203, 23);
            textBox_dni_pac.TabIndex = 111;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(655, 514);
            label18.Name = "label18";
            label18.Size = new Size(127, 15);
            label18.TabIndex = 110;
            label18.Text = "........................................";
            // 
            // textBox_esp_med
            // 
            textBox_esp_med.Location = new Point(628, 427);
            textBox_esp_med.Name = "textBox_esp_med";
            textBox_esp_med.Size = new Size(184, 23);
            textBox_esp_med.TabIndex = 109;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(547, 430);
            label12.Name = "label12";
            label12.Size = new Size(75, 15);
            label12.TabIndex = 108;
            label12.Text = "Especialidad:";
            // 
            // textBox_mat_med
            // 
            textBox_mat_med.Location = new Point(628, 456);
            textBox_mat_med.Name = "textBox_mat_med";
            textBox_mat_med.Size = new Size(184, 23);
            textBox_mat_med.TabIndex = 107;
            // 
            // textBox_nombre_med
            // 
            textBox_nombre_med.Location = new Point(628, 398);
            textBox_nombre_med.Name = "textBox_nombre_med";
            textBox_nombre_med.Size = new Size(184, 23);
            textBox_nombre_med.TabIndex = 106;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(561, 401);
            label16.Name = "label16";
            label16.Size = new Size(61, 15);
            label16.TabIndex = 104;
            label16.Text = "Médico/a:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(562, 459);
            label17.Name = "label17";
            label17.Size = new Size(60, 15);
            label17.TabIndex = 105;
            label17.Text = "Matrícula:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(384, 45);
            label11.Name = "label11";
            label11.Size = new Size(32, 15);
            label11.TabIndex = 102;
            label11.Text = "DNI:";
            // 
            // textBox_fecha
            // 
            textBox_fecha.Location = new Point(688, 16);
            textBox_fecha.Name = "textBox_fecha";
            textBox_fecha.Size = new Size(124, 23);
            textBox_fecha.TabIndex = 101;
            // 
            // textBox_plan_pac
            // 
            textBox_plan_pac.Location = new Point(232, 100);
            textBox_plan_pac.Name = "textBox_plan_pac";
            textBox_plan_pac.Size = new Size(393, 23);
            textBox_plan_pac.TabIndex = 100;
            // 
            // textBox_nrosoc_pac
            // 
            textBox_nrosoc_pac.Location = new Point(89, 100);
            textBox_nrosoc_pac.Name = "textBox_nrosoc_pac";
            textBox_nrosoc_pac.Size = new Size(98, 23);
            textBox_nrosoc_pac.TabIndex = 99;
            // 
            // textBox_oss_pac
            // 
            textBox_oss_pac.Location = new Point(89, 71);
            textBox_oss_pac.Name = "textBox_oss_pac";
            textBox_oss_pac.Size = new Size(536, 23);
            textBox_oss_pac.TabIndex = 98;
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
            // button_editar_pac
            // 
            button_editar_pac.BackColor = SystemColors.ActiveCaption;
            button_editar_pac.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_editar_pac.Location = new Point(687, 68);
            button_editar_pac.Name = "button_editar_pac";
            button_editar_pac.Size = new Size(125, 27);
            button_editar_pac.TabIndex = 88;
            button_editar_pac.Text = "Editar Paciente";
            button_editar_pac.UseVisualStyleBackColor = false;
            button_editar_pac.Click += button_editar_pac_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(32, 45);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 89;
            label13.Text = "Afiliado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 103);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 46;
            label3.Text = "N° Socio:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(38, 74);
            label14.Name = "label14";
            label14.Size = new Size(45, 15);
            label14.TabIndex = 90;
            label14.Text = "OOSS: ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(197, 103);
            label15.Name = "label15";
            label15.Size = new Size(36, 15);
            label15.TabIndex = 91;
            label15.Text = "Plan: ";
            // 
            // dataGridView_medicamentos
            // 
            dataGridView_medicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_medicamentos.Location = new Point(17, 152);
            dataGridView_medicamentos.Name = "dataGridView_medicamentos";
            dataGridView_medicamentos.Size = new Size(795, 174);
            dataGridView_medicamentos.TabIndex = 86;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 134);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 51;
            label7.Text = "RP/";
            // 
            // treeView_recetas
            // 
            treeView_recetas.Location = new Point(3, 3);
            treeView_recetas.Name = "treeView_recetas";
            treeView_recetas.Size = new Size(355, 543);
            treeView_recetas.TabIndex = 61;
            treeView_recetas.AfterSelect += treeView_recetas_AfterSelect;
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(383, 244);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 226);
            uC_Buscar_Paciente1.TabIndex = 56;
            // 
            // button_rec_imprimir
            // 
            button_rec_imprimir.BackColor = Color.Ivory;
            button_rec_imprimir.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_imprimir.Image = Properties.Resources.printer;
            button_rec_imprimir.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_imprimir.Location = new Point(353, 5);
            button_rec_imprimir.Margin = new Padding(5);
            button_rec_imprimir.Name = "button_rec_imprimir";
            button_rec_imprimir.Size = new Size(77, 27);
            button_rec_imprimir.TabIndex = 29;
            button_rec_imprimir.Text = "Imprimir";
            button_rec_imprimir.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_imprimir.UseVisualStyleBackColor = false;
            button_rec_imprimir.Click += button_rec_imprimir_Click;
            // 
            // button_rec_guardar
            // 
            button_rec_guardar.BackColor = Color.DarkSeaGreen;
            button_rec_guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_guardar.Image = Properties.Resources.save;
            button_rec_guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_guardar.Location = new Point(266, 5);
            button_rec_guardar.Margin = new Padding(5);
            button_rec_guardar.Name = "button_rec_guardar";
            button_rec_guardar.Size = new Size(77, 27);
            button_rec_guardar.TabIndex = 25;
            button_rec_guardar.Text = "Guardar";
            button_rec_guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_guardar.UseVisualStyleBackColor = false;
            button_rec_guardar.Click += button_rec_guardar_Click;
            // 
            // button_rec_editar
            // 
            button_rec_editar.BackColor = SystemColors.ActiveCaption;
            button_rec_editar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_editar.Image = Properties.Resources.edit;
            button_rec_editar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_editar.Location = new Point(179, 5);
            button_rec_editar.Margin = new Padding(5);
            button_rec_editar.Name = "button_rec_editar";
            button_rec_editar.Size = new Size(77, 27);
            button_rec_editar.TabIndex = 24;
            button_rec_editar.Text = "Editar";
            button_rec_editar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_editar.UseVisualStyleBackColor = false;
            button_rec_editar.Click += button_rec_editar_Click;
            // 
            // button_rec_limpiar
            // 
            button_rec_limpiar.BackColor = Color.SandyBrown;
            button_rec_limpiar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_limpiar.Image = Properties.Resources.clear;
            button_rec_limpiar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_limpiar.Location = new Point(92, 5);
            button_rec_limpiar.Margin = new Padding(5);
            button_rec_limpiar.Name = "button_rec_limpiar";
            button_rec_limpiar.Size = new Size(77, 27);
            button_rec_limpiar.TabIndex = 23;
            button_rec_limpiar.Text = "Limpiar";
            button_rec_limpiar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_limpiar.UseVisualStyleBackColor = false;
            button_rec_limpiar.Click += button_rec_limpiar_Click;
            // 
            // button_rec_eliminar
            // 
            button_rec_eliminar.BackColor = Color.IndianRed;
            button_rec_eliminar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_rec_eliminar.Image = Properties.Resources.delete;
            button_rec_eliminar.ImageAlign = ContentAlignment.MiddleRight;
            button_rec_eliminar.Location = new Point(5, 5);
            button_rec_eliminar.Margin = new Padding(5);
            button_rec_eliminar.Name = "button_rec_eliminar";
            button_rec_eliminar.Size = new Size(77, 27);
            button_rec_eliminar.TabIndex = 22;
            button_rec_eliminar.Text = "Eliminar";
            button_rec_eliminar.TextAlign = ContentAlignment.MiddleLeft;
            button_rec_eliminar.UseVisualStyleBackColor = false;
            button_rec_eliminar.Click += button_rec_eliminar_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(button_rec_eliminar);
            flowLayoutPanel3.Controls.Add(button_rec_limpiar);
            flowLayoutPanel3.Controls.Add(button_rec_editar);
            flowLayoutPanel3.Controls.Add(button_rec_guardar);
            flowLayoutPanel3.Controls.Add(button_rec_imprimir);
            flowLayoutPanel3.Location = new Point(453, 558);
            flowLayoutPanel3.Margin = new Padding(5);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(436, 35);
            flowLayoutPanel3.TabIndex = 88;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(17, 333);
            label19.Name = "label19";
            label19.Size = new Size(87, 15);
            label19.TabIndex = 116;
            label19.Text = "Observaciones:";
            // 
            // richTextBox_observ
            // 
            richTextBox_observ.Location = new Point(17, 351);
            richTextBox_observ.Name = "richTextBox_observ";
            richTextBox_observ.Size = new Size(436, 80);
            richTextBox_observ.TabIndex = 115;
            richTextBox_observ.Text = "";
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
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_medicamentos).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label_nombre_completo;
        private Label label3;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label_nro_socio;
        private Label label_ooss;
        private GroupBox groupBox3;
        private Button button_seleccionar_paciente;
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
        private Button button_editar_pac;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox textBox_plan_pac;
        private TextBox textBox_nrosoc_pac;
        private TextBox textBox_oss_pac;
        private TextBox textBox1;
        private TextBox textBox6;
        private Label label11;
        private TextBox textBox_fecha;
        private TextBox textBox_esp_med;
        private Label label12;
        private TextBox textBox_mat_med;
        private TextBox textBox_nombre_med;
        private Label label16;
        private Label label17;
        private Label label18;
        private TextBox textBox_nom_pac;
        private TextBox textBox_dni_pac;
        private Label label_PLAN;
        private Label label20;
        private Forms_Seguridad.UC_Buscar_Paciente uC_Buscar_Paciente1;
        private CheckBox checkBox_cronico;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button_rec_eliminar;
        private Button button_rec_limpiar;
        private Button button_rec_editar;
        private Button button_rec_guardar;
        private Button button_rec_imprimir;
        private Label label19;
        private RichTextBox richTextBox_observ;
    }
}