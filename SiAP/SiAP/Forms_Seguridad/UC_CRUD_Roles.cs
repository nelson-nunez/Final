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
using SiAP.UI.Controles;
using SiAP.UI.Extensiones;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class UC_CRUD_Roles : UserControl
    {
        BLL_Permiso _bllPermiso;
        public Permiso itemSeleccionado = new PermisoCompuesto("0", null);
        public event EventHandler<EventArgs> ShouldUpdate;

        public UC_CRUD_Roles()
        {
            InitializeComponent();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            treeView_Roles.ArmarArbolSoloRoles(_bllPermiso.ObtenerTodos().ToList());
            comboBox_roles.DataSource = _bllPermiso.ObtenerTodos().OfType<PermisoCompuesto>().ToList();
        }


        #region Carga de dtos
        private void CargarDatos()
        {
            label_id.Text = itemSeleccionado.Id.ToString();
            textBox_Cod_Rol.Text = itemSeleccionado.Codigo;
            textBox_Desc_Rol.Text = itemSeleccionado.Descripcion;
        }

        public void CargarMenus()
        {
            treeView_Roles.ArmarArbolSoloRoles(_bllPermiso.ObtenerTodos().ToList());
            itemSeleccionado = new PermisoCompuesto("0", null);
            treeView_Roles.SelectedNode = null;
            comboBox_roles.DataSource = _bllPermiso.ObtenerTodos().OfType<PermisoCompuesto>().ToList();
            CargarDatos();
            ShouldUpdate?.Invoke(null, new EventArgs());
        }

        private void treeView_Roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Solo permitir selección de nodos raíz (color negro)
            if (e.Node.ForeColor == Color.DarkGreen)
            {
                treeView_Roles.SelectedNode = null;
                return;
            }

            itemSeleccionado = e.Node?.Tag as Permiso;
            CargarDatos();
        }
       
        #endregion

        #region Buttons ABM

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                itemSeleccionado = new PermisoCompuesto("0", null);
                InputsExtensions.PedirConfirmacion("Desea crear el Rol?");
                //Valores
                itemSeleccionado.Codigo = textBox_Cod_Rol.Text;
                itemSeleccionado.Descripcion = textBox_Desc_Rol.Text;

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
                itemSeleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>();
                InputsExtensions.PedirConfirmacion("Desea guardar los cambios?");
                //Valores
                itemSeleccionado.Codigo = textBox_Cod_Rol.Text;
                itemSeleccionado.Descripcion = textBox_Desc_Rol.Text;

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
                itemSeleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones
                itemSeleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>();
                var itemhijo = comboBox_roles.SelectedItem as Permiso;
                InputsExtensions.OnlySelected(itemhijo, "un rol a asociar ");
                if (itemSeleccionado.ObtenerPermisos().Any(x=>x.Codigo== itemhijo.Codigo))
                {
                    InputsExtensions.PedirConfirmacion("Desea desasociar este rol?");
                    _bllPermiso.Desasignar(itemSeleccionado, itemhijo);
                }
                else
                {
                    InputsExtensions.PedirConfirmacion("Desea asociar este rol?");
                    _bllPermiso.Asignar(itemSeleccionado, itemhijo);
                }

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

        #endregion

    }
}
