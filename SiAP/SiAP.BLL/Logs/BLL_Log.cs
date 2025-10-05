using SiAP.Abstracciones;
using SiAP.BE_Vistas;
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

        // Obtener logs filtrados por fecha, propiedad y texto
        public IList<VistaLog> ObtenerLogs(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            var lista = _logger.ObtenerLog(desde, hasta, propiedad, texto);
            return ConstruirVista(lista);
        }

        // Método para pruebas
        public IList<VistaLog> ObtenerLogs()
        {
            var lista = _logger.ObtenerLog();
            return ConstruirVista(lista);
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

        public void GenerarLog(IAuditable auditable, string tipoAccion, string textoAdicional = null)
        {
            string operacion = $"{tipoAccion.ToUpper()} de {auditable.GetType().Name} - {auditable}";
            if (!string.IsNullOrWhiteSpace(textoAdicional))
            {
                operacion = $"{operacion}. {textoAdicional}";
            }

            Log log = new Log()
            {
                Usuario = GestionUsuario.UsuarioLogueado.Username,
                Fecha = DateTime.Now,
                Operacion = operacion
            };

            _logger.GuardarLog(log);
        }

        private IList<VistaLog> ConstruirVista(IList<Log> source)
        {
            return source.Select(sourceItem => new VistaLog
            {
                Fecha = sourceItem.Fecha,
                Usuario = sourceItem.Usuario,
                Operacion = sourceItem.Operacion
            }).ToList();
        }
    }
}
