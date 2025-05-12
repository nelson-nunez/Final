using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.IO;

namespace SiAP.DAL
{
    /// <summary>
    /// Clase estática que contiene las referencias a la base de datos (nombres de archivo y carpetas)
    /// </summary>
    public static class ReferenciasBD
    {
        private static readonly string directorioProyecto = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent?.FullName ?? "";

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
                string path = Path.Combine(directorioProyecto, carpeta_BaseDatos);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return Path.Combine(path, baseDatos_SiAP);
            }
        }

        public static string Path_BDLogs
        {
            get
            {
                string path = Path.Combine(directorioProyecto, carpeta_BaseDatos);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return Path.Combine(path, baseDatos_Logs);
            }
        }

        #endregion

        #region Backups

        public static string BaseDatosBackups
        {
            get
            {
                string path = Path.Combine(directorioProyecto, carpeta_BaseDatos);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return Path.Combine(path, baseDatos_Backups);
            }
        }

        public static string NombreCarpetaBackUp
        {
            get
            {
                string path = Path.Combine(directorioProyecto, carpeta_Backup);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return path;
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
