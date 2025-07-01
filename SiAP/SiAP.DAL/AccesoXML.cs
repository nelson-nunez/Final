using System.Data;
using System.Diagnostics;
using System.Xml;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.BE;
using SiAP.UI;

namespace SiAP.DAL
{
    public class AccesoXML : IAccesoDatos
    {
        private static AccesoXML _acceso = null;
        private DataSet _dataSet;
        private DataSet _dataSetLogs;

        private AccesoXML()
        {
            _dataSet = ObtenerODatosOInicializar();
            _dataSetLogs = ObtenerLOGDatosOInicializar();
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

        #region LeerBD Comun

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
        #endregion

        #region LeerBD Logs
        private DataSet ObtenerLOGDatosOInicializar()
        {
            AsegurarExistenciaArchivo(ReferenciasBD.Path_BDLogs, "Log");
            var ds = new DataSet();
            ds.ReadXml(ReferenciasBD.Path_BDLogs, XmlReadMode.ReadSchema);
            InicializarTablasLog(ds);
            return ds;
        }

        public DataSet Obtener_Logs()
        {
            return _dataSetLogs;           
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
            try
            {
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
                if (!ds.Tables.Contains("Medico"))
                {
                    ds.Tables.Add(CrearTablaMedico());
                    Actualizar_BD(ds);
                }
                if (!ds.Tables.Contains("Paciente"))
                {
                    ds.Tables.Add(CrearTablaPaciente());
                    Actualizar_BD(ds);
                }
            }
            catch (Exception ex)
            {

                throw;
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
            fila["Password"] = "STqG+Tki2fc=";
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
            long idActual = 10;
            // Agrego el permiso compuesto "Administrador"
            tabla.Rows.Add(idActual, "Administrador", "Permisos administrativos", true);
            long idAdministrador = idActual;
            idActual++;
            // Agrego los permisos simples desde MenusConstantes
            foreach (var menu in MenusConstantes.ObtenerTodos())
            {
                tabla.Rows.Add(idActual, menu.Etiqueta, menu.Nombre, false);
                idActual++;
            }
            return tabla;
        }

        // Tabla PermisoHijo (para representar el Composite)
        private DataTable CrearTablaPermisoHijo()
        {
            var tabla = new DataTable("PermisoHijo");
            tabla.Columns.Add(new DataColumn("PadreId", typeof(long)));
            tabla.Columns.Add(new DataColumn("HijoId", typeof(long)));
            tabla.PrimaryKey = new[] { tabla.Columns["PadreId"], tabla.Columns["HijoId"] };
            // ID del permiso compuesto "Administrador"
            long idAdministrador = 10;
            long idHijoInicio = 11;
            // Se crean las relaciones para todos los Menus dentro del compuesto "Administrador"
            foreach (var menu in MenusConstantes.ObtenerTodos())
            {
                tabla.Rows.Add(idAdministrador, idHijoInicio);
                idHijoInicio++;
            }
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

        private DataTable CrearTablaMedico()
        {
            var tabla = new DataTable("Medico");

            // Propiedades heredadas de ClaseBase y Persona
            tabla.Columns.Add(new DataColumn("Id", typeof(long)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Apellido", typeof(string)));
            tabla.Columns.Add(new DataColumn("Dni", typeof(string)));
            tabla.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Email", typeof(string)));
            tabla.Columns.Add(new DataColumn("Telefono", typeof(string)));

            // Propiedades específicas de Medico
            tabla.Columns.Add(new DataColumn("MedicoId", typeof(int)));
            tabla.Columns.Add(new DataColumn("Titulo", typeof(string)));
            tabla.Columns.Add(new DataColumn("EspecialidadId", typeof(int)));
            tabla.Columns.Add(new DataColumn("EspecialidadNombre", typeof(string)));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Fila 1
            var fila1 = tabla.NewRow();
            fila1["Id"] = 1;
            fila1["Nombre"] = "Ana";
            fila1["Apellido"] = "Pérez";
            fila1["Dni"] = "12345678";
            fila1["FechaNacimiento"] = new DateTime(1980, 5, 10);
            fila1["Email"] = "ana.perez@hospital.com";
            fila1["Telefono"] = "1122334455";
            fila1["MedicoId"] = 101;
            fila1["Titulo"] = "Doctora en Medicina";
            fila1["EspecialidadId"] = 4;
            fila1["EspecialidadNombre"] = "Cardiología";
            tabla.Rows.Add(fila1);

            // Fila 2
            var fila2 = tabla.NewRow();
            fila2["Id"] = 2;
            fila2["Nombre"] = "Marcos";
            fila2["Apellido"] = "Andrada";
            fila2["Dni"] = "13345678";
            fila2["FechaNacimiento"] = new DateTime(1981, 8, 20);
            fila2["Email"] = "marcos@hospital.com";
            fila2["Telefono"] = "1122334466";
            fila2["MedicoId"] = 102;
            fila2["Titulo"] = "Doctor en Medicina";
            fila2["EspecialidadId"] = 2;
            fila2["EspecialidadNombre"] = "Pediatría";
            tabla.Rows.Add(fila2);

            // Fila 2
            var fila3 = tabla.NewRow();
            fila3["Id"] = 3;
            fila3["Nombre"] = "Marcelo";
            fila3["Apellido"] = "Pereira";
            fila3["Dni"] = "43345678";
            fila3["FechaNacimiento"] = new DateTime(1991, 8, 20);
            fila3["Email"] = "marcosp@hospital.com";
            fila3["Telefono"] = "1122334466";
            fila3["MedicoId"] = 102;
            fila3["Titulo"] = "Doctor en Medicina";
            fila3["EspecialidadId"] = 2;
            fila3["EspecialidadNombre"] = "Pediatría";
            tabla.Rows.Add(fila3);

            return tabla;
        }

        private DataTable CrearTablaPaciente()
        {
            var tabla = new DataTable("Paciente");

            // Propiedades heredadas de ClaseBase y Persona
            tabla.Columns.Add(new DataColumn("Id", typeof(long)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Apellido", typeof(string)));
            tabla.Columns.Add(new DataColumn("Dni", typeof(string)));
            tabla.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Email", typeof(string)));
            tabla.Columns.Add(new DataColumn("Telefono", typeof(string)));

            // Propiedades específicas de Paciente
            tabla.Columns.Add(new DataColumn("PacienteId", typeof(int)));
            tabla.Columns.Add(new DataColumn("ObraSocial", typeof(string)));
            tabla.Columns.Add(new DataColumn("Plan", typeof(string)));
            tabla.Columns.Add(new DataColumn("NumeroSocio", typeof(int)));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Fila mockup (opcional)
            var fila = tabla.NewRow();
            fila["Id"] = 2;
            fila["Nombre"] = "Juan";
            fila["Apellido"] = "Gómez";
            fila["Dni"] = "87654321";
            fila["FechaNacimiento"] = new DateTime(1990, 3, 20);
            fila["Email"] = "juan.gomez@paciente.com";
            fila["Telefono"] = "1133445566";
            fila["PacienteId"] = 201;
            fila["ObraSocial"] = "OSDE";
            fila["Plan"] = "210";
            fila["NumeroSocio"] = 445566;
            tabla.Rows.Add(fila);

            return tabla;
        }

        #endregion

        #region Crea BD Logs

        private void InicializarTablasLog(DataSet ds)
        {
            try
            {
                if (!ds.Tables.Contains("Log"))
                {
                    ds.Tables.Add(CrearTablaLog());
                    Actualizar_BD(ds);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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


