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
            new Menu(1, "Inicio", "TAG001"),
            new Menu(2, "MiCuenta", "TAG002"),
            new Menu(3, "Usuarios", "TAG003"),
            new Menu(4, "Permisos", "TAG004"),
            new Menu(5, "Médicos", "TAG005"),
            new Menu(6, "Pacientes", "TAG006"),
            new Menu(7, "Turnos", "TAG007"),
            new Menu(8, "HistorialMedico", "TAG008"),
            new Menu(9, "Reportes", "TAG009"),
            new Menu(10, "Agenda", "TAG010"),
            new Menu(11, "Cobros", "TAG011"),
        };

        public static IReadOnlyList<Menu> ObtenerTodos() => _menus;

        public static Menu Obtener(string cod)
        {
            return _menus.FirstOrDefault(x => x.Etiqueta == cod);
        }
    }

    public static class TiposPersonas
    {
        private static readonly List<Menu> _tipos = new()
        {
            new Menu(1, "Médico", "Médico"),
            new Menu(2, "Paciente", "Paciente"),
        };

        public static IReadOnlyList<Menu> ObtenerTodos() => _tipos;
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

