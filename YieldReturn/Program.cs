using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldReturn
{
    class Program
    {
        /*El YieldReturn funciona junto a la interfaz Enumerable
         * sirve para retornar componentes que de computan en tiempo real     
         * 
         * CONSIDERACIONES
         *1-No puede tener en la firma out ni ref.
         * 2-No se puede incluir dentro de un lambda
         * 
         */

        static IEnumerable<int> GetNumPair(int start)
        {
            for (int i = start; i < i + 2; i++)
            {
                if (i % 2 != 0) continue;
                yield return i;
            }
        }

        /// <summary>
        /// Return basic number using yiel return
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        static IEnumerable<int> GetNum()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }

 
        /// <summary>
        /// Return a Powered numbers
        /// </summary>
        /// <param name="number"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        static void Main(string[] args)
        {
            // EXAMPLE #1
            Console.WriteLine("*****Example1******");
            // GetNumPair es una función que retorna
            // numeros infinitos. Por esto se usa Take
            // que es una funcion Linq para que tome
            // solo los primeros 50.
            var myList = GetNumPair(101).Take(10);

            foreach (int myInt in myList)
            {
                Console.WriteLine(myInt);
            }

            // EXAMPLE #2
            Console.WriteLine("*****Example2******");
            IEnumerable<int> myList2 = GetNum();

            myList2.ToList().ForEach(x => Console.WriteLine(x));

            // EXAMPLE #3
            Console.WriteLine("*****Example3******");
            IEnumerable<int> myList3 = Power(5,8);

            myList3.ToList().ForEach(x => Console.Write(x + "  "));

            Console.ReadLine();
        }
    }
}
