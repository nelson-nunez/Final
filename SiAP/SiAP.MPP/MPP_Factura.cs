using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;
using SiAP.UI;

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
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables[NombreTabla];
            var dr = dt.NewRow();

            // Generar nuevo ID
            long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Id"] = nuevoId;

            // Generar número de factura con formato PPPP-NNNNNNNN
            int puntoVenta = ReferenciasNegocio.PuntoDeVenta;
            long ultimoNumeroSecuencial = ObtenerUltimoNumeroSecuencial(dt, puntoVenta);
            long nuevoNumeroSecuencial = ultimoNumeroSecuencial + 1;
            string numeroFactura = $"{puntoVenta:D4}-{nuevoNumeroSecuencial:D8}";

            dr["NumeroFactura"] = numeroFactura;
            entidad.NumeroFactura = numeroFactura;

            AsignarDatos(dr, entidad);
            dt.Rows.Add(dr);
            _datos.Actualizar_BDSiAP(ds);
            entidad.Id = nuevoId;
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
        public Factura LeerPorCobroId(long id)
        {
            return ObtenerTodos().FirstOrDefault(x=>x.CobroId == id);
        }

        private void AsignarDatos(DataRow dr, Factura entidad)
        {
            dr["RazonSocialEmisor"] = entidad.RazonSocialEmisor;
            dr["CUITEmisor"] = entidad.CUITEmisor;
            dr["DomicilioEmisor"] = entidad.DomicilioEmisor;
            dr["PuntoDeVenta"] = entidad.PuntoDeVenta;
            dr["RazonSocialReceptor"] = entidad.RazonSocialReceptor;

            dr["FechaEmision"] = entidad.FechaEmision;
            dr["NumeroFactura"] = entidad.NumeroFactura;
            dr["Importe"] = entidad.Importe;
            dr["Descripcion"] = entidad.Descripcion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["CobroId"] = entidad.CobroId;
        }

        private Factura HidratarObjeto(DataRow r)
        {
            return new Factura
            {
                Id = Convert.ToInt64(r["Id"]),

                RazonSocialEmisor = r["RazonSocialEmisor"].ToString(),
                CUITEmisor = r["CUITEmisor"].ToString(),
                DomicilioEmisor = r["DomicilioEmisor"].ToString(),
                PuntoDeVenta = Convert.ToInt32(r["PuntoDeVenta"]),
                RazonSocialReceptor = r["RazonSocialReceptor"].ToString(),

                FechaEmision = Convert.ToDateTime(r["FechaEmision"]),
                NumeroFactura = r["NumeroFactura"].ToString(),
                Importe = Convert.ToDecimal(r["Importe"]),
                Descripcion = r["Descripcion"].ToString(),
                Estado = Enum.Parse<EstadoFactura>(r["Estado"].ToString()),
                CobroId = Convert.ToInt32(r["CobroId"])
            };
        }
        
        private long ObtenerUltimoNumeroSecuencial(DataTable dt, int puntoVenta)
        {
            if (dt.Rows.Count == 0) return 0;

            string prefijo = $"{puntoVenta:D4}-";
            long maxNumero = 0;

            foreach (DataRow row in dt.Rows)
            {
                string numFactura = row["NumeroFactura"]?.ToString() ?? "";

                if (numFactura.StartsWith(prefijo))
                {
                    // Extraer la parte numérica después del guion
                    string parteNumerica = numFactura.Substring(5); // Después de "0001-"

                    if (long.TryParse(parteNumerica, out long numero))
                    {
                        if (numero > maxNumero)
                            maxNumero = numero;
                    }
                }
            }

            return maxNumero;
        }
    }
}