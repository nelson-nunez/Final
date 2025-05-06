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
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class Form_Roles : Form
    {
        BLL_Rol _bllRol;
        BLL_Permiso _bllPermiso;
        Rol itemSeleccionado = new Rol();

        public Form_Roles()
        {
            InitializeComponent();
            _bllRol = BLL_Rol.ObtenerInstancia();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
            //Cargar Grids
            dataGrid_Roles.DataSource = _bllRol.ObtenerTodos();
            dataGrid_PermisosDisp.DataSource = _bllPermiso.ObtenerTodos();
        }

        #region Buttons Actions

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = dataGrid_Roles.VerificarYRetornarSeleccion<Rol>();
                //VerificarDatos();
                InputsExtensions.PedirConfirmacion("Desea eliminar el registro?");
                _bllRol.Eliminar(itemSeleccionado);
                MessageBox.Show("Se eliminó el registro con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                //CargarDatos(new Socio());
            }

        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {

        }

        private void button_Editar_Click(object sender, EventArgs e)
        {

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
