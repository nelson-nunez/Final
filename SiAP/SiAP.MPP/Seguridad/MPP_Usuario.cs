using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using System.Data;
using System.Linq;
using SiAP.MPP.Base;

namespace SiAP.MPP.Seguridad
{
    public class MPP_Usuario : IMapper<Usuario>
    {
        private readonly IGestorDatos _datos;
        private static MPP_Usuario _instancia;
        private readonly MPP_Rol _mppRol;

        private MPP_Usuario()
        {
            _datos = GestorDatos.ObtenerInstancia();
            _mppRol = MPP_Rol.ObtenerInstancia();
        }

        public static MPP_Usuario ObtenerInstancia()
        {
            return _instancia ??= new MPP_Usuario();
        }

        public void Agregar(Usuario entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];
            var dr = dt.NewRow();

            dr["Legajo"] = entidad.Legajo;
            dr["Logon"] = entidad.Logon;
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Email"] = entidad.Email;
            dr["Password"] = entidad.Password;
            dr["Bloqueado"] = entidad.Bloqueado;
            dr["Activo"] = entidad.Activo;

            dt.Rows.Add(dr);
            _datos.Guardar_Datos(ds);

            // Asignación de roles
            foreach (var rol in entidad.Roles)
            {
                Asignar(entidad, rol);
            }
        }

        public void Modificar(Usuario entidad, string idAnterior = null)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];

            var dr = dt.AsEnumerable()
                       .FirstOrDefault(r => r["Legajo"].ToString() == idAnterior);

            if (dr == null) throw new Exception("Usuario no encontrado");

            dr["Legajo"] = entidad.Legajo;
            dr["Logon"] = entidad.Logon;
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Email"] = entidad.Email;
            dr["Password"] = entidad.Password;
            dr["Bloqueado"] = entidad.Bloqueado;
            dr["Activo"] = entidad.Activo;

            _datos.Guardar_Datos(ds);
        }

        public void Eliminar(Usuario entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Usuario"];
            var row = dt.AsEnumerable()
                        .FirstOrDefault(r => r["Legajo"].ToString() == entidad.Legajo.ToString());

            if (row != null)
                row.Delete();

            // Eliminar asignaciones de roles
            var dtRelacion = ds.Tables["UsuarioRol"];
            var relaciones = dtRelacion.Select($"UsuarioLegajo = '{entidad.Legajo}'");
            foreach (var rel in relaciones)
                rel.Delete();

            _datos.Guardar_Datos(ds);
        }

        public bool Existe(Usuario entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Usuario"]
                     .AsEnumerable()
                     .Any(r => r["Legajo"].ToString() == entidad.Legajo.ToString());
        }

        public bool TieneDependencias(Usuario entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dtRelacion = ds.Tables["UsuarioRol"];
            return dtRelacion.Select($"UsuarioLegajo = '{entidad.Legajo}'").Any();
        }

        public IList<Usuario> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            var dtUsuarios = ds.Tables["Usuario"];
            var dtRelacion = ds.Tables["UsuarioRol"];
            var roles = _mppRol.ObtenerTodos();

            var usuarios = dtUsuarios.AsEnumerable()
                                     .Select(r => HidratarUsuario(r))
                                     .ToList();

            foreach (var usuario in usuarios)
            {
                var relaciones = dtRelacion.AsEnumerable()
                                           .Where(r => r["UsuarioLegajo"].ToString() == usuario.Legajo.ToString())
                                           .Select(r => r["RolCodigo"].ToString());

                foreach (var codRol in relaciones)
                {
                    var rol = roles.FirstOrDefault(r => r.Codigo == codRol);
                    if (rol != null)
                        usuario.Roles.Add(rol);
                }
            }

            return usuarios;
        }

        public IList<Usuario> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var todos = ObtenerTodos();

            if (!incluirInactivos)
                todos = todos.Where(u => u.Activo).ToList();

            return campo.ToLower() switch
            {
                "logon" => todos.Where(u => u.Logon.Contains(valor)).ToList(),
                "nombre" => todos.Where(u => u.Nombre.Contains(valor)).ToList(),
                "apellido" => todos.Where(u => u.Apellido.Contains(valor)).ToList(),
                _ => todos
            };
        }

        public Usuario LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(u => u.Legajo.ToString() == id.ToString());
        }

        public void Asignar(Usuario usuario, Usuario rolAsUsuario)
        {
            // Ignorar - solo aplica para Permiso como IMapperAsignar<Permiso>
            throw new NotImplementedException();
        }

        public void Asignar(Usuario usuario, Rol rol)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["UsuarioRol"];

            if (ExisteAsignacion(usuario, rol)) return;

            var dr = dt.NewRow();
            dr["UsuarioLegajo"] = usuario.Legajo;
            dr["RolCodigo"] = rol.Codigo;

            dt.Rows.Add(dr);
            _datos.Guardar_Datos(ds);
        }

        public void Desasignar(Usuario usuario, Rol rol)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["UsuarioRol"];

            var row = dt.AsEnumerable()
                        .FirstOrDefault(r => r["UsuarioLegajo"].ToString() == usuario.Legajo.ToString() &&
                                             r["RolCodigo"].ToString() == rol.Codigo);

            if (row != null)
            {
                row.Delete();
                _datos.Guardar_Datos(ds);
            }
        }

        public void ActualizarAsignacion(Usuario usuario, Rol rol)
        {
            Desasignar(usuario, rol);
            Asignar(usuario, rol);
        }

        public bool ExisteAsignacion(Usuario usuario, Rol rol)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["UsuarioRol"];

            return dt.AsEnumerable()
                     .Any(r => r["UsuarioLegajo"].ToString() == usuario.Legajo.ToString() &&
                               r["RolCodigo"].ToString() == rol.Codigo);
        }

        private Usuario HidratarUsuario(DataRow row)
        {
            return new Usuario
            {
                Legajo = int.Parse(row["Legajo"].ToString()),
                Logon = row["Logon"].ToString(),
                Nombre = row["Nombre"].ToString(),
                Apellido = row["Apellido"].ToString(),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                Bloqueado = Convert.ToBoolean(row["Bloqueado"]),
                Activo = Convert.ToBoolean(row["Activo"]),
                Roles = new List<Rol>()
            };
        }
    }
}
