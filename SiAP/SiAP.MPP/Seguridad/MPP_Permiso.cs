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
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["Permiso"];

            //if (Existe(entidad) || ExistePorCodigo(entidad.Codigo)) throw new Exception("El permiso ya existe");
            if (Existe(entidad)) throw new Exception("El permiso ya existe");
            
            var dr = dt.NewRow();
            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Codigo"] = entidad.Codigo;
            dr["Descripcion"] = entidad.Descripcion;
            dr["EsCompuesto"] = entidad is PermisoCompuesto;
            dt.Rows.Add(dr);

            _datos.Actualizar_BDSiAP(ds);
        }

        public void Modificar(Permiso entidad)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["Permiso"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);

            if (dr == null) throw new Exception("Permiso no encontrado");

            dr["Codigo"] = entidad.Codigo;
            dr["Descripcion"] = entidad.Descripcion;
            dr["EsCompuesto"] = entidad is PermisoCompuesto;

            _datos.Actualizar_BDSiAP(ds);
        }

        public void Eliminar(Permiso entidad)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["Permiso"];
            var dr = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);

            if (dr != null)
                dr.Delete();

            var dtRelaciones = ds.Tables["PermisoHijo"];
            var relaciones = dtRelaciones.Select($"PadreId = {entidad.Id} OR HijoId = {entidad.Id}");

            foreach (var rel in relaciones)
                rel.Delete();

            _datos.Actualizar_BDSiAP(ds);
        }

        public bool Existe(Permiso entidad)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            return ds.Tables["Permiso"].AsEnumerable().Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool ExistePorCodigo(string codigo)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            return ds.Tables["Permiso"].AsEnumerable().Any(r => r["Codigo"].ToString() == codigo);
        }

        public bool TieneDependencias(Permiso entidad)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var rel = ds.Tables["PermisoHijo"];
            return rel.Select($"PadreId = {entidad.Id} OR HijoId = {entidad.Id}").Length > 0;
        }

        public IList<Permiso> ObtenerTodos()
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["Permiso"];

            var permisos = dt.AsEnumerable()
                             .Select(HidratarPermisoBasico)
                             .ToDictionary(p => p.Id, p => p);

            var relaciones = ds.Tables["PermisoHijo"].AsEnumerable();

            foreach (var rel in relaciones)
            {
                var padreId = Convert.ToInt64(rel["PadreId"]);
                var hijoId = Convert.ToInt64(rel["HijoId"]);

                if (permisos.TryGetValue(padreId, out var padre) &&
                    permisos.TryGetValue(hijoId, out var hijo) &&
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

            valor = valor.ToLower();

            return campo.ToLower() switch
            {
                "codigo" => todos.Where(p => p.Codigo.ToLower().Contains(valor)).ToList(),
                "descripcion" => todos.Where(p => p.Descripcion.ToLower().Contains(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Permiso LeerPorId(object id)
        {
            long idLong = Convert.ToInt64(id);
            return ObtenerTodos().FirstOrDefault(p => p.Id == idLong);
        }

        public void Asignar(Permiso padre, Permiso hijo)
        {
            if (padre is not PermisoCompuesto)
                throw new InvalidOperationException("Solo se pueden asignar permisos a un permiso compuesto.");

            if (ExisteAsignacion(padre, hijo))
                throw new Exception("El permiso ya se encuentra asignado");
            

            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["PermisoHijo"];

            var dr = dt.NewRow();
            dr["PadreId"] = padre.Id;
            dr["HijoId"] = hijo.Id;
            dt.Rows.Add(dr);

            _datos.Actualizar_BDSiAP(ds);
        }

        public void Desasignar(Permiso padre, Permiso hijo)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["PermisoHijo"];

            var row = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["PadreId"]) == padre.Id && Convert.ToInt64(r["HijoId"]) == hijo.Id);

            if (row != null)
            {
                row.Delete();
                _datos.Actualizar_BDSiAP(ds);
            }
            else
                throw new Exception("El permiso no se encuentraba asignado");

        }

        public void ActualizarAsignacion(Permiso padre, Permiso hijo)
        {
            Desasignar(padre, hijo);
            Asignar(padre, hijo);
        }

        public bool ExisteAsignacion(Permiso padre, Permiso hijo)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var dt = ds.Tables["PermisoHijo"];
            return dt.AsEnumerable().Any(r =>
                Convert.ToInt64(r["PadreId"]) == padre.Id &&
                Convert.ToInt64(r["HijoId"]) == hijo.Id);
        }

        private Permiso HidratarPermisoBasico(DataRow row)
        {
            long id = Convert.ToInt64(row["Id"]);
            string codigo = row["Codigo"].ToString();
            string descripcion = row["Descripcion"].ToString();
            bool esCompuesto = row.Table.Columns.Contains("EsCompuesto") && Convert.ToBoolean(row["EsCompuesto"]);

            Permiso permiso = esCompuesto
                ? (Permiso)new PermisoCompuesto(codigo, descripcion)
                : new PermisoSimple(codigo, descripcion);

            permiso.Id = id;
            return permiso;
        }
    }
}
