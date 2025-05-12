using System.Data;
using SiAP.Abstracciones;
using SiAP.MPP.Base;
using SiAP.BE.Logs;

namespace SiAP.MPP.Logs
{
    public class MPPLog
    {
        private readonly IGestorDatos _datos;
        private static MPPLog _instancia;

        private MPPLog()
        {
            _datos = GestorDatos.ObtenerInstancia();
        }

        public static MPPLog ObtenerInstancia()
        {
            return _instancia ??= new MPPLog();
        }

        public IList<Log> ObtenerLog()
        {
            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables["Log"];

            return dt.AsEnumerable()
                     .Select(CargarObjeto)
                     .Where(log => log != null)
                     .OrderByDescending(log => log.Fecha)
                     .ToList();
        }

        public IList<Log> ObtenerLog(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables["Log"];
            var filtro = ConstruirFiltro(desde, hasta, propiedad, texto);
            var filas = dt.Select(filtro);

            return filas
                .Select(CargarObjeto)
                .Where(log => log != null)
                .OrderByDescending(log => log.Fecha)
                .ToList();
        }

        public void GuardarLog(Log log)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables["Log"];
            var dr = dt.NewRow();

            dr["CodigoTransaccion"] = Guid.NewGuid();
            dr["Fecha"] = log.Fecha;
            dr["Usuario"] = log.Usuario ?? string.Empty;
            dr["Operacion"] = log.Operacion ?? string.Empty;

            dt.Rows.Add(dr);
            _datos.Guardar_Datos(ds);
        }

        public void ActualizarUsuarioUsername(string usernameActual, string usernameNuevo)
        {
            if (string.IsNullOrWhiteSpace(usernameActual) || string.IsNullOrWhiteSpace(usernameNuevo))
                throw new ArgumentException("Los valores de usuario no pueden estar vacíos.");

            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables["Log"];
            var registros = dt.Select($"Usuario = '{usernameActual.Replace("'", "''")}'");

            foreach (var dr in registros)
            {
                dr["Usuario"] = usernameNuevo;
            }

            _datos.Guardar_Datos(ds);
        }

        private string ConstruirFiltro(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            string filtro = $"Fecha >= #{desde:MM/dd/yyyy 00:00:00}# AND Fecha <= #{hasta:MM/dd/yyyy 23:59:59}#";

            if (!string.IsNullOrWhiteSpace(texto))
            {
                if (propiedad != nameof(Log.Usuario) && propiedad != nameof(Log.Operacion))
                    throw new ArgumentException("La propiedad especificada no es válida.");

                var textoSanitizado = texto.Replace("'", "''");
                filtro += $" AND {propiedad} LIKE '%{textoSanitizado}%'";
            }

            return filtro;
        }

        private Log CargarObjeto(DataRow dr)
        {
            if (dr == null) return null;

            return new Log
            {
                Fecha = dr["Fecha"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha"]) : DateTime.MinValue,
                Usuario = dr["Usuario"]?.ToString(),
                Operacion = dr["Operacion"]?.ToString()
            };
        }
    }
}
