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

        #region Leer y Grabar BD

        private DataSet ObtenerODatosOInicializar()
        {
            AsegurarExistenciaArchivo(ReferenciasBD.Path_BD, "SiAP");
            var ds = new DataSet();
            ds.ReadXml(ReferenciasBD.Path_BD, XmlReadMode.ReadSchema);
            InicializarTablas(ds);
            return ds;
        }

        public DataSet Obtener_Datos() => _dataSet;

        public void Actualizar_BD(DataSet ds)
        {
            ds.WriteXml(ReferenciasBD.Path_BD, XmlWriteMode.WriteSchema);
        }

        #endregion

        #region Leer y Grabar Logs

        private DataSet ObtenerLOGDatosOInicializar()
        {
            AsegurarExistenciaArchivo(ReferenciasBD.Path_BDLogs, "Log");
            var ds = new DataSet();
            ds.ReadXml(ReferenciasBD.Path_BDLogs, XmlReadMode.ReadSchema);
            InicializarTablasLog(ds);
            return ds;
        }

        public DataSet Obtener_Logs() => _dataSetLogs;

        public void Actualizar_BDLogs(DataSet ds)
        {
            ds.WriteXml(ReferenciasBD.Path_BDLogs, XmlWriteMode.WriteSchema);
        }

        #endregion

        #region Respaldos

        public void CrearBackup(string nombre_Backup)
        {
            string backupDir = ReferenciasBD.NombreCarpetaBackUp;
            string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
            string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

            AsegurarExistenciaArchivo(ReferenciasBD.Path_BD, "SiAP");
            AsegurarExistenciaArchivo(ReferenciasBD.Path_BDLogs, "Log");

            File.Copy(ReferenciasBD.Path_BD, backupFileBD, true);
            File.Copy(ReferenciasBD.Path_BDLogs, backupFileLogs, true);
        }

        public void EliminarBackup(string nombre_Backup)
        {
            string backupDir = ReferenciasBD.NombreCarpetaBackUp;
            string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
            string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

            if (File.Exists(backupFileBD)) File.Delete(backupFileBD);
            if (File.Exists(backupFileLogs)) File.Delete(backupFileLogs);
        }

        public void RestaurarBackup(string nombre_Backup)
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

            _dataSet = ObtenerODatosOInicializar();
        }

        #endregion

        #region Inicializar Tablas

        private void InicializarTablas(DataSet ds)
        {
            var tablas = new Dictionary<string, Func<DataTable>>
            {
                { "Persona", CrearTablaPersona },
                { "Permiso", CrearTablaPermiso },
                { "PermisoHijo", CrearTablaPermisoHijo },
                { "Usuario", CrearTablaUsuario },
                { "UsuarioPermiso", CrearTablaUsuarioPermiso },
                { "Administrador", CrearTablaAdministrador },
                { "Secretario", CrearTablaSecretario },
                { "Medico", CrearTablaMedico },
                { "Paciente", CrearTablaPaciente },
                { "Agenda", CrearTablaAgenda },
                { "Turno", CrearTablaTurno },
                { "Factura", CrearTablaFactura },
                { "Cobro", CrearTablaCobro },
                { "HistoriaClinica", CrearTablaHistoriaClinica },
                { "Consulta", CrearTablaConsulta },
                { "Receta", CrearTablaReceta },
                { "Certificado", CrearTablaCertificado }
            };

            foreach (var tabla in tablas)
            {
                if (!ds.Tables.Contains(tabla.Key))
                {
                    ds.Tables.Add(tabla.Value());
                    Actualizar_BD(ds);
                }
            }
        }

        private void InicializarTablasLog(DataSet ds)
        {
            if (!ds.Tables.Contains("Log"))
            {
                ds.Tables.Add(CrearTablaLog());
                Actualizar_BDLogs(ds);
            }
        }

        #endregion

        #region Tabla Persona (Base)

        private DataTable CrearTablaPersona()
        {
            var tabla = new DataTable("Persona");

            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Dni", typeof(string));
            tabla.Columns.Add("FechaNacimiento", typeof(DateTime));
            tabla.Columns.Add("Email", typeof(string));
            tabla.Columns.Add("Telefono", typeof(string));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Datos iniciales
            tabla.Rows.Add(1, "Admin", "Sistema", "00000000", new DateTime(1990, 1, 1), "admin@sistema.com", "0000000000");
            tabla.Rows.Add(2, "Julio", "Losada", "12345678", new DateTime(1980, 5, 10), "julio@hospital.com", "1122334455");
            tabla.Rows.Add(3, "Ana", "Pérez", "23456789", new DateTime(1980, 5, 10), "ana.perez@hospital.com", "1122334455");
            tabla.Rows.Add(4, "Marcos", "Andrada", "34567890", new DateTime(1981, 8, 20), "marcos@hospital.com", "1122334466");
            tabla.Rows.Add(5, "Marcelo", "Pereira", "45678901", new DateTime(1991, 8, 20), "marcosp@hospital.com", "1122334466");
            tabla.Rows.Add(6, "Juan", "Gómez", "87654321", new DateTime(1990, 3, 20), "juan.gomez@paciente.com", "1133445566");

            return tabla;
        }

        #endregion

        #region Tablas Especializadas (referencian a Persona)

        private DataTable CrearTablaAdministrador()
        {
            var tabla = new DataTable("Administrador");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("PersonaId", typeof(long)); // FK a Persona
            tabla.Columns.Add("Area", typeof(string));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, 1, "Desarrollo"); // Referencia a Persona Id=1
            return tabla;
        }

        private DataTable CrearTablaSecretario()
        {
            var tabla = new DataTable("Secretario");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("PersonaId", typeof(long));
            tabla.Columns.Add("Legajo", typeof(string));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, 2, "0001"); // Referencia a Persona Id=2
            return tabla;
        }

        private DataTable CrearTablaMedico()
        {
            var tabla = new DataTable("Medico");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("PersonaId", typeof(long));
            tabla.Columns.Add("Titulo", typeof(string));
            tabla.Columns.Add("EspecialidadId", typeof(int));
            tabla.Columns.Add("EspecialidadNombre", typeof(string));
            tabla.Columns.Add("ArancelConsulta", typeof(decimal));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, 3, "Doctora en Medicina", 4, "Cardiología", 10000m);
            tabla.Rows.Add(2, 4, "Doctor en Medicina", 2, "Pediatría", 12000m);
            tabla.Rows.Add(3, 5, "Doctor en Medicina", 2, "Pediatría", 9000m);
            tabla.Rows.Add(4, 1, "ADMIN also Doctor", 2, "Pediatría", 9000m);
            return tabla;
        }

        private DataTable CrearTablaPaciente()
        {
            var tabla = new DataTable("Paciente");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("PersonaId", typeof(long));
            tabla.Columns.Add("ObraSocial", typeof(string));
            tabla.Columns.Add("Plan", typeof(string));
            tabla.Columns.Add("NumeroSocio", typeof(int));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, 6, "OSDE", "210", 445566);
            return tabla;
        }

        #endregion

        #region Usuarios y Permisos

        private DataTable CrearTablaUsuario()
        {
            var tabla = new DataTable("Usuario");

            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("Username", typeof(string));
            tabla.Columns.Add("Password", typeof(string));
            tabla.Columns.Add("FechaUltimoCambioPassword", typeof(DateTime));
            tabla.Columns.Add("PalabraClave", typeof(string));
            tabla.Columns.Add("RespuestaClave", typeof(string));
            tabla.Columns.Add("Bloqueado", typeof(bool));
            tabla.Columns.Add("Activo", typeof(bool));
            tabla.Columns.Add("PersonaId", typeof(long));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Usuario admin vinculado a Administrador (Persona Id=1)
            tabla.Rows.Add(1, "admin", "STqG+Tki2fc=", DateTime.Now, "default", "admin", false, true, 1);
            return tabla;
        }

        private DataTable CrearTablaPermiso()
        {
            var tabla = new DataTable("Permiso");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("Codigo", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("EsCompuesto", typeof(bool));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            long idActual = 10;
            tabla.Rows.Add(idActual++, "Administrador", "Permisos administrativos", true);

            foreach (var menu in MenusConstantes.ObtenerTodos())
            {
                tabla.Rows.Add(idActual++, menu.Etiqueta, menu.Nombre, false);
            }

            return tabla;
        }

        private DataTable CrearTablaPermisoHijo()
        {
            var tabla = new DataTable("PermisoHijo");
            tabla.Columns.Add("PadreId", typeof(long));
            tabla.Columns.Add("HijoId", typeof(long));
            tabla.PrimaryKey = new[] { tabla.Columns["PadreId"], tabla.Columns["HijoId"] };

            long idAdministrador = 10;
            long idHijo = 11;

            foreach (var menu in MenusConstantes.ObtenerTodos())
            {
                tabla.Rows.Add(idAdministrador, idHijo++);
            }

            return tabla;
        }

        private DataTable CrearTablaUsuarioPermiso()
        {
            var tabla = new DataTable("UsuarioPermiso");
            tabla.Columns.Add("UsuarioId", typeof(long));
            tabla.Columns.Add("PermisoId", typeof(long));
            tabla.PrimaryKey = new[] { tabla.Columns["UsuarioId"], tabla.Columns["PermisoId"] };

            tabla.Rows.Add(1, 10); // Admin tiene permiso Administrador
            return tabla;
        }

        #endregion

        #region Tablas de Negocio

        private DataTable CrearTablaAgenda()
        {
            var tabla = new DataTable("Agenda");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("HoraInicio", typeof(TimeSpan));
            tabla.Columns.Add("HoraFin", typeof(TimeSpan));
            tabla.Columns.Add("MedicoId", typeof(long));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            var fechaBase = DateTime.Today.Date;
            long idAgenda = 1;

            // Crear agenda para los 3 médicos
            for (int medicoId = 1; medicoId <= 3; medicoId++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                    var fecha = fechaBase.AddDays(dia);
                    for (int hora = 8; hora < 13; hora++)
                    {
                        tabla.Rows.Add(idAgenda++, fecha, new TimeSpan(hora, 0, 0),
                            new TimeSpan(hora + 1, 0, 0), medicoId);
                    }
                }
            }

            return tabla;
        }

        private DataTable CrearTablaTurno()
        {
            var tabla = new DataTable("Turno");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("HoraInicio", typeof(TimeSpan));
            tabla.Columns.Add("HoraFin", typeof(TimeSpan));
            tabla.Columns.Add("TipoAtencion", typeof(string));
            tabla.Columns.Add("Estado", typeof(string));
            tabla.Columns.Add("MedicoId", typeof(long));
            tabla.Columns.Add("PacienteId", typeof(long));
            tabla.Columns.Add("AgendaId", typeof(long));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, new DateTime(2025, 7, 8), new TimeSpan(9, 0, 0),
                new TimeSpan(10, 0, 0), "Consulta general", EstadoTurno.Asignado.ToString(),
                1, 1, 12);

            return tabla;
        }

        private DataTable CrearTablaFactura()
        {
            var tabla = new DataTable("Factura");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("FechaEmision", typeof(DateTime));
            tabla.Columns.Add("NumeroFactura", typeof(string));
            tabla.Columns.Add("Importe", typeof(decimal));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Estado", typeof(string));
            tabla.Columns.Add("TurnoId", typeof(long));
            tabla.Columns.Add("PacienteId", typeof(long));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, new DateTime(2025, 7, 8), "F0001-00000001", 10000m, "Consulta médica general", EstadoFactura.Emitida.ToString(), 1, 1);
            tabla.Rows.Add(2, new DateTime(2025, 7, 9), "F0001-00000002", 12000m, "Consulta pediátrica", EstadoFactura.Pagada.ToString(), 1, 1);

            return tabla;
        }

        private DataTable CrearTablaCobro()
        {
            var tabla = new DataTable("Cobro");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("FechaHora", typeof(DateTime));
            tabla.Columns.Add("TipoPago", typeof(string));
            tabla.Columns.Add("Monto", typeof(decimal));
            tabla.Columns.Add("Estado", typeof(string));
            tabla.Columns.Add("FacturaId", typeof(long));
            tabla.Columns.Add("FormaPagoId", typeof(long));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(1, new DateTime(2025, 7, 8, 10, 30, 0), "Efectivo", 5000m,
                EstadoCobro.Registrado.ToString(), 1, 1);
            tabla.Rows.Add(2, new DateTime(2025, 7, 9, 12, 0, 0), "Transferencia", 12000m,
                EstadoCobro.Confirmado.ToString(), 2, 4);

            return tabla;
        }

        #endregion

        #region Tablas Historia Clínica

        private DataTable CrearTablaHistoriaClinica()
        {
            var tabla = new DataTable("HistoriaClinica");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("PacienteId", typeof(long));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("FechaCreacion", typeof(DateTime));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Historia clínica del paciente 1 (Juan Gómez)
            tabla.Rows.Add(1, 1, "Historia clínica inicial - Paciente Juan Gómez", new DateTime(2024, 1, 15));

            return tabla;
        }

        private DataTable CrearTablaConsulta()
        {
            var tabla = new DataTable("Consulta");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("HistoriaClinicaId", typeof(long));
            tabla.Columns.Add("MedicoId", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Motivo", typeof(string));
            tabla.Columns.Add("Diagnostico", typeof(string));
            tabla.Columns.Add("Tratamiento", typeof(string));
            tabla.Columns.Add("Observaciones", typeof(string));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Consulta para el paciente 1 con el médico 1 (Ana Pérez - Cardióloga)
            tabla.Rows.Add(
                1, // Id
                1, // HistoriaClinicaId (Historia del paciente 1)
                1, // MedicoId (Ana Pérez - Cardióloga)
                new DateTime(2024, 6, 15, 10, 30, 0), // Fecha
                "Control de rutina y dolor en el pecho", // Motivo
                "Hipertensión leve. Precarga cardíaca aumentada", // Diagnostico
                "Enalapril 10mg, 1 comprimido cada 12 horas. Control en 30 días", // Tratamiento
                "Paciente refiere episodios de dolor torácico ocasional. PA: 145/90. Se indica tratamiento y estudios complementarios" // Observaciones
            );

            return tabla;
        }

        private DataTable CrearTablaReceta()
        {
            var tabla = new DataTable("Receta");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("ConsultaId", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Medicamentos", typeof(string));
            tabla.Columns.Add("Profesional", typeof(string));
            tabla.Columns.Add("Nro_Socio", typeof(int));
            tabla.Columns.Add("Obra_social", typeof(string));
            tabla.Columns.Add("Plan", typeof(string));
            tabla.Columns.Add("Observaciones", typeof(string));
            tabla.Columns.Add("EsCronica", typeof(bool));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Receta de la consulta 1
            tabla.Rows.Add(
                1, // Id
                1, // ConsultaId
                new DateTime(2024, 6, 15), // Fecha
                "Enalapril 10mg - 1 comprimido cada 12 horas\nAspirina 100mg - 1 comprimido por día", // Medicamentos
                "Dra. Ana Pérez - Cardióloga", // Profesional
                445566, // Nro_Socio (del paciente 1)
                "OSDE", // Obra_social
                "210", // Plan
                "Tomar con las comidas. No suspender sin indicación médica", // Observaciones
                true // EsCronica
            );

            return tabla;
        }

        private DataTable CrearTablaCertificado()
        {
            var tabla = new DataTable("Certificado");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("ConsultaId", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("TipoCertificado", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Observaciones", typeof(string));
            tabla.Columns.Add("FechaVigenciaDesde", typeof(DateTime));
            tabla.Columns.Add("FechaVigenciaHasta", typeof(DateTime));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            // Certificado médico de la consulta 1
            tabla.Rows.Add(
                1, // Id
                1, // ConsultaId
                new DateTime(2024, 6, 15), // Fecha
                "Certificado Médico de Aptitud Física", // TipoCertificado
                "El paciente Juan Gómez (DNI 87654321) se encuentra bajo tratamiento por hipertensión leve. " +
                "Se recomienda evitar actividades físicas de alta intensidad hasta nuevo control médico. " +
                "Puede realizar actividades físicas moderadas con autorización médica.", // Descripcion
                "Control en 30 días. Presentar certificado actualizado según evolución del cuadro", // Observaciones
                new DateTime(2024, 6, 15), // FechaVigenciaDesde
                new DateTime(2024, 7, 15) // FechaVigenciaHasta (30 días de vigencia)
            );

            return tabla;
        }

        #endregion

        #region Logs

        private DataTable CrearTablaLog()
        {
            var tabla = new DataTable("Log");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Usuario", typeof(string));
            tabla.Columns.Add("Operacion", typeof(string));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };
            return tabla;
        }

        #endregion
    }
}


