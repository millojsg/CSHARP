using System;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializacion
{
    class Program
    {
/// <summary>
/// Este ejemplo serializa bajo el protocolo binario
/// por defecto el archivo serializado se guarda en bin/debug
/// </summary>
/// <param name="args"></param>

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
                BinaryFormatter formateador = new BinaryFormatter();

                //Se crea stream 
                Stream miStream;
                miStream = new FileStream("miArchivoBinario.miPropiaExtension", FileMode.Create, FileAccess.Write, FileShare.None);

                //Sertializar
                formateador.Serialize(miStream, miClase);

                //cerrar el stream
                miStream.Close();
                mostrar($"Clase {miClase.Nombre} serializada correctamente");
            }
            else
            {

                mostrar("deserializando miArchivoBinario.miPropiaExtension");

                //Crear formateador
                BinaryFormatter formateador = new BinaryFormatter();

                //Se crea stream 
                Stream miStream;
                miStream = new FileStream("miArchivoBinario.miPropiaExtension", FileMode.Open, FileAccess.Read, FileShare.None);

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
