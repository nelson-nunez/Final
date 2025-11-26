using SiAP.Abstracciones;
using SiAP.MPP.Logs;
using SiAP.BE.Logs;
using SiAP.BLL.Seguridad;

namespace SiAP.BLL.Logs
{
    public class BLLLog : ILogger
    {
        private static BLLLog _instancia;
        private readonly MPPLog _logger;

        private BLLLog()
        {
            _logger = MPPLog.ObtenerInstancia();
        }

        public static BLLLog ObtenerInstancia()
        {
            return _instancia ??= new BLLLog();
        }

        // Método para pruebas--------------------
        public IList<Log> ObtenerLogs()
        {
            var lista = _logger.ObtenerLog();
            return lista;
        }

        public void GenerarLog(string detalle, string usuario = null)
        {
            Log log = new Log()
            {
                Usuario =  GestionUsuario.UsuarioLogueado.Username,
                Fecha = DateTime.Now,
                Operacion = detalle
            };

            _logger.GuardarLog(log);
        }
    }
}
