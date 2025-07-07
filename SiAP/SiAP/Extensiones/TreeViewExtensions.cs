using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var nodoUsuario = new TreeNode($"👤 {usuario.Username} - {usuario.Nombre} {usuario.Apellido}")
                {
                    Name = usuario.Id.ToString(),
                    Tag = usuario,
                    ForeColor = Color.DarkBlue
                };

                if (usuario.Permiso is PermisoCompuesto rol)
                {
                    // Reutilizamos el método ya implementado
                    var nodoRol = CrearNodoCompuesto(rol, esRaiz: true);
                    nodoUsuario.Nodes.Add(nodoRol);
                }
                else if (usuario.Permiso != null)
                {
                    var nodoPermiso = CrearNodoSimple(usuario.Permiso);
                    nodoUsuario.Nodes.Add(nodoPermiso);
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
                    TreeNode nodoRol = treeView.Nodes.Add(rol.Id.ToString(), $"{rol.Username}: {rol.Nombre}, {rol.Apellido}");
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

                foreach (var medico in grupo.OrderBy(m => m.Apellido))
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
    }
}
