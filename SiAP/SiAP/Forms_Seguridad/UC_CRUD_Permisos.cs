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

        public UC_CRUD_Permisos()
        {
            InitializeComponent();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            ArmarArbolPermisosSimples(_bllPermiso.ObtenerTodos().ToList());
            comboBox1.DataSource = _bllPermiso.ObtenerTodos().OfType<PermisoSimple>().ToList();
        }

        private void treeView_Permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            itemSeleccionado = e.Node?.Tag as Permiso;
            CargarDatos();
        }

        #region Arbol
        private void ArmarArbolPermisosSimples(List<Permiso> permisos)
        {
            HashSet<string> codigosAgregados = new(); // Para evitar duplicados
            treeView_Permisos.Nodes.Clear();
            foreach (var permiso in permisos)
            {
                if (permiso is PermisoSimple rol)
                {
                    TreeNode nodoRol = treeView_Permisos.Nodes.Add(rol.Codigo, $"{rol.Codigo}-{rol.Descripcion}");
                    nodoRol.Tag = rol;
                }
            }
        }
        #endregion

        #region Buttons

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = new PermisoCompuesto("0", null);
                InputsExtensions.PedirConfirmacion("Desea crear el Rol?");
                var item = comboBox1.SelectedItem as Permiso;
                InputsExtensions.OnlySelected(item, "un rol a asociar ");
                
                //Valores
                itemSeleccionado.Codigo = item.Codigo;
                itemSeleccionado.Descripcion = textBox_Descripcion.Text;

                _bllPermiso.Agregar(itemSeleccionado);
                MessageBox.Show("Se creó el registro con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
                var item = comboBox1.SelectedItem as Permiso;
                InputsExtensions.OnlySelected(item, "un menú ");
                //Valores
                itemSeleccionado.Codigo = item.Codigo;
                itemSeleccionado.Descripcion = textBox_Descripcion.Text;

                _bllPermiso.Modificar(itemSeleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
                MessageBox.Show(ex.Message, "Error");
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
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                CargarMenus();
            }
        }

        #endregion

        #region MyRegion

        private void CargarDatos()
        {
            label_id.Text = itemSeleccionado.Id.ToString();
            comboBox1.SelectedItem = itemSeleccionado;
            textBox_Descripcion.Text = itemSeleccionado.Descripcion;
        }

        private void CargarMenus()
        {
            ArmarArbolPermisosSimples(_bllPermiso.ObtenerTodos().ToList());
            itemSeleccionado = new PermisoSimple("0", null);
            comboBox1.SelectedItem = null;
            treeView_Permisos.SelectedNode = null;
            CargarDatos();
        }

        #endregion
    }
}
