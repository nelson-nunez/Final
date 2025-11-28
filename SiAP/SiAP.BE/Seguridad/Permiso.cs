using System;
using SiAP.BE.Base;

namespace SiAP.BE.Seguridad
{
    public abstract class Permiso
    {
        public long Id { get; set; }
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

    }
}
