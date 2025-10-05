using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Cobro : MapperBase<Cobro>, IMapper<Cobro>
    {
        private static MPP_Cobro _instancia;
        protected override string NombreTabla => "Cobro";

        private MPP_Cobro() : base() { }

        public static MPP_Cobro ObtenerInstancia()
        {
            return _instancia ??= new MPP_Cobro();
        }

        public void Agregar(Cobro entidad)
        {
            if (Existe(entidad)) return;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Cobro entidad)
        {
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Cobro entidad)
        {
            EliminarEntidad(entidad);
        }

        public bool Existe(Cobro entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Cobro entidad)
        {
            return false;
        }

        public IList<Cobro> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Cobro LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Cobro> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var cobros = ObtenerTodos();

            if (!incluirInactivos)
                cobros = cobros.Where(c => c.Estado != EstadoCobro.Rechazado).ToList();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return cobros;

            valor = valor.ToLower();

            return campo.ToLower() switch
            {
                "tipopago" => BuscarPorCampo(cobros, campo, valor, c => c.TipoPago),
                "estado" => cobros.Where(c => c.Estado.ToString().ToLower().Contains(valor)).ToList(),
                "facturaid" => cobros.Where(c => c.FacturaId.ToString() == valor).ToList(),
                "formapagoid" => cobros.Where(c => c.FormaPagoId.ToString() == valor).ToList(),
                _ => cobros
            };
        }

        private void AsignarDatos(DataRow dr, Cobro entidad)
        {
            dr["FechaHora"] = entidad.FechaHora;
            dr["TipoPago"] = entidad.TipoPago;
            dr["Monto"] = entidad.Monto;
            dr["Estado"] = entidad.Estado.ToString();
            dr["FacturaId"] = entidad.FacturaId;
            dr["FormaPagoId"] = entidad.FormaPagoId;
        }

        private Cobro HidratarObjeto(DataRow r)
        {
            return new Cobro
            {
                Id = Convert.ToInt32(r["Id"]),
                FechaHora = Convert.ToDateTime(r["FechaHora"]),
                TipoPago = r["TipoPago"].ToString(),
                Monto = Convert.ToDecimal(r["Monto"]),
                Estado = Enum.Parse<EstadoCobro>(r["Estado"].ToString()),
                FacturaId = Convert.ToInt32(r["FacturaId"]),
                FormaPagoId = Convert.ToInt32(r["FormaPagoId"])
            };
        }
    }
}