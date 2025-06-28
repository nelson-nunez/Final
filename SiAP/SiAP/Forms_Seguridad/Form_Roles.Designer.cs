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
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            treeView_Permisos = new TreeView();
            groupBox3 = new GroupBox();
            button_Quitar_Perm_Rol = new Button();
            button_Asoc_Perm_Rol = new Button();
            treeView_Roles = new TreeView();
            groupBox2 = new GroupBox();
            button_Quitar_Permiso_User = new Button();
            button_Asociar_Permiso_User = new Button();
            button_Quitar_Rol_User = new Button();
            button_Asociar_Rol_User = new Button();
            treeView_Users = new TreeView();
            ABMs = new GroupBox();
            uC_cruD_Permisos2 = new UC_CRUD_Permisos();
            uC_cruD_Roles2 = new UC_CRUD_Roles();
            uC_BuscarUsuario2 = new Controles.UC_BuscarUsuario();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ABMs.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(3, 371);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1223, 356);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asignar Roles/Permisos";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(treeView_Permisos);
            groupBox4.Location = new Point(882, 19);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(332, 331);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "Permisos";
            // 
            // treeView_Permisos
            // 
            treeView_Permisos.HideSelection = false;
            treeView_Permisos.Location = new Point(6, 19);
            treeView_Permisos.Name = "treeView_Permisos";
            treeView_Permisos.Size = new Size(312, 306);
            treeView_Permisos.TabIndex = 22;
            treeView_Permisos.AfterSelect += treeView_Permisos_AfterSelect;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button_Quitar_Perm_Rol);
            groupBox3.Controls.Add(button_Asoc_Perm_Rol);
            groupBox3.Controls.Add(treeView_Roles);
            groupBox3.Location = new Point(457, 19);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(419, 331);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Roles";
            // 
            // button_Quitar_Perm_Rol
            // 
            button_Quitar_Perm_Rol.BackColor = Color.IndianRed;
            button_Quitar_Perm_Rol.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Quitar_Perm_Rol.ImageAlign = ContentAlignment.MiddleRight;
            button_Quitar_Perm_Rol.Location = new Point(324, 83);
            button_Quitar_Perm_Rol.Name = "button_Quitar_Perm_Rol";
            button_Quitar_Perm_Rol.Size = new Size(65, 55);
            button_Quitar_Perm_Rol.TabIndex = 32;
            button_Quitar_Perm_Rol.Text = "Quitar Permiso a Rol";
            button_Quitar_Perm_Rol.UseVisualStyleBackColor = false;
            button_Quitar_Perm_Rol.Click += button_Quitar_Perm_Rol_Click;
            // 
            // button_Asoc_Perm_Rol
            // 
            button_Asoc_Perm_Rol.BackColor = SystemColors.ActiveCaption;
            button_Asoc_Perm_Rol.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Asoc_Perm_Rol.ImageAlign = ContentAlignment.MiddleRight;
            button_Asoc_Perm_Rol.Location = new Point(324, 22);
            button_Asoc_Perm_Rol.Name = "button_Asoc_Perm_Rol";
            button_Asoc_Perm_Rol.Size = new Size(65, 55);
            button_Asoc_Perm_Rol.TabIndex = 33;
            button_Asoc_Perm_Rol.Text = "Asociar Permiso a Rol";
            button_Asoc_Perm_Rol.UseVisualStyleBackColor = false;
            button_Asoc_Perm_Rol.Click += button_Asoc_Perm_Rol_Click;
            // 
            // treeView_Roles
            // 
            treeView_Roles.HideSelection = false;
            treeView_Roles.Location = new Point(6, 19);
            treeView_Roles.Name = "treeView_Roles";
            treeView_Roles.Size = new Size(312, 306);
            treeView_Roles.TabIndex = 22;
            treeView_Roles.AfterSelect += treeView_Roles_AfterSelect;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_Quitar_Permiso_User);
            groupBox2.Controls.Add(button_Asociar_Permiso_User);
            groupBox2.Controls.Add(button_Quitar_Rol_User);
            groupBox2.Controls.Add(button_Asociar_Rol_User);
            groupBox2.Controls.Add(treeView_Users);
            groupBox2.Location = new Point(9, 19);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(442, 331);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios";
            // 
            // button_Quitar_Permiso_User
            // 
            button_Quitar_Permiso_User.BackColor = Color.IndianRed;
            button_Quitar_Permiso_User.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Quitar_Permiso_User.ImageAlign = ContentAlignment.MiddleRight;
            button_Quitar_Permiso_User.Location = new Point(324, 202);
            button_Quitar_Permiso_User.Name = "button_Quitar_Permiso_User";
            button_Quitar_Permiso_User.Size = new Size(65, 55);
            button_Quitar_Permiso_User.TabIndex = 32;
            button_Quitar_Permiso_User.Text = "Quitar Permiso a Usuario";
            button_Quitar_Permiso_User.UseVisualStyleBackColor = false;
            button_Quitar_Permiso_User.Click += button_Quitar_Permiso_User_Click;
            // 
            // button_Asociar_Permiso_User
            // 
            button_Asociar_Permiso_User.BackColor = SystemColors.ActiveCaption;
            button_Asociar_Permiso_User.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Asociar_Permiso_User.ImageAlign = ContentAlignment.MiddleRight;
            button_Asociar_Permiso_User.Location = new Point(324, 141);
            button_Asociar_Permiso_User.Name = "button_Asociar_Permiso_User";
            button_Asociar_Permiso_User.Size = new Size(65, 55);
            button_Asociar_Permiso_User.TabIndex = 33;
            button_Asociar_Permiso_User.Text = "Asociar Permiso a Usuario";
            button_Asociar_Permiso_User.UseVisualStyleBackColor = false;
            button_Asociar_Permiso_User.Click += button_Asociar_Permiso_User_Click;
            // 
            // button_Quitar_Rol_User
            // 
            button_Quitar_Rol_User.BackColor = Color.IndianRed;
            button_Quitar_Rol_User.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Quitar_Rol_User.ImageAlign = ContentAlignment.MiddleRight;
            button_Quitar_Rol_User.Location = new Point(324, 80);
            button_Quitar_Rol_User.Name = "button_Quitar_Rol_User";
            button_Quitar_Rol_User.Size = new Size(65, 55);
            button_Quitar_Rol_User.TabIndex = 30;
            button_Quitar_Rol_User.Text = "Quitar Rol a Usuario";
            button_Quitar_Rol_User.UseVisualStyleBackColor = false;
            button_Quitar_Rol_User.Click += button_Quitar_Rol_User_Click;
            // 
            // button_Asociar_Rol_User
            // 
            button_Asociar_Rol_User.BackColor = SystemColors.ActiveCaption;
            button_Asociar_Rol_User.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            button_Asociar_Rol_User.ImageAlign = ContentAlignment.MiddleRight;
            button_Asociar_Rol_User.Location = new Point(324, 19);
            button_Asociar_Rol_User.Name = "button_Asociar_Rol_User";
            button_Asociar_Rol_User.Size = new Size(65, 55);
            button_Asociar_Rol_User.TabIndex = 31;
            button_Asociar_Rol_User.Text = "Asociar Rol a Usuario";
            button_Asociar_Rol_User.UseVisualStyleBackColor = false;
            button_Asociar_Rol_User.Click += button_Asociar_Rol_User_Click;
            // 
            // treeView_Users
            // 
            treeView_Users.HideSelection = false;
            treeView_Users.Location = new Point(6, 19);
            treeView_Users.Name = "treeView_Users";
            treeView_Users.Size = new Size(312, 306);
            treeView_Users.TabIndex = 22;
            treeView_Users.AfterSelect += treeView_Users_AfterSelect;
            // 
            // ABMs
            // 
            ABMs.Controls.Add(uC_cruD_Permisos2);
            ABMs.Controls.Add(uC_cruD_Roles2);
            ABMs.Controls.Add(uC_BuscarUsuario2);
            ABMs.Location = new Point(3, 1);
            ABMs.Margin = new Padding(0);
            ABMs.Name = "ABMs";
            ABMs.Size = new Size(1223, 370);
            ABMs.TabIndex = 17;
            ABMs.TabStop = false;
            ABMs.Text = "ABMs";
            // 
            // uC_cruD_Permisos2
            // 
            uC_cruD_Permisos2.Location = new Point(879, 19);
            uC_cruD_Permisos2.Name = "uC_cruD_Permisos2";
            uC_cruD_Permisos2.Size = new Size(335, 345);
            uC_cruD_Permisos2.TabIndex = 2;
            // 
            // uC_cruD_Roles2
            // 
            uC_cruD_Roles2.Location = new Point(457, 22);
            uC_cruD_Roles2.Name = "uC_cruD_Roles2";
            uC_cruD_Roles2.Size = new Size(335, 345);
            uC_cruD_Roles2.TabIndex = 1;
            // 
            // uC_BuscarUsuario2
            // 
            uC_BuscarUsuario2.Location = new Point(6, 22);
            uC_BuscarUsuario2.Name = "uC_BuscarUsuario2";
            uC_BuscarUsuario2.Size = new Size(442, 342);
            uC_BuscarUsuario2.TabIndex = 0;
            // 
            // Form_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1234, 731);
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
        private UC_CRUD_Roles uC_cruD_Roles1;
        private UC_CRUD_Permisos uC_cruD_Permisos1;
        private GroupBox groupBox1;
        private TreeView treeView_Users;
        private GroupBox groupBox4;
        private TreeView treeView_Permisos;
        private GroupBox groupBox3;
        private Button button_Quitar_Perm_Rol;
        private Button button_Asoc_Perm_Rol;
        private TreeView treeView_Roles;
        private GroupBox groupBox2;
        private Button button_Quitar_Permiso_User;
        private Button button_Asociar_Permiso_User;
        private Button button_Quitar_Rol_User;
        private Button button_Asociar_Rol_User;
        private GroupBox ABMs;
        private Controles.UC_BuscarUsuario uC_BuscarUsuario1;
        private UC_CRUD_Permisos uC_cruD_Permisos2;
        private UC_CRUD_Roles uC_cruD_Roles2;
        private Controles.UC_BuscarUsuario uC_BuscarUsuario2;
    }
}