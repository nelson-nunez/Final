namespace SiAP.UI.Forms_Seguridad
{
    partial class Form_Roles
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
            UC_BuscarUsuario1 = new Controles.UC_BuscarUsuario();
            uC_cruD_Roles1 = new UC_CRUD_Roles();
            uC_cruD_Permisos1 = new UC_CRUD_Permisos();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            treeView2 = new TreeView();
            groupBox3 = new GroupBox();
            button3 = new Button();
            button4 = new Button();
            treeView1 = new TreeView();
            groupBox2 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            button_Borrar = new Button();
            button_Guardar = new Button();
            treeView_Permisos = new TreeView();
            ABMs = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ABMs.SuspendLayout();
            SuspendLayout();
            // 
            // UC_BuscarUsuario1
            // 
            UC_BuscarUsuario1.Location = new Point(6, 19);
            UC_BuscarUsuario1.Name = "UC_BuscarUsuario1";
            UC_BuscarUsuario1.Size = new Size(442, 260);
            UC_BuscarUsuario1.TabIndex = 2;
            // 
            // uC_cruD_Roles1
            // 
            uC_cruD_Roles1.Location = new Point(457, 19);
            uC_cruD_Roles1.Name = "uC_cruD_Roles1";
            uC_cruD_Roles1.Size = new Size(337, 345);
            uC_cruD_Roles1.TabIndex = 7;
            // 
            // uC_cruD_Permisos1
            // 
            uC_cruD_Permisos1.Location = new Point(882, 19);
            uC_cruD_Permisos1.Name = "uC_cruD_Permisos1";
            uC_cruD_Permisos1.Size = new Size(332, 345);
            uC_cruD_Permisos1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(3, 371);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1265, 356);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asignar Roles/Permisos";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(treeView2);
            groupBox4.Location = new Point(882, 19);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(332, 331);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "Permisos";
            // 
            // treeView2
            // 
            treeView2.Location = new Point(6, 19);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(312, 306);
            treeView2.TabIndex = 22;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(treeView1);
            groupBox3.Location = new Point(457, 19);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(419, 331);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Roles";
            // 
            // button3
            // 
            button3.BackColor = Color.IndianRed;
            button3.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button3.ImageAlign = ContentAlignment.MiddleRight;
            button3.Location = new Point(324, 83);
            button3.Name = "button3";
            button3.Size = new Size(65, 55);
            button3.TabIndex = 32;
            button3.Text = "Quitar Permiso a Rol";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.Location = new Point(324, 22);
            button4.Name = "button4";
            button4.Size = new Size(65, 55);
            button4.TabIndex = 33;
            button4.Text = "Asociar Permiso a Rol";
            button4.UseVisualStyleBackColor = false;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(6, 19);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(312, 306);
            treeView1.TabIndex = 22;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button_Borrar);
            groupBox2.Controls.Add(button_Guardar);
            groupBox2.Controls.Add(treeView_Permisos);
            groupBox2.Location = new Point(9, 19);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(442, 331);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios";
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(324, 202);
            button1.Name = "button1";
            button1.Size = new Size(65, 55);
            button1.TabIndex = 32;
            button1.Text = "Quitar Permiso a Usuario";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.Location = new Point(324, 141);
            button2.Name = "button2";
            button2.Size = new Size(65, 55);
            button2.TabIndex = 33;
            button2.Text = "Asociar Permiso a Usuario";
            button2.UseVisualStyleBackColor = false;
            // 
            // button_Borrar
            // 
            button_Borrar.BackColor = Color.IndianRed;
            button_Borrar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Borrar.ImageAlign = ContentAlignment.MiddleRight;
            button_Borrar.Location = new Point(324, 80);
            button_Borrar.Name = "button_Borrar";
            button_Borrar.Size = new Size(65, 55);
            button_Borrar.TabIndex = 30;
            button_Borrar.Text = "Quitar Rol a Usuario";
            button_Borrar.UseVisualStyleBackColor = false;
            // 
            // button_Guardar
            // 
            button_Guardar.BackColor = SystemColors.ActiveCaption;
            button_Guardar.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Guardar.ImageAlign = ContentAlignment.MiddleRight;
            button_Guardar.Location = new Point(324, 19);
            button_Guardar.Name = "button_Guardar";
            button_Guardar.Size = new Size(65, 55);
            button_Guardar.TabIndex = 31;
            button_Guardar.Text = "Asociar Rol a Usuario";
            button_Guardar.UseVisualStyleBackColor = false;
            // 
            // treeView_Permisos
            // 
            treeView_Permisos.Location = new Point(6, 19);
            treeView_Permisos.Name = "treeView_Permisos";
            treeView_Permisos.Size = new Size(312, 306);
            treeView_Permisos.TabIndex = 22;
            // 
            // ABMs
            // 
            ABMs.Controls.Add(UC_BuscarUsuario1);
            ABMs.Controls.Add(uC_cruD_Permisos1);
            ABMs.Controls.Add(uC_cruD_Roles1);
            ABMs.Location = new Point(3, 1);
            ABMs.Name = "ABMs";
            ABMs.Size = new Size(1265, 370);
            ABMs.TabIndex = 17;
            ABMs.TabStop = false;
            ABMs.Text = "ABMs";
            // 
            // Form_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1280, 731);
            Controls.Add(groupBox1);
            Controls.Add(ABMs);
            Name = "Form_Roles";
            Text = "Form_Roles";
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ABMs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Controles.UC_BuscarUsuario UC_BuscarUsuario1;
        private UC_CRUD_Roles uC_cruD_Roles1;
        private UC_CRUD_Permisos uC_cruD_Permisos1;
        private GroupBox groupBox1;
        private TreeView treeView_Permisos;
        private GroupBox groupBox4;
        private TreeView treeView2;
        private GroupBox groupBox3;
        private Button button3;
        private Button button4;
        private TreeView treeView1;
        private GroupBox groupBox2;
        private Button button1;
        private Button button2;
        private Button button_Borrar;
        private Button button_Guardar;
        private GroupBox ABMs;
    }
}