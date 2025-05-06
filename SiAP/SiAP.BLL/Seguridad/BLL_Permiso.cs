using SiAP.BE.Seguridad;
using SiAP.Abstracciones;
using SiAP.MPP.Seguridad;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Permiso : IBLL<Permiso>
    {
        private readonly MPP_Permiso _mppPermiso;
        private static BLL_Permiso _instancia;
        private readonly ILogger _logger;

        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Permiso()
        {
            _mppPermiso = MPP_Permiso.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Permiso ObtenerInstancia()
        {
            return _instancia ??= new BLL_Permiso();
        }

        public void Agregar(Permiso permiso)
        {
            if (!EsValido(permiso))
                throw new ArgumentException(MensajeError);

            if (_mppPermiso.Existe(permiso))
                throw new InvalidOperationException("El permiso ya existe.");

            _mppPermiso.Agregar(permiso);
            _logger.GenerarLog($"Permiso agregado: {permiso.Codigo}");
        }

        public void Modificar(Permiso permiso, string codigoAnterior = null)
        {
            if (!EsValido(permiso))
                throw new ArgumentException(MensajeError);

            _mppPermiso.Modificar(permiso, codigoAnterior);
            _logger.GenerarLog($"Permiso modificado: {permiso.Codigo}");
        }

        public void Eliminar(Permiso permiso)
        {
            if (_mppPermiso.TieneDependencias(permiso))
                throw new InvalidOperationException("El permiso tiene dependencias y no puede eliminarse.");

            _mppPermiso.Eliminar(permiso);
            _logger.GenerarLog($"Permiso eliminado: {permiso.Codigo}");
        }

        public IList<Permiso> ObtenerTodos()
        {
            return _mppPermiso.ObtenerTodos();
        }

        public Permiso Leer(Permiso permiso)
        {
            return _mppPermiso.LeerPorId(permiso.Codigo);
        }

        public bool EsValido(Permiso permiso)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(permiso.Codigo))
                _mensajeError += "El código es obligatorio. ";

            if (string.IsNullOrWhiteSpace(permiso.Descripcion))
                _mensajeError += "La descripción es obligatoria. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}
