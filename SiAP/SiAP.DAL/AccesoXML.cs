using System.Data;
using System.Diagnostics;
using System.Xml;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;

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
            ds.ReadXml(ReferenciasBD.Path_BD, XmlReadMode.ReadSchema);

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
            {
                ds.Tables.Add(CrearTablaLog());
                Actualizar_BD(ds);
            }

            if (!ds.Tables.Contains("Permiso"))
            {
                ds.Tables.Add(CrearTablaPermiso());
                Actualizar_BD(ds);
            }
            if (!ds.Tables.Contains("PermisoHijo"))
            {
                ds.Tables.Add(CrearTablaPermisoHijo());
                Actualizar_BD(ds);
            }
            if (!ds.Tables.Contains("Usuario"))
            {
                ds.Tables.Add(CrearTablaUsuario());
                Actualizar_BD(ds);
            }
            if (!ds.Tables.Contains("UsuarioPermiso"))
            { 
                ds.Tables.Add(CrearTablaUsuarioPermiso());
                Actualizar_BD(ds);
            }
        }

        // Tabla Usuario
        private DataTable CrearTablaUsuario()
        {
            var tabla = new DataTable("Usuario");

            tabla.Columns.Add(new DataColumn("Id", typeof(long)));
            tabla.Columns.Add(new DataColumn("Legajo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Username", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Apellido", typeof(string)));
            tabla.Columns.Add(new DataColumn("Email", typeof(string)));
            tabla.Columns.Add(new DataColumn("Password", typeof(string)));
            tabla.Columns.Add(new DataColumn("FechaUltimoCambioPassword", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("PalabraClave", typeof(string)));
            tabla.Columns.Add(new DataColumn("RespuestaClave", typeof(string)));
            tabla.Columns.Add(new DataColumn("Bloqueado", typeof(bool)));
            tabla.Columns.Add(new DataColumn("Activo", typeof(bool)));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Usuario mockup
            var fila = tabla.NewRow();
            fila["Id"] = 1;
            fila["Legajo"] = 1001;
            fila["Username"] = "admin";
            fila["Nombre"] = "Administrador";
            fila["Apellido"] = "Sistema";
            fila["Email"] = "admin@empresa.com";
            fila["Password"] = "admin";
            fila["FechaUltimoCambioPassword"] = DateTime.Now;
            fila["PalabraClave"] = "default";
            fila["RespuestaClave"] = "admin";
            fila["Bloqueado"] = false;
            fila["Activo"] = true;
            tabla.Rows.Add(fila);

            return tabla;
        }

        // Tabla Permiso
        private DataTable CrearTablaPermiso()
        {
            var tabla = new DataTable("Permiso");

            tabla.Columns.Add(new DataColumn("Id", typeof(long)));
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tabla.Columns.Add(new DataColumn("EsCompuesto", typeof(bool)));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Permiso compuesto - administrador
            tabla.Rows.Add(10, "Administrador", "Permisos administrativos", true);

            // Permisos simples
            tabla.Rows.Add(11, "TAG001", "Acceso a Inicio", false);
            tabla.Rows.Add(12, "TAG002", "Modificar Clave", false);
            tabla.Rows.Add(13, "TAG003", "Gestión de Usuarios", false);
            tabla.Rows.Add(14, "TAG004", "Gestión de Roles", false);
            tabla.Rows.Add(15, "TAG005", "Gestión de Permisos", false);

            return tabla;
        }

        // Tabla PermisoHijo (para representar el Composite)
        private DataTable CrearTablaPermisoHijo()
        {
            var tabla = new DataTable("PermisoHijo");

            tabla.Columns.Add(new DataColumn("PadreId", typeof(long)));
            tabla.Columns.Add(new DataColumn("HijoId", typeof(long)));

            tabla.PrimaryKey = new[] {
                tabla.Columns["PadreId"],
                tabla.Columns["HijoId"]
            };

            // Relaciones del permiso compuesto "Administrador"
            tabla.Rows.Add(10, 11);
            tabla.Rows.Add(10, 12);
            tabla.Rows.Add(10, 13);
            tabla.Rows.Add(10, 14);
            tabla.Rows.Add(10, 15);

            return tabla;
        }

        // Tabla UsuarioPermiso (relación Usuario → PermisoCompuesto)
        private DataTable CrearTablaUsuarioPermiso()
        {
            var tabla = new DataTable("UsuarioPermiso");

            tabla.Columns.Add(new DataColumn("UsuarioId", typeof(long)));
            tabla.Columns.Add(new DataColumn("PermisoId", typeof(long)));

            tabla.PrimaryKey = new[] {
                tabla.Columns["UsuarioId"],
                tabla.Columns["PermisoId"]
            };

            // Relación entre admin y el permiso compuesto
            tabla.Rows.Add(1, 10);

            return tabla;
        }

        // Tabla Log
        private DataTable CrearTablaLog()
        {
            var tabla = new DataTable("Log");

            tabla.Columns.Add(new DataColumn("Id", typeof(long)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Usuario", typeof(string)));
            tabla.Columns.Add(new DataColumn("Operacion", typeof(string)));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            return tabla;
        }

        #endregion
    }
}


