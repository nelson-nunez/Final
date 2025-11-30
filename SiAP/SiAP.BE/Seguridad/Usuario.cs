using System;
using SiAP.BE.Base;

namespace SiAP.BE.Seguridad
{
    public class Usuario : ClaseBase
    {
        #region Contructor

        public Usuario(){}
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }

        #endregion

        public string Username { get; set; }
        public bool Bloqueado { get; set; } = false;
        public bool Activo { get; set; } = true;
        public string Password { get; set; }
        public DateTime? FechaUltimoCambioPassword { get; set; } = null;
        public List<Permiso> Permisos { get; set; }

        //Persona
        public long? PersonaId { get; set; }
        public Persona Persona { get; set; }
       
    }
}
