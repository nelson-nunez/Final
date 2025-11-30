using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Factura : IBLL<Factura>
    {
        private readonly MPP_Factura _mppFactura;
        private static BLL_Factura _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Factura()
        {
            _mppFactura = MPP_Factura.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Factura ObtenerInstancia()
        {
            return _instancia ??= new BLL_Factura();
        }

        public void Agregar(Factura factura)
        {
            if (!EsValido(factura))
                throw new ArgumentException(MensajeError);

            _mppFactura.Agregar(factura);
            _logger.GenerarLog($"Factura agregada: Nº {factura.NumeroFactura}, Importe {factura.Importe}");
        }

        public void Modificar(Factura factura)
        {
            if (!EsValido(factura))
                throw new ArgumentException(MensajeError);

            _mppFactura.Modificar(factura);
            _logger.GenerarLog($"Factura modificada: ID {factura.Id}, Estado {factura.Estado}");
        }

        public void Eliminar(Factura factura)
        {
            if (_mppFactura.TieneDependencias(factura))
                throw new InvalidOperationException("La factura tiene cobros asociados y no puede eliminarse.");

            _mppFactura.Eliminar(factura);
            _logger.GenerarLog($"Factura eliminada: ID {factura.Id}");
        }

        public IList<Factura> ObtenerTodos() => _mppFactura.ObtenerTodos();

        public Factura Leer(long facturaId) => _mppFactura.LeerPorId(facturaId);
       
        public Factura LeerPorCobroId(long id) => _mppFactura.LeerPorCobroId(id);

        public bool EsValido(Factura factura)
        {
            _mensajeError = "";

            if (factura.FechaEmision == default)
                _mensajeError += "La fecha de emisión es obligatoria. ";
            if (string.IsNullOrWhiteSpace(factura.NumeroFactura))
                _mensajeError += "El número de factura es obligatorio. ";
            if (factura.Importe <= 0)
                _mensajeError += "El importe debe ser mayor a cero. ";
            if (!Enum.IsDefined(typeof(EstadoFactura), factura.Estado))
                _mensajeError += "El estado de la factura no es válido. ";

            return string.IsNullOrEmpty(_mensajeError);
        }

        //Otros
        public IList<Factura> BuscarporRango(DateTime desde, DateTime hasta)
        {
            return _mppFactura.BuscarFacturasporRangoFecha(desde, hasta);
        }
    }
}
