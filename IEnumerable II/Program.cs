using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_II
{
    //IEnumerable genericos


    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in Potencia(2, 8))
            {
                Console.Write("{0} ", i);
            }
        }

        public static System.Collections.Generic.IEnumerable<int> Potencia(int numero, int exponente)
        {
            int resultado = 1;

            for (int i = 0; i < exponente; i++)
            {
                resultado = resultado * numero;
                 yield return resultado; //Con la palabra yield regreso una coleccion de array tipo int.
            }
        }
    }
}
