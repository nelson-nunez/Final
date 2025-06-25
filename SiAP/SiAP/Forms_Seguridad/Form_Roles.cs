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
using SiAP.UI.Controles;
using SiAP.UI.Extensiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class Form_Roles : Form
    {
        BLL_Permiso _bllPermiso;
        BLL_Usuario _bllUsuario;
        UC_BuscarUsuario userControl;
        UC_CRUD_Roles uc_CRUD_Roles;
        UC_CRUD_Permisos uc_CRUD_Permisos;

        public Usuario usuario_Seleccionado = new Usuario();
        public Permiso rol_Seleccionado = new PermisoCompuesto("0", null);
        public Permiso permiso_Seleccionado = new PermisoSimple("0", null);

        #region Cargas
        public Form_Roles()
        {
            InitializeComponent();
            //_bllRol = BLL_Rol.ObtenerInstancia();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            _bllUsuario = BLL_Usuario.ObtenerInstancia();

            //asocio controles a sus instancias
            userControl = this.FindUserControl<UC_BuscarUsuario>("UC_BuscarUsuario1");
            uc_CRUD_Roles = this.FindUserControl<UC_CRUD_Roles>("uC_cruD_Roles1");
            uc_CRUD_Permisos = this.FindUserControl<UC_CRUD_Permisos>("uC_cruD_Permisos1");
            //Asociar eventos
            uc_CRUD_Permisos.ShouldUpdate += ShouldUpdate;
            uc_CRUD_Roles.ShouldUpdate += ShouldUpdate;
            CargarDatos();
        }

        //Actualizar controles Hijos
        private void ShouldUpdate(object? sender, EventArgs e)
        {
            //uc_CRUD_Roles.CargarMenus();
            CargarDatos();
        }

        #endregion

        #region Asignaciones

        private void CargarDatos()
        {
            //Cargando trees
            treeView_Users.ArmarArbolDeUsuariosConRoles(_bllUsuario.ObtenerTodos().ToList());
            treeView_Roles.ArmarArbolDeRoles(_bllPermiso.ObtenerTodos().ToList());
            treeView_Permisos.ArmarArbolPermisosSimples(_bllPermiso.ObtenerTodos().ToList());
        }

        private void treeView_Users_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ForeColor != Color.DarkBlue)
            {
                treeView_Users.SelectedNode = null;
                return;
            }
            usuario_Seleccionado = e.Node?.Tag as Usuario;
        }

        private void treeView_Roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ForeColor != Color.Black)
            {
                treeView_Roles.SelectedNode = null;
                return;
            }
            rol_Seleccionado = e.Node?.Tag as Permiso;
        }

        private void treeView_Permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            permiso_Seleccionado = e.Node?.Tag as Permiso;
        }

        #endregion

        #region Roles
     
        private void button_Asoc_Perm_Rol_Click(object sender, EventArgs e)
        {
            try
            {
                permiso_Seleccionado = treeView_Permisos.VerificarYRetornarSeleccion<Permiso>("permiso");
                rol_Seleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>("rol");
                InputsExtensions.PedirConfirmacion($"Desea asociar el permiso '{permiso_Seleccionado.Descripcion}' al rol '{rol_Seleccionado.Descripcion}'?");
                _bllPermiso.Asignar(rol_Seleccionado, permiso_Seleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        private void button_Quitar_Perm_Rol_Click(object sender, EventArgs e)
        {
            try
            {
                permiso_Seleccionado = treeView_Permisos.VerificarYRetornarSeleccion<Permiso>("permiso");
                rol_Seleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>("rol");
                InputsExtensions.PedirConfirmacion($"Desea quitar el permiso '{permiso_Seleccionado.Descripcion}' al rol '{rol_Seleccionado.Descripcion}'?");
                _bllPermiso.Desasignar(rol_Seleccionado, permiso_Seleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        #endregion

        #region Usuarios

        private void button_Asociar_Rol_User_Click(object sender, EventArgs e)
        {
            try
            {
                usuario_Seleccionado = treeView_Users.VerificarYRetornarSeleccion<Usuario>("usuario");
                rol_Seleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>("rol");
                InputsExtensions.PedirConfirmacion($"Desea asociar el rol '{rol_Seleccionado.Descripcion}' al usuario '{usuario_Seleccionado.Username}'?");
                _bllUsuario.AgregarPermiso(usuario_Seleccionado, rol_Seleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        private void button_Quitar_Rol_User_Click(object sender, EventArgs e)
        {
            try
            {
                usuario_Seleccionado = treeView_Users.VerificarYRetornarSeleccion<Usuario>("usuario");
                rol_Seleccionado = treeView_Roles.VerificarYRetornarSeleccion<Permiso>("rol");
                InputsExtensions.PedirConfirmacion($"Desea quitar el rol '{rol_Seleccionado.Descripcion}' al usuario '{usuario_Seleccionado.Username}'?");
                _bllUsuario.QuitarPermiso(usuario_Seleccionado, rol_Seleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        private void button_Asociar_Permiso_User_Click(object sender, EventArgs e)
        {
            try
            {
                usuario_Seleccionado = treeView_Users.VerificarYRetornarSeleccion<Usuario>("usuario");
                permiso_Seleccionado = treeView_Permisos.VerificarYRetornarSeleccion<Permiso>("permiso");
                InputsExtensions.PedirConfirmacion($"Desea asociar el permiso '{permiso_Seleccionado.Descripcion}' al usuario '{usuario_Seleccionado.Username}'?");
                _bllUsuario.AgregarPermiso(usuario_Seleccionado, permiso_Seleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        private void button_Quitar_Permiso_User_Click(object sender, EventArgs e)
        {
            try
            {
                usuario_Seleccionado = treeView_Users.VerificarYRetornarSeleccion<Usuario>("usuario");
                permiso_Seleccionado = treeView_Permisos.VerificarYRetornarSeleccion<Permiso>("permiso");
                InputsExtensions.PedirConfirmacion($"Desea quitar el permiso '{permiso_Seleccionado.Descripcion}' al usuario '{usuario_Seleccionado.Username}'?");
                _bllUsuario.QuitarPermiso(usuario_Seleccionado, permiso_Seleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
            finally
            {
                CargarDatos();
            }
        }

        #endregion

    }
}
