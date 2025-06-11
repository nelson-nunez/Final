namespace SiAP.UI.Forms_Seguridad
{
    partial class UC_CRUD_Roles
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
            groupBox2 = new GroupBox();
            treeView_Roles = new TreeView();
            uC_Guardar_h1 = new Controles.UC_Guardar_H();
            label4 = new Label();
            label3 = new Label();
            textBox_Desc_Rol = new TextBox();
            textBox_Cod_Rol = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(treeView_Roles);
            groupBox2.Controls.Add(uC_Guardar_h1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox_Desc_Rol);
            groupBox2.Controls.Add(textBox_Cod_Rol);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(347, 402);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Roles";
            // 
            // treeView_Roles
            // 
            treeView_Roles.Location = new Point(6, 121);
            treeView_Roles.Name = "treeView_Roles";
            treeView_Roles.Size = new Size(322, 207);
            treeView_Roles.TabIndex = 14;
            treeView_Roles.AfterSelect += treeView_Roles_AfterSelect;
            // 
            // uC_Guardar_h1
            // 
            uC_Guardar_h1.Location = new Point(16, 82);
            uC_Guardar_h1.Name = "uC_Guardar_h1";
            uC_Guardar_h1.Size = new Size(312, 33);
            uC_Guardar_h1.TabIndex = 13;
            uC_Guardar_h1.Load += uC_Guardar_h1_Load;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 27);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 27);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 11;
            label3.Text = "----";
            // 
            // textBox_Desc_Rol
            // 
            textBox_Desc_Rol.Location = new Point(138, 53);
            textBox_Desc_Rol.Name = "textBox_Desc_Rol";
            textBox_Desc_Rol.Size = new Size(190, 23);
            textBox_Desc_Rol.TabIndex = 3;
            // 
            // textBox_Cod_Rol
            // 
            textBox_Cod_Rol.Location = new Point(138, 24);
            textBox_Cod_Rol.Name = "textBox_Cod_Rol";
            textBox_Cod_Rol.Size = new Size(190, 23);
            textBox_Cod_Rol.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 56);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(24, 15);
            label1.TabIndex = 0;
            label1.Text = "ID: ";
            // 
            // UC_CRUD_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "UC_CRUD_Roles";
            Size = new Size(354, 481);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TreeView treeView_Roles;
        private Controles.UC_Guardar_H uC_Guardar_h1;
        private Label label4;
        private Label label3;
        private TextBox textBox_Desc_Rol;
        private TextBox textBox_Cod_Rol;
        private Label label2;
        private Label label1;
    }
}
