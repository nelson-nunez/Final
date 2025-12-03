using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;
using SiAP.UI;

namespace SiAP.BLL
{
    public class BLL_Cobro : IBLL<Cobro>
    {
        private readonly MPP_Cobro _mppCobro;
        private readonly MPP_Factura _mppFactura;
        private static BLL_Cobro _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Cobro()
        {
            _mppCobro = MPP_Cobro.ObtenerInstancia();
            _mppFactura = MPP_Factura.ObtenerInstancia();
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
            _logger.GenerarLog($"Cobro agregado: Monto Pagado {cobro.Importe}, FacturaID {cobro.TurnoId}, MedioPagoID {cobro.MediodePago}");
        }

        public void Modificar(Cobro cobro)
        {
            if (!EsValido(cobro))
                throw new ArgumentException(MensajeError);

            _mppCobro.Modificar(cobro);
            _logger.GenerarLog($"Cobro modificado: ID {cobro.Id}, Estado {cobro.Estado}");
        }

        public void Pagar(Turno itemSeleccionado)
        {
            //Validar Turno
            if (itemSeleccionado.Estado == EstadoTurno.Cancelado || itemSeleccionado.Estado == EstadoTurno.Ausente)
                throw new Exception("No puede realizar un pago de un turno ausente o cancelado.");
            //Validar Cbro
            if (itemSeleccionado.Cobro.Estado == EstadoCobro.Reembolsado)
                throw new Exception("El cobro ya fué reembolsado, no puede realizar otro pago.");
            if (itemSeleccionado?.Fecha.Date < DateTime.Now.Date)
                throw new Exception("La fecha del turno es anterior a la actual y no se puede realizar un cobro.");
            if (itemSeleccionado.Cobro.Estado == EstadoCobro.PagoTotal)
                throw new Exception("El cobro total ya fue completado y facturado.");
            if (itemSeleccionado.Cobro.Importe <= 0)
                throw new Exception("El importe debe ser mayor a cero.");
            if (itemSeleccionado.Cobro.Importe > itemSeleccionado.Cobro.MontoRestante)
                throw new Exception($"El importe ({itemSeleccionado.Cobro.Importe:C}) excede el monto restante ({itemSeleccionado.Cobro.MontoRestante:C}).");

            // Acumular el monto 
            itemSeleccionado.Cobro.MontoAcumulado += itemSeleccionado.Cobro.Importe;
            itemSeleccionado.Cobro.FechaHora = DateTime.Now;
            itemSeleccionado.Cobro.TurnoId = itemSeleccionado.Id;

            // DESPUS determinar el estado
            if (itemSeleccionado.Cobro.MontoRestante > 0)
                itemSeleccionado.Cobro.Estado = EstadoCobro.PagoParcial;
            else if (itemSeleccionado.Cobro.MontoRestante == 0)
                itemSeleccionado.Cobro.Estado = EstadoCobro.PagoTotal;

            if (itemSeleccionado.Cobro.Id > 0)
                Modificar(itemSeleccionado.Cobro);
            else
                Agregar(itemSeleccionado.Cobro);

            if (itemSeleccionado.Cobro.Estado == EstadoCobro.PagoTotal)
            {
                //Creo factura
                var cobro = LeerPorTurnoId(itemSeleccionado.Id);
                var factura = new Factura();
                factura.RazonSocialEmisor = ReferenciasNegocio.RazonSocialEmisor;
                factura.CUITEmisor = ReferenciasNegocio.CUITEmisor;
                factura.DomicilioEmisor = ReferenciasNegocio.DomicilioEmisor;
                factura.PuntoDeVenta = ReferenciasNegocio.PuntoDeVenta;
                factura.RazonSocialReceptor = itemSeleccionado.NombrePaciente;

                factura.FechaEmision = DateTime.Now;
                factura.Importe = cobro.MontoTotal;
                factura.Descripcion = "Consulta particular: " + itemSeleccionado.TipoAtencion;
                factura.Estado = EstadoFactura.Emitida;
                factura.CobroId = cobro.Id;
                _mppFactura.Agregar(factura);
            }

            _logger.GenerarLog($"Cobro registrado: ID {itemSeleccionado.Cobro.Id}, Importe {itemSeleccionado.Cobro.Importe:C}, Estado {itemSeleccionado.Cobro.Estado}");
        }

        public void Reembolsar(Turno itemSeleccionado)
        {
            //Validar
            if (itemSeleccionado.Cobro == null || itemSeleccionado.Cobro.MontoAcumulado <= 0)
                throw new Exception("No hay un cobro registrado para reembolsar.");
            if (itemSeleccionado.Cobro.Estado == EstadoCobro.PagoTotal)
                throw new Exception("El cobro ya se facturó y no se puede reembolsar.");
            if (itemSeleccionado?.Fecha.Date < DateTime.Now.Date)
                throw new Exception("El plazo máximo para reembolso ya expiró.");
            //Validar Turno
            if (itemSeleccionado.Estado == EstadoTurno.Atendido || itemSeleccionado.Estado == EstadoTurno.Cancelado || itemSeleccionado.Estado == EstadoTurno.Ausente)
                throw new Exception("No se puede realizar un reembolso de un turno atendido, ausente o cancelado.");

            // Guardar valores para el log
            var montoReembolsado = itemSeleccionado.Cobro.MontoAcumulado;
            // Resetear valores
            itemSeleccionado.Cobro.FechaHora = DateTime.Now;
            itemSeleccionado.Cobro.Importe = 0;
            itemSeleccionado.Cobro.MontoAcumulado = 0;
            itemSeleccionado.Cobro.MediodePago = 0;
            itemSeleccionado.Cobro.Estado = EstadoCobro.Reembolsado;
            _mppCobro.Modificar(itemSeleccionado.Cobro);
            _logger.GenerarLog($"Cobro reembolsado: ID {itemSeleccionado.Cobro.Id}, Monto devuelto {montoReembolsado:C}, Estado {itemSeleccionado.Cobro.Estado}");
        }

        public void Eliminar(Cobro cobro)
        {
            _mppCobro.Eliminar(cobro);
            _logger.GenerarLog($"Cobro eliminado: ID {cobro.Id}");
        }

        public IList<Cobro> ObtenerTodos() => _mppCobro.ObtenerTodos();

        public Cobro Leer(long cobroId) => _mppCobro.LeerPorId(cobroId);
        
        public Cobro LeerPorTurnoId(long id) => _mppCobro.LeerPorTurnoId(id);

        public bool EsValido(Cobro cobro)
        {
            _mensajeError = "";

            if (cobro.FechaHora == default)
                _mensajeError += "La fecha del cobro es obligatoria. ";
            if (cobro.MontoTotal <= 0)
                _mensajeError += "El monto total debe ser mayor a cero. ";
            if (cobro.Importe <= 0)
                _mensajeError += "El monto pagado debe ser mayor a cero. ";
            if (cobro.MontoAcumulado > cobro.MontoTotal)
                _mensajeError += "El monto pagado no debe exceder el pago total. ";
            //if (cobro.FacturaId <= 0)
            //    _mensajeError += "Debe estar asociado a una factura válida. ";
            if (!Enum.IsDefined(typeof(EstadoCobro), cobro.Estado))
                _mensajeError += "El estado del cobro no es válido. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}
