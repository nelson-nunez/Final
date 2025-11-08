using SiAP.BE;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using System.ComponentModel;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class UC_Mostrar_Medico : UserControl
    {
        private Medico medicoLoggeado;
        private BLL_Medico _bllMedico;


        public UC_Mostrar_Medico()
        {
            InitializeComponent();

            // NO ejecutar código en modo diseño
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            try
            {
                _bllMedico = BLL_Medico.ObtenerInstancia();

                var useractual = GestionUsuario.UsuarioLogueado;

                if (useractual?.PersonaId != null)
                {
                    medicoLoggeado = _bllMedico.LeerPorPersonId((long)useractual.PersonaId);
                    CargarDatosMedico();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del médico: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatosMedico()
        {
            var useractual = GestionUsuario.UsuarioLogueado;
            medicoLoggeado = _bllMedico.LeerPorPersonId((long)useractual.PersonaId);


            if (medicoLoggeado == null) return;

            label_nombre_med.Text = medicoLoggeado?.ToString() ?? "";
            label_especialidad_med.Text = medicoLoggeado?.Especialidad?.ToString() ?? "";
            label_metricula_med.Text = medicoLoggeado?.Titulo ?? "";
        }
    }
}