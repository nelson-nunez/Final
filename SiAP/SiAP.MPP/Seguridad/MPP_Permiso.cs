using System.Data;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP.Seguridad
{
    public class MPP_Permiso : IMapperAsignar<Permiso>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Permiso _instancia;

        private MPP_Permiso()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Permiso ObtenerInstancia()
        {
            return _instancia ??= new MPP_Permiso();
        }

        public void Agregar(Permiso entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Permiso"];

            if (Existe(entidad)) return;

            var dr = dt.NewRow();
            dr["Codigo"] = entidad.Codigo;
            dr["Descripcion"] = entidad.Descripcion;
            dr["EsCompuesto"] = entidad is PermisoCompuesto;
            dt.Rows.Add(dr);

            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Permiso entidad, string idAnterior = null)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Permiso"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => r["Codigo"].ToString() == idAnterior);

            if (dr == null) throw new Exception("Permiso no encontrado");

            dr["Codigo"] = entidad.Codigo;
            dr["Descripcion"] = entidad.Descripcion;
            dr["EsCompuesto"] = entidad is PermisoCompuesto;

            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Permiso entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Permiso"];
            var row = dt.AsEnumerable().FirstOrDefault(r => r["Codigo"].ToString() == entidad.Codigo);

            if (row != null)
            {
                row.Delete();
            }

            // Eliminar asociaciones en PermisoHijo
            var dtRelaciones = ds.Tables["PermisoHijo"];
            var relaciones = dtRelaciones.Select($"PadreCodigo = '{entidad.Codigo}' OR HijoCodigo = '{entidad.Codigo}'");

            foreach (var rel in relaciones)
                rel.Delete();

            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Permiso entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Permiso"].AsEnumerable()
                     .Any(r => r["Codigo"].ToString() == entidad.Codigo);
        }

        public bool TieneDependencias(Permiso entidad)
        {
            var ds = _datos.Obtener_Datos();
            var rel = ds.Tables["PermisoHijo"];
            return rel.Select($"PadreCodigo = '{entidad.Codigo}' OR HijoCodigo = '{entidad.Codigo}'").Length > 0;
        }

        public IList<Permiso> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Permiso"];

            var permisos = dt.AsEnumerable()
                             .Select(r => HidratarPermisoBasico(r))
                             .ToDictionary(p => p.Codigo, p => p);

            var relaciones = ds.Tables["PermisoHijo"].AsEnumerable();

            foreach (var rel in relaciones)
            {
                var padreCodigo = rel["PadreCodigo"].ToString();
                var hijoCodigo = rel["HijoCodigo"].ToString();

                if (permisos.TryGetValue(padreCodigo, out var padre) &&
                    permisos.TryGetValue(hijoCodigo, out var hijo) &&
                    padre is PermisoCompuesto compuesto)
                {
                    compuesto.AgregarPermiso(hijo);
                }
            }

            return permisos.Values.ToList();
        }

        public IList<Permiso> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var todos = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return todos;

            return campo.ToLower() switch
            {
                "codigo" => todos.Where(p => p.Codigo.Contains(valor)).ToList(),
                "descripcion" => todos.Where(p => p.Descripcion.Contains(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Permiso LeerPorId(object id)
        {
            var todos = ObtenerTodos();
            return todos.FirstOrDefault(p => p.Codigo == id.ToString());
        }

        public void Asignar(Permiso padre, Permiso hijo)
        {
            if (padre is not PermisoCompuesto)
                throw new InvalidOperationException("Solo se pueden asignar permisos a un permiso compuesto.");

            if (ExisteAsignacion(padre, hijo)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["PermisoHijo"];

            var dr = dt.NewRow();
            dr["PadreCodigo"] = padre.Codigo;
            dr["HijoCodigo"] = hijo.Codigo;
            dt.Rows.Add(dr);

            _datos.Actualizar_BD(ds);
        }

        public void Desasignar(Permiso padre, Permiso hijo)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["PermisoHijo"];

            var row = dt.AsEnumerable()
                        .FirstOrDefault(r => r["PadreCodigo"].ToString() == padre.Codigo &&
                                             r["HijoCodigo"].ToString() == hijo.Codigo);
            if (row != null)
            {
                row.Delete();
                _datos.Actualizar_BD(ds);
            }
        }

        public void ActualizarAsignacion(Permiso padre, Permiso hijo)
        {
            Desasignar(padre, hijo);
            Asignar(padre, hijo);
        }

        public bool ExisteAsignacion(Permiso padre, Permiso hijo)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["PermisoHijo"];
            return dt.AsEnumerable().Any(r =>
                r["PadreCodigo"].ToString() == padre.Codigo &&
                r["HijoCodigo"].ToString() == hijo.Codigo);
        }

        private Permiso HidratarPermisoBasico(DataRow row)
        {
            string codigo = row["Codigo"].ToString();
            string descripcion = row["Descripcion"].ToString();
            bool esCompuesto = row.Table.Columns.Contains("EsCompuesto") && Convert.ToBoolean(row["EsCompuesto"]);

            return esCompuesto
                ? new PermisoCompuesto(codigo, descripcion)
                : new PermisoSimple(codigo, descripcion);
        }
    }
}

