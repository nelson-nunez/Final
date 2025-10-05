using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE.Base;

namespace SiAP.BE.Seguridad
{
    public class Usuario : ClaseBase, IAuditable
    {
        #region Contructor

        //1 Vacio
        public Usuario(){}
        //2 Datos
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }
        //3 Con rol
        public Usuario(string username, string password, PermisoCompuesto rol) : this(username, password)
        {
            Permiso = rol;
        }

        #endregion

        public string Username { get; set; }
        public bool Bloqueado { get; set; } = false;
        public bool Activo { get; set; } = true;
        public string Password { get; set; }
        public DateTime? FechaUltimoCambioPassword { get; set; } = null;
        public string PalabraClave { get; set; }
        public string RespuestaClave { get; set; }
        public Permiso Permiso { get; set; }

        //Persona
        public long? PersonaId { get; set; }
        public Persona Persona { get; set; }

        #region Pemisos
        // En la clase Usuario
        public bool TienePermiso(Permiso permiso)
        {
            if (permiso == null || this.Permiso == null)
                return false;

            // Si es el mismo permiso (comparación por código/ID)
            if (this.Permiso.Codigo == permiso.Codigo)
                return true;

            // Si el permiso del usuario es compuesto, buscar recursivamente
            if (this.Permiso is PermisoCompuesto compuesto)
                return BuscarPermisoEnJerarquia(compuesto, permiso);

            return false;
        }

        private bool BuscarPermisoEnJerarquia(PermisoCompuesto permisoCompuesto, Permiso permisoBuscado)
        {
            foreach (var permisoHijo in permisoCompuesto.ObtenerPermisos())
            {
                // Comparar por código/ID
                if (permisoHijo.Codigo == permisoBuscado.Codigo)
                    return true;

                // Si es compuesto, buscar recursivamente
                if (permisoHijo is PermisoCompuesto compuestoHijo)
                {
                    if (BuscarPermisoEnJerarquia(compuestoHijo, permisoBuscado))
                        return true;
                }
            }
            return false;
        }
        
        #endregion
    }
}
