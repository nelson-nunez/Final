using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;

namespace SiAP.BE.Seguridad
{
    // Usuario del sistema
    public class Usuario : IComparable, IAuditable
    {
        public Usuario()
        {

        }

        public Usuario(int legajo, string logon, string nombre, string apellido, string email, string password)
        {
            Legajo = legajo;
            Logon = logon;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

        public Usuario(int legajo, string logon, string nombre, string apellido, string email, string password, PermisoCompuesto perfil) : this(legajo, logon, nombre, apellido, email, password)
        {
            Permiso = perfil;
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
        public Permiso Permiso { get; set; }


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