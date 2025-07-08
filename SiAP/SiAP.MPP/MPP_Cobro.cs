using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using global::SiAP.Abstracciones;
using global::SiAP.BE;
using global::SiAP.DAL;
using global::SiAP.MPP.Base;
using SiAP.BE;

namespace SiAP.MPP
{
    public class MPP_Cobro : IMapper<Cobro>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Cobro _instancia;

        private MPP_Cobro()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Cobro ObtenerInstancia()
        {
            return _instancia ??= new MPP_Cobro();
        }

        public void Agregar(Cobro entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Cobro"];
            var dr = dt.NewRow();

            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["FechaHora"] = entidad.FechaHora;
            dr["TipoPago"] = entidad.TipoPago;
            dr["Monto"] = entidad.Monto;
            dr["Estado"] = entidad.Estado.ToString();
            dr["FacturaId"] = entidad.FacturaId;
            dr["FormaPagoId"] = entidad.FormaPagoId;

            dt.Rows.Add(dr);
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Cobro entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Cobro"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)
                ?? throw new Exception("Cobro no encontrado.");

            dr["FechaHora"] = entidad.FechaHora;
            dr["TipoPago"] = entidad.TipoPago;
            dr["Monto"] = entidad.Monto;
            dr["Estado"] = entidad.Estado.ToString();
            dr["FacturaId"] = entidad.FacturaId;
            dr["FormaPagoId"] = entidad.FormaPagoId;

            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Cobro entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Cobro"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();
            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Cobro entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Cobro"].AsEnumerable().Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Cobro entidad)
        {
            return false;
        }

        public IList<Cobro> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Cobro"].AsEnumerable().Select(Hidratar).ToList();
        }

        public Cobro LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(c => c.Id == Convert.ToInt64(id));
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
                "tipopago" => cobros.Where(c => c.TipoPago.ToLower().Contains(valor)).ToList(),
                "estado" => cobros.Where(c => c.Estado.ToString().ToLower().Contains(valor)).ToList(),
                "facturaid" => cobros.Where(c => c.FacturaId.ToString() == valor).ToList(),
                "formapagoid" => cobros.Where(c => c.FormaPagoId.ToString() == valor).ToList(),
                _ => cobros
            };
        }

        private Cobro Hidratar(DataRow r)
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

