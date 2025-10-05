using SiAP.BE;
using SiAP.BLL;
using SiAP.UI.Extensiones;

namespace SiAP.UI
{
    public partial class Form_CRUD_Medicos : Form
    {
        #region Vars

        Medico itemSeleccionado = new Medico();
        BLL_Medico _bllMedico;
        private List<string> campos = new List<string> { "Titulo", "Especialidad", "ArancelConsulta", "NombreCompleto", "Email", "Telefono" };

        #endregion

        public Form_CRUD_Medicos()
        {
            InitializeComponent();
            _bllMedico = BLL_Medico.ObtenerInstancia();
            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
            comboBox_especialidad.DataSource = Especialidad.ObtenerTodas();
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
                InputsExtensions.PedirConfirmacion("Desea crear el Médico?");
                //Asignar
                AsignarDatos();
                _bllMedico.Agregar(itemSeleccionado);
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
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                VerificarDatos();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea guardar los cambios?");
                //Asignar
                AsignarDatos();
                _bllMedico.Modificar(itemSeleccionado);
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
                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea eliminar el registro?");
                _bllMedico.Eliminar(itemSeleccionado);
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
                itemSeleccionado = new Medico { Persona = new Persona() };
                dataGridView1.CargarGrid(campos, _bllMedico.ObtenerTodos().ToList());
            }
            itemSeleccionado.Persona ??= new Persona();
            // Usar las propiedades de conveniencia de Paciente
            textBox_nombre.Text = itemSeleccionado.Nombre;
            textBox_apellido.Text = itemSeleccionado.Apellido;
            textBox_DNI.Text = itemSeleccionado.Dni;
            dateTime_feccha_nac.Value = (itemSeleccionado.FechaNacimiento.Year > 1900) ? itemSeleccionado.FechaNacimiento : DateTime.Today;
            textBox_email.Text = itemSeleccionado.Email;
            textBox_telefono.Text = itemSeleccionado.Telefono;
            textBox_precio.Text = itemSeleccionado.ArancelConsulta.ToString();
            textBox_titulo.Text = itemSeleccionado.Titulo ?? "";
            comboBox_especialidad.SelectedItem = itemSeleccionado.Especialidad;
        }

        private void AsignarDatos()
        {
            // Asegurarse de que Persona no sea null
            if (itemSeleccionado.Persona == null)
                itemSeleccionado.Persona = new Persona();

            itemSeleccionado.Persona.Nombre = textBox_nombre.Text;
            itemSeleccionado.Persona.Apellido = textBox_apellido.Text;
            itemSeleccionado.Persona.Dni = textBox_DNI.Text;
            itemSeleccionado.Persona.FechaNacimiento = dateTime_feccha_nac.Value;
            itemSeleccionado.Persona.Email = textBox_email.Text;
            itemSeleccionado.Persona.Telefono = textBox_telefono.Text;
            itemSeleccionado.ArancelConsulta = Convert.ToDecimal(textBox_precio.Text);
            itemSeleccionado.Titulo = textBox_titulo.Text;
            itemSeleccionado.Especialidad = (Especialidad)comboBox_especialidad.SelectedItem;
        }

        private void VerificarDatos()
        {
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_DNI.Text.ValidarSoloNumeros("DNI");
            dateTime_feccha_nac.Value.ValidarMayorEdad("Fecha Nac.");
            textBox_email.Text.ValidarEmail("Email");
            textBox_telefono.Text.ValidarSoloNumeros("Teléfono");
            textBox_titulo.Text.ValidarSoloTexto("Título");
            textBox_precio.Text.ValidarSoloNumeros("Precio");
            var item = comboBox_especialidad.SelectedItem as Especialidad;
            InputsExtensions.OnlySelected(item, "especialidad ");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                itemSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error al seleccionar");
            }
        }

        #endregion

    }
}