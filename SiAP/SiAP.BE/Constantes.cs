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
    public class Menu : ClaseBase
    {
        public string Nombre { get; init; }
        public string Etiqueta { get; init; }

        public override string ToString()
        {
            return $"{Id} - {Nombre} - {Etiqueta}";
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
            new Menu(1, "MiCuenta", "TAG01"),
            
            new Menu(2, "Médicos", "TAG02"),
            new Menu(3, "Secretarios", "TAG03"),
            new Menu(4, "Pacientes", "TAG04"),
            
            new Menu(5, "Usuarios", "TAG05"),
            new Menu(6, "Permisos", "TAG06"),

            new Menu(7, "Agenda", "TAG07"),
            new Menu(8, "Turnos", "TAG08"),
            
            new Menu(9, "HistorialMedico", "TAG09"),
            new Menu(10, "Recetas", "TAG10"),
            
            new Menu(11, "Cobros", "TAG11"),
            new Menu(12, "Reportes", "TAG12"),
        };

        public static IReadOnlyList<Menu> ObtenerTodos() => _menus;

        public static Menu Obtener(string cod)
        {
            return _menus.FirstOrDefault(x => x.Etiqueta == cod);
        }
    }

    public static class TiposPersonas
    {
        private static readonly List<Menu> _menus = new()
        {
            new Menu(1, "Medico", "001"),
            new Menu(3, "Secretario", "003"),
        };

        public static IReadOnlyList<Menu> ObtenerTodos() => _menus;
    }

    public static class ConfiguracionCalendario
    {
        public static readonly DayOfWeek[] DiasSemana = new[]
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };

        public static readonly TimeSpan HoraInicio = TimeSpan.FromHours(8);
        public static readonly TimeSpan HoraFin = TimeSpan.FromHours(20);
        public static readonly TimeSpan BloqueHorarioMinimo = TimeSpan.FromMinutes(30);
    }
}

