using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Factura : IMapper<Factura>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Factura _instancia;

        private MPP_Factura()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Factura ObtenerInstancia()
        {
            return _instancia ??= new MPP_Factura();
        }

        public void Agregar(Factura entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Factura"];
            var dr = dt.NewRow();

            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["FechaEmision"] = entidad.FechaEmision;
            dr["NumeroFactura"] = entidad.NumeroFactura;
            dr["Importe"] = entidad.Importe;
            dr["Descripcion"] = entidad.Descripcion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["TurnoId"] = entidad.TurnoId;
            dr["PacienteId"] = entidad.PacienteId;

            dt.Rows.Add(dr);
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Factura entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Factura"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)
                ?? throw new Exception("Factura no encontrada.");

            dr["FechaEmision"] = entidad.FechaEmision;
            dr["NumeroFactura"] = entidad.NumeroFactura;
            dr["Importe"] = entidad.Importe;
            dr["Descripcion"] = entidad.Descripcion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["TurnoId"] = entidad.TurnoId;
            dr["PacienteId"] = entidad.PacienteId;

            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Factura entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Factura"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();
            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Factura entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Factura"].AsEnumerable()
                .Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Factura entidad)
        {
            // Podrías validar si tiene cobros asociados
            return entidad.Cobros != null && entidad.Cobros.Count > 0;
        }

        public IList<Factura> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Factura"].AsEnumerable().Select(Hidratar).ToList();
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
                "numerofactura" => facturas.Where(f => f.NumeroFactura.ToLower().Contains(valor)).ToList(),
                "descripcion" => facturas.Where(f => f.Descripcion.ToLower().Contains(valor)).ToList(),
                "estado" => facturas.Where(f => f.Estado.ToString().ToLower().Contains(valor)).ToList(),
                "pacienteid" => facturas.Where(f => f.PacienteId.ToString() == valor).ToList(),
                "turnoid" => facturas.Where(f => f.TurnoId.ToString() == valor).ToList(),
                _ => facturas
            };
        }

        public Factura LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(f => f.Id == Convert.ToInt64(id));
        }

        private Factura Hidratar(DataRow r)
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
                Cobros = new List<Cobro>() // Se puede cargar luego con otra capa (MPP_Cobro)
            };
        }

    }
}
