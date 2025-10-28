using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE;
using SiAP.BE.Base;

namespace Policonsultorio.BE
{
    public class Receta : ClaseBase
    {
        public DateTime Fecha { get; set; }
        public int Nro_Socio { get; set; }
        public string Obra_social { get; set; }
        public string Observaciones { get; set; }
        public string Plan { get; set; }
        public string Profesional { get; set; }
        public long ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
        public bool EsCronica { get; set; }
        public List<Medicamento> Medicamentos { get; set; }

        #region Constructor
        public Receta()
        {
            Fecha = DateTime.Now;
            EsCronica = false;
            Medicamentos = new List<Medicamento>();
        }
        #endregion

        #region Métodos Principales
        public void CrearReceta()
        {
            if (!ValidarReceta())
                throw new InvalidOperationException("Datos de receta incompletos");
            Fecha = DateTime.Now;
        }

        public bool ValidarReceta()
        {
            if (string.IsNullOrWhiteSpace(Profesional))
                return false;
            if (Fecha == default(DateTime))
                return false;
            if (Medicamentos == null || Medicamentos.Count == 0)
                return false;
            return true;
        }

        public Receta RenovarReceta()
        {
            if (!EsCronica)
                throw new InvalidOperationException("Solo se pueden renovar recetas crónicas");

            var recetaRenovada = new Receta
            {
                Medicamentos = new List<Medicamento>(this.Medicamentos.Select(m => new Medicamento
                {
                    NombreComercial = m.NombreComercial,
                    NombreMonodroga = m.NombreMonodroga,
                    Cantidad = m.Cantidad
                })),
                Profesional = this.Profesional,
                Obra_social = this.Obra_social,
                Nro_Socio = this.Nro_Socio,
                Plan = this.Plan,
                Observaciones = "Renovación de receta crónica",
                EsCronica = true,
                Fecha = DateTime.Now
            };
            return recetaRenovada;
        }

        public void MarcarComoCronica()
        {
            EsCronica = true;
        }

        public bool ValidarVigencia()
        {
            int diasVigencia = EsCronica ? 180 : 30;
            return (DateTime.Now - Fecha).Days <= diasVigencia;
        }

        public void AgregarMedicamento(Medicamento Medicamento)
        {
            if (Medicamento == null)
                throw new ArgumentNullException(nameof(Medicamento));

            if (string.IsNullOrWhiteSpace(Medicamento.NombreComercial) &&
                string.IsNullOrWhiteSpace(Medicamento.NombreMonodroga))
                throw new ArgumentException("El medicamento debe tener al menos un nombre");

            if (Medicamentos == null)
                Medicamentos = new List<Medicamento>();

            Medicamentos.Add(Medicamento);
        }

        public void AgregarMedicamento(string nombreComercial, string nombreMonodroga, int cantidad)
        {
            var Medicamento = new Medicamento
            {
                NombreComercial = nombreComercial,
                NombreMonodroga = nombreMonodroga,
                Cantidad = cantidad
            };
            AgregarMedicamento(Medicamento);
        }

        public void EliminarMedicamento(Medicamento Medicamento)
        {
            if (Medicamentos != null && Medicamento != null)
                Medicamentos.Remove(Medicamento);
        }

        public List<Medicamento> ObtenerMedicamentos()
        {
            return Medicamentos ?? new List<Medicamento>();
        }

        public int CantidadMedicamentos()
        {
            return Medicamentos?.Count ?? 0;
        }
        #endregion

        #region Métodos Override
        public override string ToString()
        {
            return $"Receta #{Id} - {Fecha.ToShortDateString()} - {Profesional}";
        }
        #endregion
    }
}