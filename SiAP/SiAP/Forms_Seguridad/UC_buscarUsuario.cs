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
using SiAP.BE.Seguridad;
using SiAP.BLL.Base;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;

namespace SiAP.UI.Controles
{
    public partial class UC_BuscarUsuario : UserControl
    {
        BLL_Usuario _bllUsuario;
        public Usuario itemSeleccionado = new Usuario();
        private IEncriptacion _encriptacion;

        public UC_BuscarUsuario()
        {
            InitializeComponent();
            _bllUsuario = BLL_Usuario.ObtenerInstancia();
            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
            _encriptacion = new Encriptador();
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
            //Campos
            textBox_NombreSeleccionado.Text = item.Username;
            textBox_ConstraseñaSeleccionada.Text = item.Password;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox_ConstraseñaSeleccionada.Text = _encriptacion.Desencriptar3DES(itemSeleccionado.Password);
            else
                textBox_ConstraseñaSeleccionada.Text = itemSeleccionado.Password;
        }
    }
}
