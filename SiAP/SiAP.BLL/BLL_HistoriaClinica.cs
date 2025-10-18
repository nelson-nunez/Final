using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using SiAP.Abstracciones;
using SiAP.BLL.Logs;
using SiAP.MPP;
using Policonsultorio.BE;

namespace SiAP.BLL
{
    public class BLL_HistoriaClinica : IBLL<HistoriaClinica>
    {
        private readonly MPP_HistoriaClinica _mppHistoriaClinica;
        private static BLL_HistoriaClinica _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_HistoriaClinica()
        {
            _mppHistoriaClinica = MPP_HistoriaClinica.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_HistoriaClinica ObtenerInstancia()
        {
            return _instancia ??= new BLL_HistoriaClinica();
        }

        public void Agregar(HistoriaClinica historia)
        {
            if (!EsValido(historia))
                throw new ArgumentException(MensajeError);

            if (_mppHistoriaClinica.Existe(historia))
                throw new InvalidOperationException("La historia clínica ya existe.");

            _mppHistoriaClinica.Agregar(historia);
            _logger.GenerarLog($"Historia clínica agregada para paciente: {historia.Paciente?.Apellido}, {historia.Paciente?.Nombre}");
        }

        public void Modificar(HistoriaClinica historia)
        {
            if (!EsValido(historia))
                throw new ArgumentException(MensajeError);

            _mppHistoriaClinica.Modificar(historia);
            _logger.GenerarLog($"Historia clínica modificada para paciente: {historia.Paciente?.Apellido}, {historia.Paciente?.Nombre}");
        }

        public void Eliminar(HistoriaClinica historia)
        {
            if (_mppHistoriaClinica.TieneDependencias(historia))
                throw new InvalidOperationException("La historia clínica tiene consultas asociadas y no puede eliminarse.");

            _mppHistoriaClinica.Eliminar(historia);
            _logger.GenerarLog($"Historia clínica eliminada para paciente: {historia.Paciente?.Apellido}, {historia.Paciente?.Nombre}");
        }

        public IList<HistoriaClinica> ObtenerTodos()
        {
            return _mppHistoriaClinica.ObtenerTodos();
        }

        public HistoriaClinica Leer(long historiaId)
        {
            return _mppHistoriaClinica.LeerPorId(historiaId);
        }


        public HistoriaClinica BuscarPorPaciente(long pacienteId)
        {
            if (pacienteId <= 0)
                throw new ArgumentException("El ID del paciente debe ser válido.");

            return _mppHistoriaClinica.BuscarPorPacienteId(pacienteId);
        }

        public IList<HistoriaClinica> BuscarPorMedico(long medicoId)
        {
            if (medicoId <= 0)
                throw new ArgumentException("El ID del médico debe ser válido.");

            var historias = _mppHistoriaClinica.BuscarPorMedicoId(medicoId);
            _logger.GenerarLog($"Búsqueda de historias clínicas por médico ID: {medicoId}. Resultados: {historias.Count}");

            return historias;
        }

        public IList<HistoriaClinica> Filtrar(string nombrePaciente, string dniPaciente)
        {
            return _mppHistoriaClinica.Filtrar(nombrePaciente, dniPaciente);
        }

        public HistoriaClinica CrearOObtenerHistoriaClinica(long pacienteId)
        {
            var historiaExistente = _mppHistoriaClinica.BuscarPorPacienteId(pacienteId);

            if (historiaExistente != null)
                return historiaExistente;

            // Si no existe, crear una nueva
            var nuevaHistoria = new HistoriaClinica
            {
                Paciente = new SiAP.BE.Paciente { Id = pacienteId },
                FechaCreacion = DateTime.Now,
                Descripcion = "Historia clínica inicial"
            };

            Agregar(nuevaHistoria);
            return nuevaHistoria;
        }

        public bool EsValido(HistoriaClinica historia)
        {
            _mensajeError = "";

            if (historia == null)
            {
                _mensajeError = "La historia clínica no puede ser nula. ";
                return false;
            }

            if (historia.Paciente == null || historia.Paciente.Id <= 0)
                _mensajeError += "La historia clínica debe tener un paciente asociado. ";

            if (historia.FechaCreacion == default(DateTime))
                _mensajeError += "La fecha de creación es obligatoria. ";

            if (historia.FechaCreacion > DateTime.Now)
                _mensajeError += "La fecha de creación no puede ser futura. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}