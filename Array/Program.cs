using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] edades;   //Declaracion
            edades = new int[3];  //Inicializacion

            edades[0] = 15;
            edades[1] = 20;
            edades[2] = 25;

            int i = 0;

            do
            {
                Console.WriteLine(edades[i++]);

            } while (i <= 2);

            Console.ReadLine();




        }
    }
}
