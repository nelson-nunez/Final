using SiAP.BE;
using SiAP.BLL;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI
{
    public partial class Form_Turnos : Form
    {
        #region Campos

        private readonly BLL_Medico _bllMedicos;
        private readonly BLL_Agenda _bllAgenda;
        private readonly BLL_Turno _bllTurnos;
        private readonly BLL_Paciente _bllPaciente;
        private readonly UC_Buscar_Paciente _userControl;

        private Medico _medicoSeleccionado;
        private Paciente _pacienteSeleccionado;
        private DateTime _fechaSeleccionada;

        #endregion

        #region Constructor

        public Form_Turnos()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllTurnos = BLL_Turno.ObtenerInstancia();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();

            _userControl = this.FindUserControl<UC_Buscar_Paciente>("uC_Buscar_Paciente1");
            _userControl.Visible = false;
            _userControl.ShouldUpdate += OnPacienteSeleccionado;

            InicializarControles();
        }

        private void InicializarControles()
        {
            treeView1.ArmarArbolMedicos(_bllMedicos.ObtenerTodos().ToList());
            comboBox1.CargarMesesRelativos();
            _fechaSeleccionada = DateTime.Now;
            OcultarTodosBotones();
        }

        private void OcultarTodosBotones()
        {
            button_seleccionar_paciente.Visible = false;
            button_asignar_turno.Visible = false;
            button_eliminar_turno.Visible = false;
            button_cobrar.Visible = false;
        }

        #endregion

        #region Selección de Médico

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.ForeColor != Color.DarkGreen)
                {
                    treeView1.SelectedNode = null;
                    return;
                }

                _medicoSeleccionado = e.Node?.Tag as Medico;
                label_titular_agenda.Text = $"Agenda: {_medicoSeleccionado}";
                _pacienteSeleccionado = null;
                CargarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Carga de Agenda

        public void CargarAgenda()
        {
            try
            {
                if (_medicoSeleccionado == null || _medicoSeleccionado.Id == 0)
                {
                    dataGridView1.DataSource = null;
                    LimpiarFormulario();
                    return;
                }

                var agendas = _bllAgenda.BuscarPorMedicoyRango(_medicoSeleccionado, _fechaSeleccionada);
                var turnos = _bllTurnos.BuscarPorMedicoyRango(_medicoSeleccionado, _fechaSeleccionada);
                dataGridView1.CargarAgenda(agendas, turnos, _fechaSeleccionada);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Selección de Celda

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignorar clicks en headers
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                ActualizarVistaSegunSeleccion();
            }
            catch (Exception ex)
            {
                dataGridView1.ClearSelection();
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarVistaSegunSeleccion()
        {
            var celda = dataGridView1.ObtenerCeldaSeleccionada();

            if (celda == null)
            {
                LimpiarFormulario();
                return;
            }

            MostrarInformacionCelda(celda);
            ConfigurarBotones(celda);
        }

        #endregion

        #region Visualización

        private void MostrarInformacionCelda(AgendaExtensions.CeldaAgenda celda)
        {
            textBox_medico.Text = _medicoSeleccionado?.ToString();
            textBox_fecha.Text = celda.Agenda.Fecha.ToShortDateString();
            textBox_hora_inicio.Text = celda.Agenda.HoraInicio.ToString(@"hh\:mm");
            textBox_hora_fin.Text = celda.Agenda.HoraFin.ToString(@"hh\:mm");

            if (celda.TieneTurno)
            {
                var paciente = _bllPaciente.Leer(celda.Turno.PacienteId);
                textBox_paciente.Text = paciente?.ToString() ?? "Paciente no encontrado";
                textBox_estado.Text = celda.Turno.Estado.ToString();
            }
            else
            {
                textBox_paciente.Text = _pacienteSeleccionado?.ToString() ?? string.Empty;
                textBox_estado.Text = celda.TieneAgenda ? "Disponible" : "Sin agenda";
            }
        }

        private void ConfigurarBotones(AgendaExtensions.CeldaAgenda celda)
        {
            bool esDisponible = celda.TieneAgenda && !celda.TieneTurno;
            bool hayPaciente = _pacienteSeleccionado != null;

            button_seleccionar_paciente.Visible = esDisponible;
            button_asignar_turno.Visible = esDisponible && hayPaciente;
            button_eliminar_turno.Visible = celda.TieneTurno;
            button_cobrar.Visible = celda.TieneTurno &&
                (celda.Turno.Estado == EstadoTurno.Asignado ||
                 celda.Turno.Estado == EstadoTurno.Confirmado);
        }

        private void LimpiarFormulario()
        {
            OcultarTodosBotones();
            textBox_medico.Text = _medicoSeleccionado?.ToString();
            textBox_fecha.Clear();
            textBox_hora_inicio.Clear();
            textBox_hora_fin.Clear();
            textBox_paciente.Clear();
            textBox_estado.Clear();
        }

        #endregion

        #region Filtros de Fecha

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is DateTime fecha)
            {
                _fechaSeleccionada = fecha;
                CargarAgenda();
            }
        }

        private void button_sem_anterior_Click(object sender, EventArgs e)
        {
            _fechaSeleccionada = _fechaSeleccionada.AddDays(-7);
            CargarAgenda();
        }

        private void button_sem_actual_Click(object sender, EventArgs e)
        {
            _fechaSeleccionada = DateTime.Now;
            CargarAgenda();
        }

        private void button_sem_siguiente_Click(object sender, EventArgs e)
        {
            _fechaSeleccionada = _fechaSeleccionada.AddDays(7);
            CargarAgenda();
        }

        #endregion

        #region Gestión de Turnos

        private void button_seleccionar_paciente_Click(object sender, EventArgs e)
        {
            _userControl.Visible = true;
        }

        private void OnPacienteSeleccionado(object sender, EventArgs e)
        {
            _userControl.Visible = false;
            _pacienteSeleccionado = _userControl.itemSeleccionado;
            ActualizarVistaSegunSeleccion();
        }

        private void button_asignar_turno_Click(object sender, EventArgs e)
        {
            try
            {
                var celda = ValidarAsignacionTurno();
                InputsExtensions.PedirConfirmacion("¿Desea reservar el turno?");

                var turno = CrearTurno(celda);
                _bllTurnos.Agregar(turno);
                MessageBox.Show("Se creó el turno con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarYRecargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private AgendaExtensions.CeldaAgenda ValidarAsignacionTurno()
        {
            if (_medicoSeleccionado == null)
                throw new InvalidOperationException("Debe seleccionar un médico.");

            var celda = dataGridView1.ObtenerCeldaSeleccionada();

            if (celda == null || !celda.TieneAgenda)
                throw new InvalidOperationException("Debe seleccionar una agenda disponible.");

            if (celda.TieneTurno)
                throw new InvalidOperationException("Este horario ya tiene un turno asignado.");

            if (_pacienteSeleccionado == null)
                throw new InvalidOperationException("Debe seleccionar un paciente.");

            return celda;
        }

        private Turno CrearTurno(AgendaExtensions.CeldaAgenda celda)
        {
            return new Turno
            {
                Fecha = celda.Agenda.Fecha,
                HoraInicio = celda.Agenda.HoraInicio,
                HoraFin = celda.Agenda.HoraFin,
                AgendaId = celda.Agenda.Id,
                MedicoId = _medicoSeleccionado.Id,
                PacienteId = _pacienteSeleccionado.Id,
                TipoAtencion = _medicoSeleccionado.Especialidad.Nombre,
                Estado = EstadoTurno.Asignado
            };
        }

        private void button_eliminar_turno_Click(object sender, EventArgs e)
        {
            try
            {
                var celda = dataGridView1.ObtenerCeldaSeleccionada();

                if (celda == null || !celda.TieneTurno)
                    throw new InvalidOperationException("Debe seleccionar un turno para eliminar.");

                InputsExtensions.PedirConfirmacion("¿Desea eliminar el turno?");
                _bllTurnos.Eliminar(celda.Turno);
                MessageBox.Show("Se eliminó el turno con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cobrar_Click(object sender, EventArgs e)
        {
            try
            {
                var celda = dataGridView1.ObtenerCeldaSeleccionada();

                if (celda == null || !celda.TieneTurno)
                    throw new InvalidOperationException("Debe seleccionar un turno para cobrar.");

                // TODO: Implementar lógica de cobro
                MessageBox.Show("Funcionalidad de cobro pendiente de implementación");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos Auxiliares

        private void LimpiarYRecargar()
        {
            _pacienteSeleccionado = null;
            _userControl.itemSeleccionado = null;
            CargarAgenda();
        }

        #endregion
    }
}