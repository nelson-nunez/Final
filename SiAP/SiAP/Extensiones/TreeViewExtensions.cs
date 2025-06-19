using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region ROLES

        public static void ArmarArbolSoloRoles(this TreeView treeView, List<Permiso> permisos)
        {
            ArgumentNullException.ThrowIfNull(treeView);

            treeView.Nodes.Clear();
            foreach (var permiso in permisos.OfType<PermisoCompuesto>())
            {
                var nodo = CrearNodoCompuesto(permiso, esRaiz: true);

                if (nodo != null)
                    treeView.Nodes.Add(nodo);
            }
        }

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
            var nodo = new TreeNode($"{permiso.Codigo}-{permiso.Descripcion}")
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
            return new TreeNode($"{permiso.Codigo}-{permiso.Descripcion}")
            {
                Name = permiso.Codigo,
                Tag = permiso,
                ForeColor = Color.DarkRed
            };
        }
        
        #endregion

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
    }
}
