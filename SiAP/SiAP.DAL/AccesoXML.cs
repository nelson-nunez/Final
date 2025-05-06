using System.Data;
using System.Xml;

namespace SiAP.DAL
{
    public class AccesoXML : IAccesoDatos
    {
        private static AccesoXML _acceso = null;
        private DataSet _dataSet;

        private AccesoXML()
        {
            _dataSet = ObtenerODatosOInicializar();
        }

        public static AccesoXML ObtenerInstancia()
        {
            return _acceso ??= new AccesoXML();
        }

        #region Helpers

        private void AsegurarExistenciaArchivo(string path, string nodoRaiz)
        {
            string directorio = Path.GetDirectoryName(path);

            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            if (!File.Exists(path))
            {
                using (var writer = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(nodoRaiz);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        #endregion

        #region Leer

        private DataSet ObtenerODatosOInicializar()
        {
            AsegurarExistenciaArchivo(ReferenciasBD.Path_BD, "SiAP");

            var ds = new DataSet();

            try
            {
                ds.ReadXml(ReferenciasBD.Path_BD, XmlReadMode.ReadSchema);
            }
            catch
            {
                // Si falla la lectura del XML (p. ej., vacío), seguimos con el DataSet vacío
            }

            InicializarTablas(ds);
            return ds;
        }

        public DataSet Obtener_Datos()
        {
            return _dataSet;
        }

        public DataSet Obtener_Logs()
        {
            try
            {
                AsegurarExistenciaArchivo(ReferenciasBD.Path_BDLogs, "Log");

                DataSet ds = new DataSet();
                ds.ReadXml(ReferenciasBD.Path_BDLogs, XmlReadMode.ReadSchema);
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

                if (File.Exists(backupFileBD)) File.Delete(backupFileBD);
                if (File.Exists(backupFileLogs)) File.Delete(backupFileLogs);
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
                    throw new FileNotFoundException("No se encontró el backup de la base de datos principal.");

                if (!File.Exists(backupFileLogs))
                    throw new FileNotFoundException("No se encontró el backup de la base de datos de logs.");

                File.Copy(backupFileBD, ReferenciasBD.Path_BD, true);
                File.Copy(backupFileLogs, ReferenciasBD.Path_BDLogs, true);

                _dataSet = ObtenerODatosOInicializar(); // Releer después de restaurar
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Crear BD

        private void InicializarTablas(DataSet ds)
        {
            if (!ds.Tables.Contains("Log"))
                ds.Tables.Add(CrearTablaLog());
            if (!ds.Tables.Contains("Rol"))
                ds.Tables.Add(CrearTablaRol());
            if (!ds.Tables.Contains("Permiso"))
                ds.Tables.Add(CrearTablaPermiso());
            if (!ds.Tables.Contains("RolPermiso"))
                ds.Tables.Add(CrearTablaRolPermiso());
            if (!ds.Tables.Contains("PermisoHijo"))
                ds.Tables.Add(CrearTablaPermisoHijos());
            if (!ds.Tables.Contains("Usuario"))
                ds.Tables.Add(CrearTablaUsuario());
            if (!ds.Tables.Contains("UsuarioRol"))
                ds.Tables.Add(CrearTablaUsuarioRol());
        }

        private DataTable CrearTablaLog()
        {
            var tabla = new DataTable("Log");

            tabla.Columns.Add(new DataColumn("CodigoTransaccion", typeof(Guid)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Usuario", typeof(string)));
            tabla.Columns.Add(new DataColumn("Operacion", typeof(string)));

            tabla.PrimaryKey = new[] { tabla.Columns["CodigoTransaccion"] };
            return tabla;
        }

        private DataTable CrearTablaRol()
        {
            var tabla = new DataTable("Rol");

            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Descripcion", typeof(string)));

            tabla.PrimaryKey = new[] { tabla.Columns["Codigo"] };
            return tabla;
        }

        private DataTable CrearTablaPermiso()
        {
            var tabla = new DataTable("Permiso");

            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tabla.Columns.Add(new DataColumn("EsCompuesto", typeof(bool)));

            tabla.PrimaryKey = new[] { tabla.Columns["Codigo"] };
            return tabla;
        }

        private DataTable CrearTablaRolPermiso()
        {
            var tabla = new DataTable("RolPermiso");

            tabla.Columns.Add(new DataColumn("RolCodigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("PermisoCodigo", typeof(string)));

            tabla.PrimaryKey = new[]
            {
                tabla.Columns["RolCodigo"],
                tabla.Columns["PermisoCodigo"]
            };

            return tabla;
        }

        private DataTable CrearTablaPermisoHijos()
        {
            var tabla = new DataTable("PermisoHijo");

            tabla.Columns.Add(new DataColumn("PadreCodigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("HijoCodigo", typeof(string)));

            tabla.PrimaryKey = new[]
            {
                tabla.Columns["PadreCodigo"],
                tabla.Columns["HijoCodigo"]
            };

            return tabla;
        }

        private DataTable CrearTablaUsuario()
        {
            var tabla = new DataTable("Usuario");

            tabla.Columns.Add(new DataColumn("Legajo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Logon", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Apellido", typeof(string)));
            tabla.Columns.Add(new DataColumn("Email", typeof(string)));
            tabla.Columns.Add(new DataColumn("Password", typeof(string)));
            tabla.Columns.Add(new DataColumn("FechaUltimoCambioPassword", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("PalabraClave", typeof(string)));
            tabla.Columns.Add(new DataColumn("RespuestaClave", typeof(string)));
            tabla.Columns.Add(new DataColumn("Bloqueado", typeof(bool)));
            tabla.Columns.Add(new DataColumn("Activo", typeof(bool)));

            tabla.PrimaryKey = new[] { tabla.Columns["Legajo"] };
            return tabla;
        }

        private DataTable CrearTablaUsuarioRol()
        {
            var tabla = new DataTable("UsuarioRol");

            tabla.Columns.Add(new DataColumn("UsuarioLegajo", typeof(int)));
            tabla.Columns.Add(new DataColumn("RolCodigo", typeof(string)));

            tabla.PrimaryKey = new[]
            {
                tabla.Columns["UsuarioLegajo"],
                tabla.Columns["RolCodigo"]
            };

            return tabla;
        }

        #endregion
    }
}


