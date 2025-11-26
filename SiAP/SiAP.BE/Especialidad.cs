using SiAP.BE.Base;

namespace SiAP.BE
{
    public class Especialidad: ClaseBase
    {
        public string Nombre { get; init; }
        public string Etiqueta { get; init; }

        public override string ToString()
        {
            return $"{Id} - {Nombre ?? "[S/inf]"}";
        }
        private Especialidad(int id, string nombre, string etiqueta)
        {
            Id = id;
            Nombre = nombre;
            Etiqueta = etiqueta;
        }

        // Lista de especialidades predefinidas
        private static readonly List<Especialidad> _todas = new()
        {
            new(1, "Clínica Médica", "Clínica Médica"),
            new(2, "Pediatría", "Pediatría"),
            new(3, "Ginecología", "Ginecología"),
            new(4, "Cardiología", "Cardiología"),
            new(5, "Dermatología", "Dermatología"),
            new(6, "Neurología", "Neurología"),
            new(7, "Traumatología", "Traumatología"),
            new(8, "Oftalmología", "Oftalmología"),
            new(9, "Otorrinolaringología", "Otorrinolaringología"),
            new(10, "Psiquiatría", "Psiquiatría"),
            new(11, "Endocrinología", "Endocrinología"),
            new(12, "Urología", "Urología"),
            new(13, "Neumonología", "Neumonología"),
            new(14, "Reumatología", "Reumatología"),
            new(15, "Gastroenterología", "Gastroenterología")
        };

        public static IReadOnlyList<Especialidad> ObtenerTodas() => _todas;
    }
}