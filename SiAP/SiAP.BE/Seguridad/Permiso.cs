using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;

namespace SiAP.BE.Seguridad
{
    public abstract class Permiso : IAuditable
    {
        public Permiso(string codigo)
        {
            Codigo = codigo;
        }


        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Otorgado { get; set; }

        public abstract List<Permiso> ObtenerPermisos();
        public abstract void AgregarPermiso(Permiso permiso);

        public override string ToString()
        {
            return $"{Codigo ?? "[Sin Codigo]"}-{Descripcion ?? "[Sin Descripcion]"}";
        }
        public override bool Equals(object obj)
        {
            if (this.Codigo == null)
                return false;
            else if (obj == null || !(obj is Permiso))
                return false;
            return this.Codigo.Equals(((Permiso)obj).Codigo);
        }
        public override int GetHashCode()
        {
            return Codigo != null ? Codigo.GetHashCode() : base.GetHashCode();
        }
    }
}
