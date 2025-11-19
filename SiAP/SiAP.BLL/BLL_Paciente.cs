using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Paciente : IBLL<Paciente>
    {
        private readonly MPP_Paciente _mppPaciente;
        private static BLL_Paciente _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Paciente()
        {
            _mppPaciente = MPP_Paciente.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Paciente ObtenerInstancia()
        {
            return _instancia ??= new BLL_Paciente();
        }

        public void Agregar(Paciente paciente)
        {
            if (!EsValido(paciente))
                throw new ArgumentException(MensajeError);

            if (_mppPaciente.Existe(paciente))
                throw new InvalidOperationException("El paciente ya existe.");

            _mppPaciente.Agregar(paciente);
            _logger.GenerarLog($"Paciente agregado: {paciente.Persona.Nombre} {paciente.Persona.Apellido}");
        }

        public void Modificar(Paciente paciente)
        {
            if (!EsValido(paciente))
                throw new ArgumentException(MensajeError);

            _mppPaciente.Modificar(paciente);
            _logger.GenerarLog($"Paciente modificado: {paciente.Persona.Nombre} {paciente.Persona.Apellido}");
        }

        public void Eliminar(Paciente paciente)
        {
            if (_mppPaciente.TieneDependencias(paciente))
                throw new InvalidOperationException("El paciente tiene dependencias y no puede eliminarse.");

            _mppPaciente.Eliminar(paciente);
            _logger.GenerarLog($"Paciente eliminado: {paciente.Persona.Nombre} {paciente.Persona.Apellido}");
        }

        public IList<Paciente> ObtenerTodos()
        {
            return _mppPaciente.ObtenerTodos();
        }

        public IList<Paciente> Buscar(string parametro)
        {
            var pacientes = _mppPaciente.Buscar(parametro).ToList();
            return pacientes;
        }

        public Paciente Leer(long pacienteId)
        {
            return _mppPaciente.LeerPorId(pacienteId);
        }

        public bool EsValido(Paciente paciente)
        {
            _mensajeError = "";

            if (paciente.Persona == null)
            {
                _mensajeError = "El paciente debe tener una persona asociada. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(paciente.Persona.Nombre))
                _mensajeError += "El nombre es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.Persona.Apellido))
                _mensajeError += "El apellido es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.Persona.Dni))
                _mensajeError += "El DNI es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.Persona.Email))
                _mensajeError += "El email es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.ObraSocial))
                _mensajeError += "La obra social es obligatoria. ";

            if (string.IsNullOrWhiteSpace(paciente.Plan))
                _mensajeError += "El plan es obligatorio. ";

            if (paciente.NumeroSocio <= 0)
                _mensajeError += "El número de socio debe ser mayor a cero. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}