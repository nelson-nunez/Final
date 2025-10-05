using System.Data;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.MPP.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.DAL;
using SiAP.MPP.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.DAL;
using SiAP.MPP.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP.Seguridad
{
    public class MPP_Usuario : MapperBase<Usuario>, IMapper<Usuario>
    {
        private static MPP_Usuario _instancia;
        private static MPP_Permiso _instanciaPermiso;
        private static MPP_Persona _instanciaPersona;
        protected override string NombreTabla => "Usuario";

        private MPP_Usuario() : base()
        {
            _instanciaPermiso = MPP_Permiso.ObtenerInstancia();
            _instanciaPersona = MPP_Persona.ObtenerInstancia();
        }

        public static MPP_Usuario ObtenerInstancia()
        {
            return _instancia ??= new MPP_Usuario();
        }

        #region ABM

        public void Agregar(Usuario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            if (Existe(entidad)) return;

            // Usar método de la base para agregar
            AgregarEntidad(entidad, AsignarDatosUsuario);

            // Guardar permisos después de agregar
            var ds = _datos.Obtener_Datos();
            GuardarPermisosUsuario(entidad, ds);
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Usuario entidad)
        {
            // Usar método de la base para modificar
            ModificarEntidad(entidad, AsignarDatosUsuario);

            // Actualizar permisos
            var ds = _datos.Obtener_Datos();
            ActualizarPermisos(entidad, ds);
            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Usuario entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();

            // Eliminar permisos antes de eliminar usuario
            EliminarPermisosUsuario(entidad.Id, ds);

            // Usar método de la base para eliminar
            EliminarEntidad(entidad);
        }

        #endregion

        #region Búsquedas

        public bool Existe(Usuario entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Usuario entidad)
        {
            if (entidad == null) return false;
            return TieneDependenciasEnTabla(entidad.Id, "UsuarioPermiso", "UsuarioId");
        }

        public IList<Usuario> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables[NombreTabla].AsEnumerable()
                .Select(r => HidratarObjeto(r, ds))
                .ToList();
        }

        public IList<Usuario> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var usuarios = ObtenerTodos();

            if (!incluirInactivos)
                usuarios = usuarios.Where(u => u.Activo).ToList();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return usuarios;

            return campo.ToLower() switch
            {
                "id" => usuarios.Where(u => u.Id == Convert.ToInt64(valor)).ToList(),
                "username" => usuarios.Where(u => u.Username.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Usuario LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(u => u.Id == Convert.ToInt64(id));
        }

        public Usuario LeerPorUsername(string username)
        {
            var ds = _datos.Obtener_Datos();
            var row = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(dr => dr["Username"].ToString().Equals(username, StringComparison.OrdinalIgnoreCase));

            return row != null ? HidratarObjeto(row, ds) : null;
        }

        #endregion

        #region Permisos

        private void GuardarPermisosUsuario(Usuario entidad, DataSet ds)
        {
            if (entidad.Permiso is not PermisoCompuesto compuesto) return;

            var dt = ds.Tables["UsuarioPermiso"];
            var dr = dt.NewRow();
            dr["UsuarioId"] = entidad.Id;
            dr["PermisoId"] = compuesto.Id;
            dt.Rows.Add(dr);
        }

        public void AgregarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || usuario.Id == 0)
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null || string.IsNullOrWhiteSpace(permiso.Codigo))
                throw new ArgumentException("Permiso inválido.");

            var ds = _datos.Obtener_Datos();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];

            // Verificar si ya existe la relación
            var existeRelacion = dtUsuarioPermiso.AsEnumerable().Any(r => Convert.ToInt64(r["UsuarioId"]) == usuario.Id && r["PermisoId"].ToString() == permiso.Codigo);

            if (existeRelacion)
                throw new InvalidOperationException("La relación usuario-permiso ya existe.");

            // Agregar nueva relación
            var nuevaFila = dtUsuarioPermiso.NewRow();
            nuevaFila["UsuarioId"] = usuario.Id;
            nuevaFila["PermisoId"] = permiso.Codigo;
            dtUsuarioPermiso.Rows.Add(nuevaFila);

            _datos.Actualizar_BD(ds);
        }

        public void QuitarPermiso(Usuario usuario, Permiso permiso)
        {
            if (usuario == null || usuario.Id == 0)
                throw new ArgumentException("Usuario inválido.");

            if (permiso == null || string.IsNullOrWhiteSpace(permiso.Codigo))
                throw new ArgumentException("Permiso inválido.");

            var ds = _datos.Obtener_Datos();
            var dtUsuarioPermiso = ds.Tables["UsuarioPermiso"];

            // Buscar y eliminar la relación
            var relacion = dtUsuarioPermiso.AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["UsuarioId"]) == usuario.Id &&
                                    r["PermisoId"].ToString() == permiso.Codigo);

            if (relacion == null)
                throw new InvalidOperationException("La relación usuario-permiso no existe.");

            relacion.Delete();
            _datos.Actualizar_BD(ds);
        }

        #endregion

        #region Auxiliares

        private void AsignarDatosUsuario(DataRow dr, Usuario entidad)
        {
            dr["Username"] = entidad.Username;
            dr["Password"] = entidad.Password;
            dr["Bloqueado"] = entidad.Bloqueado;
            dr["Activo"] = entidad.Activo;
            dr["FechaUltimoCambioPassword"] = entidad.FechaUltimoCambioPassword ?? (object)DBNull.Value;
            dr["PalabraClave"] = entidad.PalabraClave ?? string.Empty;
            dr["RespuestaClave"] = entidad.RespuestaClave ?? string.Empty;
        }

        private Usuario HidratarObjeto(DataRow r, DataSet ds)
        {
            var usuario = new Usuario
            {
                Id = Convert.ToInt64(r["Id"]),
                Username = r["Username"].ToString(),
                Password = r["Password"].ToString(),
                Bloqueado = Convert.ToBoolean(r["Bloqueado"]),
                Activo = Convert.ToBoolean(r["Activo"]),
                FechaUltimoCambioPassword = r["FechaUltimoCambioPassword"] != DBNull.Value ? Convert.ToDateTime(r["FechaUltimoCambioPassword"]) : null,
                PalabraClave = r["PalabraClave"]?.ToString() ?? string.Empty,
                RespuestaClave = r["RespuestaClave"]?.ToString() ?? string.Empty,
                PersonaId = Convert.ToInt64(r["PersonaId"]),

            };

            CargarPersonaCompleta(usuario); 
            CargarPermisosUsuario(usuario, ds);
            return usuario;
        }

        private void CargarPersonaCompleta(Usuario usuario)
        {
            if (usuario.PersonaId.HasValue && usuario.PersonaId.Value > 0)
                usuario.Persona = _instanciaPersona.LeerPorIdSinUsuario(usuario.PersonaId.Value);
        }

        private void CargarPermisosUsuario(Usuario usuario, DataSet ds)
        {
            var permisos = _instanciaPermiso.ObtenerTodos().ToDictionary(p => p.Id);
            var relaciones = ds.Tables["UsuarioPermiso"].Select($"UsuarioId = '{usuario.Id}'");

            foreach (var rel in relaciones)
            {
                var permisoId = Convert.ToInt64(rel["PermisoId"]);
                if (permisos.TryGetValue(permisoId, out var permiso) && permiso is PermisoCompuesto compuesto)
                {
                    usuario.Permiso = compuesto;
                    break; // Solo uno por usuario según la lógica actual
                }
            }
        }

        private void ActualizarPermisos(Usuario entidad, DataSet ds)
        {
            EliminarPermisosUsuario(entidad.Id, ds);
            GuardarPermisosUsuario(entidad, ds);
        }

        private void EliminarPermisosUsuario(long usuarioId, DataSet ds)
        {
            var relaciones = ds.Tables["UsuarioPermiso"].Select($"UsuarioId = '{usuarioId}'");
            foreach (var rel in relaciones)
                rel.Delete();
        }

        #endregion
    }
}