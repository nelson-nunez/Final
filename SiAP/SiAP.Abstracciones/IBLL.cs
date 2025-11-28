using System;


namespace SiAP.Abstracciones
{
    public interface IBLL<T>
    {
        void Agregar(T objeto);
        void Modificar(T objeto);
        void Eliminar(T objeto);
        IList<T> ObtenerTodos();
        T Leer(long Id);

        //Valido
        bool EsValido(T objeto);
        string MensajeError { get; }
    }
}
