using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Cobro : IBLL<Cobro>
    {
        private readonly MPP_Cobro _mppCobro;
        private static BLL_Cobro _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Cobro()
        {
            _mppCobro = MPP_Cobro.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Cobro ObtenerInstancia()
        {
            return _instancia ??= new BLL_Cobro();
        }

        public void Agregar(Cobro cobro)
        {
            if (!EsValido(cobro))
                throw new ArgumentException(MensajeError);

            _mppCobro.Agregar(cobro);
            _logger.GenerarLog($"Cobro agregado: Monto {cobro.Monto}, FacturaID {cobro.FacturaId}, FormaPagoID {cobro.FormaPagoId}");
        }

        public void Modificar(Cobro cobro)
        {
            if (!EsValido(cobro))
                throw new ArgumentException(MensajeError);

            _mppCobro.Modificar(cobro);
            _logger.GenerarLog($"Cobro modificado: ID {cobro.Id}, Estado {cobro.Estado}");
        }

        public void Eliminar(Cobro cobro)
        {
            _mppCobro.Eliminar(cobro);
            _logger.GenerarLog($"Cobro eliminado: ID {cobro.Id}");
        }

        public IList<Cobro> ObtenerTodos() => _mppCobro.ObtenerTodos();

        public Cobro Leer(long cobroId) => _mppCobro.LeerPorId(cobroId);

        public bool EsValido(Cobro cobro)
        {
            _mensajeError = "";

            if (cobro.FechaHora == default)
                _mensajeError += "La fecha del cobro es obligatoria. ";
            if (cobro.Monto <= 0)
                _mensajeError += "El monto debe ser mayor a cero. ";
            if (cobro.FacturaId <= 0)
                _mensajeError += "Debe estar asociado a una factura válida. ";
            if (cobro.FormaPagoId <= 0)
                _mensajeError += "Debe seleccionar una forma de pago válida. ";
            if (!Enum.IsDefined(typeof(EstadoCobro), cobro.Estado))
                _mensajeError += "El estado del cobro no es válido. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}
