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

        private MPP_Cobro() : base() 
        {

        }

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
            return ObtenerTodasEntidades(HidratarObjeto).OrderByDescending(x=>x.FechaHora).ToList();
        }

        public Cobro LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }


        private void AsignarDatos(DataRow dr, Cobro entidad)
        {
            dr["FechaHora"] = entidad.FechaHora;
            dr["MediodePago"] = entidad.MediodePago;
            dr["MontoTotal"] = entidad.MontoTotal;
            dr["MontoPagado"] = entidad.MontoPagado;
            dr["Estado"] = entidad.Estado.ToString();
            dr["FacturaId"] = entidad.FacturaId;
            dr["TurnoId"] = entidad.TurnoId;
            dr["FormaPagoId"] = entidad.FormaPagoId;
        }

        private Cobro HidratarObjeto(DataRow r)
        {
            return new Cobro
            {
                Id = Convert.ToInt32(r["Id"]),
                FechaHora = Convert.ToDateTime(r["FechaHora"]),
                MediodePago = Enum.Parse <MediodePago> (r["MediodePago"].ToString()),
                MontoTotal = Convert.ToDecimal(r["MontoTotal"]),
                MontoPagado = Convert.ToDecimal(r["MontoPagado"]),
                Estado = Enum.Parse<EstadoCobro>(r["Estado"].ToString()),
                FacturaId = Convert.ToInt32(r["FacturaId"]),
                TurnoId = Convert.ToInt32(r["TurnoId"]),
                FormaPagoId = Convert.ToInt32(r["FormaPagoId"])
            };
        }
    }
}