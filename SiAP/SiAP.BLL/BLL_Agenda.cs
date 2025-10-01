using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Agenda : IBLL<Agenda>
    {
        private readonly MPP_Agenda _mppAgenda;
        private static BLL_Agenda _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Agenda()
        {
            _mppAgenda = MPP_Agenda.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Agenda ObtenerInstancia()
        {
            return _instancia ??= new BLL_Agenda();
        }

        public void Agregar(Agenda agenda)
        {
            if (!EsValido(agenda))
                throw new ArgumentException(MensajeError);
            if (_mppAgenda.Existe(agenda))
                throw new InvalidOperationException("La agenda ya existe.");
            _mppAgenda.Agregar(agenda);
            _logger.GenerarLog($"Agenda agregada: Médico ID {agenda.MedicoId}, Fecha {agenda.Fecha:dd/MM/yyyy}");
        }

        public void Modificar(Agenda agenda)
        {
            if (!EsValido(agenda))
                throw new ArgumentException(MensajeError);
            _mppAgenda.Modificar(agenda);
            _logger.GenerarLog($"Agenda modificada: Médico ID {agenda.MedicoId}, Fecha {agenda.Fecha:dd/MM/yyyy}");
        }

        public void Eliminar(Agenda agenda)
        {
            if (agenda.Fecha < DateTime.Now)
                throw new ArgumentException("No se puede eliminar una agenda cuya fecha es posterior al corriente día.");
            
            if (_mppAgenda.TieneDependencias(agenda))
                throw new InvalidOperationException("La agenda tiene dependencias y no puede eliminarse.");

            _mppAgenda.Eliminar(agenda);
            _logger.GenerarLog($"Agenda eliminada: Médico ID {agenda.MedicoId}, Fecha {agenda.Fecha:dd/MM/yyyy}");
        }

        public IList<Agenda> ObtenerTodos()
        {
            return _mppAgenda.ObtenerTodos();
        }

        public Agenda Leer(long agendaId)
        {
            return _mppAgenda.LeerPorId(agendaId);
        }

        public bool EsValido(Agenda agenda)
        {
            _mensajeError = "";

            if (agenda.Fecha == default(DateTime))
                _mensajeError += "La fecha es obligatoria. ";
            if (agenda.Fecha < DateTime.Today)
                _mensajeError += "La fecha no puede ser anterior a hoy. ";
            if (agenda.HoraInicio >= agenda.HoraFin)
                _mensajeError += "La hora de inicio debe ser anterior a la hora de fin. ";
            if (agenda.MedicoId <= 0)
                _mensajeError += "El ID del médico es obligatorio. ";

            return string.IsNullOrEmpty(_mensajeError);
        }

        public IList<Agenda> BuscarPorMedicoyRango(Medico medico, DateTime fecha)
        {
            // Calcular el inicio de semana (lunes)
            var diasDesdeLunes = (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;
            if (diasDesdeLunes < 0) diasDesdeLunes += 7;
            var desde = fecha.Date.AddDays(-diasDesdeLunes);
            var hasta = desde.AddDays(6);
            return _mppAgenda.BuscarPorMedicoyRango(medico.Id, desde, hasta);
        }

        public void AgregarAgendas(List<Agenda> agendas)
        {
            foreach (var agenda in agendas) 
            { 
                if (!EsValido(agenda))
                    throw new ArgumentException(MensajeError);
    
            }
            _mppAgenda.AgregarAgendas(agendas);
            foreach (var agenda in agendas)
                _logger.GenerarLog($"Agenda agregada: Médico ID {agenda.MedicoId}, Fecha {agenda.Fecha:dd/MM/yyyy}");       
        }

        public void EliminarAgendas(List<Agenda> agendas)
        {
            foreach (var agenda in agendas)
            {
                if (!EsValido(agenda))
                    throw new ArgumentException(MensajeError);
                if (agenda.Fecha < DateTime.Now)
                    throw new ArgumentException("No se puede eliminar una agenda cuya fecha es posterior al corriente día.");

            }
            _mppAgenda.EliminarAgendas(agendas);
            foreach (var agenda in agendas)
                _logger.GenerarLog($"Agenda eliminada: Médico ID {agenda.MedicoId}, Fecha {agenda.Fecha:dd/MM/yyyy}");
        }
    }
}
