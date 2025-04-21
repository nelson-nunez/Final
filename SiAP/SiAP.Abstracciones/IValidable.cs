using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    // Interfaz que expone método para validar una entidad utilizado en la capa del negocio
    public interface IValidable<T>
    {
        string Error { get; }
        bool EsValido(T objeto);
    }
}
