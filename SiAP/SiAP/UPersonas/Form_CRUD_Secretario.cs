using SiAP.BE;
using SiAP.BLL;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_CRUD_Secretario : Form
    {
        #region Vars

        Secretario itemSeleccionado = new Secretario();
        BLL_Secretario _bllSecretario;
        private List<string> campos = new List<string> { "Dni", "NombreCompleto", "Telefono", "Email", "Legajo"};

        #endregion

        public Form_CRUD_Secretario()
        {
            InitializeComponent();
            _bllSecretario = BLL_Secretario.ObtenerInstancia();
            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
            CargarDatos(true);
        }

        #region Buttons

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico
                VerificarDatos();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea crear el Secretario?");
                //Asignar
                AsignarDatos();
                _bllSecretario.Agregar(itemSeleccionado);
                MessageBox.Show("Se creó el registro con éxito");
                //Si sale bien limpio
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico seleccion
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Secretario>();
                VerificarDatos();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea guardar los cambios?");
                //Asignar
                AsignarDatos();
                _bllSecretario.Modificar(itemSeleccionado);
                MessageBox.Show("Se guardaron los cambios con éxito");
                //Si sale bien limpio
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos(true);
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico seleccion
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Secretario>();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea eliminar el registro?");
                _bllSecretario.Eliminar(itemSeleccionado);
                MessageBox.Show("Se eliminó el registro con éxito");
                //Si sale bien limpio
                CargarDatos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        #endregion

        #region Carga de datos

        private void CargarDatos(bool limpiar = false)
        {

            if (limpiar)
            {
                itemSeleccionado = new Secretario { Persona = new Persona() };
                dataGridView1.CargarGrid(campos, _bllSecretario.ObtenerTodos().ToList());
            }
            itemSeleccionado.Persona ??= new Persona();
            // Usar las propiedades de conveniencia de Paciente
            textBox_nombre.Text = itemSeleccionado.Nombre;
            textBox_apellido.Text = itemSeleccionado.Apellido;
            textBox_DNI.Text = itemSeleccionado.Dni;
            dateTime_feccha_nac.Value = (itemSeleccionado.FechaNacimiento.Year > 1900) ? itemSeleccionado.FechaNacimiento : DateTime.Today;
            textBox_email.Text = itemSeleccionado.Email;
            textBox_telefono.Text = itemSeleccionado.Telefono;
            textBox_legajo.Text = itemSeleccionado.Legajo ?? "";
        }

        private void AsignarDatos()
        {
            if (itemSeleccionado.Persona == null)
                itemSeleccionado.Persona = new Persona();

            // Asignar datos 
            itemSeleccionado.Persona.Nombre = textBox_nombre.Text;
            itemSeleccionado.Persona.Apellido = textBox_apellido.Text;
            itemSeleccionado.Persona.Dni = textBox_DNI.Text;
            itemSeleccionado.Persona.FechaNacimiento = dateTime_feccha_nac.Value;
            itemSeleccionado.Persona.Email = textBox_email.Text;
            itemSeleccionado.Persona.Telefono = textBox_telefono.Text;

            itemSeleccionado.Legajo = textBox_legajo.Text;
        }

        private void VerificarDatos()
        {
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_DNI.Text.ValidarSoloNumeros("DNI");
            dateTime_feccha_nac.Value.ValidarMayorEdad("Fecha Nac.");
            textBox_email.Text.ValidarEmail("Email");
            textBox_telefono.Text.ValidarSoloNumeros("Teléfono");
            textBox_legajo.Text.Validar("Legajo");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Secretario>();
            CargarDatos();
        }

        #endregion
    }
}