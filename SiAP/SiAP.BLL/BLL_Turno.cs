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
    public class BLL_Turno : IBLL<Turno>
    {
        private readonly MPP_Turno _mppTurno;
        private static BLL_Turno _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Turno()
        {
            _mppTurno = MPP_Turno.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Turno ObtenerInstancia()
        {
            return _instancia ??= new BLL_Turno();
        }

        public void Agregar(Turno turno)
        {
            if (!EsValido(turno))
                throw new ArgumentException(MensajeError);
            if (_mppTurno.Existe(turno))
                throw new InvalidOperationException("El turno ya existe.");
            _mppTurno.Agregar(turno);
            _logger.GenerarLog($"Turno agregado: Médico ID {turno.MedicoId}, Paciente ID {turno.PacienteId}, Fecha {turno.Fecha:dd/MM/yyyy}");
        }

        public void Modificar(Turno turno)
        {
            if (!EsValido(turno))
                throw new ArgumentException(MensajeError);
            _mppTurno.Modificar(turno);
            _logger.GenerarLog($"Turno modificado: ID {turno.Id}, Estado {turno.Estado}");
        }

        public void Eliminar(Turno turno)
        {
            if (_mppTurno.TieneDependencias(turno))
                throw new InvalidOperationException("El turno tiene dependencias y no puede eliminarse.");
            _mppTurno.Eliminar(turno);
            _logger.GenerarLog($"Turno eliminado: ID {turno.Id}");
        }

        public IList<Turno> ObtenerTodos()
        {
            return _mppTurno.ObtenerTodos();
        }

        public Turno Leer(Turno turno)
        {
            return _mppTurno.LeerPorId(turno.Id);
        }

        public bool EsValido(Turno turno)
        {
            _mensajeError = "";

            if (turno.Fecha == default(DateTime))
                _mensajeError += "La fecha es obligatoria. ";
            if (turno.HoraInicio >= turno.HoraFin)
                _mensajeError += "La hora de inicio debe ser anterior a la hora de fin. ";
            if (string.IsNullOrWhiteSpace(turno.TipoAtencion))
                _mensajeError += "El tipo de atención es obligatorio. ";
            if (turno.MedicoId <= 0)
                _mensajeError += "El ID del médico es obligatorio. ";
            if (turno.PacienteId <= 0)
                _mensajeError += "El ID del paciente es obligatorio. ";
            if (!Enum.IsDefined(typeof(EstadoTurno), turno.Estado))
                _mensajeError += "El estado del turno no es válido. ";

            return string.IsNullOrEmpty(_mensajeError);
        }

        public IList<Turno> BuscarPorMedico(long medicoId)
        {
            return _mppTurno.Buscar("medicoid", medicoId.ToString());
        }

        public IList<Turno> BuscarPorFecha(DateTime fecha)
        {
            return _mppTurno.Buscar("fecha", fecha.ToShortDateString());
        }

        public void CambiarEstado(Turno turno, EstadoTurno nuevoEstado)
        {
            turno.Estado = nuevoEstado;
            Modificar(turno);
        }

        public IList<Turno> ObtenerTurnosPorEstado(EstadoTurno estado)
        {
            return ObtenerTodos().Where(t => t.Estado == estado).ToList();
        }
    }
}
