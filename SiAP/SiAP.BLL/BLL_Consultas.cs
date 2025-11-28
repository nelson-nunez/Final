using SiAP.Abstracciones;
using SiAP.BLL.Logs;
using SiAP.MPP;
using Policonsultorio.BE;
using SiAP.BLL.Seguridad;

namespace SiAP.BLL
{
    public class BLL_Consulta : IBLL<Consulta>
    {
        private readonly MPP_Consulta _mppConsulta;
        private readonly BLL_Receta _bllReceta;
        private readonly BLL_Certificado _bllCertificado;
        private readonly BLL_Medico _bllMedico;
        private static BLL_Consulta _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Consulta()
        {
            _mppConsulta = MPP_Consulta.ObtenerInstancia();
            _bllReceta = BLL_Receta.ObtenerInstancia();
            _bllCertificado = BLL_Certificado.ObtenerInstancia();
            _bllMedico = BLL_Medico.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Consulta ObtenerInstancia()
        {
            return _instancia ??= new BLL_Consulta();
        }

        public void Agregar(Consulta consulta)
        {
            //Intento asignar el medico primero
            consulta.Medico = _bllMedico.LeerPorPersonId((long)GestionUsuario.UsuarioLogueado.PersonaId);
            if (!EsValido(consulta))
                throw new ArgumentException(MensajeError);

            if (_mppConsulta.Existe(consulta))
                throw new InvalidOperationException("La consulta ya existe.");
            _mppConsulta.Agregar(consulta);
            _logger.GenerarLog($"Consulta agregada - Médico: {consulta.Medico?.Persona?.NombreCompleto}, Fecha: {consulta.Fecha.ToShortDateString()}");
        }

        public void Modificar(Consulta consulta)
        {
            var useractual = GestionUsuario.UsuarioLogueado;
            
            if (!EsValido(consulta))
                throw new ArgumentException(MensajeError);
            
            if (consulta.Medico == null)
                throw new ArgumentException("La consulta no tiene un médico asignado. Guardela antes de editarla");
            
            if (consulta.Medico.PersonaId != useractual.PersonaId)
                throw new ArgumentException("No puede modificar una consulta realizada por otro médico");

            _mppConsulta.Modificar(consulta);
            _logger.GenerarLog($"Consulta modificada - ID: {consulta.Id}");
        }

        public void Eliminar(Consulta consulta)
        {
            if (_mppConsulta.TieneDependencias(consulta))
                throw new InvalidOperationException("La consulta tiene recetas o certificados asociados y no puede eliminarse.");

            _mppConsulta.Eliminar(consulta);
            _logger.GenerarLog($"Consulta eliminada - ID: {consulta.Id}");
        }

        public IList<Consulta> ObtenerTodos()
        {
            return _mppConsulta.ObtenerTodos();
        }

        public Consulta Leer(long consultaId)
        {
            return _mppConsulta.LeerPorId(consultaId);
        }

        public IList<Consulta> BuscarPorHistoriaClinica(long historiaClinicaId)
        {
            if (historiaClinicaId <= 0)
                throw new ArgumentException("El ID de la historia clínica debe ser válido.");

            return _mppConsulta.BuscarPorHistoriaClinicaId(historiaClinicaId);
        }

        public bool EsValido(Consulta consulta)
        {
            _mensajeError = "";

            if (consulta == null)
            {
                _mensajeError = "La consulta no puede ser nula. ";
                return false;
            }

            if (consulta.Medico == null || consulta.Medico.Id <= 0)
                _mensajeError += "La consulta debe tener un médico asociado. ";

            if (string.IsNullOrWhiteSpace(consulta.Motivo))
                _mensajeError += "El motivo de la consulta es obligatorio. ";

            if (consulta.Fecha == default(DateTime))
                _mensajeError += "La fecha es obligatoria. ";

            if (consulta.Fecha > DateTime.Now)
                _mensajeError += "La fecha no puede ser futura. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}