using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.IO;
using SiAP.BE.Logs;

namespace SiAP.DAL
{
    public class ReferenciaBD
    {
        private static readonly string directorioProyecto = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent?.FullName ?? "";
       
        public ReferenciaBD(string nombre, string carpeta)
        {
            NombreBD = nombre;
            Carpeta_BD = carpeta;
        }
        
        public string NombreBD { get; set; }    
        public string Carpeta_BD { get; set; }
        public string Archivo_BD
        {
            get
            {
                return this.NombreBD + ".xml";
            }
        }
        public string Path_BD
        {
            get
            {
                string path = Path.Combine(directorioProyecto, this.Carpeta_BD);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return Path.Combine(path, Archivo_BD);
            }
        }

        public string Path_ArchivoBackup(string nombre)
        {
            string path = Path.Combine(directorioProyecto, this.Carpeta_BD);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return Path.Combine(path, NombreBD + "_Respaldo_" + nombre + ".xml");
        }
    }

    public static class ReferenciasBD
    {
        public static ReferenciaBD BD_Siap = new ReferenciaBD("SiAP", "BaseDatos");
        public static ReferenciaBD BD_Log = new ReferenciaBD("Logs", "BaseDatos");
        public static ReferenciaBD BD_Respaldo = new ReferenciaBD("Respaldos", "Backups");

        public static List<string> Todos()
        {
            return new List<string> { BD_Siap.NombreBD, BD_Log.NombreBD };
        }
    }
}
