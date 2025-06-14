using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;

namespace SiAP.BLL.Base
{
    public class Encriptador : IEncriptacion
    {
        private readonly string _claveBase = "CLAVEDESARROLLO";

        private string CalcularHashHMACSHA1(byte[] datos, string clave)
        {
            var claveCompuesta = _claveBase + clave;
            var claveBytes = Encoding.UTF8.GetBytes(claveCompuesta);

            using var hmac = new HMACSHA1(claveBytes);
            hmac.ComputeHash(datos); // Calcula el hash directamente

            return Convert.ToBase64String(hmac.Hash);
        }

        private string CalcularHashHMACSHA1(string texto, string clave)
        {
            var datos = Encoding.UTF8.GetBytes(texto);
            return CalcularHashHMACSHA1(datos, clave);
        }

        public string EncriptarSHA(string texto)
        {
            return CalcularHashHMACSHA1(texto, string.Empty);
        }

        public string Encriptar3DES(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                return string.Empty;

            var datos = Encoding.UTF8.GetBytes(textoPlano);
            byte[] claveBytes;

            using (var md5 = MD5.Create())
                claveBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(_claveBase));

            using var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = claveBytes,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            using var encryptor = tripleDes.CreateEncryptor();
            var resultado = encryptor.TransformFinalBlock(datos, 0, datos.Length);

            return Convert.ToBase64String(resultado);
        }

        public string Desencriptar3DES(string textoCifrado)
        {
            if (string.IsNullOrEmpty(textoCifrado))
                return string.Empty;

            byte[] datosCifrados = Convert.FromBase64String(textoCifrado);
            byte[] claveBytes;

            using (var md5 = MD5.Create())
                claveBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(_claveBase));

            using var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = claveBytes,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            using var decryptor = tripleDes.CreateDecryptor();
            byte[] resultado = decryptor.TransformFinalBlock(datosCifrados, 0, datosCifrados.Length);

            return Encoding.UTF8.GetString(resultado);
        }
    }
}
