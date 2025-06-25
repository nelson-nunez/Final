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

namespace SiAP.UI.Forms_Seguridad
{
    public partial class UC_CRUD_Permisos : UserControl
    {
        BLL_Permiso _bllPermiso;
        public Permiso itemSeleccionado = new PermisoSimple("0", null);
        public event EventHandler<EventArgs> ShouldUpdate;

        public UC_CRUD_Permisos()
        {
            InitializeComponent();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            treeView_Permisos.ArmarArbolPermisosSimples(_bllPermiso.ObtenerTodos().ToList());
            comboBox1.DataSource = MenusConstantes.ObtenerTodos();
            comboBox1.DisplayMember = "Mostrar";
        }

        #region Buttons

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = new PermisoCompuesto("0", null);
                InputsExtensions.PedirConfirmacion("Desea crear el Permiso?");
                var item = comboBox1.SelectedItem as Menu;              
                //Valores
                itemSeleccionado.Codigo = item.Etiqueta;
                itemSeleccionado.Descripcion = textBox_Descripcion.Text;
                _bllPermiso.Agregar(itemSeleccionado);
                MessageBox.Show("Se creó el permiso con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarMenus();
            }
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = treeView_Permisos.VerificarYRetornarSeleccion<Permiso>();
                InputsExtensions.PedirConfirmacion("Desea guardar los cambios?");
                var item = comboBox1.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "un menú ");
                //Valores
                itemSeleccionado.Codigo = item.Etiqueta;
                itemSeleccionado.Descripcion = textBox_Descripcion.Text;

                _bllPermiso.Modificar(itemSeleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarMenus();
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = treeView_Permisos.VerificarYRetornarSeleccion<Permiso>();
                InputsExtensions.PedirConfirmacion("Desea eliminar el registro?");
                _bllPermiso.Eliminar(itemSeleccionado);
                MessageBox.Show("Se eliminó el registro con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarMenus();
            }
        }

        #endregion

        #region CargarDatos

        private void CargarDatos()
        {
            label_id.Text = itemSeleccionado.Id.ToString();
            comboBox1.SelectedItem = MenusConstantes.Obtener(itemSeleccionado.Codigo);
            textBox_Descripcion.Text = itemSeleccionado.Descripcion;
        }

        private void CargarMenus()
        {
            treeView_Permisos.ArmarArbolPermisosSimples(_bllPermiso.ObtenerTodos().ToList());
            itemSeleccionado = new PermisoSimple("0", null);
            comboBox1.SelectedItem = null;
            treeView_Permisos.SelectedNode = null;
            CargarDatos();
            ShouldUpdate?.Invoke(null, new EventArgs());
        }
        
        private void treeView_Permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            itemSeleccionado = e.Node?.Tag as Permiso;
            CargarDatos();
        }

        #endregion
    }
}
