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
            groupBox3 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            groupBox5 = new GroupBox();
            button_Borrar = new Button();
            label18 = new Label();
            button_Guardar = new Button();
            label17 = new Label();
            dataGridView2 = new DataGridView();
            textBox4 = new TextBox();
            label16 = new Label();
            comboBox2 = new ComboBox();
            label13 = new Label();
            textBox3 = new TextBox();
            groupBox4 = new GroupBox();
            label12 = new Label();
            richTextBox1 = new RichTextBox();
            label14 = new Label();
            textBox5 = new TextBox();
            comboBox1 = new ComboBox();
            label15 = new Label();
            textBox1 = new TextBox();
            label11 = new Label();
            textBox2 = new TextBox();
            label10 = new Label();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ActiveCaption;
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(851, 466);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pagar";
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Image = Properties.Resources.reembolso;
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.Location = new Point(278, 420);
            button2.Name = "button2";
            button2.Size = new Size(140, 40);
            button2.TabIndex = 32;
            button2.Text = "Reembolso";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSeaGreen;
            button1.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Image = Properties.Resources.ingresos;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(428, 420);
            button1.Name = "button1";
            button1.Size = new Size(140, 40);
            button1.TabIndex = 31;
            button1.Text = "Pagar";
            button1.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button_Borrar);
            groupBox5.Controls.Add(label18);
            groupBox5.Controls.Add(button_Guardar);
            groupBox5.Controls.Add(label17);
            groupBox5.Controls.Add(dataGridView2);
            groupBox5.Controls.Add(textBox4);
            groupBox5.Controls.Add(label16);
            groupBox5.Controls.Add(comboBox2);
            groupBox5.Controls.Add(label13);
            groupBox5.Controls.Add(textBox3);
            groupBox5.Location = new Point(428, 22);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(412, 392);
            groupBox5.TabIndex = 28;
            groupBox5.TabStop = false;
            groupBox5.Text = "Detalles de Pago";
            // 
            // button_Borrar
            // 
            button_Borrar.BackColor = Color.IndianRed;
            button_Borrar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Borrar.Image = Properties.Resources.delete;
            button_Borrar.ImageAlign = ContentAlignment.MiddleRight;
            button_Borrar.Location = new Point(101, 83);
            button_Borrar.Name = "button_Borrar";
            button_Borrar.Size = new Size(74, 27);
            button_Borrar.TabIndex = 29;
            button_Borrar.Text = "Quitar";
            button_Borrar.TextAlign = ContentAlignment.MiddleLeft;
            button_Borrar.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(41, 114);
            label18.Name = "label18";
            label18.Size = new Size(55, 15);
            label18.TabIndex = 31;
            label18.Text = "Detalles: ";
            // 
            // button_Guardar
            // 
            button_Guardar.BackColor = Color.DarkSeaGreen;
            button_Guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Guardar.Image = Properties.Resources.mas;
            button_Guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_Guardar.Location = new Point(323, 82);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(74, 27);
            button_Guardar.TabIndex = 30;
            button_Guardar.Text = "Agregar";
            button_Guardar.TextAlign = ContentAlignment.MiddleLeft;
            button_Guardar.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(50, 273);
            label17.Name = "label17";
            label17.Size = new Size(48, 15);
            label17.TabIndex = 30;
            label17.Text = "TOTAL: ";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(101, 114);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(296, 146);
            dataGridView2.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(101, 270);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(296, 23);
            textBox4.TabIndex = 29;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(3, 60);
            label16.Name = "label16";
            label16.Size = new Size(93, 15);
            label16.TabIndex = 20;
            label16.Text = "Medio de Pago: ";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(101, 57);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(296, 23);
            comboBox2.TabIndex = 19;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(40, 31);
            label13.Name = "label13";
            label13.Size = new Size(56, 15);
            label13.TabIndex = 18;
            label13.Text = "Importe: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(101, 28);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(296, 23);
            textBox3.TabIndex = 17;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(richTextBox1);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(textBox5);
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(textBox2);
            groupBox4.Controls.Add(label10);
            groupBox4.Location = new Point(6, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(412, 392);
            groupBox4.TabIndex = 27;
            groupBox4.TabStop = false;
            groupBox4.Text = "Servicio";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(48, 31);
            label12.Name = "label12";
            label12.Size = new Size(46, 15);
            label12.TabIndex = 16;
            label12.Text = "Cliente:";
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(101, 86);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(296, 174);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(29, 305);
            label14.Name = "label14";
            label14.Size = new Size(65, 15);
            label14.TabIndex = 26;
            label14.Text = "Cobertura: ";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(101, 57);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(296, 23);
            textBox5.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(101, 302);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(296, 23);
            comboBox1.TabIndex = 25;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(9, 60);
            label15.Name = "label15";
            label15.Size = new Size(86, 15);
            label15.TabIndex = 14;
            label15.Text = "Fecha Emisión:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 270);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 23);
            textBox1.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 273);
            label11.Name = "label11";
            label11.Size = new Size(78, 15);
            label11.TabIndex = 22;
            label11.Text = "Fecha Turno: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(101, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(296, 23);
            textBox2.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 88);
            label10.Name = "label10";
            label10.Size = new Size(73, 15);
            label10.TabIndex = 23;
            label10.Text = "Descripción:";
            // 
            // Form_Cobros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox3);
            Name = "Form_Cobros";
            Text = "Form_Cobros";
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox3;
        private RichTextBox richTextBox1;
        private Label label10;
        private Label label11;
        private TextBox textBox1;
        private Label label13;
        private TextBox textBox3;
        private Label label15;
        private TextBox textBox5;
        private Label label14;
        private ComboBox comboBox1;
        private Label label12;
        private TextBox textBox2;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private DataGridView dataGridView2;
        private Label label16;
        private ComboBox comboBox2;
        private Label label18;
        private Label label17;
        private TextBox textBox4;
        private Button button_Borrar;
        private Button button_Guardar;
        private Button button2;
        private Button button1;
    }
}