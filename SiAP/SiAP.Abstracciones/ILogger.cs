using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    public interface ILogger
    {
        void GenerarLog(string detalle, string usuario = default);
        void GenerarLog(IAuditable entidad, string tipoAccion, string textoAdicional = "");
    }
}
