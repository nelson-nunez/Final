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
        private DataSet _dataSet_Siap;
        private DataSet _dataSet_Logs;
        private DataSet _dataSet_Respaldos;

        #region Constructor e Instancia
        
        private AccesoXML()
        {
            _dataSet_Siap = InicializarBD(ReferenciasBD.BD_Siap);
            _dataSet_Logs = InicializarBD(ReferenciasBD.BD_Log);
            _dataSet_Respaldos = InicializarBD(ReferenciasBD.BD_Respaldo);
        }

        public static AccesoXML ObtenerInstancia()
        {
            return _acceso ??= new AccesoXML();
        }

        #endregion

        #region Leer y Grabar BD

        public DataSet InicializarBD(ReferenciaBD item)
        {
            AsegurarExistenciaArchivo(item);
            var ds = new DataSet();
            ds.ReadXml(item.Path_BD, XmlReadMode.ReadSchema);
            InicializarTablas(ds, item);
            return ds;
        }

        private void AsegurarExistenciaArchivo(ReferenciaBD item)
        {
            string directorio = Path.GetDirectoryName(item.Path_BD);

            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            if (!File.Exists(item.Path_BD))
            {
                using (var writer = XmlWriter.Create(item.Path_BD, new XmlWriterSettings { Indent = true }))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(item.NombreBD);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
       
        public void Actualizar_BDSiAP(DataSet ds)
        {
            ds.WriteXml(ReferenciasBD.BD_Siap.Path_BD, XmlWriteMode.WriteSchema);
        }
        
        public void Actualizar_BDLogs(DataSet ds)
        {
            ds.WriteXml(ReferenciasBD.BD_Log.Path_BD, XmlWriteMode.WriteSchema);
        }

        public void Actualizar_BDRespaldos(DataSet ds)
        {
            ds.WriteXml(ReferenciasBD.BD_Respaldo.Path_BD, XmlWriteMode.WriteSchema);
        }

        public DataSet ObtenerDatos_BDSiAP() => _dataSet_Siap;

        public DataSet ObtenerDatos_BDLogs() => _dataSet_Logs;

        public DataSet ObtenerDatos_BDRespaldos() => _dataSet_Respaldos;
        
        
        #endregion

        #region Respaldos

        public void CrearBackup(string nombre_Backup)
        {
            //AsegurarExistenciaArchivo(ReferenciasBD.BD_Respaldo);
            //AsegurarExistenciaArchivo(ReferenciasBD.BD_Siap);
            //AsegurarExistenciaArchivo(ReferenciasBD.BD_Log);

            //File.Copy(ReferenciasBD.Path_BD, backupFileBD, true);
            //File.Copy(ReferenciasBD.Path_BDLogs, backupFileLogs, true);

            //if (_dataSet_Respaldos == null)
            //    _dataSet_Respaldos = InicializarBD(ReferenciasBD.Path_BDRespaldos, "Backups");
            //if (!_dataSet_Respaldos.Tables.Contains("Respaldo"))
            //    _dataSet_Respaldos.Tables.Add(CrearTablaRespaldo());

            //var tabla = _dataSet_Respaldos.Tables["Respaldo"];
            //// Calcular nuevo Id (simple: max + 1)
            //long nuevoId = 1;
            //if (tabla.Rows.Count > 0)
            //{
            //    nuevoId = Convert.ToInt64(tabla.AsEnumerable().Max(r => r.Field<long>("Id"))) + 1;
            //}

            //var info = new FileInfo(backupFileBD);
            //long tamanioKb = info.Exists ? info.Length / 1024 : 0;
            //tabla.Rows.Add(nuevoId, Path.GetFileName(backupFileBD), "", DateTime.Now, Environment.UserName, tamanioKb);
            //// Persistir DataSet de respaldos en su archivo correspondiente
            //_dataSet_Respaldos.WriteXml(ReferenciasBD.Path_BDRespaldos, XmlWriteMode.WriteSchema);
        }

        public void EliminarBackup(string nombre_Backup)
        {
            //string backupDir = Path.GetDirectoryName(ReferenciasBD.Path_BDRespaldos)
            //                   ?? throw new InvalidOperationException("No se pudo determinar el directorio de respaldos.");

            //string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
            //string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

            //if (File.Exists(backupFileBD)) File.Delete(backupFileBD);
            //if (File.Exists(backupFileLogs)) File.Delete(backupFileLogs);

            //// Actualizar tabla de respaldos en memoria (si existe) y persistir cambios
            //if (_dataSet_Respaldos == null && File.Exists(ReferenciasBD.Path_BDRespaldos))
            //    _dataSet_Respaldos = InicializarBD(ReferenciasBD.Path_BDRespaldos, "Backups");
            //if (_dataSet_Respaldos != null && _dataSet_Respaldos.Tables.Contains("Respaldo"))
            //{
            //    var tabla = _dataSet_Respaldos.Tables["Respaldo"];
            //    var filas = tabla.Select($"NombreArchivo = '{nombre_Backup}_SiAP.xml'");
            //    foreach (var fila in filas)
            //        tabla.Rows.Remove(fila);
            //    // Persistir cambios
            //    _dataSet_Respaldos.WriteXml(ReferenciasBD.Path_BDRespaldos, XmlWriteMode.WriteSchema);
            //}
        }

        public void RestaurarBackup(string nombre_Backup)
        {
            //string backupDir = Path.GetDirectoryName(ReferenciasBD.Path_BDRespaldos)
            //                   ?? throw new InvalidOperationException("No se pudo determinar el directorio de respaldos.");

            //string backupFileBD = Path.Combine(backupDir, $"{nombre_Backup}_SiAP.xml");
            //string backupFileLogs = Path.Combine(backupDir, $"{nombre_Backup}_Logs.xml");

            //if (!File.Exists(backupFileBD))
            //    throw new FileNotFoundException("No se encontró el backup de la base de datos principal.", backupFileBD);
            //if (!File.Exists(backupFileLogs))
            //    throw new FileNotFoundException("No se encontró el backup de la base de datos de logs.", backupFileLogs);
            //// Copiamos los archivos de backup sobre las rutas principales
            //File.Copy(backupFileBD, ReferenciasBD.Path_BD, true);
            //File.Copy(backupFileLogs, ReferenciasBD.Path_BDLogs, true);
            //// Re-inicializamos los DataSets en memoria
            //_dataSet_Siap = InicializarBD(ReferenciasBD.Path_BD, "SiAP");
            //_dataSet_Logs = InicializarBD(ReferenciasBD.Path_BDLogs, "Log");
            //// Opcional: refrescar lista de respaldos desde archivo de respaldos (si existe)
            //if (File.Exists(ReferenciasBD.Path_BDRespaldos))
            //    _dataSet_Respaldos = InicializarBD(ReferenciasBD.Path_BDRespaldos, "Backups");
        }

        #endregion

        #region TODAS LAS TABLAS ACA
       
        private void InicializarTablas(DataSet ds, ReferenciaBD item)
        {
            if (item == ReferenciasBD.BD_Siap)
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
                    { "Certificado", CrearTablaCertificado },
                    { "Medicamento", CrearTablaMedicamento },
                    { "Respaldo", CrearTablaRespaldo },
                };

                foreach (var tabla in tablas)
                {
                    if (!ds.Tables.Contains(tabla.Key))
                    {
                        ds.Tables.Add(tabla.Value());
                        Actualizar_BDSiAP(ds);
                    }
                }
            }
            else if (item == ReferenciasBD.BD_Log)
            {
                if (!ds.Tables.Contains("Log"))
                {
                    ds.Tables.Add(CrearTablaLog());
                    Actualizar_BDLogs(ds);
                }
            }
            else if (item == ReferenciasBD.BD_Respaldo)
            {
                if (!ds.Tables.Contains("Respaldo"))
                {
                    ds.Tables.Add(CrearTablaRespaldo());
                    Actualizar_BDRespaldos(ds);
                }
            }
        }

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

        private DataTable CrearTablaRespaldo()
        {
            var tabla = new DataTable("Respaldo");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("NombreArchivo", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("FechaCreacion", typeof(DateTime));
            tabla.Columns.Add("CreadoPor", typeof(string));
            tabla.Columns.Add("TamanioKB", typeof(long));

            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            return tabla;
        }

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
            tabla.Columns.Add("Profesional", typeof(string));
            tabla.Columns.Add("Nro_Socio", typeof(int));
            tabla.Columns.Add("Obra_social", typeof(string));
            tabla.Columns.Add("Plan", typeof(string));
            tabla.Columns.Add("Observaciones", typeof(string));
            tabla.Columns.Add("EsCronica", typeof(bool));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(
                1,
                1,
                new DateTime(2024, 6, 15),
                "Dra. Ana Pérez - Cardióloga",
                445566,
                "OSDE",
                "210",
                "Tomar con las comidas. No suspender sin indicación médica",
                true
            );

            return tabla;
        }

        private DataTable CrearTablaMedicamento()
        {
            var tabla = new DataTable("Medicamento");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("RecetaId", typeof(long));
            tabla.Columns.Add("NombreComercial", typeof(string));
            tabla.Columns.Add("NombreMonodroga", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.PrimaryKey = new[] { tabla.Columns["Id"] };

            tabla.Rows.Add(
                1,
                1,
                "Enalapril",
                "Enalapril Maleato",
                30
            );

            tabla.Rows.Add(
                2,
                1,
                "Aspirineta",
                "Ácido Acetilsalicílico",
                30
            );

            tabla.Rows.Add(
                3,
                1,
                "Losacor",
                "Losartán Potásico",
                60
            );

            return tabla;
        }

        private DataTable CrearTablaCertificado()
        {
            var tabla = new DataTable("Certificado");
            tabla.Columns.Add("Id", typeof(long));
            tabla.Columns.Add("ConsultaId", typeof(long));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Profesional", typeof(string));
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
                "Dra. Ana Pérez - Cardióloga",
                "Aptitud", // TipoCertificado
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
    }
}


