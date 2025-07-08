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
        Agenda agendaSeleccionado;
        Turno turnoSeleccionado;
        Paciente pacienteSeleccionado;
        DateTime fechaseleccionada;

        public Form_Turnos()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllTurnos = BLL_Turno.ObtenerInstancia();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();
            //asocio controles a sus instancias
            userControl = this.FindUserControl<UC_Buscar_Paciente>("uC_Buscar_Paciente1");
            userControl.Visible = false;
            userControl.ShouldUpdate += ShouldUpdate;
            //Cargo trees
            treeView1.ArmarArbolMedicos(_bllMedicos.ObtenerTodos().ToList());
            //Cargo Datagrid
            CargarAgenda();
            //Cargo Combo
            comboBox1.CargarMesesRelativos();
            fechaseleccionada = DateTime.Now;
            button_eliminar_turno.Visible = false;
            button_asignar_turno.Visible = false;
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
                turnoSeleccionado = null;
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

                agendaSeleccionado = null;
                turnoSeleccionado = null;
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
                agendaSeleccionado = dataGridView1.ObtenerAgendaSeleccionada();
                turnoSeleccionado = _bllTurnos.BuscarTurnoPorRango(medicoSeleccionado, agendaSeleccionado);
                MostrarTurno();
            }
            catch (Exception ex)
            {
                agendaSeleccionado = null;
                dataGridView1.ClearSelection();
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        public void MostrarTurno()
        {
            bool hayTurno = turnoSeleccionado != null;
            //Botones
            button_seleccionar_paciente.Visible = !hayTurno;
            button_eliminar_turno.Visible = hayTurno;
            button_asignar_turno.Visible = !hayTurno;
            button_cobrar.Visible = hayTurno &&
                (turnoSeleccionado.Estado == EstadoTurno.Asignado || turnoSeleccionado.Estado == EstadoTurno.Confirmado);

            //Textos
            if (hayTurno)
            {             
                textBox_medico.Text = medicoSeleccionado.ToString();
                textBox_fecha.Text = turnoSeleccionado.Fecha.ToShortDateString();
                textBox_hora_inicio.Text = turnoSeleccionado.HoraInicio.ToString();
                textBox_hora_fin.Text = turnoSeleccionado.HoraFin.ToString();
                textBox_paciente.Text = _bllPaciente.Leer(turnoSeleccionado.PacienteId).ToString();
                textBox_estado.Text = turnoSeleccionado.Estado.ToString();
            }
            else
            {
                textBox_medico.Text = medicoSeleccionado.ToString();
                textBox_fecha.Text = agendaSeleccionado?.Fecha.ToShortDateString();
                textBox_hora_inicio.Text = agendaSeleccionado?.HoraInicio.ToString();
                textBox_hora_fin.Text = agendaSeleccionado?.HoraFin.ToString();
                pacienteSeleccionado = userControl.itemSeleccionado;
                textBox_paciente.Text = pacienteSeleccionado?.ToString();
                textBox_estado.Text = turnoSeleccionado?.Estado.ToString();
            }
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
                //Verifico
                if (medicoSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un medico para continuar.");
                if (agendaSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar una agenda para continuar.");
                if (userControl.itemSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea reservar el turno?");
                //Crear
                turnoSeleccionado = new Turno();
                turnoSeleccionado.Fecha = agendaSeleccionado.Fecha;
                turnoSeleccionado.HoraInicio = agendaSeleccionado.HoraInicio;
                turnoSeleccionado.HoraFin = agendaSeleccionado.HoraFin;
                turnoSeleccionado.AgendaId = agendaSeleccionado.Id;
                turnoSeleccionado.MedicoId = medicoSeleccionado.Id;
                turnoSeleccionado.PacienteId = pacienteSeleccionado.Id;
                turnoSeleccionado.Estado = EstadoTurno.Asignado;
                _bllTurnos.Agregar(turnoSeleccionado);
                MessageBox.Show("Se creó el registro con éxito");
                //Si sale bien limpio Cargo Datagrid
                CargarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_eliminar_turno_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico
                if (turnoSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un turno para eliminar.");
                //Confirmacion
                InputsExtensions.PedirConfirmacion("Desea eliminar el turno?");
                //Eliminar
                _bllTurnos.Eliminar(turnoSeleccionado);
                MessageBox.Show("Se eliminó el registro con éxito");
                //Si sale bien limpio Cargo Datagrid
                CargarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void button_cobrar_Click(object sender, EventArgs e)
        {
            //button_cobrar
        }

        #endregion
    }
}
