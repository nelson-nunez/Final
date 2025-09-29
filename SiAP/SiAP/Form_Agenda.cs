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
    public partial class Form_Agenda : Form
    {
        BLL_Medico _bllMedicos;
        BLL_Agenda _bllAgenda;
        BLL_Turno _bllTurnos;
        BLL_Paciente _bllPaciente;
        UC_Buscar_Paciente userControl;

        Medico medicoSeleccionado;
        Agenda agendaSeleccionado;
        List<Agenda> listaAgendaSeleccionadas;
        DateTime fechaseleccionada;

        public Form_Agenda()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllTurnos = BLL_Turno.ObtenerInstancia();
            _bllPaciente = BLL_Paciente.ObtenerInstancia();
            //Cargo trees
            treeView1.ArmarArbolMedicos(_bllMedicos.ObtenerTodos().ToList());
            //Cargo Datagrid
            CargarAgendaMedica();
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
                CargarAgendaMedica();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is DateTime fechaSeleccionada)
            {
                this.fechaseleccionada = fechaSeleccionada;
                CargarAgendaMedica();
            }
        }

        #region AGENDA

        public void CargarAgendaMedica()
        {
            try
            {
                if (medicoSeleccionado == null || medicoSeleccionado.Id == 0)
                {
                    dataGridView1.DataSource = null;
                    return;
                }

                agendaSeleccionado = null;
                var agendas = _bllAgenda.BuscarPorMedicoyRango(medicoSeleccionado, fechaseleccionada);
                var turnos = _bllTurnos.BuscarPorMedicoyRango(medicoSeleccionado, fechaseleccionada);
                dataGridView1.CargarAgendaMedica(agendas, turnos, fechaseleccionada);
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
            }
            catch (Exception ex)
            {
                agendaSeleccionado = null;
                dataGridView1.ClearSelection();
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var grid = sender as DataGridView;
                var celdasSeleccionadas = grid.SelectedCells;
                Console.WriteLine($"Celdas seleccionadas: {celdasSeleccionadas.Count}");
                foreach (DataGridViewCell celda in celdasSeleccionadas)
                {
                    agendaSeleccionado = dataGridView1.ObtenerAgendaSeleccionada();
                    listaAgendaSeleccionadas.Add(agendaSeleccionado);
                }
            }
            catch (Exception ex)
            {
                agendaSeleccionado = null;
                dataGridView1.ClearSelection();
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        #endregion


        #region Buttons filtros

        private void button_sem_anterior_Click(object sender, EventArgs e)
        {
            fechaseleccionada = fechaseleccionada.AddDays(-7);
            CargarAgendaMedica();
        }

        private void button_sem_actual_Click(object sender, EventArgs e)
        {
            fechaseleccionada = DateTime.Now;
            CargarAgendaMedica();
        }

        private void button_sem_siguiente_Click(object sender, EventArgs e)
        {
            fechaseleccionada = fechaseleccionada.AddDays(7);
            CargarAgendaMedica();
        }

        #endregion

        #region BUTTONS AGENDA

        private void button_Borrar_Click(object sender, EventArgs e)
        {

        }
        private void button_Limpiar_Click(object sender, EventArgs e)
        {

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
