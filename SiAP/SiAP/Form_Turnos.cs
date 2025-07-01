using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BE;
using SiAP.BE.Seguridad;
using SiAP.BLL;
using SiAP.BLL.Logs;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_Turnos : Form
    {
        BLL_Medico _bllMedicos;
        Medico itemSeleccionado;

        public Form_Turnos()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            //Cargando trees
            treeView1.ArmarArbolMedicos(_bllMedicos.ObtenerTodos().ToList());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Solo permitir selección de nodos raíz (color negro)
            if (e.Node.ForeColor != Color.DarkGreen)
            {
                treeView1.SelectedNode = null;
                return;
            }
            itemSeleccionado = e.Node?.Tag as Medico;
            label_titular_agenda.Text = $"Agenda: {itemSeleccionado.ToString()}";
        }

        ColumnReorderedEventArgs cree los mpps y blls de agenda y turno, continuar creando el datagrid para ver las agendas disponibles y luego los turnos que puedo elegir.
    }
}
