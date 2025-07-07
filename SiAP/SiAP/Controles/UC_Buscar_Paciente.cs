using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BE.Seguridad;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class UC_Buscar_Paciente : UserControl
    {
        BLL_Paciente _bllPaciente;
        public Paciente itemSeleccionado;
        public event EventHandler<EventArgs> ShouldUpdate;
        private List<string> campos = new List<string> { "Dni", "Apellido", "Nombre", "ObraSocial" };


        public UC_Buscar_Paciente()
        {
            InitializeComponent();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_Buscar.Text))
                {
                    dataGridView_paciente.DataSource = null;
                    return;
                }

                var usuarios = _bllPaciente.Buscar(textBox_Buscar.Text).ToList();
                dataGridView_paciente.CargarGrid(campos, usuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                itemSeleccionado = dataGridView_paciente.VerificarYRetornarSeleccion<Paciente>();
                if (itemSeleccionado != null)
                    ShouldUpdate?.Invoke(null, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
