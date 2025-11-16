using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE;

namespace SiAP.DAL
{
    public interface IAccesoDatos
    {
        //Creacion
        DataSet InicializarBD(ReferenciaBD item);
        //Lectura
        DataSet ObtenerDatos_BDSiAP();
        DataSet ObtenerDatos_BDLogs();
        DataSet ObtenerDatos_BDRespaldos();
        //Escritura
        void Actualizar_BDSiAP(DataSet ds);
        void Actualizar_BDLogs(DataSet ds);
        void Actualizar_BDRespaldos(DataSet ds);
        //Respaldos
        Respaldo CrearRespaldo(Respaldo item);
        void EliminarRespaldo(Respaldo item);
        void RestaurarRespaldo(Respaldo item);
    }
}
