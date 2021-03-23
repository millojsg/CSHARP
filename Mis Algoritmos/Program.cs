using System;

namespace Mis_Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ordenamiento burbuja:");

            int[] intArrayDesordenado = new int[] { 4, 3, 97, 43, 4, 8, 7, 63, 9, 7, 41166, 87, 43, 698, 466, 87, 5, 987, 5 };

            int[] intArrayOrdenado = AlgoritmoBurbuja.OrdenarAscendentemente(intArrayDesordenado);

            Console.Read();
        }
    }
}
