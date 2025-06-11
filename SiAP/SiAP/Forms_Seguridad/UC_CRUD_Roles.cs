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

namespace SiAP.UI.Forms_Seguridad
{
    public partial class UC_CRUD_Roles : UserControl
    {
        BLL_Permiso _bllPermiso;


        public UC_CRUD_Roles()
        {
            InitializeComponent();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            ArmarArbol(_bllPermiso.ObtenerTodos().ToList());
        }

        private void uC_Guardar_h1_Load(object sender, EventArgs e)
        {

        }

        private void treeView_Roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var item = e.Node;
            var permiso = item?.Tag as Permiso;
            CargarDatos(permiso);
        }

        private void CargarDatos(Permiso item)
        {
            textBox_Cod_Rol.Text = item.Codigo;
            textBox_Desc_Rol.Text = item.Descripcion;
        }

        private void ArmarArbol(List<Permiso> permisos )
        {
            treeView_Roles.Nodes.Clear();
            foreach (var permiso in permisos)
            {
                TreeNode nodo = treeView_Roles.Nodes.Add(permiso.Codigo, $"{permiso.Codigo}-{permiso.Descripcion}");
                nodo.Tag = permiso;
                foreach (var pHijo in permiso.ObtenerPermisos())
                {
                    TreeNode nodoHijo = nodo.Nodes.Add(pHijo.Codigo, $"{pHijo.Codigo}-{pHijo.Descripcion} {(pHijo.Otorgado ? "✅" : "❎")}");
                    nodoHijo.ForeColor = pHijo.Otorgado ? Color.Green : Color.Red;
                    nodoHijo.Tag = pHijo;
                }
            }
        }

    }
}
