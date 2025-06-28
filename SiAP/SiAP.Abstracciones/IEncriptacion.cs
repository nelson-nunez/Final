using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    public interface IEncriptacion
    {
        //string EncriptarSHA(string texto);
        string Encriptar3DES(string texto);
        string Desencriptar3DES(string textoEncriptado);
    }
}
