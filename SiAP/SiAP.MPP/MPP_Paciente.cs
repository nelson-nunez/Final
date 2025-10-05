using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Paciente : MapperBase<Paciente>, IMapper<Paciente>
    {
        private readonly MPP_Persona _mppPersona;
        private static MPP_Paciente _instancia;
        protected override string NombreTabla => "Paciente";

        private MPP_Paciente() : base()
        {
            _mppPersona = MPP_Persona.ObtenerInstancia();
        }

        public static MPP_Paciente ObtenerInstancia()
        {
            return _instancia ??= new MPP_Paciente();
        }

        public void Agregar(Paciente entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Persona, "El paciente debe tener una persona asociada");

            if (Existe(entidad)) return;
            _mppPersona.Agregar(entidad.Persona);
            entidad.PersonaId = entidad.Persona.Id;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Paciente entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Persona, "El paciente debe tener una persona asociada");
            _mppPersona.Modificar(entidad.Persona);
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Paciente entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables[NombreTabla].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);

            if (dr != null)
            {
                long personaId = Convert.ToInt64(dr["PersonaId"]);
                EliminarEntidad(entidad);
                var persona = _mppPersona.LeerPorId(personaId);
                if (persona != null && !_mppPersona.TieneDependencias(persona))
                {
                    _mppPersona.Eliminar(persona);
                }
            }
        }

        public bool Existe(Paciente entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Paciente entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Turno", "PacienteId") ||
                   TieneDependenciasEnTabla(entidad.Id, "Factura", "PacienteId");
        }

        public IList<Paciente> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public IList<Paciente> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var pacientes = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return pacientes;

            return campo.ToLower() switch
            {
                "nombre" => pacientes.Where(p => p.Persona.Nombre.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "apellido" => pacientes.Where(p => p.Persona.Apellido.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "dni" => pacientes.Where(p => p.Persona.Dni == valor).ToList(),
                "email" => pacientes.Where(p => p.Persona.Email.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "obrasocial" => pacientes.Where(p => p.ObraSocial.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "numerosocio" => pacientes.Where(p => p.NumeroSocio.ToString().Contains(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Paciente LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        private void AsignarDatos(DataRow dr, Paciente entidad)
        {
            dr["PersonaId"] = entidad.PersonaId;
            dr["ObraSocial"] = entidad.ObraSocial;
            dr["Plan"] = entidad.Plan;
            dr["NumeroSocio"] = entidad.NumeroSocio;
        }

        private Paciente HidratarObjeto(DataRow rPaciente)
        {
            var personaId = Convert.ToInt64(rPaciente["PersonaId"]);
            var persona = _mppPersona.LeerPorId(personaId)
                ?? throw new Exception($"Persona con Id {personaId} no encontrada.");

            return new Paciente
            {
                Id = Convert.ToInt64(rPaciente["Id"]),
                PersonaId = personaId,
                Persona = persona,
                ObraSocial = rPaciente["ObraSocial"].ToString(),
                Plan = rPaciente["Plan"].ToString(),
                NumeroSocio = Convert.ToInt32(rPaciente["NumeroSocio"])
            };
        }
    }
}