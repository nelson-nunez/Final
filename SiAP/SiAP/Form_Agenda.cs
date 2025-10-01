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
using static SiAP.UI.Extensiones.AgendaExtensions;

namespace SiAP.UI
{
    public partial class Form_Agenda : Form
    {
        BLL_Medico _bllMedicos;
        BLL_Agenda _bllAgenda;
        BLL_Turno _bllTurnos;

        Medico medicoSeleccionado;
        List<CeldaAgenda> listaCeldasSeleccionadas;
        DateTime fechaseleccionada;

        public Form_Agenda()
        {
            InitializeComponent();

            _bllMedicos = BLL_Medico.ObtenerInstancia();
            _bllAgenda = BLL_Agenda.ObtenerInstancia();
            _bllTurnos = BLL_Turno.ObtenerInstancia();
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
       
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = null;
                    return;
                }
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
                listaCeldasSeleccionadas = dataGridView1.ObtenerCeldasSeleccionadas();
            }
            catch (Exception ex)
            {
                listaCeldasSeleccionadas = null;
                dataGridView1.ClearSelection();
                MessageBox.Show(ex.Message, "⛔ Error");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                listaCeldasSeleccionadas = null;
                listaCeldasSeleccionadas = dataGridView1.ObtenerCeldasSeleccionadas();
            }
            catch (Exception ex)
            {
                listaCeldasSeleccionadas = null;
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
            try
            {
                // Verifico
                if (medicoSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un médico para continuar.");
                //Verificaciones
                if (listaCeldasSeleccionadas.Where(x => x.TieneTurno).Any())
                    InputsExtensions.PedirConfirmacion("La agenda seleccionada cuenta con turnos otorgados. ¿Desea eliminarla igualmente?");
                else
                    InputsExtensions.PedirConfirmacion("¿Desea eliminar las agendas seleccionadas para el médico?");

                _bllAgenda.EliminarAgendas(listaCeldasSeleccionadas.Select(x => x.Agenda).ToList());
                MessageBox.Show("Se eliminaron las agendas con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar y limpiar
                CargarAgendaMedica();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            // Recargar y limpiar
            medicoSeleccionado = null;

            listaCeldasSeleccionadas = null;
            dataGridView1.ClearSelection();

            CargarAgendaMedica();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifico
                if (medicoSeleccionado == null)
                    throw new InvalidOperationException("Debe seleccionar un médico para continuar.");
                //Verificaciones
                if (listaCeldasSeleccionadas.Where(x => x.TieneAgenda).Any())
                    throw new Exception("La agenda ya se encuentra reservada");
                // Confirmación
                InputsExtensions.PedirConfirmacion("¿Desea registrar las agendas seleccionadas para el médico?");

                var lista = listaCeldasSeleccionadas.Select(x => x.Agenda).ToList();
                lista.ForEach(x => x.MedicoId = medicoSeleccionado.Id);
                _bllAgenda.AgregarAgendas(lista);
                MessageBox.Show("Se reservaron las agendas con éxito", "✔ Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar y limpiar
                CargarAgendaMedica();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "⛔ Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
