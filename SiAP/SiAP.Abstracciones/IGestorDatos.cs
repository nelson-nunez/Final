using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    public interface IGestorDatos
    {
        DataSet Obtener_Datos();
        DataSet Obtener_Logs();
        void Guardar_Datos(DataSet ds);

    }
}
