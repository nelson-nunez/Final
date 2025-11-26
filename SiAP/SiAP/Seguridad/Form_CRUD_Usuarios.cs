using SiAP.BE;
using SiAP.BE.Seguridad;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class Form_CRUD_Usuarios : Form
    {
        #region Vars

        BLL_Usuario _bllUsuario;
        BLL_Medico _bllMedico;
        BLL_Paciente _bllPaciente;
        BLL_Secretario _bllSecretario;
        Persona personaSeleccionada;
        Usuario usuarioSeleccionado;
        private List<string> camposmedicos = new List<string> { "Apellido", "Nombre", "Dni", "Email", "Especialidad" };
        private List<string> campossecretarios = new List<string> { "Apellido", "Nombre", "Dni", "Email", "Legajo" };

        #endregion

        #region Constructor

        public Form_CRUD_Usuarios()
        {
            InitializeComponent();
            _bllUsuario = BLL_Usuario.ObtenerInstancia();
            _bllMedico = BLL_Medico.ObtenerInstancia();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();
            _bllSecretario = BLL_Secretario.ObtenerInstancia();

            //Configurar Grids
            this.Controls.ConfigurarTodosLosGrids();
            //Combo
            comboBox_ocupacion.DataSource = TiposPersonas.ObtenerTodos();
            comboBox_ocupacion.DisplayMember = "Nombre";
        }

        #endregion

        private void ShouldUpdate(object? sender, EventArgs e)
        {
            CargarDatos();
        }

        #region Personal

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = textBox_nombre_personal.Text.Trim();
                string emailBusqueda = textBox_email_personal.Text.Trim();

                //Verificaciones
                var item = comboBox_ocupacion.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "una ocupación");
                if (string.IsNullOrWhiteSpace(textoBusqueda) && string.IsNullOrWhiteSpace(emailBusqueda))
                    throw new Exception("Ingrese un Nombre, Apellido o Email para realizar una búsqueda");

                if (item.Nombre == "Medico")
                {
                    var medicos = _bllMedico.Filtrar(textoBusqueda, emailBusqueda).ToList();
                    dataGridView1.CargarGrid(camposmedicos, medicos);
                }
                else if (item.Nombre == "Secretario")
                {
                    var secretarios = _bllSecretario.Filtrar(textoBusqueda, textoBusqueda, emailBusqueda).ToList();
                    dataGridView1.CargarGrid(campossecretarios, secretarios);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Verificaciones
                var item = comboBox_ocupacion.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "una ocupación");

                personaSeleccionada = null;

                if (item.Nombre == "Medico")
                {
                    var result = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                    personaSeleccionada = result.Persona;
                }
                else if (item.Nombre == "Secretario")
                {
                    var result = dataGridView1.VerificarYRetornarSeleccion<Secretario>();
                    personaSeleccionada = result.Persona;
                }
                usuarioSeleccionado = _bllUsuario.BuscarPorIdPersona(personaSeleccionada.Id) ;
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        #endregion

        #region Buttons

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarSeleccion();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }
        
        private void LimpiarSeleccion()
        {
            personaSeleccionada = null;
            usuarioSeleccionado = null;
            textBox_ocupacion.Text = "";
            textBox_username.Text = "";
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_email.Text = "";
            textBox_password.Text = "";
            textBox_palabra_clave.Text = "";
            checkBox1.Checked = false;
            dataGridView1.ClearSelection();
        }
        
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaSeleccionada == null)
                    throw new Exception("Seleccione un personal antes de crear un usuario.");
                if (usuarioSeleccionado != null)
                    throw new Exception("El usuario ya existe. Edite el existente o seleccione otro personal.");

                VerificarDatos();
                usuarioSeleccionado = new Usuario();
                usuarioSeleccionado.Activo = true;
                usuarioSeleccionado.PalabraClave = textBox_palabra_clave.Text;
                usuarioSeleccionado.Bloqueado = false;
                usuarioSeleccionado.PersonaId = personaSeleccionada.Id;
                usuarioSeleccionado.Username = textBox_username.Text;
                usuarioSeleccionado.Password = textBox_password.Text;

                InputsExtensions.PedirConfirmacion($"Desea crear el usuario '{usuarioSeleccionado.Username}'?");
                _bllUsuario.Agregar(usuarioSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
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

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaSeleccionada == null)
                    throw new Exception("Seleccione un personal antes de editar un usuario.");
                if (usuarioSeleccionado == null)
                    throw new Exception("El personal seleccionado no cuenta con usuario creado para editar.");

                VerificarDatos();
                usuarioSeleccionado.Username = textBox_username.Text;
                usuarioSeleccionado.Password = textBox_password.Text;
                usuarioSeleccionado.Activo = checkBox1.Checked;
                usuarioSeleccionado.PalabraClave = textBox_palabra_clave.Text;

                InputsExtensions.PedirConfirmacion($"Desea editar el usuario '{usuarioSeleccionado.Username}'?");
                _bllUsuario.Modificar(usuarioSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
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
        
        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaSeleccionada == null)
                    throw new Exception("Seleccione un personal antes de eliminar un usuario.");
                if (usuarioSeleccionado == null)
                    throw new Exception("El personal seleccionado no cuenta con usuario creado para eliminar.");

                VerificarDatos();
                InputsExtensions.PedirConfirmacion($"Desea eliminar el usuario '{usuarioSeleccionado.Username}'?");
                _bllUsuario.Eliminar(usuarioSeleccionado);

                MessageBox.Show("Se eliminó el usuario con éxito");
                LimpiarSeleccion();
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

        private void button_Blanqueo_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaSeleccionada == null)
                    throw new Exception("Seleccione un personal antes de blanquear una contraseña de usuario.");
                if (usuarioSeleccionado == null)
                    throw new Exception("El personal seleccionado no cuenta con usuario creado.");

                VerificarDatos();
                textBox_password.Text = "Cambiar_" + textBox_username.Text;
                usuarioSeleccionado.Password = "Cambiar_" + textBox_username.Text;
                InputsExtensions.PedirConfirmacion($"Desea restablecer la contraseña del usuario '{usuarioSeleccionado.Username}'?");
                _bllUsuario.Blanqueo(usuarioSeleccionado);

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
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

        private void CargarDatos()
        {
            //Verificaciones
            if (personaSeleccionada == null)
            {
                LimpiarSeleccion();
                return;
            }
            var item = comboBox_ocupacion.SelectedItem as Menu;
            InputsExtensions.OnlySelected(item, "una ocupación");

            if (personaSeleccionada != null)
            {
                textBox_ocupacion.Text = item.Nombre;
                textBox_nombre.Text = personaSeleccionada.Nombre;
                textBox_apellido.Text = personaSeleccionada.Apellido;
                textBox_email.Text = personaSeleccionada.Email;
            }
            if (usuarioSeleccionado == null)
            {
                groupBox3.Text = "Nuevo Usuario";
                textBox_username.Text = ((personaSeleccionada.Nombre[0] + personaSeleccionada.Apellido).RemoveDiacritics());
                textBox_password.Text = "Cambiar_" + textBox_username.Text;
                textBox_palabra_clave.Text = "";
                checkBox1.Checked = true;

                button_Borrar.Visible = false;
                button_Limpiar.Visible = true;
                button_Editar.Visible = false;
                button_Blanqueo.Visible = false;
            }
            else
            {
                groupBox3.Text = "Usuario existente";
                textBox_username.Text = usuarioSeleccionado.Username;
                textBox_password.Text = usuarioSeleccionado.Password;
                textBox_palabra_clave.Text = usuarioSeleccionado.PalabraClave;
                checkBox1.Checked = usuarioSeleccionado.Activo;
                button_Borrar.Visible = true;
                button_Limpiar.Visible = true;
                button_Editar.Visible = true;
                button_Blanqueo.Visible = true;
            }
        }

        private void VerificarDatos()
        {
            textBox_ocupacion.Text.ValidarSoloTexto("Ocupación");
            textBox_username.Text.ValidarSoloTexto("Username");
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_email.Text.ValidarEmail("Email");
            textBox_palabra_clave.Text.Validar("Palabra clave");
            checkBox1.Checked.Validar("Activo");
        }
    }
}