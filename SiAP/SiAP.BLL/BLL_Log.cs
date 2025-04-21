using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BE_Vistas;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLLLog
    {
        private BLLLog(){ }

        private static BLLLog _bllLog = null;

        public static BLLLog ObtenerInstancia()
        {
            if (_bllLog == null)
                _bllLog = new BLLLog();
            return _bllLog;
        }

        public IList<VistaLog> ObtenerLogs(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            return ConstruirVista(MPPLog.ObtenerInstancia().ObtenerLog(desde, hasta, propiedad, texto));
        }
       //sacar
        public List<VistaLog> ObtenerLogs()
        {
            return (List<VistaLog>)ConstruirVista(MPPLog.ObtenerInstancia().ObtenerLog());
        }

        public void GenerarLog(string detalle, string usuario = default)
        {
            Log log = new Log()
            {
               // Usuario = usuario ?? Ticket.UsuarioLogueado.Logon,
                Fecha = DateTime.Now,
                Operacion = detalle
            };

            MPPLog.ObtenerInstancia().GuardarLog(log);
        }
        
        public void GenerarLog(IAuditable auditable, string tipoAccion, string textoAdicional = default)
        {

            string operacion = $"{tipoAccion.ToUpper()} de {auditable.GetType().Name} - {auditable}";
            if (!String.IsNullOrWhiteSpace(textoAdicional))
            {
                operacion = $"{operacion}. {textoAdicional}";
            }

            Log log = new Log()
            {
                //Usuario = Ticket.UsuarioLogueado.Logon,
                Fecha = DateTime.Now,
                Operacion = operacion
            };

            MPPLog.ObtenerInstancia().GuardarLog(log);
        }

        private IList<VistaLog> ConstruirVista(IList<Log> source)
        {
            IList<VistaLog> lista = new List<VistaLog>();
            VistaLog destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaLog();

                destItem.Fecha = sourceItem.Fecha;
                destItem.Usuario = sourceItem.Usuario;
                destItem.Operacion = sourceItem.Operacion;


                lista.Add(destItem);
            }
            return lista;
        }
    }
}