namespace SiAP.UI
{
    partial class Form_Respaldos
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
            treeView_respaldos = new TreeView();
            groupBox4 = new GroupBox();
            dateTimePicker_hasta = new DateTimePicker();
            dateTimePicker_desde = new DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            button6 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            richTextBox_motivo_consulta = new RichTextBox();
            textBox_nombre_completo = new TextBox();
            textBox_ooss = new TextBox();
            label28 = new Label();
            label30 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView_respaldos
            // 
            treeView_respaldos.Location = new Point(6, 78);
            treeView_respaldos.Name = "treeView_respaldos";
            treeView_respaldos.Size = new Size(355, 623);
            treeView_respaldos.TabIndex = 92;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.WhiteSmoke;
            groupBox4.Controls.Add(groupBox1);
            groupBox4.Controls.Add(button6);
            groupBox4.Controls.Add(treeView_respaldos);
            groupBox4.Controls.Add(dateTimePicker_hasta);
            groupBox4.Controls.Add(dateTimePicker_desde);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1210, 707);
            groupBox4.TabIndex = 91;
            groupBox4.TabStop = false;
            groupBox4.Text = "Respaldos:";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // dateTimePicker_hasta
            // 
            dateTimePicker_hasta.Format = DateTimePickerFormat.Short;
            dateTimePicker_hasta.Location = new Point(133, 47);
            dateTimePicker_hasta.Name = "dateTimePicker_hasta";
            dateTimePicker_hasta.Size = new Size(110, 23);
            dateTimePicker_hasta.TabIndex = 127;
            // 
            // dateTimePicker_desde
            // 
            dateTimePicker_desde.Format = DateTimePickerFormat.Short;
            dateTimePicker_desde.Location = new Point(6, 47);
            dateTimePicker_desde.Name = "dateTimePicker_desde";
            dateTimePicker_desde.Size = new Size(110, 23);
            dateTimePicker_desde.TabIndex = 126;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(133, 29);
            label9.Name = "label9";
            label9.Size = new Size(89, 15);
            label9.TabIndex = 125;
            label9.Text = "Vigencia Hasta:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(6, 29);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 123;
            label8.Text = "Vigencia desde:";
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ActiveCaption;
            button6.Image = Properties.Resources.lupa;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(249, 47);
            button6.Name = "button6";
            button6.Size = new Size(112, 25);
            button6.TabIndex = 130;
            button6.Text = "Filtrar";
            button6.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSeaGreen;
            button4.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button4.Image = Properties.Resources.save;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(5, 42);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(218, 27);
            button4.TabIndex = 25;
            button4.Text = "Guardar Nuevo Respaldo";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button3.Image = Properties.Resources.respaldo_3_;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(5, 79);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(218, 27);
            button3.TabIndex = 24;
            button3.Text = "Restaurar Respaldo Seleccionado";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button1.Image = Properties.Resources.delete;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(5, 5);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(218, 27);
            button1.TabIndex = 22;
            button1.Text = "Eliminar  Respaldo Seleccionado";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Controls.Add(button3);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(176, 313);
            flowLayoutPanel2.Margin = new Padding(5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(228, 114);
            flowLayoutPanel2.TabIndex = 129;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 132);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 93;
            label1.Text = "Descripcion:";
            // 
            // richTextBox_motivo_consulta
            // 
            richTextBox_motivo_consulta.Location = new Point(117, 129);
            richTextBox_motivo_consulta.Name = "richTextBox_motivo_consulta";
            richTextBox_motivo_consulta.Size = new Size(359, 176);
            richTextBox_motivo_consulta.TabIndex = 92;
            richTextBox_motivo_consulta.Text = "";
            // 
            // textBox_nombre_completo
            // 
            textBox_nombre_completo.Enabled = false;
            textBox_nombre_completo.Location = new Point(117, 42);
            textBox_nombre_completo.Name = "textBox_nombre_completo";
            textBox_nombre_completo.Size = new Size(359, 23);
            textBox_nombre_completo.TabIndex = 136;
            // 
            // textBox_ooss
            // 
            textBox_ooss.Enabled = false;
            textBox_ooss.Location = new Point(117, 71);
            textBox_ooss.Name = "textBox_ooss";
            textBox_ooss.Size = new Size(359, 23);
            textBox_ooss.TabIndex = 133;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Enabled = false;
            label28.Location = new Point(42, 45);
            label28.Name = "label28";
            label28.Size = new Size(69, 15);
            label28.TabIndex = 131;
            label28.Text = "Creado por:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Enabled = false;
            label30.Location = new Point(13, 74);
            label30.Name = "label30";
            label30.Size = new Size(98, 15);
            label30.TabIndex = 132;
            label30.Text = "Nombre Archivo:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(117, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(359, 23);
            textBox1.TabIndex = 138;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(20, 103);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 137;
            label2.Text = "Fecha Creación:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox_motivo_consulta);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(flowLayoutPanel2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_nombre_completo);
            groupBox1.Controls.Add(label30);
            groupBox1.Controls.Add(textBox_ooss);
            groupBox1.Controls.Add(label28);
            groupBox1.Location = new Point(367, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(489, 443);
            groupBox1.TabIndex = 139;
            groupBox1.TabStop = false;
            groupBox1.Text = "Respaldo";
            // 
            // Form_Respaldos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox4);
            Name = "Form_Respaldos";
            Text = "Form_Respaldos";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView_respaldos;
        private GroupBox groupBox4;
        private DateTimePicker dateTimePicker_hasta;
        private DateTimePicker dateTimePicker_desde;
        private Label label9;
        private Label label8;
        private Button button6;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button1;
        private Button button4;
        private Button button3;
        private Label label1;
        private RichTextBox richTextBox_motivo_consulta;
        private TextBox textBox_nombre_completo;
        private TextBox textBox_ooss;
        private Label label28;
        private Label label30;
        private TextBox textBox1;
        private Label label2;
        private GroupBox groupBox1;
    }
}