using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using SiAP.BE.Base;

namespace SiAP.UI
{
    public class Menu: ClaseBase
    {
        public string Nombre { get; init; }
        public string Etiqueta { get; init; }

        public string Mostrar
        {
            get { return $"{Nombre} - {Etiqueta}"; }
        }

        public Menu(long id, string nombre, string etiqueta)
        {
            Id = id;
            Nombre = nombre;
            Etiqueta = etiqueta;
        }
    }

    public static class MenusConstantes
    {
        private static readonly List<Menu> _menus = new()
        {
            new Menu(1, "Inicio", "TAG001"),
            new Menu(2, "ModificarClave", "TAG002"),
            new Menu(3, "MiCuenta", "TAG002"),
            new Menu(4, "Usuarios", "TAG003"),
            new Menu(5, "Permisos", "TAG005"),
            new Menu(6, "Turnos", "TAG006"),
            new Menu(7, "HistorialMedico", "TAG007"),
            new Menu(8, "Reportes", "TAG008"),
        };

        public static IReadOnlyList<Menu> ObtenerTodos() => _menus;
        
        public static Menu Obtener(string cod)
        {
            return _menus.FirstOrDefault(x => x.Etiqueta == cod);
        }
    }
}

