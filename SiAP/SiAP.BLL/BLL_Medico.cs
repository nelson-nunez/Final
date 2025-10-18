using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Medico : IBLL<Medico>
    {
        private readonly MPP_Medico _mppMedico;
        private static BLL_Medico _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Medico()
        {
            _mppMedico = MPP_Medico.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Medico ObtenerInstancia()
        {
            return _instancia ??= new BLL_Medico();
        }

        public void Agregar(Medico medico)
        {
            if (!EsValido(medico))
                throw new ArgumentException(MensajeError);

            if (_mppMedico.Existe(medico))
                throw new InvalidOperationException("El médico ya existe.");

            _mppMedico.Agregar(medico);
            _logger.GenerarLog($"Médico agregado: {medico.Persona.Nombre} {medico.Persona.Apellido}");
        }

        public void Modificar(Medico medico)
        {
            if (!EsValido(medico))
                throw new ArgumentException(MensajeError);

            _mppMedico.Modificar(medico);
            _logger.GenerarLog($"Médico modificado: {medico.Persona.Nombre} {medico.Persona.Apellido}");
        }

        public void Eliminar(Medico medico)
        {
            if (_mppMedico.TieneDependencias(medico))
                throw new InvalidOperationException("El médico tiene dependencias y no puede eliminarse.");

            _mppMedico.Eliminar(medico);
            _logger.GenerarLog($"Médico eliminado: {medico.Persona.Nombre} {medico.Persona.Apellido}");
        }

        public IList<Medico> ObtenerTodos()
        {
            return _mppMedico.ObtenerTodos();
        }

        public IList<Medico> Filtrar(string Nombre, string Email)
        {
            return _mppMedico.Filtrar(Nombre, Email);
        }
        public Medico Leer(long medicoId)
        {
            return _mppMedico.LeerPorId(medicoId);
        }

        public Medico LeerPorPersonId(long medicoId)
        {
            return _mppMedico.LeerPorPersonId(medicoId);
        }

        public bool EsValido(Medico medico)
        {
            _mensajeError = "";

            if (medico.Persona == null)
            {
                _mensajeError = "El médico debe tener una persona asociada. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(medico.Persona.Nombre))
                _mensajeError += "El nombre es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Persona.Apellido))
                _mensajeError += "El apellido es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Persona.Dni))
                _mensajeError += "El DNI es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Persona.Email))
                _mensajeError += "El email es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Titulo))
                _mensajeError += "El título es obligatorio. ";

            if (medico.Especialidad == null)
                _mensajeError += "La especialidad es obligatoria. ";

            if (medico.ArancelConsulta <= 0)
                _mensajeError += "El arancel debe ser mayor a cero. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}