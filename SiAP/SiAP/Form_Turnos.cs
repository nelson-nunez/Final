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

                CargarAgenda();
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
            if (turnoSeleccionado != null)
            {
                label_estado.Visible = true;
                button_seleccionar_paciente.Visible = false;
                button_eliminar_turno.Visible = true;
                button_asignar_turno.Visible = false;

                label_medico.Text = medicoSeleccionado.ToString();
                label_fecha.Text = turnoSeleccionado.Fecha.ToShortDateString();
                label_h_inicio.Text = turnoSeleccionado.HoraInicio.ToString();
                label_h_fin.Text = turnoSeleccionado.HoraFin.ToString();
                label_Paciente.Text = _bllPaciente.Leer(turnoSeleccionado.PacienteId).ToString();
                label_estado.Text = turnoSeleccionado.Estado.ToString();
            }
            else
            {
                label_estado.Visible = false;
                button_seleccionar_paciente.Visible = true;
                button_eliminar_turno.Visible = false;
                button_asignar_turno.Visible = true;

                label_medico.Text = medicoSeleccionado.ToString();
                label_fecha.Text = agendaSeleccionado.Fecha.ToShortDateString();
                label_h_inicio.Text = agendaSeleccionado.HoraInicio.ToString();
                label_h_fin.Text = agendaSeleccionado.HoraFin.ToString();
                pacienteSeleccionado = userControl.itemSeleccionado;
                label_Paciente.Text = pacienteSeleccionado?.ToString();
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
            if (medicoSeleccionado == null)
                throw new InvalidOperationException("Debe seleccionar un medico para continuar.");
            if (agendaSeleccionado == null)
                throw new InvalidOperationException("Debe seleccionar una agenda para continuar.");           
            if (userControl.itemSeleccionado == null)
                throw new InvalidOperationException("Debe seleccionar un paciente para continuar.");

            AsyncCallback aca quede asignar turnos y eliminarlo slo demas paraece uqe ya esta completpo
        }

        private void button_eliminar_turno_Click(object sender, EventArgs e)
        {

        }
        
        #endregion
    }
}
