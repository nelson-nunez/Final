using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Factura : MapperBase<Factura>, IMapper<Factura>
    {
        private static MPP_Factura _instancia;
        protected override string NombreTabla => "Factura";

        private MPP_Factura() : base() { }

        public static MPP_Factura ObtenerInstancia()
        {
            return _instancia ??= new MPP_Factura();
        }

        public void Agregar(Factura entidad)
        {
            if (Existe(entidad)) return;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Factura entidad)
        {
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Factura entidad)
        {
            EliminarEntidad(entidad);
        }

        public bool Existe(Factura entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Factura entidad)
        {
            // Verificar si tiene cobros asociados en la BD
            return TieneDependenciasEnTabla(entidad.Id, "Cobro", "FacturaId");
        }

        public IList<Factura> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Factura LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Factura> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var facturas = ObtenerTodos();

            if (!incluirInactivos)
                facturas = facturas.Where(f => f.Estado != EstadoFactura.Anulada).ToList();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return facturas;

            valor = valor.ToLower();

            return campo.ToLower() switch
            {
                "numerofactura" => BuscarPorCampo(facturas, campo, valor, f => f.NumeroFactura),
                "descripcion" => BuscarPorCampo(facturas, campo, valor, f => f.Descripcion),
                "estado" => facturas.Where(f => f.Estado.ToString().ToLower().Contains(valor)).ToList(),
                "pacienteid" => facturas.Where(f => f.PacienteId.ToString() == valor).ToList(),
                "turnoid" => facturas.Where(f => f.TurnoId.ToString() == valor).ToList(),
                _ => facturas
            };
        }

        private void AsignarDatos(DataRow dr, Factura entidad)
        {
            dr["FechaEmision"] = entidad.FechaEmision;
            dr["NumeroFactura"] = entidad.NumeroFactura;
            dr["Importe"] = entidad.Importe;
            dr["Descripcion"] = entidad.Descripcion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["TurnoId"] = entidad.TurnoId;
            dr["PacienteId"] = entidad.PacienteId;
        }

        private Factura HidratarObjeto(DataRow r)
        {
            return new Factura
            {
                Id = Convert.ToInt64(r["Id"]),
                FechaEmision = Convert.ToDateTime(r["FechaEmision"]),
                NumeroFactura = r["NumeroFactura"].ToString(),
                Importe = Convert.ToDecimal(r["Importe"]),
                Descripcion = r["Descripcion"].ToString(),
                Estado = Enum.Parse<EstadoFactura>(r["Estado"].ToString()),
                TurnoId = Convert.ToInt32(r["TurnoId"]),
                PacienteId = Convert.ToInt32(r["PacienteId"]),
                Cobros = new List<Cobro>() // Se puede cargar luego con MPP_Cobro si es necesario
            };
        }
    }
}