using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Medico : MapperBase<Medico>, IMapper<Medico>
    {
        private readonly MPP_Persona _mppPersona;
        private static MPP_Medico _instancia;
        protected override string NombreTabla => "Medico";

        private MPP_Medico() : base()
        {
            _mppPersona = MPP_Persona.ObtenerInstancia();
        }

        public static MPP_Medico ObtenerInstancia()
        {
            return _instancia ??= new MPP_Medico();
        }

        public void Agregar(Medico entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Persona, "El médico debe tener una persona asociada");

            if (Existe(entidad)) 
                return;

            _mppPersona.Agregar(entidad.Persona);
            entidad.PersonaId = entidad.Persona.Id;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Medico entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Persona, "El médico debe tener una persona asociada");

            _mppPersona.Modificar(entidad.Persona);
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Medico entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);

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

        public bool Existe(Medico entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Medico entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Agenda", "MedicoId") ||
                   TieneDependenciasEnTabla(entidad.Id, "Turno", "MedicoId");
        }

        public IList<Medico> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Medico LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Medico> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var medicos = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return medicos;

            return campo.ToLower() switch
            {
                "nombre" => BuscarPorCampo(medicos, campo, valor, m => m.Persona.Nombre),
                "apellido" => BuscarPorCampo(medicos, campo, valor, m => m.Persona.Apellido),
                "dni" => BuscarPorCampo(medicos, campo, valor, m => m.Persona.Dni),
                "email" => BuscarPorCampo(medicos, campo, valor, m => m.Persona.Email),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public IList<Medico> Filtrar(string nombre, string email)
        {
            var secretarios = ObtenerTodos().Where(m =>
                                                (!string.IsNullOrWhiteSpace(nombre) &&
                                                (m.Persona.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) ||
                                                m.Persona.Apellido.Contains(nombre, StringComparison.OrdinalIgnoreCase))) ||
                                                (!string.IsNullOrWhiteSpace(email) &&
                                                m.Persona.Email.Contains(email, StringComparison.OrdinalIgnoreCase)))
                                            .ToList();

            return secretarios.ToList();
        }

        private void AsignarDatos(DataRow dr, Medico entidad)
        {
            dr["PersonaId"] = entidad.PersonaId;
            dr["Titulo"] = entidad.Titulo;
            dr["ArancelConsulta"] = entidad.ArancelConsulta;
            dr["EspecialidadId"] = entidad.Especialidad?.Id ?? 0;
            dr["EspecialidadNombre"] = entidad.Especialidad?.Nombre ?? string.Empty;
        }

        private Medico HidratarObjeto(DataRow rMedico)
        {
            var personaId = Convert.ToInt64(rMedico["PersonaId"]);

            var persona = _mppPersona.LeerPorId(personaId) ?? throw new Exception($"Persona con Id {personaId} no encontrada.");

            var especialidadId = Convert.ToInt32(rMedico["EspecialidadId"]);
            var especialidad = Especialidad.ObtenerTodas().FirstOrDefault(e => e.Id == especialidadId);

            return new Medico
            {
                Id = Convert.ToInt64(rMedico["Id"]),
                PersonaId = personaId,
                Persona = persona,
                Titulo = rMedico["Titulo"].ToString(),
                ArancelConsulta = Convert.ToDecimal(rMedico["ArancelConsulta"]),
                Especialidad = especialidad
            };
        }
    }
}