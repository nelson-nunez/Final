using System.Data;
using SiAP.BE;
using SiAP.BE.Seguridad;
using SiAP.BLL;
using SiAP.BLL.Seguridad;
using SiAP.UI.Extensiones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SiAP.UI.Forms_Seguridad
{
    public partial class Form_CRUD_Usuarios : Form
    {
        #region Vars

        BLL_Usuario _bllUsuario;
        BLL_Medico _bllMedico;
        BLL_Paciente _bllPaciente;
        BLL_Secretario _bllSecretario;
        private object personalSeleccionado;
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
                    var medicos = _bllMedico.Filtrar(textoBusqueda, textoBusqueda, emailBusqueda).ToList();
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
                var item = comboBox_ocupacion.SelectedItem as Menu;
                if (item == null) return;
                
                if (item.Nombre == "Medico")
                    personalSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Medico>();
                else if (item.Nombre == "Secretario")
                    personalSeleccionado = dataGridView1.VerificarYRetornarSeleccion<Secretario>();
                CargarDatos();
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
            //try
            //{
            //    if (personalSeleccionado == null)
            //        throw new Exception("Seleccione un usuario antes de continuar");

            //    var item = comboBox_ocupacion.SelectedItem as Menu;
            //    InputsExtensions.OnlySelected(item, "una ocupación");

            //    string mensaje = "";
            //    switch (item.Nombre)
            //    {
            //        case "Medico":
            //            var medico = personalSeleccionado as Medico;
            //            mensaje = $"Desea eliminar el médico '{medico.Persona.NombreCompleto}'?";
            //            InputsExtensions.PedirConfirmacion(mensaje);
            //            _bllMedico.Eliminar(medico);
            //            break;
            //        case "Secretario":
            //            var secretario = personalSeleccionado as Secretario;
            //            mensaje = $"Desea eliminar el secretario '{secretario.Persona.NombreCompleto}'?";
            //            InputsExtensions.PedirConfirmacion(mensaje);
            //            _bllSecretario.Eliminar(secretario);
            //            break;
            //    }

            //    MessageBox.Show("Se eliminó el registro con éxito");
            //    LimpiarSeleccion();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "⛔ Error");
            //}
            //finally
            //{
            //    CargarDatos();
            //}
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LimpiarSeleccion();
            //    CargarDatos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "⛔ Error");
            //}
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            ////try
            //{
            //    if (personalSeleccionado == null)
            //        throw new Exception("Seleccione un usuario antes de continuar");

            //    VerificarDatos();

            //    var item = comboBox_ocupacion.SelectedItem as Menu;
            //    InputsExtensions.OnlySelected(item, "una ocupación");

            //    switch (item.Nombre)
            //    {
            //        case "Medico":
            //            var medico = personalSeleccionado as Medico;
            //            InputsExtensions.PedirConfirmacion($"Desea modificar el médico '{medico.Persona.NombreCompleto}'?");

            //            medico.Persona.Email = textBox_email.Text;
            //            // Actualizar otros campos según tu formulario

            //            _bllMedico.Modificar(medico);
            //            break;

            //        case "Secretario":
            //            var secretario = personalSeleccionado as Secretario;
            //            InputsExtensions.PedirConfirmacion($"Desea modificar el secretario '{secretario.Persona.NombreCompleto}'?");

            //            secretario.Persona.Email = textBox_email.Text;
            //            // Actualizar otros campos según tu formulario

            //            _bllSecretario.Modificar(secretario);
            //            break;
            //    }

            //    MessageBox.Show("Se guardaron los cambios con éxito");
            //    LimpiarSeleccion();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "⛔ Error");
            //}
            //finally
            //{
            //    CargarDatos();
            //}
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            ////try
            //{
            //    if (personalSeleccionado != null)
            //        throw new Exception("Limpie la selección antes de continuar");

            //    VerificarDatos();

            //    var item = comboBox_ocupacion.SelectedItem as Menu;
            //    InputsExtensions.OnlySelected(item, "una ocupación");

            //    switch (item.Nombre)
            //    {
            //        case "Medico":
            //            var medico = new Medico
            //            {
            //                Persona = new Persona
            //                {
            //                    // Asignar valores del formulario
            //                    Email = textBox_email.Text,
            //                    // ... otros campos
            //                }
            //            };
            //            InputsExtensions.PedirConfirmacion($"Desea guardar el médico '{medico.Persona.NombreCompleto}'?");
            //            _bllMedico.Agregar(medico);
            //            break;

            //        case "Secretario":
            //            var secretario = new Secretario
            //            {
            //                Persona = new Persona
            //                {
            //                    // Asignar valores del formulario
            //                    Email = textBox_email.Text,
            //                    // ... otros campos
            //                }
            //            };
            //            InputsExtensions.PedirConfirmacion($"Desea guardar el secretario '{secretario.Persona.NombreCompleto}'?");
            //            _bllSecretario.Agregar(secretario);
            //            break;
            //    }

            //    MessageBox.Show("Se guardaron los cambios con éxito");
            //    LimpiarSeleccion();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "⛔ Error");
            //}
        }

        private void button_Blanqueo_Click(object sender, EventArgs e)
        {
            ////try
            //{
            //    if (personalSeleccionado == null)
            //        throw new Exception("Seleccione un usuario antes de continuar");

            //    var item = comboBox_ocupacion.SelectedItem as Menu;
            //    InputsExtensions.OnlySelected(item, "una ocupación");

            //    Persona persona = null;
            //    string mensaje = "";

            //    switch (item.Nombre)
            //    {
            //        case "Medico":
            //            var medico = personalSeleccionado as Medico;
            //            persona = medico.Persona;
            //            mensaje = $"Desea blanquear la contraseña del médico: '{persona.NombreCompleto}'?";
            //            break;
            //        case "Secretario":
            //            var secretario = personalSeleccionado as Secretario;
            //            persona = secretario.Persona;
            //            mensaje = $"Desea blanquear la contraseña del secretario: '{persona.NombreCompleto}'?";
            //            break;
            //    }

            //    if (persona?.Usuario != null)
            //    {
            //        VerificarDatos();
            //        InputsExtensions.PedirConfirmacion(mensaje);
            //        persona.Usuario.Password = "Cambiar_" + textBox_email.Text;
            //        _bllUsuario.Blanqueo(persona.Usuario);
            //        MessageBox.Show("Se blanqueó la contraseña con éxito");
            //        LimpiarSeleccion();
            //    }
            //    else
            //    {
            //        throw new Exception("El usuario seleccionado no tiene una cuenta de usuario asociada");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "⛔ Error");
            //}
            //finally
            //{
            //    CargarDatos();
            //}
        }

        private void LimpiarSeleccion()
        {
            personalSeleccionado = null;
            textBox_username.Text = "";
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_password.Text = "";
            textBox_email.Text = "";
            checkBox1.Checked = false;
            dataGridView1.ClearSelection();
        }

        #endregion

        private void CargarDatos()
        {
            if (personalSeleccionado == null) 
                return;

            var item = comboBox_ocupacion.SelectedItem as Menu;
            if (item == null) return;
            Persona persona = null;
            Usuario usuario = null;

            if (item.Nombre == "Medico")
            {
                var tt = personalSeleccionado as Medico;
                persona = tt.Persona;
            }
            else if (item.Nombre == "Secretario")
            {
                var tt = personalSeleccionado as Secretario;
                persona = tt.Persona;
            }

            if (persona == null)
                return;


            usuario = persona.Usuario;
            textBox_ocupacion.Text= item.ToString();
            textBox_nombre.Text = persona.Nombre;
            textBox_apellido.Text = persona.Apellido;
            textBox_email.Text = persona.Email;

            if (usuario == null)
            {
                textBox_username.Text = ((persona.Nombre[0] + persona.Apellido).RemoveDiacritics());
                textBox_password.Text = "Cambiar_" + textBox_email.Text; 
                textBox_palabra_clave.Text = "";
                checkBox1.Checked = true;

                button_Borrar.Visible = false;
                button_Limpiar.Visible = false;
                button_Editar.Visible = false;
                button_Blanqueo.Visible = false;
            }
            else
            {
                textBox_username.Text = usuario.Username;
                textBox_password.Text = usuario.Password;
                textBox_password.Text = usuario.PalabraClave;
                checkBox1.Checked = usuario.Activo;

                button_Borrar.Visible = true;
                button_Limpiar.Visible = true;
                button_Editar.Visible = true;
                button_Blanqueo.Visible = true;
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
    }
}