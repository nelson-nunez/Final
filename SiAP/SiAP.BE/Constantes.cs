using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using SiAP.BE.Base;
using SiAP.BE;

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
            //new Menu(1, "Inicio", "TAG01"),
            new Menu(2, "MiCuenta", "TAG02"),
             
            //new Menu(3, "Personal", "TAG03"),
            new Menu(4, "Medicos", "TAG04"),
            new Menu(5, "Secretarios", "TAG05"),
            
            //new Menu(6, "Turnos", "TAG06"),
            new Menu(7, "Agenda Medica", "TAG07"),
            new Menu(8, "Turnos Pacientes", "TAG08"),
            
            //new Menu(9, "Pacientas", "TAG09"),
            new Menu(10, "Alta Pacientes", "TAG10"),
            new Menu(11, "Historias y Consultas", "TAG11"),
            
            new Menu(12, "Cobros", "TAG12"),
            new Menu(12, "Reportes", "TAG13"),

            //new Menu(14, "Sistema", "TAG14"),
            new Menu(15, "Usuarios", "TAG15"),
            new Menu(16, "Permisos", "TAG16"),
            new Menu(17, "Respaldos", "TAG17"),
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

    public static class TipoCertificados
    {
        private static readonly List<string> _menus = new()
        {
            "AltaMedica",
            "AptitudFisica",
            "CertificadoNacimiento",
            "ControlSalud",
            "Defuncion",
            "Discapacidad",
            "ReposoMedico",
            "Vacunacion",
        };

        public static IReadOnlyList<string> ObtenerTodos() => _menus;
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

    public static class ReferenciasNegocio
    {
        public static string RazonSocialEmisor = "Policonsultorio Centro";
        public static string CUITEmisor = "11-20154248-8";
        public static string DomicilioEmisor = "Laprida 1532";
        public static int PuntoDeVenta = 1;
    }

}

