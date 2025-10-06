using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Secretario : MapperBase<Secretario>, IMapper<Secretario>
    {
        private readonly MPP_Persona _mppPersona;
        private static MPP_Secretario _instancia;
        protected override string NombreTabla => "Secretario";

        private MPP_Secretario() : base()
        {
            _mppPersona = MPP_Persona.ObtenerInstancia();
        }

        public static MPP_Secretario ObtenerInstancia()
        {
            return _instancia ??= new MPP_Secretario();
        }

        public void Agregar(Secretario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Persona, "El secretario debe tener una persona asociada");

            if (Existe(entidad)) return;

            _mppPersona.Agregar(entidad.Persona);
            entidad.PersonaId = entidad.Persona.Id;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Secretario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Persona, "El secretario debe tener una persona asociada");

            _mppPersona.Modificar(entidad.Persona);
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Secretario entidad)
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
                    _mppPersona.Eliminar(persona);
            }
        }

        public bool Existe(Secretario entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Secretario entidad)
        {
            return _mppPersona.TieneDependencias(entidad.Persona);
        }

        public IList<Secretario> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public IList<Secretario> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var secretarios = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return secretarios;

            return campo.ToLower() switch
            {
                "nombre" => secretarios.Where(s => s.Persona.Nombre.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "apellido" => secretarios.Where(s => s.Persona.Apellido.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "dni" => secretarios.Where(s => s.Persona.Dni == valor).ToList(),
                "legajo" => secretarios.Where(s => s.Legajo.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                "email" => secretarios.Where(s => s.Persona.Email.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public IList<Secretario> Filtrar(string nombre, string email)
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

        public Secretario LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        private void AsignarDatos(DataRow dr, Secretario entidad)
        {
            dr["PersonaId"] = entidad.PersonaId;
            dr["Legajo"] = entidad.Legajo;
        }

        private Secretario HidratarObjeto(DataRow rSecretario)
        {
            var personaId = Convert.ToInt64(rSecretario["PersonaId"]);

            // Usar MPP_Persona para obtener la persona
            var persona = _mppPersona.LeerPorId(personaId)
                ?? throw new Exception($"Persona con Id {personaId} no encontrada.");

            return new Secretario
            {
                Id = Convert.ToInt64(rSecretario["Id"]),
                PersonaId = personaId,
                Persona = persona,
                Legajo = rSecretario["Legajo"].ToString()
            };
        }
    }
}