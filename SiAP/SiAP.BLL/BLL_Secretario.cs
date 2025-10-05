using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Secretario : IBLL<Secretario>
    {
        private readonly MPP_Secretario _mppSecretario;
        private static BLL_Secretario _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Secretario()
        {
            _mppSecretario = MPP_Secretario.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Secretario ObtenerInstancia()
        {
            return _instancia ??= new BLL_Secretario();
        }

        public void Agregar(Secretario secretario)
        {
            if (!EsValido(secretario))
                throw new ArgumentException(MensajeError);

            if (_mppSecretario.Existe(secretario))
                throw new InvalidOperationException("El secretario ya existe.");

            _mppSecretario.Agregar(secretario);
            _logger.GenerarLog($"Secretario agregado: {secretario.Persona.Nombre} {secretario.Persona.Apellido}");
        }

        public void Modificar(Secretario secretario)
        {
            if (!EsValido(secretario))
                throw new ArgumentException(MensajeError);

            _mppSecretario.Modificar(secretario);
            _logger.GenerarLog($"Secretario modificado: {secretario.Persona.Nombre} {secretario.Persona.Apellido}");
        }

        public void Eliminar(Secretario secretario)
        {
            if (_mppSecretario.TieneDependencias(secretario))
                throw new InvalidOperationException("El secretario tiene dependencias y no puede eliminarse.");

            _mppSecretario.Eliminar(secretario);
            _logger.GenerarLog($"Secretario eliminado: {secretario.Persona.Nombre} {secretario.Persona.Apellido}");
        }

        public IList<Secretario> ObtenerTodos()
        {
            return _mppSecretario.ObtenerTodos();
        }

        public Secretario Leer(long secretarioId)
        {
            return _mppSecretario.LeerPorId(secretarioId);
        }

        public bool EsValido(Secretario secretario)
        {
            _mensajeError = "";

            if (secretario.Persona == null)
            {
                _mensajeError = "El secretario debe tener una persona asociada. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(secretario.Persona.Nombre))
                _mensajeError += "El nombre es obligatorio. ";

            if (string.IsNullOrWhiteSpace(secretario.Persona.Apellido))
                _mensajeError += "El apellido es obligatorio. ";

            if (string.IsNullOrWhiteSpace(secretario.Persona.Dni))
                _mensajeError += "El DNI es obligatorio. ";

            if (string.IsNullOrWhiteSpace(secretario.Persona.Email))
                _mensajeError += "El email es obligatorio. ";

            if (string.IsNullOrWhiteSpace(secretario.Legajo))
                _mensajeError += "El legajo es obligatorio. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}

