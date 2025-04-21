using System.Data;
using System.Xml;

namespace SiAP.DAL
{
    public class AccesoXML : IAccesoDatos
    {
        private static AccesoXML _acceso = null;

        private AccesoXML()
        {
        }

        public static AccesoXML ObtenerInstancia()
        {
            if (_acceso == null)
            {
                _acceso = new AccesoXML();
            }

            return _acceso;
        }

        #region Helpers

        private void AsegurarExistenciaArchivo(string path, string nodoRaiz)
        {
            string directorio = Path.GetDirectoryName(path);

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            if (!File.Exists(path))
            {
                using (var writer = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(nodoRaiz); // Nodo raíz configurable
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        #endregion

        #region Leer

        public DataSet Obtener_Datos()
        {
            try
            {
                AsegurarExistenciaArchivo(ReferenciasBD.Path_BD, "SiAP");

                DataSet ds = new DataSet();
                ds.ReadXml(ReferenciasBD.Path_BD, XmlReadMode.Auto);
                return ds;
            }
            catch
            {
                throw;
            }
        }

        public DataSet Obtener_Logs()
        {
            try
            {
                AsegurarExistenciaArchivo(ReferenciasBD.Path_BDLogs, "Log");

                DataSet ds = new DataSet();

                //PRUEBASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
                ds.Tables.Add(CrearTablaLog()); 
                
                ds.ReadXml(ReferenciasBD.Path_BDLogs, XmlReadMode.Auto);
                return ds;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Grabar

        public void Actualizar_BD(DataSet ds)
        {
            try
            {
                ds.WriteXml(ReferenciasBD.Path_BD, XmlWriteMode.WriteSchema);
            }
            catch
            {
                throw;
            }
        }

        public void Actualizar_BDLogs(DataSet ds)
        {
            try
            {
                ds.WriteXml(ReferenciasBD.Path_BDLogs, XmlWriteMode.WriteSchema);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Respaldos

        public void CrearBackup(string nombre_Backup)
        {
            try
            {
                string backupDir = ReferenciasBD.NombreCarpetaBackUp;
                string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
                string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

                AsegurarExistenciaArchivo(ReferenciasBD.Path_BD, "SiAP");
                AsegurarExistenciaArchivo(ReferenciasBD.Path_BDLogs, "Log");

                File.Copy(ReferenciasBD.Path_BD, backupFileBD, true);
                File.Copy(ReferenciasBD.Path_BDLogs, backupFileLogs, true);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarBackup(string nombre_Backup)
        {
            try
            {
                string backupDir = ReferenciasBD.NombreCarpetaBackUp;
                string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
                string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

                if (File.Exists(backupFileBD))
                {
                    File.Delete(backupFileBD);
                }

                if (File.Exists(backupFileLogs))
                {
                    File.Delete(backupFileLogs);
                }
            }
            catch
            {
                throw;
            }
        }

        public void RestaurarBackup(string nombre_Backup)
        {
            try
            {
                string backupDir = ReferenciasBD.NombreCarpetaBackUp;
                string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
                string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

                if (!File.Exists(backupFileBD))
                {
                    throw new FileNotFoundException("No se encontró el backup de la base de datos principal.");
                }

                if (!File.Exists(backupFileLogs))
                {
                    throw new FileNotFoundException("No se encontró el backup de la base de datos de logs.");
                }

                File.Copy(backupFileBD, ReferenciasBD.Path_BD, true);
                File.Copy(backupFileLogs, ReferenciasBD.Path_BDLogs, true);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        //PRUEBASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        private DataTable CrearTablaLog()
        {
            var tabla = new DataTable("Log");
            DataColumn columna;

            columna = new DataColumn();
            columna.ColumnName = "CodigoTransaccion";
            columna.DataType = typeof(Guid);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Fecha";
            columna.DataType = typeof(DateTime);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Usuario";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.ColumnName = "Operacion";
            columna.DataType = typeof(string);
            tabla.Columns.Add(columna);

            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["CodigoTransaccion"] };

            return tabla;
        }
    }
}

