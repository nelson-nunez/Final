using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.DAL
{
    public interface IAccesoDatos
    {
        DataSet Obtener_Datos();
        DataSet Obtener_Logs();

        void Actualizar_BD(DataSet ds);
        void Actualizar_BDLogs(DataSet ds);

        void CrearBackup(string nombre_Backup);
        void EliminarBackup(string nombre_Backup);
        void RestaurarBackup(string nombre_Backup);
    }
}
