using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPPLog
    {
        private MPPLog()
        {
            _datos = GestorDatos.ObtenerInstancia();
        }

        private static MPPLog _mppLog = null;
        private IGestorDatos _datos;

        public static MPPLog ObtenerInstancia()
        {
            if (_mppLog == null)
                _mppLog = new MPPLog();
            return _mppLog;
        }

        public IList<Log> ObtenerLog()
        {
            var ds = _datos.Obtener_Logs();
            var tablaLogs = ds.Tables["Log"];
            var filas = tablaLogs.Select();

            return filas
                .Select(CargarObjeto)
                .OrderByDescending(log => log.Fecha)
                .ToList();
        }

        public IList<Log> ObtenerLog(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            var ds = _datos.Obtener_Logs();
            var tablaLogs = ds.Tables["Log"];
            var filtro = ConstruirFiltro(desde, hasta, propiedad, texto);
            var filas = tablaLogs.Select(filtro);

            return filas
                .Select(CargarObjeto)
                .OrderByDescending(log => log.Fecha)
                .ToList();
        }

        public void GuardarLog(Log log)
        {
            var ds = _datos.Obtener_Logs();
            var dtLog = ds.Tables["Log"];
            var dr = dtLog.NewRow();

            dr["CodigoTransaccion"] = Guid.NewGuid();
            dr["Fecha"] = log.Fecha;
            dr["Usuario"] = log.Usuario;
            dr["Operacion"] = log.Operacion;

            dtLog.Rows.Add(dr);
            _datos.Guardar_Datos(ds);
        }

        public void ActualizarUsuarioLogon(string logonActual, string logonNuevo)
        {
            var ds = _datos.Obtener_Logs();
            var drLogs = ds.Tables["Log"].Select($"Usuario = '{logonActual}'");

            foreach (var dr in drLogs)
            {
                dr["Usuario"] = logonNuevo;
            }

            _datos.Guardar_Datos(ds);
        }

        private string ConstruirFiltro(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            var filtro = $"Fecha >= '#{desde:dd/MM/yyyy 00:00:00}#' AND Fecha <= '#{hasta:dd/MM/yyyy 23:59:59}#'";
            // Si se ha especificado un texto para filtrar
            if (!string.IsNullOrWhiteSpace(texto))
            {
                if (propiedad != nameof(Log.Usuario) && propiedad != nameof(Log.Operacion))
                    throw new ArgumentException("La propiedad especificada no es válida.");

                var textoPreparado = texto.Replace("*", "%").Replace("'", "''");
                filtro += $" AND {propiedad} LIKE '%{textoPreparado}%'";
            }
            return filtro;
        }

        private Log CargarObjeto(DataRow dr)
        {
            if (dr == null) return null;

            return new Log
            {
                Fecha = Convert.ToDateTime(dr["Fecha"]),
                Usuario = dr["Usuario"].ToString(),
                Operacion = dr["Operacion"].ToString()
            };
        }

    }
}