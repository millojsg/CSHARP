using System;

namespace Mis_Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> mostrar = (texto) => Console.WriteLine(texto);

            Console.WriteLine("Ordenamiento burbuja:");

            int[] intArrayOriginal = new int[] { 4, 3, 97, 43, 4, 8, 7, 63, 9, 7, 41166, 87, 43, 698, 466, 87, 5, 987, 5 };

            int[] intArrayOrdenado = AlgoritmoBurbuja.OrdenarAscendentemente(intArrayOriginal);

            mostrar("");
            mostrar("*******************************");
            mostrar("Buscar duplicados. Algoritmo de Floyd Liebre Tortuga");

            int[] intArrayTest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,4 };

             AlgoritmoFloydTortugaLiebre.FindDuplicate(intArrayTest);

            Console.Read();
        }
    }
}
