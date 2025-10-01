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
using SiAP.UI.Controles;
using SiAP.UI.Extensiones;
using SiAP.UI.Forms_Seguridad;

namespace SiAP.UI
{
    public partial class Form_Turnos : Form
    {
        BLL_Medico _bllMedicos;
        BLL_Agenda _bllAgenda;
        BLL_Turno _bllTurnos;
        BLL_Paciente _bllPaciente;
        UC_Buscar_Paciente userControl;

        Medico medicoSeleccionado;
        AgendaExtensions.CeldaAgenda celdaSeleccionada;
        Paciente pacienteSeleccionado;
        DateTime fechaseleccionada;

        public Form_Turnos()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllTurnos = BLL_Turno.ObtenerInstancia();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();

            // Asocio controles a sus instancias
            userControl = this.FindUserControl<UC_Buscar_Paciente>("uC_Buscar_Paciente1");
            userControl.Visible = false;
            userControl.ShouldUpdate += ShouldUpdate;

            // Cargo trees
            treeView1.ArmarArbolMedicos(_bllMedicos.ObtenerTodos().ToList());

            // Cargo Combo
            comboBox1.CargarMesesRelativos();
            fechaseleccionada = DateTime.Now;

            // Inicializo botones
            button_eliminar_turno.Visible = false;
            button_asignar_turno.Visible = false;
            button_cobrar.Visible = false;
            button_seleccionar_paciente.Visible = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // Solo permitir selección de nodos raíz (color negro)
                if (e.Node.ForeColor != Color.DarkGreen)
                {
                    treeView1.SelectedNode = null;
                    return;
                }

                medicoSeleccionado = e.Node?.Tag as Medico;
                label_titular_agenda.Text = $"Agenda: {medicoSeleccionado.ToString()}";
                celdaSeleccionada = null;
                CargarAgenda();
                MostrarTurno();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        public void CargarAgenda()
        {
            try
            {
                if (medicoSeleccionado == null || medicoSeleccionado.Id == 0)
                {
                    dataGridView1.DataSource = null;
                    return;
                }

                celdaSeleccionada = null;
                pacienteSeleccionado = null;

                var agendas = _bllAgenda.BuscarPorMedicoyRango(medicoSeleccionado, fechaseleccionada);
                var turnos = _bllTurnos.BuscarPorMedicoyRango(medicoSeleccionado, fechaseleccionada);
                dataGridView1.CargarAgenda(agendas, turnos, fechaseleccionada);
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
                celdaSeleccionada = dataGridView1.ObtenerCeldaSeleccionada();
                MostrarTurno();
            }
            catch (Exception ex)
            {
                celdaSeleccionada = null;
                dataGridView1.ClearSelection();
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        public void MostrarTurno()
        {
            if (celdaSeleccionada == null)
            {
                LimpiarFormulario();
                return;
            }

            bool hayTurno = celdaSeleccionada.TieneTurno;
            bool hayAgenda = celdaSeleccionada.TieneAgenda;

            // Visibilidad de botones
            button_seleccionar_paciente.Visible = hayAgenda && !hayTurno;
            button_asignar_turno.Visible = hayAgenda && !hayTurno && pacienteSeleccionado != null;
            button_eliminar_turno.Visible = hayTurno;
            button_cobrar.Visible = hayTurno &&
                (celdaSeleccionada.Turno.Estado == EstadoTurno.Asignado ||
                 celdaSeleccionada.Turno.Estado == EstadoTurno.Confirmado);

            // Llenar textos
            textBox_medico.Text = medicoSeleccionado?.ToString();
            textBox_fecha.Text = celdaSeleccionada.Agenda.Fecha.ToShortDateString();
            textBox_hora_inicio.Text = celdaSeleccionada.Agenda.HoraInicio.ToString(@"hh\:mm");
            textBox_hora_fin.Text = celdaSeleccionada.Agenda.HoraFin.ToString(@"hh\:mm");

            if (hayTurno)
            {
                textBox_paciente.Text = _bllPaciente.Leer(celdaSeleccionada.Turno.PacienteId).ToString();
                textBox_estado.Text = celdaSeleccionada.Turno.Estado.ToString();
            }
            else
            {
                pacienteSeleccionado = userControl.itemSeleccionado;
                textBox_paciente.Text = pacienteSeleccionado?.ToString();
                textBox_estado.Text = hayAgenda ? "Disponible" : "Sin agenda";
            }
        }

        private void LimpiarFormulario()
        {
            button_seleccionar_paciente.Visible = false;
            button_asignar_turno.Visible = false;
            button_eliminar_turno.Visible = false;
            button_cobrar.Visible = false;

            textBox_medico.Text = medicoSeleccionado?.ToString();
            textBox_fecha.Clear();
            textBox_hora_inicio.Clear();
            textBox_hora_fin.Clear();
            textBox_paciente.Clear();
            textBox_estado.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is DateTime fechaSeleccionada)
            {
                this.fechaseleccionada = fechaSeleccionada;
                CargarAgenda();
            }
        }

        #region Buttons filtros

        private void button_sem_anterior_Click(object sender, EventArgs e)
        {
            fechaseleccionada = fechaseleccionada.AddDays(-7);
            CargarAgenda();
        }

        private void button_sem_actual_Click(object sender, EventArgs e)
        {
            fechaseleccionada = DateTime.Now;
            CargarAgenda();
        }

        private void button_sem_siguiente_Click(object sender, EventArgs e)
        {
            fechaseleccionada = fechaseleccionada.AddDays(7);
            CargarAgenda();
        }

        #endregion

        #region Reserva de turnos

        private void button_seleccionar_paciente_Click(object sender, EventArgs e)
        {
            userControl.Visible = true;
        }

        private void ShouldUpdate(object? sender, EventArgs e)
        {
            userControl.Visible = false;
            MostrarTurno();
        }

        private void button_asignar_turno_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifico
                if (medicoSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un médico para continuar.");

                if (celdaSeleccionada == null || !celdaSeleccionada.TieneAgenda)
                    throw new InvalidOperationException("Debe seleccionar una agenda disponible para continuar.");

                if (pacienteSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");

                if (celdaSeleccionada.TieneTurno)
                    throw new InvalidOperationException("Este horario ya tiene un turno asignado.");

                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea reservar el turno?");

                // Crear turno
                var nuevoTurno = new Turno
                {
                    Fecha = celdaSeleccionada.Agenda.Fecha,
                    HoraInicio = celdaSeleccionada.Agenda.HoraInicio,
                    HoraFin = celdaSeleccionada.Agenda.HoraFin,
                    AgendaId = celdaSeleccionada.Agenda.Id,
                    MedicoId = medicoSeleccionado.Id,
                    PacienteId = pacienteSeleccionado.Id,
                    Estado = EstadoTurno.Asignado
                };

                _bllTurnos.Agregar(nuevoTurno);
                MessageBox.Show("Se creó el turno con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar y limpiar
                pacienteSeleccionado = null;
                userControl.itemSeleccionado = null;
                CargarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_eliminar_turno_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifico
                if (celdaSeleccionada == null || !celdaSeleccionada.TieneTurno)
                    throw new InvalidOperationException("Debe seleccionar un turno para eliminar.");

                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea eliminar el turno?");

                // Eliminar
                _bllTurnos.Eliminar(celdaSeleccionada.Turno);
                MessageBox.Show("Se eliminó el turno con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar
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
                if (celdaSeleccionada == null || !celdaSeleccionada.TieneTurno)
                    throw new InvalidOperationException("Debe seleccionar un turno para cobrar.");

                // Lógica de cobro aquí
                MessageBox.Show("Funcionalidad de cobro pendiente de implementación");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
