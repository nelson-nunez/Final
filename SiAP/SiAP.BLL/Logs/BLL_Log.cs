using SiAP.Abstracciones;
using SiAP.BE_Vistas;
using SiAP.MPP.Logs;
using SiAP.BE.Logs;

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
                Usuario = usuario ?? ObtenerUsuarioActual(),  // Usar el método para obtener el usuario actual
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
                Usuario = ObtenerUsuarioActual(), 
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

        private string ObtenerUsuarioActual()
        {
            // Aquí se puede implementar la lógica para obtener el usuario actual de la sesión.
            // Por ejemplo:
            return "UsuarioLogueado"; // Reemplazar por la lógica real para obtener el usuario logueado.
        }
    }
}
