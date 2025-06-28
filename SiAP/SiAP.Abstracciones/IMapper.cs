using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    public interface IMapper<T>
    {
        void Agregar(T entidad);
        void Modificar(T entidad);
        void Eliminar(T entidad);
        bool Existe(T entidad);
        bool TieneDependencias(T entidad); // 
        IList<T> ObtenerTodos();
        IList<T> Buscar(string campo = "", string valor = "", bool incluirInactivos = true);
        T LeerPorId(object id); 
    }

    public interface IMapperAsignar<T> : IMapper<T>
    {
        void Asignar(T padre, T hijo);
        void Desasignar(T padre, T hijo);
        void ActualizarAsignacion(T padre, T hijo);
        bool ExisteAsignacion(T padre, T hijo);
    }
}
