using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    public interface IBLL<T>
    {
        void Agregar(T objeto);
        void Modificar(T objeto);
        void Eliminar(T objeto);
        IList<T> ObtenerTodos();
        T Leer(T objeto);

        //Valido
        bool EsValido(T objeto);
        string MensajeError { get; }
    }
}
