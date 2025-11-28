using System;


namespace SiAP.Abstracciones
{
    public interface ILogger
    {
        void GenerarLog(string detalle, string usuario = default);
    }
}
