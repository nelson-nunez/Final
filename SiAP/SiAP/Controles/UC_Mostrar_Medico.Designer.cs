namespace SiAP.UI.Forms_Seguridad
{
    partial class UC_Mostrar_Medico
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
            label18 = new Label();
            label12 = new Label();
            label16 = new Label();
            label17 = new Label();
            label_nombre_med = new Label();
            label_especialidad_med = new Label();
            label_metricula_med = new Label();
            SuspendLayout();
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(84, 88);
            label18.Name = "label18";
            label18.Size = new Size(127, 15);
            label18.TabIndex = 117;
            label18.Text = "........................................";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 36);
            label12.Name = "label12";
            label12.Size = new Size(75, 15);
            label12.TabIndex = 115;
            label12.Text = "Especialidad:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(17, 12);
            label16.Name = "label16";
            label16.Size = new Size(61, 15);
            label16.TabIndex = 111;
            label16.Text = "Médico/a:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(18, 60);
            label17.Name = "label17";
            label17.Size = new Size(60, 15);
            label17.TabIndex = 112;
            label17.Text = "Matrícula:";
            // 
            // label_nombre_med
            // 
            label_nombre_med.AutoSize = true;
            label_nombre_med.Location = new Point(84, 12);
            label_nombre_med.Name = "label_nombre_med";
            label_nombre_med.Size = new Size(166, 15);
            label_nombre_med.TabIndex = 118;
            label_nombre_med.Text = ".....................................................";
            // 
            // label_especialidad_med
            // 
            label_especialidad_med.AutoSize = true;
            label_especialidad_med.Location = new Point(84, 36);
            label_especialidad_med.Name = "label_especialidad_med";
            label_especialidad_med.Size = new Size(166, 15);
            label_especialidad_med.TabIndex = 119;
            label_especialidad_med.Text = ".....................................................";
            // 
            // label_metricula_med
            // 
            label_metricula_med.AutoSize = true;
            label_metricula_med.Location = new Point(84, 60);
            label_metricula_med.Name = "label_metricula_med";
            label_metricula_med.Size = new Size(166, 15);
            label_metricula_med.TabIndex = 120;
            label_metricula_med.Text = ".....................................................";
            // 
            // UC_Mostrar_Medico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(label_metricula_med);
            Controls.Add(label_especialidad_med);
            Controls.Add(label_nombre_med);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label12);
            Controls.Add(label16);
            Name = "UC_Mostrar_Medico";
            Size = new Size(263, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private UC_Buscar_Paciente uC_Buscar_Paciente1;
        private Label label18;
        private Label label12;
        private Label label16;
        private Label label17;
        private Label label_nombre_med;
        private Label label_especialidad_med;
        private Label label_metricula_med;
    }
}
