namespace SiAP.UI.Forms_Seguridad
{
    partial class UC_Mostrar_Paciente
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            button1 = new Button();
            textBox_nombre_completo = new TextBox();
            textBox_DNI = new TextBox();
            label26 = new Label();
            textBox_plan = new TextBox();
            textBox_nro_socio = new TextBox();
            textBox_ooss = new TextBox();
            button2 = new Button();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            uC_Buscar_Paciente1 = new UC_Buscar_Paciente();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox_nombre_completo);
            groupBox1.Controls.Add(textBox_DNI);
            groupBox1.Controls.Add(label26);
            groupBox1.Controls.Add(textBox_plan);
            groupBox1.Controls.Add(textBox_nro_socio);
            groupBox1.Controls.Add(textBox_ooss);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label28);
            groupBox1.Controls.Add(label29);
            groupBox1.Controls.Add(label30);
            groupBox1.Controls.Add(label31);
            groupBox1.Location = new Point(3, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(894, 107);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Paciente";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button1.Image = Properties.Resources.lupa;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(16, 22);
            button1.Name = "button1";
            button1.Size = new Size(116, 27);
            button1.TabIndex = 124;
            button1.Text = "Buscar Paciente";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button_Buscar_Click;
            // 
            // textBox_nombre_completo
            // 
            textBox_nombre_completo.Enabled = false;
            textBox_nombre_completo.Location = new Point(274, 16);
            textBox_nombre_completo.Name = "textBox_nombre_completo";
            textBox_nombre_completo.Size = new Size(359, 23);
            textBox_nombre_completo.TabIndex = 123;
            // 
            // textBox_DNI
            // 
            textBox_DNI.Enabled = false;
            textBox_DNI.Location = new Point(675, 16);
            textBox_DNI.Name = "textBox_DNI";
            textBox_DNI.Size = new Size(203, 23);
            textBox_DNI.TabIndex = 122;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Enabled = false;
            label26.Location = new Point(639, 19);
            label26.Name = "label26";
            label26.Size = new Size(30, 15);
            label26.TabIndex = 121;
            label26.Text = "DNI:";
            // 
            // textBox_plan
            // 
            textBox_plan.Enabled = false;
            textBox_plan.Location = new Point(485, 74);
            textBox_plan.Name = "textBox_plan";
            textBox_plan.Size = new Size(393, 23);
            textBox_plan.TabIndex = 120;
            // 
            // textBox_nro_socio
            // 
            textBox_nro_socio.Enabled = false;
            textBox_nro_socio.Location = new Point(274, 74);
            textBox_nro_socio.Name = "textBox_nro_socio";
            textBox_nro_socio.Size = new Size(163, 23);
            textBox_nro_socio.TabIndex = 119;
            // 
            // textBox_ooss
            // 
            textBox_ooss.Enabled = false;
            textBox_ooss.Location = new Point(274, 45);
            textBox_ooss.Name = "textBox_ooss";
            textBox_ooss.Size = new Size(604, 23);
            textBox_ooss.TabIndex = 118;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button2.Image = Properties.Resources.edit;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(16, 65);
            button2.Name = "button2";
            button2.Size = new Size(116, 27);
            button2.TabIndex = 114;
            button2.Text = "Editar Paciente";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button_MostrarEditar_Click;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Enabled = false;
            label28.Location = new Point(217, 19);
            label28.Name = "label28";
            label28.Size = new Size(51, 15);
            label28.TabIndex = 115;
            label28.Text = "Afiliado:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Enabled = false;
            label29.Location = new Point(211, 77);
            label29.Name = "label29";
            label29.Size = new Size(56, 15);
            label29.TabIndex = 113;
            label29.Text = "N° Socio:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Enabled = false;
            label30.Location = new Point(223, 48);
            label30.Name = "label30";
            label30.Size = new Size(43, 15);
            label30.TabIndex = 116;
            label30.Text = "OOSS: ";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Enabled = false;
            label31.Location = new Point(443, 77);
            label31.Name = "label31";
            label31.Size = new Size(36, 15);
            label31.TabIndex = 117;
            label31.Text = "Plan: ";
            // 
            // uC_Buscar_Paciente1
            // 
            uC_Buscar_Paciente1.Location = new Point(226, 45);
            uC_Buscar_Paciente1.Name = "uC_Buscar_Paciente1";
            uC_Buscar_Paciente1.Size = new Size(444, 226);
            uC_Buscar_Paciente1.TabIndex = 126;
            uC_Buscar_Paciente1.Visible = false;
            // 
            // UC_Mostrar_Paciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(groupBox1);
            Controls.Add(uC_Buscar_Paciente1);
            Name = "UC_Mostrar_Paciente";
            Size = new Size(900, 275);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox_nombre_completo;
        private TextBox textBox_DNI;
        private Label label26;
        private TextBox textBox_plan;
        private TextBox textBox_nro_socio;
        private TextBox textBox_ooss;
        private Button button2;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Button button1;
        private UC_Buscar_Paciente uC_Buscar_Paciente1;
    }
}
