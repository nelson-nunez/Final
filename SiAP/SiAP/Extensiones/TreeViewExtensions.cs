using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policonsultorio.BE;
using SiAP.BE;
using SiAP.BE.Seguridad;

namespace SiAP.UI.Extensiones
{
    public static class TreeViewExtensions
    {
        public static T VerificarYRetornarSeleccion<T>(this TreeView tree, string nombre = "elemento") where T : class
        {
            ArgumentNullException.ThrowIfNull(tree);

            if (tree.Nodes.Count == 0)
                throw new InvalidOperationException($"El árbol no contiene ningún '{nombre}'.");

            if (tree.SelectedNode?.Tag is not T seleccionado)
                throw new InvalidOperationException($"Debe seleccionar un '{nombre}' válido para continuar.");

            return seleccionado;
        }

        #region USUARIOS ROLES Y PERMISOS

        public static void ArmarArbolDeUsuariosConRoles(this TreeView treeView, List<Usuario> usuarios)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            treeView.Nodes.Clear();
            foreach (var usuario in usuarios)
            {
                var nodoUsuario = new TreeNode($"👤 {usuario.Username} - {usuario.Persona?.Nombre} {usuario.Persona?.Apellido}")
                {
                    Name = usuario.Id.ToString(),
                    Tag = usuario,
                    ForeColor = Color.DarkBlue
                };
                // Verificar si el usuario tiene permisos
                if (usuario.Permisos != null && usuario.Permisos.Any())
                {
                    foreach (var permiso in usuario.Permisos)
                    {
                        TreeNode nodoPermiso;
                        if (permiso is PermisoCompuesto permisoCompuesto)
                        {
                            nodoPermiso = CrearNodoCompuesto(permisoCompuesto, esRaiz: true);
                        }
                        else
                        {
                            nodoPermiso = CrearNodoSimple(permiso);
                        }
                        nodoUsuario.Nodes.Add(nodoPermiso);
                    }
                }
                treeView.Nodes.Add(nodoUsuario);
            }
        }

        #endregion

        #region SOLO ROLES

        public static void ArmarArbolSoloRoles(this TreeView treeView, List<Permiso> permisos)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            var tt = permisos.OfType<PermisoCompuesto>();
            var tr = permisos.OfType<PermisoSimple>();

            treeView.Nodes.Clear();
            foreach (var permiso in permisos.OfType<PermisoCompuesto>())
            {
                var nodo = CrearNodo(permiso, esRaiz: true);

                if (nodo != null)
                    treeView.Nodes.Add(nodo);
            }
        }

        private static TreeNode CrearNodo(PermisoCompuesto permiso, bool esRaiz)
        {
            var nodo = new TreeNode($"Rol: {permiso.Codigo}-{permiso.Descripcion}")
            {
                Name = permiso.Codigo,
                Tag = permiso,
                ForeColor = esRaiz ? Color.Black : Color.DarkGreen
            };

            foreach (var hijo in permiso.ObtenerPermisos().OfType<PermisoCompuesto>())
            {
                var nodoHijo = CrearNodo(hijo, esRaiz: false);
                if (nodoHijo != null)
                    nodo.Nodes.Add(nodoHijo);
            }

            return nodo;
        }

        #endregion

        #region ROLES Y PERMISOS

        public static void ArmarArbolDeRoles(this TreeView treeView, List<Permiso> permisos)
        {
            ArgumentNullException.ThrowIfNull(treeView);

            treeView.Nodes.Clear();
            foreach (var permiso in permisos?.OfType<PermisoCompuesto>() ?? [])
            {
                var nodo = CrearNodoCompuesto(permiso, esRaiz: true);
                treeView.Nodes.Add(nodo);
            }
        }

        private static TreeNode CrearNodoCompuesto(PermisoCompuesto permiso, bool esRaiz)
        {
            var nodo = new TreeNode($"Rol: {permiso.Codigo}-{permiso.Descripcion}")
            {
                Name = permiso.Codigo,
                Tag = permiso,
                ForeColor = esRaiz ? Color.Black : Color.DarkGreen
            };

            foreach (var hijo in permiso.ObtenerPermisos())
            {
                var nodoHijo = hijo switch
                {
                    PermisoCompuesto compuesto => CrearNodoCompuesto(compuesto, esRaiz: false),
                    _ => CrearNodoSimple(hijo)
                };
                nodo.Nodes.Add(nodoHijo);
            }

            return nodo;
        }

        private static TreeNode CrearNodoSimple(Permiso permiso)
        {
            return new TreeNode($"Permiso: {permiso.Codigo}-{permiso.Descripcion}")
            {
                Name = permiso.Codigo,
                Tag = permiso,
                ForeColor = Color.DarkRed
            };
        }

        #endregion

        #region PERMISOS

        public static void ArmarArbolPermisosSimples(this TreeView treeView, List<Permiso> permisos)
        {
            if (treeView == null)
                throw new ArgumentNullException(nameof(treeView)); 
            
            treeView.Nodes.Clear();
            foreach (var permiso in permisos)
            {
                if (permiso is PermisoSimple rol)
                {
                    TreeNode nodoRol = treeView.Nodes.Add(rol.Codigo, $"{rol.Codigo}-{rol.Descripcion}");
                    nodoRol.Tag = rol;
                }
            }
        }

        public static void ArmarArbolSimple(this TreeView treeView, List<Usuario> usuarios)
        {
            if (treeView == null)
                throw new ArgumentNullException(nameof(treeView));

            HashSet<string> codigosAgregados = new(); // Para evitar duplicados
            treeView.Nodes.Clear();
            foreach (var usuario in usuarios)
            {
                if (usuario is Usuario rol)
                {
                    TreeNode nodoRol = treeView.Nodes.Add(rol.Id.ToString(), $"{rol.Username}: {rol.Persona.Nombre}, {rol.Persona.Apellido}");
                    nodoRol.Tag = rol;
                }
            }
        }
        #endregion

        #region Medicos
        public static void ArmarArbolMedicos(this TreeView treeView, List<Medico> medicos)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            if (medicos == null) return;

            treeView.Nodes.Clear();

            // Agrupar médicos por especialidad
            var grupos = medicos
                .Where(m => m.Especialidad != null)
                .GroupBy(m => m.Especialidad.Nombre)
                .OrderBy(g => g.Key);

            foreach (var grupo in grupos)
            {
                var nodoEspecialidad = new TreeNode($"Especialidad: {grupo.Key}")
                {
                    Name = grupo.Key,
                    Tag = grupo.First().Especialidad
                };

                foreach (var medico in grupo.OrderBy(m => m.Persona.Apellido))
                {
                    var nodoMedico = new TreeNode(medico.ToString())
                    {
                        Name = $"Medico_{medico.Id}",
                        Tag = medico,
                        ForeColor = Color.DarkGreen
                    };
                    nodoEspecialidad.Nodes.Add(nodoMedico);
                }

                treeView.Nodes.Add(nodoEspecialidad);
            }
        }

        #endregion

        #region Pacientes
        
        public static void ArmarArbolConsultas(this TreeView treeView, List<Consulta> consultas)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            if (consultas == null) return;

            treeView.Nodes.Clear();

            if (!consultas.Any())
            {
                treeView.Nodes.Add(new TreeNode("No hay consultas registradas")
                {
                    ForeColor = Color.Gray
                });
                return;
            }

            var grupos = consultas
                .GroupBy(c => new { c.Fecha.Year, c.Fecha.Month })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Month);

            foreach (var grupo in grupos)
            {
                string nombreMes = new DateTime(grupo.Key.Year, grupo.Key.Month, 1).ToString("MMMM yyyy");
                var nodoMes = new TreeNode($"📅 {nombreMes} ({grupo.Count()} consultas)")
                {
                    Name = $"{grupo.Key.Year}_{grupo.Key.Month}",
                    ForeColor = Color.DarkBlue
                };

                foreach (var consulta in grupo.OrderByDescending(c => c.Fecha))
                {
                    string nombreMedico = consulta.Medico?.Persona?.NombreCompleto ?? "Sin médico";
                    string especialidad = consulta.Medico?.Especialidad?.Nombre ?? "Sin especialidad";
                    string motivo = consulta.Motivo ?? "Sin motivo";

                    if (motivo.Length > 50)
                        motivo = motivo.Substring(0, 47) + "...";

                    string textoNodo = $"{consulta.Fecha:dd/MM} - {nombreMedico} ({especialidad}) - {motivo}";

                    var nodoConsulta = new TreeNode(textoNodo)
                    {
                        Name = $"Consulta_{consulta.Id}",
                        Tag = consulta,
                        ForeColor = Color.DarkGreen
                    };
                    nodoMes.Nodes.Add(nodoConsulta);
                }
                treeView.Nodes.Add(nodoMes);
            }
        }

        public static void ArmarArbolRecetas(this TreeView treeView, List<Consulta> consultas)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            if (consultas == null) return;

            treeView.Nodes.Clear();

            var todasLasRecetas = consultas
                .Where(c => c.Recetas != null && c.Recetas.Any())
                .SelectMany(c => c.Recetas)
                .ToList();

            if (!todasLasRecetas.Any())
            {
                treeView.Nodes.Add(new TreeNode("No hay recetas registradas")
                {
                    ForeColor = Color.Gray
                });
                return;
            }

            var grupos = todasLasRecetas
                .GroupBy(r => new { r.Fecha.Year, r.Fecha.Month })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Month);

            foreach (var grupo in grupos)
            {
                string nombreMes = new DateTime(grupo.Key.Year, grupo.Key.Month, 1).ToString("MMMM yyyy");
                var nodoMes = new TreeNode($"📅 {nombreMes} ({grupo.Count()} recetas)")
                {
                    Name = $"{grupo.Key.Year}_{grupo.Key.Month}",
                    ForeColor = Color.DarkBlue
                };

                foreach (var receta in grupo.OrderByDescending(r => r.Fecha))
                {
                    string profesional = receta.Profesional ?? "Sin profesional";
                    string medicamentos = ObtenerTextoMedicamentos(receta.Medicamentos);

                    string textoNodo = $"{receta.Fecha:dd/MM/yyyy} - {profesional} - {medicamentos}";

                    var nodoReceta = new TreeNode(textoNodo)
                    {
                        Name = $"Receta_{receta.Id}",
                        Tag = receta,
                        ForeColor = Color.DarkGreen
                    };

                    nodoMes.Nodes.Add(nodoReceta);
                }

                treeView.Nodes.Add(nodoMes);
            }
        }

        private static string ObtenerTextoMedicamentos(List<Medicamento> medicamentos)
        {
            if (medicamentos == null || !medicamentos.Any())
                return "Sin medicamentos";

            var primer = medicamentos.First();
            string nombre = !string.IsNullOrWhiteSpace(primer.NombreComercial)
                ? primer.NombreComercial
                : primer.NombreMonodroga;

            if (medicamentos.Count > 1)
                nombre += $" (+{medicamentos.Count - 1})";

            if (nombre.Length > 20)
                nombre = nombre.Substring(0, 17) + "...";

            return nombre;
        }

        public static void ArmarArbolCertificados(this TreeView treeView, List<Consulta> consultas)
        {
            ArgumentNullException.ThrowIfNull(treeView);

            treeView.Nodes.Clear();

            if (consultas == null)
                return;

            var todosCertificados = consultas.Where(c => c.Certificados != null && c.Certificados.Any()).SelectMany(c => c.Certificados).ToList();

            if (!todosCertificados.Any())
            {
                treeView.Nodes.Add(new TreeNode("No hay certificados registrados")
                {
                    ForeColor = Color.Gray
                });
                return;
            }

            var grupos = todosCertificados.GroupBy(cert => new { cert.Fecha.Year, cert.Fecha.Month })
                .OrderByDescending(g => g.Key.Year).ThenByDescending(g => g.Key.Month);

            foreach (var grupo in grupos)
            {
                string nombreMes = new DateTime(grupo.Key.Year, grupo.Key.Month, 1).ToString("MMMM yyyy", CultureInfo.CurrentCulture);
                var nodoMes = new TreeNode($"📅 {nombreMes} ({grupo.Count()} certificados)")
                {
                    Name = $"{grupo.Key.Year}_{grupo.Key.Month}",
                    ForeColor = Color.DarkBlue
                };

                foreach (var certificado in grupo.OrderByDescending(c => c.Fecha))
                {
                    string tipoCertificado = certificado.TipoCertificado ?? "Sin tipo";
                    string descripcion = certificado.Descripcion ?? "Sin descripción";
                    string textoNodo = $"{certificado.Fecha:dd/MM/yyyy} - {tipoCertificado} - {descripcion}";

                    var nodoCertificado = new TreeNode(textoNodo)
                    {
                        Name = $"Certificado_{certificado.Id}",
                        Tag = certificado,
                        ForeColor = Color.DarkGreen
                    };

                    nodoMes.Nodes.Add(nodoCertificado);
                }

                treeView.Nodes.Add(nodoMes);
            }
        }

        #endregion

        #region Respaldos

        public static void ArmarArbolRespaldosSimple(this TreeView treeView, List<Respaldo> respaldos)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            if (respaldos == null) return;

            treeView.Nodes.Clear();

            // Agrupar respaldos por año
            var grupos = respaldos
                .GroupBy(r => r.FechaCreacion.Year)
                .OrderByDescending(g => g.Key);

            foreach (var grupo in grupos)
            {
                var cantidadRespaldos = grupo.Count();
                var tamanioTotalMB = grupo.Sum(r => r.TamanioKB) / 1024.0;

                var nodoAnio = new TreeNode($"Año {grupo.Key} ({cantidadRespaldos} respaldos - {tamanioTotalMB:F2} MB)")
                {
                    Name = $"Anio_{grupo.Key}",
                    Tag = grupo.Key
                };

                foreach (var respaldo in grupo.OrderByDescending(r => r.FechaCreacion))
                {
                    var tamanioMB = respaldo.TamanioKB / 1024.0;
                    var textoRespaldo = $"{respaldo.NombreArchivo} - " +
                                      $"{respaldo.FechaCreacion:dd/MM/yyyy HH:mm} - " +
                                      $"{tamanioMB:F2} MB";

                    if (!string.IsNullOrWhiteSpace(respaldo.Descripcion))
                        textoRespaldo += $" - {respaldo.Descripcion}";

                    var nodoRespaldo = new TreeNode(textoRespaldo)
                    {
                        Name = $"Respaldo_{respaldo.Id}",
                        Tag = respaldo,
                        ForeColor = Color.DarkGreen,
                        ToolTipText = $"Creado por: {respaldo.CreadoPor}"
                    };

                    nodoAnio.Nodes.Add(nodoRespaldo);
                }

                treeView.Nodes.Add(nodoAnio);
            }

            // Expandir el año actual por defecto
            var nodoAnioActual = treeView.Nodes.Find($"Anio_{DateTime.Now.Year}", false).FirstOrDefault();
            nodoAnioActual?.Expand();
        }

        #endregion
    }
}
