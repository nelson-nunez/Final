using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BE.Seguridad;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;

namespace SiAP.UI.Controles
{
    public partial class UC_buscarUsuario : UserControl
    {
        BLL_Usuario _bllUsuario;
        public Usuario itemSeleccionado = new Usuario();

        public UC_buscarUsuario()
        {
            InitializeComponent();
            _bllUsuario = BLL_Usuario.ObtenerInstancia();
            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_Buscar.Text))
            {
                var usuarios = _bllUsuario.ObtenerTodos()
                    .Where(x => string.IsNullOrWhiteSpace(textBox_Buscar.Text)
                             || x.Username.Contains(textBox_Buscar.Text, StringComparison.OrdinalIgnoreCase)
                             || x.Nombre.Contains(textBox_Buscar.Text, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                dataGridView1.CargarGrid(new List<string> { "Id", "Nombre", "Username", "Password", "Email" }, usuarios);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Usuario>();
            CargarDatos(itemSeleccionado);
        }

        private void CargarDatos(Usuario item)
        {
            itemSeleccionado = item;
            //Campos
            textBox_NombreSeleccionado.Text = item.Username;
            textBox_ConstraseñaSeleccionada.Text = item.Password;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
