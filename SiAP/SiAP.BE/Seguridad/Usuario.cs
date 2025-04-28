using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;

namespace SiAP.BE.Seguridad
{
    public class Usuario : IComparable, IAuditable
    {
        public Usuario()
        {
            Roles = new List<Rol>();
        }

        public Usuario(int legajo, string logon, string nombre, string apellido, string email, string password) : this()
        {
            Legajo = legajo;
            Logon = logon;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

        public int? Legajo { get; set; }
        public string Logon { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Bloqueado { get; set; } = false;
        public bool Activo { get; set; } = true;
        public string Password { get; set; }
        public DateTime? FechaUltimoCambioPassword { get; set; } = null;
        public string PalabraClave { get; set; }
        public string RespuestaClave { get; set; }
        public string Email { get; set; }

        public List<Rol> Roles { get; set; }

        public bool TienePermiso(string codigoPermiso)
        {
            foreach (var rol in Roles)
            {
                if (rol.ObtenerPermisos().Exists(p => p.Codigo == codigoPermiso))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Logon;
        }

        public override bool Equals(object obj)
        {
            if (this.Legajo == null)
                return false;
            else if (obj == null || !(obj is Usuario))
                return false;
            return this.Legajo == ((Usuario)obj).Legajo;
        }

        public override int GetHashCode()
        {
            return Legajo != null ? Legajo.GetHashCode() : base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(((Usuario)obj).ToString());
        }
    }
}
