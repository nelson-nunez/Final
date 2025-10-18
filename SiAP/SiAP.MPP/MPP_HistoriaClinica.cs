using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;
using Policonsultorio.BE;

namespace SiAP.MPP
{
    public class MPP_HistoriaClinica : MapperBase<HistoriaClinica>, IMapper<HistoriaClinica>
    {
        private readonly MPP_Paciente _mppPaciente;
        private readonly MPP_Consulta _mppConsulta;
        private static MPP_HistoriaClinica _instancia;
        protected override string NombreTabla => "HistoriaClinica";

        private MPP_HistoriaClinica() : base()
        {
            _mppPaciente = MPP_Paciente.ObtenerInstancia();
            _mppConsulta = MPP_Consulta.ObtenerInstancia();
        }

        public static MPP_HistoriaClinica ObtenerInstancia()
        {
            return _instancia ??= new MPP_HistoriaClinica();
        }

        public void Agregar(HistoriaClinica entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Paciente, "La historia clínica debe tener un paciente asociado");

            if (Existe(entidad))
                return;

            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(HistoriaClinica entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Paciente, "La historia clínica debe tener un paciente asociado");

            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(HistoriaClinica entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (TieneDependencias(entidad))
                throw new InvalidOperationException("La historia clínica tiene consultas asociadas y no puede eliminarse.");

            EliminarEntidad(entidad);
        }

        public bool Existe(HistoriaClinica entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(HistoriaClinica entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Consulta", "HistoriaClinicaId");
        }

        public IList<HistoriaClinica> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public HistoriaClinica LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<HistoriaClinica> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var historias = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return historias;

            return campo.ToLower() switch
            {
                "pacienteid" => historias.Where(h => h.Paciente?.Id == Convert.ToInt64(valor)).ToList(),
                "pacientenombre" => historias.Where(h => h.Paciente?.Nombre.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "pacienteapellido" => historias.Where(h => h.Paciente?.Apellido.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                "pacientedni" => historias.Where(h => h.Paciente?.Dni == valor).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        /// Busca la historia clínica de un paciente específico
        public HistoriaClinica BuscarPorPacienteId(long pacienteId)
        {
            return ObtenerTodos().FirstOrDefault(h => h.Paciente?.Id == pacienteId);
        }

        /// Obtiene las historias clínicas de pacientes atendidos por un médico específico
        public IList<HistoriaClinica> BuscarPorMedicoId(long medicoId)
        {
            var todasHistorias = ObtenerTodos();
            var historiasDelMedico = new List<HistoriaClinica>();

            foreach (var historia in todasHistorias)
            {
                // Verificar si alguna consulta de esta historia fue realizada por el médico
                if (historia.Consultas != null &&
                    historia.Consultas.Any(c => c.Medico?.Id == medicoId))
                {
                    historiasDelMedico.Add(historia);
                }
            }

            return historiasDelMedico;
        }

        /// Filtra historias clínicas por múltiples criterios
        public IList<HistoriaClinica> Filtrar(string nombrePaciente, string dniPaciente)
        {
            var historias = ObtenerTodos().Where(h =>
                (!string.IsNullOrWhiteSpace(nombrePaciente) &&
                 (h.Paciente.Nombre.Contains(nombrePaciente, StringComparison.OrdinalIgnoreCase) ||
                  h.Paciente.Apellido.Contains(nombrePaciente, StringComparison.OrdinalIgnoreCase))) ||
                (!string.IsNullOrWhiteSpace(dniPaciente) &&
                 h.Paciente.Dni.Contains(dniPaciente, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            return historias;
        }

        private void AsignarDatos(DataRow dr, HistoriaClinica entidad)
        {
            dr["PacienteId"] = entidad.Paciente?.Id ?? 0;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["FechaCreacion"] = entidad.FechaCreacion;
        }

        private HistoriaClinica HidratarObjeto(DataRow rHistoria)
        {
            var pacienteId = Convert.ToInt64(rHistoria["PacienteId"]);
            var paciente = _mppPaciente.LeerPorId(pacienteId)
                ?? throw new Exception($"Paciente con Id {pacienteId} no encontrado.");

            var historiaId = Convert.ToInt64(rHistoria["Id"]);

            var historia = new HistoriaClinica
            {
                Id = historiaId,
                Paciente = paciente,
                Descripcion = rHistoria["Descripcion"]?.ToString() ?? string.Empty,
                FechaCreacion = Convert.ToDateTime(rHistoria["FechaCreacion"])
            };
            CargarConsultas(historia);
            return historia;
        }

        private void CargarConsultas(HistoriaClinica historia)
        {
            // Obtener todas las consultas de esta historia clínica
            var consultas = _mppConsulta.BuscarPorHistoriaClinicaId(historia.Id);

            if (consultas != null && consultas.Any())
            {
                historia.Consultas = consultas.ToList();
            }
        }
    }
}