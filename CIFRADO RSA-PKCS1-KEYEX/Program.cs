using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CIFRADO_RSA_PKCS1_KEYEX
{
    class Program
    {
        static void Main(string[] args)
        {
            RsaEnc rs = new RsaEnc();
            Console.WriteLine($"PublicKey: \n {rs.PublicKeyString()}\n");

            Console.WriteLine($"PublicKey: \n {rs.PrivateKeyString()}\n");

            Console.WriteLine($"Mensaje a encriptar: prueba");
            //var mensaje = Console.ReadLine();
            var mensaje = "prueba";
            var cifrado = String.Empty;
            if (mensaje != String.Empty)
            {
                cifrado = rs.Encriptar(mensaje);
                Console.WriteLine($"Mensaje cifrado: \n {cifrado} \n");
            }

            Console.WriteLine("Presiona enter para descifrar");

            Console.WriteLine($"Mensaje descifrado: \n {rs.Desencriptar(cifrado)} \n");

            Console.ReadLine();

        }

        public class RsaEnc
        {
            private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
            private RSAParameters _privateKey;
            private RSAParameters _publicKey;

            public RsaEnc()
            {
                _privateKey = csp.ExportParameters(true);
                _publicKey = csp.ExportParameters(false);
            }

            public string PublicKeyString()
            {
                var sw = new StringWriter();
                var xs = new XmlSerializer(typeof(RSAParameters));

                xs.Serialize(sw, _publicKey);
                return sw.ToString();
            }

            public string PrivateKeyString()
            {
                var sw = new StringWriter();
                var xs = new XmlSerializer(typeof(RSAParameters));

                xs.Serialize(sw, _privateKey);
                return sw.ToString();
            }

            public string Encriptar(string mensaje)
            {
                csp = new RSACryptoServiceProvider();
                csp.ImportParameters(_publicKey);

                byte[] data = Encoding.GetEncoding("ISO-8859-1").GetBytes(mensaje);
                byte[] cifrado = csp.Encrypt(data, false);

                return Convert.ToBase64String(cifrado);
            }

            public string Desencriptar(string cifrado)
            {
                byte[] data = Convert.FromBase64String(cifrado);
                csp.ImportParameters(_privateKey);

                var mensaje = csp.Decrypt(data, false);
                return Encoding.GetEncoding("ISO-8859-1").GetString(mensaje);
            }
        }
    }
}
