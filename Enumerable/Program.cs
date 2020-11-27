using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerable
{
    class Program
    {
        static int[] A = System.Linq.Enumerable.Range(0, 5).ToArray();
        static List<int> B = System.Linq.Enumerable.Range(0, 5).Select(elemento => elemento * 2).ToList<int>();
        static List<int> C = System.Linq.Enumerable.Range(0, 5).Select(elemento => elemento * 2).Where(elemento => elemento>4).ToList();
        static List<int> D = System.Linq.Enumerable.Range(0, 5).Select(Potencia).Where(elemento => elemento>4).ToList();

        private static int Potencia(int arg)
        {
            return (int)arg * (int)arg;
        }

        static void Main(string[] args)
        {
            List<int> A1 = A.ToList<int>();

            Console.WriteLine("----------------------------------------------");
            A1.ForEach(elemento => Console.WriteLine($"La matriz A tiene: {elemento}"));

            Console.WriteLine("----------------------------------------------");
            
            B.ForEach(elemento => Console.WriteLine($"La matriz B tiene: {elemento}"));

            Console.WriteLine("----------------------------------------------");

            C.ForEach(elemento => Console.WriteLine($"La matriz C tiene: {elemento}"));

            Console.WriteLine("----------------------------------------------");

            D.ForEach(elemento => Console.WriteLine($"La matriz D tiene: {elemento}"));

            // Bool para determinar si todos los elementos de una lista satisfacen 
            // una condicion determinada

            bool mayor0 = B.All(elemento => elemento >= 0);
            bool mayor3 = B.All(elemento => elemento > 3);
            bool menor9 = B.All(Menor9);

            Console.WriteLine($"Lista B todos los elementos mayores o igual a 0 :{mayor0}");
            Console.WriteLine($"Lista B todos los elementos mayores a 3 :{mayor3}");
            Console.WriteLine($"Lista B todos los elementos menores a 9 :{menor9}");

            Console.ReadLine();
        }

        private static bool Menor9(int arg)
        {
            return arg<9;
        }
    }
}
