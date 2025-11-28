using System;
using System.Data;
using System.Drawing;


namespace SiAP.Abstracciones
{
    public interface IMapper<T>
    {
        void Agregar(T entidad);
        void Modificar(T entidad);
        void Eliminar(T entidad);
        bool Existe(T entidad);
        bool TieneDependencias(T entidad); 
        IList<T> ObtenerTodos();
        T LeerPorId(object id);

        void AsignarDatos(DataRow dr, T entidad);
        T HidratarObjeto(DataRow r);
    }

    public interface IMapperAsignar<T> : IMapper<T>
    {
        void Asignar(T padre, T hijo);
        void Desasignar(T padre, T hijo);
        void ActualizarAsignacion(T padre, T hijo);
        bool ExisteAsignacion(T padre, T hijo);
    }
}
