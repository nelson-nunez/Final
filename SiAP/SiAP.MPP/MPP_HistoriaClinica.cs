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

        public void AsignarDatos(DataRow dr, HistoriaClinica entidad)
        {
            dr["PacienteId"] = entidad.Paciente?.Id ?? 0;
            dr["Descripcion"] = entidad.Descripcion ?? string.Empty;
            dr["FechaCreacion"] = entidad.FechaCreacion;
        }

        public HistoriaClinica HidratarObjeto(DataRow rHistoria)
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

        //Otros
        public HistoriaClinica BuscarPorPacienteId(long pacienteId)
        {
            return ObtenerTodos().FirstOrDefault(h => h.Paciente?.Id == pacienteId);
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