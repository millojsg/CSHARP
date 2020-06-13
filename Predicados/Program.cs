using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicados
{
    class Program
    {
        //Los predicados siempre deben devolver un valor bool
        //esto debido a que es un delegado presestablecido por c#.

        static void Main(string[] args)
        {
            List<int> listaNumeros = new List<int>();

            listaNumeros.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 6546, 32 });

            Predicate<int> miPredicado = new Predicate<int>(esPar);

            List<int> pares = listaNumeros.FindAll(miPredicado);

            foreach (int num in pares)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }

        static bool esPar(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }

    }
}
