using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Algoritmos
{
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
