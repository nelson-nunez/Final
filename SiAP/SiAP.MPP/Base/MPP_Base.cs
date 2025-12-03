using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.BE;
using SiAP.BE.Base;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP.Base
{
    /// <summary>
    /// Clase base abstracta que centraliza operaciones CRUD comunes para todos los MPP
    /// </summary>
    public abstract class MapperBase<T> where T : ClaseBase, new()
    {
        protected readonly IAccesoDatos _datos;
        protected abstract string NombreTabla { get; }

        protected MapperBase()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        #region Operaciones CRUD centralizadas

        protected long AgregarEntidad(T entidad, Action<DataRow, T> asignarDatos)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables[NombreTabla];
            var dr = dt.NewRow();

            long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Id"] = nuevoId;
            asignarDatos(dr, entidad);

            dt.Rows.Add(dr);
            _datos.Actualizar_BDSiAP(ds);

            return nuevoId;
        }

        protected void ModificarEntidad(T entidad, Action<DataRow, T> asignarDatos)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)?? throw new Exception($"{typeof(T).Name} no encontrado.");

            asignarDatos(dr, entidad);
            _datos.Actualizar_BDSiAP(ds);
        }

        protected void EliminarEntidad(T entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);

            dr?.Delete();
            _datos.Actualizar_BDSiAP(ds);
        }

        protected bool ExisteEntidad(T entidad)
        {
            if (entidad == null) 
                return false;

            var ds = _datos.ObtenerDatos_BDSiAP();
            var result = ds.Tables[NombreTabla].AsEnumerable().Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            return result;
        }

        protected IList<T> ObtenerTodasEntidades(Func<DataRow, T> hidratarObjeto)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var result = ds.Tables[NombreTabla].AsEnumerable().Select(hidratarObjeto).ToList();
            return result;
        }

        protected T LeerEntidadPorId(object id, Func<DataRow, T> hidratarObjeto)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == Convert.ToInt64(id));

            return dr != null ? hidratarObjeto(dr) : null;
        }

        protected bool TieneDependenciasEnTabla(long entidadId, string tablaRelacionada, string campoFK)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();

            if (!ds.Tables.Contains(tablaRelacionada))
                return false;

            var result= ds.Tables[tablaRelacionada].AsEnumerable().Any(r => Convert.ToInt64(r[campoFK]) == entidadId);
            return result;
        }

        #endregion

        #region Búsqueda centralizada

        protected IList<T> BuscarPorCampo<TValue>( IList<T> entidades, string campo, string valor, Func<T, TValue> selector)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return entidades;

            if (typeof(TValue) == typeof(string))
            {
                return entidades.Where(e =>
                {
                    var valorCampo = selector(e)?.ToString();
                    return !string.IsNullOrEmpty(valorCampo) &&
                           valorCampo.Contains(valor, StringComparison.OrdinalIgnoreCase);
                }).ToList();
            }
            else
            {
                return entidades.Where(e =>
                {
                    var valorCampo = selector(e)?.ToString();
                    return valorCampo == valor;
                }).ToList();
            }
        }

        #endregion
    }
}
