using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiAP.UI
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
            // Hacer que esta ventana sea un contenedor MDI
            this.IsMdiContainer = true;
        }


        private Form_Turnos form_turnos;
        private Form_HistoriaClinica form_historia;

        private void AbrirForm_Turnos(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_turnos);
        }
        private void AbrirForm_Historia(object sender, EventArgs e)
        {
            AbrirFormGeneral(ref form_historia);
        }

        private void AbrirFormGeneral<T>(ref T formulario) where T : Form, new()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                T nuevoFormulario = new T();
                //Dentro del padre
                nuevoFormulario.MdiParent = this;
                //Sin controles de cerrar
                nuevoFormulario.ControlBox = false;
                //Sin bordes
                nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
                // Establecer la ubicación centrada
                nuevoFormulario.StartPosition = FormStartPosition.CenterScreen;
                formulario = nuevoFormulario;
            }

            formulario.Show();
            formulario.BringToFront();
        }
        private void CerrarTodosLosFormulariosHijos(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
