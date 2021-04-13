using System;

namespace Algoritmo_Floyd_Tortuga_y_Liebre
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> mostrar = (texto) => Console.WriteLine(texto);

            mostrar("*******************************");
            mostrar("Buscar duplicados. Algoritmo de Floyd Liebre Tortuga");

            int[] intArrayTest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 4 };

            AlgoritmoFloydTortugaLiebre.FindDuplicate(intArrayTest);

            Console.Read();
        }
    }

    public static class AlgoritmoFloydTortugaLiebre
    {
        /*Este es un algoritmo que permite 
         * encontrar duplicados de manera eficiente 
         */

        public static void FindDuplicate(int[] numeros)
        {
            var tortuga = numeros[0];
            var liebre = numeros[0];

            while (true)
            {
                tortuga = numeros[tortuga];
                liebre = numeros[numeros[liebre]];

                if (tortuga == liebre) break;
            }

            var puntero1 = numeros[0];
            var puntero2 = tortuga;

            while (puntero1 != puntero2)
            {
                puntero1 = numeros[puntero1];
                puntero2 = numeros[puntero2];
            }

            var result = puntero1;
        }



    }
}
