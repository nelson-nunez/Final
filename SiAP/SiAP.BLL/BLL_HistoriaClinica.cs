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

        //Otros
        public HistoriaClinica BuscarPorPaciente(long pacienteId)
        {
            if (pacienteId <= 0)
                throw new ArgumentException("El ID del paciente debe ser válido.");

            return _mppHistoriaClinica.BuscarPorPacienteId(pacienteId);
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