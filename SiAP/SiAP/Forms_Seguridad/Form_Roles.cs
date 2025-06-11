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
        //BLL_Rol _bllRol;
        BLL_Permiso _bllPermiso;
        //Rol itemSeleccionado = new Rol();

        public Form_Roles()
        {
            InitializeComponent();
            //_bllRol = BLL_Rol.ObtenerInstancia();
            _bllPermiso = BLL_Permiso.ObtenerInstancia();
        }

        #region Buttons Actions
        private void uC_Guardar_h1_Load(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
