using System;
using System.Collections.Generic;
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


        public IList<Certificado> BuscarPorConsulta(long consultaId)
        {
            if (consultaId <= 0)
                throw new ArgumentException("El ID de la consulta debe ser válido.");

            return _mppCertificado.BuscarPorConsultaId(consultaId);
        }


        public IList<Certificado> BuscarPorTipo(string tipoCertificado)
        {
            if (string.IsNullOrWhiteSpace(tipoCertificado))
                throw new ArgumentException("El tipo de certificado no puede estar vacío.");

            return _mppCertificado.BuscarPorTipo(tipoCertificado);
        }


        public IList<Certificado> ObtenerVigentes()
        {
            return _mppCertificado.BuscarVigentes();
        }


        public IList<Certificado> BuscarPorRangoFechas(DateTime desde, DateTime hasta)
        {
            if (hasta < desde)
                throw new ArgumentException("La fecha 'hasta' debe ser posterior a la fecha 'desde'.");

            return _mppCertificado.BuscarPorRangoFechas(desde, hasta);
        }


        public IList<Certificado> ObtenerProximosAVencer(int dias = 30)
        {
            if (dias <= 0)
                throw new ArgumentException("Los días deben ser un valor positivo.");

            return _mppCertificado.BuscarProximosAVencer(dias);
        }


        public void EstablecerVigencia(long certificadoId, DateTime desde, DateTime hasta)
        {
            var certificado = _mppCertificado.LeerPorId(certificadoId);

            if (certificado == null)
                throw new InvalidOperationException("Certificado no encontrado.");

            certificado.EstablecerVigencia(desde, hasta);
            Modificar(certificado);

            _logger.GenerarLog($"Vigencia establecida para certificado ID: {certificadoId} - Desde: {desde.ToShortDateString()}, Hasta: {hasta.ToShortDateString()}");
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