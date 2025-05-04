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
        public Permiso(string codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Otorgado { get; set; }

        public abstract List<Permiso> ObtenerPermisos();
        public abstract void AgregarPermiso(Permiso permiso);

        public override string ToString()
        {
            return $"{Codigo ?? "[Sin Codigo]"} - {Descripcion ?? "[Sin Descripcion]"}";
        }

        public override bool Equals(object obj)
        {
            return obj is Permiso other && Codigo != null && Codigo.Equals(other.Codigo);
        }

        public override int GetHashCode()
        {
            return Codigo != null ? Codigo.GetHashCode() : base.GetHashCode();
        }
    }

}
