using SiAP.Abstracciones;
using SiAP.BLL.Logs;
using SiAP.MPP;
using Policonsultorio.BE;

namespace SiAP.BLL
{
    public class BLL_Certificado : IBLL<Certificado>
    {
        private readonly MPP_Certificado _mppCertificado;
        private static BLL_Certificado _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Certificado()
        {
            _mppCertificado = MPP_Certificado.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Certificado ObtenerInstancia()
        {
            return _instancia ??= new BLL_Certificado();
        }

        public void Agregar(Certificado certificado)
        {
            if (!EsValido(certificado))
                throw new ArgumentException(MensajeError);

            if (_mppCertificado.Existe(certificado))
                throw new InvalidOperationException("El certificado ya existe.");

            _mppCertificado.Agregar(certificado);
            _logger.GenerarLog($"Certificado agregado - Tipo: {certificado.TipoCertificado}, Fecha: {certificado.Fecha.ToShortDateString()}");
        }

        public void Modificar(Certificado certificado)
        {
            if (!EsValido(certificado))
                throw new ArgumentException(MensajeError);

            _mppCertificado.Modificar(certificado);
            _logger.GenerarLog($"Certificado modificado - ID: {certificado.Id}");
        }

        public void Eliminar(Certificado certificado)
        {
            if (_mppCertificado.TieneDependencias(certificado))
                throw new InvalidOperationException("El certificado tiene dependencias y no puede eliminarse.");

            _mppCertificado.Eliminar(certificado);
            _logger.GenerarLog($"Certificado eliminado - ID: {certificado.Id}");
        }

        public IList<Certificado> ObtenerTodos()
        {
            return _mppCertificado.ObtenerTodos();
        }

        public Certificado Leer(long certificadoId)
        {
            return _mppCertificado.LeerPorId(certificadoId);
        }

        public bool EsValido(Certificado certificado)
        {
            _mensajeError = "";

            if (certificado == null)
            {
                _mensajeError = "El certificado no puede ser nulo. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(certificado.TipoCertificado))
                _mensajeError += "El tipo de certificado es obligatorio. ";

            if (string.IsNullOrWhiteSpace(certificado.Descripcion))
                _mensajeError += "La descripción es obligatoria. ";

            if (certificado.Fecha == default(DateTime))
                _mensajeError += "La fecha es obligatoria. ";

            if (certificado.Fecha > DateTime.Now)
                _mensajeError += "La fecha no puede ser futura. ";

            if (certificado.FechaVigenciaDesde != default(DateTime) &&
                certificado.FechaVigenciaHasta != default(DateTime) &&
                certificado.FechaVigenciaHasta < certificado.FechaVigenciaDesde)
                _mensajeError += "La fecha de vigencia hasta debe ser posterior a la fecha desde. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}