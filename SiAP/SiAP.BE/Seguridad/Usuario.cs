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
    public class Usuario : ClaseBase, IComparable, IAuditable
    {
        //1 Vacio
        public Usuario(){}
        //2 Datos
        public Usuario(int legajo, string username, string nombre, string apellido, string email, string password)
        {
            Legajo = legajo;
            Username = username;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }
        //3 Con rol
        public Usuario(int legajo, string username, string nombre, string apellido, string email, string password, PermisoCompuesto rol) : this(legajo, username, nombre, apellido, email, password)
        {
            Permiso = rol;
        }

        public int? Legajo { get; set; }
        public string Username { get; set; }
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
            return Username;
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
