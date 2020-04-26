using System;

using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Serializacion_II
{ 

    /// <summary>
    /// Este serializa bajo el protocolo SOAP
    /// El archivo serializado se guarda en bin/debug
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Mis codigos Lambdas
            Action<string> mostrar = (string texto) => Console.WriteLine(texto);
            Func<String> leer = () => { return Console.ReadLine(); };

            // Action<> esperar = () => Console.ReadLine();

            mostrar("Opcion 1, crear y serializar clase.");
            mostrar("Opcion 2, leer clase serializada.");

            if (leer() == "1")
            {
                string nombre;
                string caracteristicas;


                mostrar("Introduzca nombre de la clase");
                nombre = leer();

                mostrar("Introduzca caracteristica de la clase");
                caracteristicas = leer();

                Clase miClase = new Clase(nombre, caracteristicas);

                mostrar($"Clase a serializar {miClase.Nombre}");

                //Formateador
                SoapFormatter formateador = new SoapFormatter();

                //Se crea stream 
                Stream miStream;
                miStream = new FileStream("miArchivoSoap.miPropiaExtension", FileMode.Create, FileAccess.Write, FileShare.None);

                //Sertializar
                formateador.Serialize(miStream, miClase);

                //cerrar el stream
                miStream.Close();
                mostrar($"Clase {miClase.Nombre} serializada correctamente");
            }
            else
            {

                mostrar("deserializando miArchivo.miPropiaExtension");

                //Crear formateador
                SoapFormatter formateador = new SoapFormatter();

                //Se crea stream 
                Stream miStream;
                miStream = new FileStream("miArchivoSoap.miPropiaExtension", FileMode.Open, FileAccess.Read, FileShare.None);

                //Des-sertializar
                Clase miClase = (Clase)formateador.Deserialize(miStream);

                //cerrar el stream
                miStream.Close();

                //usar el objeto des-serializadoo
                mostrar($"La clase Des-serializada es {miClase.Nombre}");

            }

            esperar();
        }
        static void esperar() { Console.ReadLine(); }

    }

    [Serializable]
    class Clase
    {
        string _nombre;
        string _caracteristicas;

        public Clase(string nombre, string caracteristicas)
        {
            this.Nombre = nombre;
            this.Caracteristicas = caracteristicas;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Caracteristicas { get => _caracteristicas; set => _caracteristicas = value; }

    }
}
