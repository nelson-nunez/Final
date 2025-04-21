using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAP.BLL;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_Turnos : Form
    {
        BLLLog _logger;

        public Form_Turnos()
        {
            InitializeComponent();

            _logger = BLLLog.ObtenerInstancia();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            _logger.GenerarLog($"Backup del día {DateTime.Now:dd/MM/yyyy HH:mm:ss} generado.");

            dataGridView1.CargarGrid(new List<string> { "Fecha", "Usuario", "Operacion"}, _logger.ObtenerLogs());
        }
    }
}
