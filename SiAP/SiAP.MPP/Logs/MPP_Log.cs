using System.Data;
using SiAP.BE.Logs;
using SiAP.MPP.Base;

namespace SiAP.MPP.Logs
{
    public class MPPLog : MapperBase<Log>
    {
        private static MPPLog _instancia;
        protected override string NombreTabla => "Log";

        private MPPLog() : base() { }

        public static MPPLog ObtenerInstancia()
        {
            return _instancia ??= new MPPLog();
        }

        public IList<Log> ObtenerLog()
        {
            var ds = _datos.Obtener_Logs();
            return ds.Tables[NombreTabla].AsEnumerable()
                .Select(HidratarObjeto)
                .Where(log => log != null)
                .OrderByDescending(log => log.Fecha)
                .ToList();
        }

        public IList<Log> ObtenerLog(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables[NombreTabla];
            var filtro = ConstruirFiltro(desde, hasta, propiedad, texto);
            var filas = dt.Select(filtro);

            return filas
                .Select(HidratarObjeto)
                .Where(log => log != null)
                .OrderByDescending(log => log.Fecha)
                .ToList();
        }

        public void GuardarLog(Log log)
        {
            ArgumentNullException.ThrowIfNull(log);

            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables[NombreTabla];
            var dr = dt.NewRow();

            long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Id"] = nuevoId;
            AsignarDatos(dr, log);

            dt.Rows.Add(dr);
            _datos.Actualizar_BDLogs(ds);

            log.Id = nuevoId;
        }

        public void ActualizarUsuarioUsername(string usernameActual, string usernameNuevo)
        {
            if (string.IsNullOrWhiteSpace(usernameActual) || string.IsNullOrWhiteSpace(usernameNuevo))
                throw new ArgumentException("Los valores de usuario no pueden estar vacíos.");

            var ds = _datos.Obtener_Logs();
            var dt = ds.Tables[NombreTabla];
            var registros = dt.Select($"Usuario = '{usernameActual.Replace("'", "''")}'");

            foreach (var dr in registros)
            {
                dr["Usuario"] = usernameNuevo;
            }

            _datos.Actualizar_BDLogs(ds);
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

        private void AsignarDatos(DataRow dr, Log entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["Usuario"] = entidad.Usuario ?? string.Empty;
            dr["Operacion"] = entidad.Operacion ?? string.Empty;
        }

        private Log HidratarObjeto(DataRow dr)
        {
            if (dr == null) return null;

            return new Log
            {
                Id = Convert.ToInt64(dr["Id"]),
                Fecha = dr["Fecha"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha"]) : DateTime.MinValue,
                Usuario = dr["Usuario"]?.ToString(),
                Operacion = dr["Operacion"]?.ToString()
            };
        }
    }
}