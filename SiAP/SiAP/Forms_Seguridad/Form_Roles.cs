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

namespace SiAP.UI.Forms_Seguridad
{
    public partial class Form_Roles : Form
    {
        BLL_Permiso _bllPermiso;
        UC_BuscarUsuario userControl;
        public Form_Roles()
        {
            InitializeComponent();
            //_bllRol = BLL_Rol.ObtenerInstancia();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
            userControl = this.FindUserControl<UC_BuscarUsuario>("UC_BuscarUsuario1");
        }

        #region Buttons Actions



        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            var tt = userControl.itemSeleccionado;

        }
    }
}
