namespace SiAP.UI
{
    partial class Form_Turnos
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
            dataGridView1 = new DataGridView();
            treeView1 = new TreeView();
            groupBox1 = new GroupBox();
            label_titular_agenda = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(398, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 437);
            dataGridView1.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.HideSelection = false;
            treeView1.Location = new Point(6, 22);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(314, 462);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label_titular_agenda);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 497);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reservar Turno";
            // 
            // label_titular_agenda
            // 
            label_titular_agenda.AutoSize = true;
            label_titular_agenda.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titular_agenda.Location = new Point(399, 23);
            label_titular_agenda.Name = "label_titular_agenda";
            label_titular_agenda.Size = new Size(48, 15);
            label_titular_agenda.TabIndex = 4;
            label_titular_agenda.Text = "Agenda";
            // 
            // Form_Turnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 731);
            Controls.Add(groupBox1);
            Name = "Form_Turnos";
            Text = "Form_Turnos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private TreeView treeView1;
        private GroupBox groupBox1;
        private Label label_titular_agenda;
    }
}