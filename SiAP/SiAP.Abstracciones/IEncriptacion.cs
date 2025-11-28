using System;


namespace SiAP.Abstracciones
{
    public interface IEncriptacion
    {
        string Encriptar3DES(string texto);
        string Desencriptar3DES(string textoEncriptado);
    }
}
