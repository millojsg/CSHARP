using System;

namespace Mis_Algoritmos
{
   public static class AlgoritmoBurbuja
    {
        /*El algoritmo burbuja, es facil de usar.
         *tiene una complejidad cuadratica por tanto 
         *se cataloga como uno de los más deficientess.
         */

        /// <summary>
        /// Nota: el parametro intArrayDesordenado se pasa por referencia.
        /// </summary>
        /// <param name="intArrayDesordenado"></param>
        /// <returns></returns>
        public static int[] OrdenarAscendentemente(int[] intArrayDesordenado)
        {
            int[] miArray = (int[])intArrayDesordenado.Clone();
            
            //int[] miArray = intArrayDesordenado; //<-- El array se pasa por referencia. 

            // Recorrer según la cantidad de elementos del array partiendo desde la posicion 0.
            int cantElementosBaseCero = miArray.Length - 1;

            for (int ciclos = cantElementosBaseCero; ciclos > 0; ciclos--)
            {
                for (int puntero = 0; puntero < ciclos; puntero++)
                {
                    // Si el valor contenido en mi puntero es mayor que el valor de la derecha, entonces intercambiar.
                    if ( miArray[puntero] > miArray[puntero + 1])
                    {
                        int memoria1 = miArray[puntero];
                        int memoria2 = miArray[puntero + 1];

                        // Se intercambian los valores.
                        miArray[puntero] = memoria2;
                        miArray[puntero + 1] = memoria1;

 
                    }
                }
                // Mostrar resultados en consola
                foreach (int valor in miArray)
                {
                    Console.Write(valor + "  ");
                }
                Console.WriteLine();
            }
            return miArray;
        }
    }
}
