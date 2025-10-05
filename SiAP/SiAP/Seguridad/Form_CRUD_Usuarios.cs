using System.Data;
using SiAP.BE;
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
        private List<string> campos = new List<string> { };
        private object itemSeleccionado;

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

                switch (item.Nombre)
                {
                    case "Medico":
                        var medicos = _bllMedico.ObtenerTodos()
                            .Where(m =>
                                (!string.IsNullOrWhiteSpace(textoBusqueda) &&
                                 (m.Persona.Nombre.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                                  m.Persona.Apellido.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))) ||
                                (!string.IsNullOrWhiteSpace(emailBusqueda) &&
                                 m.Persona.Email.Contains(emailBusqueda, StringComparison.OrdinalIgnoreCase)))
                            .ToList();

                        // Proyectar a un tipo anónimo o DTO para mostrar en el grid
                        var medicosDtos = medicos.Select(m => new
                        {
                            m.Id,
                            Apellido = m.Persona.Apellido,
                            Nombre = m.Persona.Nombre,
                            Dni = m.Persona.Dni,
                            Email = m.Persona.Email,
                            Especialidad = m.Especialidad?.Nombre ?? "Sin especialidad",
                            EntidadOriginal = m
                        }).ToList();

                        campos = new List<string> { "Apellido", "Nombre", "Dni", "Email", "Especialidad" };
                        dataGridView1.CargarGrid(campos, medicosDtos);
                        break;

                    case "Secretario":
                        var secretarios = _bllSecretario.ObtenerTodos()
                            .Where(s =>
                                (!string.IsNullOrWhiteSpace(textoBusqueda) &&
                                 (s.Persona.Nombre.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                                  s.Persona.Apellido.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))) ||
                                (!string.IsNullOrWhiteSpace(emailBusqueda) &&
                                 s.Persona.Email.Contains(emailBusqueda, StringComparison.OrdinalIgnoreCase)))
                            .ToList();

                        // Proyectar a un tipo anónimo o DTO para mostrar en el grid
                        var secretariosDtos = secretarios.Select(s => new
                        {
                            s.Id,
                            Apellido = s.Persona.Apellido,
                            Nombre = s.Persona.Nombre,
                            Dni = s.Persona.Dni,
                            Email = s.Persona.Email,
                            s.Legajo,
                            EntidadOriginal = s
                        }).ToList();

                        campos = new List<string> { "Apellido", "Nombre", "Dni", "Email", "Legajo" };
                        dataGridView1.CargarGrid(campos, secretariosDtos);
                        break;

                    default:
                        throw new Exception("Ocupación no válida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        #endregion

        #region Buttons

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un usuario antes de continuar");

                var item = comboBox_ocupacion.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "una ocupación");

                string mensaje = "";
                switch (item.Nombre)
                {
                    case "Medico":
                        var medico = itemSeleccionado as Medico;
                        mensaje = $"Desea eliminar el médico '{medico.Persona.NombreCompleto}'?";
                        InputsExtensions.PedirConfirmacion(mensaje);
                        _bllMedico.Eliminar(medico);
                        break;
                    case "Secretario":
                        var secretario = itemSeleccionado as Secretario;
                        mensaje = $"Desea eliminar el secretario '{secretario.Persona.NombreCompleto}'?";
                        InputsExtensions.PedirConfirmacion(mensaje);
                        _bllSecretario.Eliminar(secretario);
                        break;
                }

                MessageBox.Show("Se eliminó el registro con éxito");
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

        private void button_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un usuario antes de continuar");

                VerificarDatos();

                var item = comboBox_ocupacion.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "una ocupación");

                switch (item.Nombre)
                {
                    case "Medico":
                        var medico = itemSeleccionado as Medico;
                        InputsExtensions.PedirConfirmacion($"Desea modificar el médico '{medico.Persona.NombreCompleto}'?");

                        medico.Persona.Email = textBox_email.Text;
                        // Actualizar otros campos según tu formulario

                        _bllMedico.Modificar(medico);
                        break;

                    case "Secretario":
                        var secretario = itemSeleccionado as Secretario;
                        InputsExtensions.PedirConfirmacion($"Desea modificar el secretario '{secretario.Persona.NombreCompleto}'?");

                        secretario.Persona.Email = textBox_email.Text;
                        // Actualizar otros campos según tu formulario

                        _bllSecretario.Modificar(secretario);
                        break;
                }

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

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado != null)
                    throw new Exception("Limpie la selección antes de continuar");

                VerificarDatos();

                var item = comboBox_ocupacion.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "una ocupación");

                switch (item.Nombre)
                {
                    case "Medico":
                        var medico = new Medico
                        {
                            Persona = new Persona
                            {
                                // Asignar valores del formulario
                                Email = textBox_email.Text,
                                // ... otros campos
                            }
                        };
                        InputsExtensions.PedirConfirmacion($"Desea guardar el médico '{medico.Persona.NombreCompleto}'?");
                        _bllMedico.Agregar(medico);
                        break;

                    case "Secretario":
                        var secretario = new Secretario
                        {
                            Persona = new Persona
                            {
                                // Asignar valores del formulario
                                Email = textBox_email.Text,
                                // ... otros campos
                            }
                        };
                        InputsExtensions.PedirConfirmacion($"Desea guardar el secretario '{secretario.Persona.NombreCompleto}'?");
                        _bllSecretario.Agregar(secretario);
                        break;
                }

                MessageBox.Show("Se guardaron los cambios con éxito");
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_Blanqueo_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null)
                    throw new Exception("Seleccione un usuario antes de continuar");

                var item = comboBox_ocupacion.SelectedItem as Menu;
                InputsExtensions.OnlySelected(item, "una ocupación");

                Persona persona = null;
                string mensaje = "";

                switch (item.Nombre)
                {
                    case "Medico":
                        var medico = itemSeleccionado as Medico;
                        persona = medico.Persona;
                        mensaje = $"Desea blanquear la contraseña del médico: '{persona.NombreCompleto}'?";
                        break;
                    case "Secretario":
                        var secretario = itemSeleccionado as Secretario;
                        persona = secretario.Persona;
                        mensaje = $"Desea blanquear la contraseña del secretario: '{persona.NombreCompleto}'?";
                        break;
                }

                if (persona?.Usuario != null)
                {
                    VerificarDatos();
                    InputsExtensions.PedirConfirmacion(mensaje);
                    persona.Usuario.Password = "Cambiar_" + textBox_email.Text;
                    _bllUsuario.Blanqueo(persona.Usuario);
                    MessageBox.Show("Se blanqueó la contraseña con éxito");
                    LimpiarSeleccion();
                }
                else
                {
                    throw new Exception("El usuario seleccionado no tiene una cuenta de usuario asociada");
                }
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

        private void CargarDatos()
        {
            if (itemSeleccionado == null) return;

            var item = comboBox_ocupacion.SelectedItem as Menu;
            if (item == null) return;

            Persona persona = null;

            switch (item.Nombre)
            {
                case "Medico":
                    var medico = itemSeleccionado as Medico;
                    persona = medico?.Persona;
                    break;
                case "Secretario":
                    var secretario = itemSeleccionado as Secretario;
                    persona = secretario?.Persona;
                    break;
            }

            if (persona != null)
            {
                textBox_username.Text = persona.Usuario?.Username ?? "";
                textBox_nombre.Text = persona.Nombre;
                textBox_apellido.Text = persona.Apellido;
                textBox_password.Text = persona.Usuario?.Password ?? "";
                textBox_email.Text = persona.Email;
                checkBox1.Checked = persona.Usuario?.Activo ?? false;
            }
        }

        private void VerificarDatos()
        {
            textBox_username.Text.ValidarSoloTexto("Username");
            textBox_nombre.Text.ValidarSoloTexto("Nombre");
            textBox_apellido.Text.ValidarSoloTexto("Apellido");
            textBox_email.Text.ValidarEmail("Email");
            checkBox1.Checked.Validar("Activo");
        }

        private void LimpiarSeleccion()
        {
            itemSeleccionado = null;
            textBox_username.Text = "";
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_password.Text = "";
            textBox_email.Text = "";
            checkBox1.Checked = false;
            dataGridView1.ClearSelection();
        }

        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var row = dataGridView1.Rows[e.RowIndex];
                var cellValue = row.Cells["EntidadOriginal"].Value;

                if (cellValue != null)
                {
                    itemSeleccionado = cellValue;
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }
    }
}