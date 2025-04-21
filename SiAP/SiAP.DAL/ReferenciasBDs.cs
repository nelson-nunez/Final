using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SiAP.DAL
{
    /// <summary>
    /// Clase estática que contiene las referencias a la base de datos (nombres de archivo y carpetas)
    /// </summary>
    public static class ReferenciasBD
    {
        private static string carpeta_BaseDatos = "BaseDatos";
        private static string carpeta_Backup = "Backups";
        private static string baseDatos_SiAP = "SiAP.xml";
        private static string baseDatos_Logs = "Logs.xml";
        private static string baseDatos_Backups = "Backups.xml";

        #region BDS

        public static string Path_BD
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(carpeta_BaseDatos))
                {
                    if (!Directory.Exists(carpeta_BaseDatos))
                        Directory.CreateDirectory(carpeta_BaseDatos);
                    return Path.Combine(carpeta_BaseDatos, baseDatos_SiAP);
                }
                else
                    return baseDatos_SiAP;
            }
        }
        public static string Path_BDLogs
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(carpeta_BaseDatos))
                {
                    if (!Directory.Exists(carpeta_BaseDatos))
                        Directory.CreateDirectory(carpeta_BaseDatos);
                    return Path.Combine(carpeta_BaseDatos, baseDatos_Logs);
                }
                else
                    return baseDatos_SiAP;
            }
        }

        #endregion

        #region Backups

        public static string BaseDatosBackups
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(carpeta_BaseDatos))
                {
                    if (!Directory.Exists(carpeta_BaseDatos))
                        Directory.CreateDirectory(carpeta_BaseDatos);
                    return Path.Combine(carpeta_BaseDatos, baseDatos_Backups);
                }
                else
                    return baseDatos_SiAP;
            }
        }
        public static string NombreCarpetaBackUp
        {
            get
            {
                if (!Directory.Exists(carpeta_Backup))
                    Directory.CreateDirectory(carpeta_Backup);

                return carpeta_Backup;
            }
        }

        #endregion

        #region Verificaciones

        public static bool Existe_BD()
        {
            try
            {
                return File.Exists(Path_BD);
            }
            catch
            {
                throw;
            }
        }

        public static bool Existe_BDLogs()
        {
            try
            {
                return File.Exists(Path_BDLogs);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}