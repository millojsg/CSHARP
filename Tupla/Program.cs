using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tupla
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, string>> miListaTupla = new List<Tuple<int, string>>();

            miListaTupla.Add(new Tuple<int, string>(1,"prueba1"));
            miListaTupla.Add(new Tuple<int, string>(2,"prueba2"));
            miListaTupla.Add(new Tuple<int, string>(3,"prueba3"));
            miListaTupla.Add(new Tuple<int, string>(4,"prueba4"));


            foreach(Tuple<int, string> t in miListaTupla)
            {
                Console.WriteLine(String.Format("Valor int: {0} | Valor string: {1}", t.Item1, t.Item2));


            }



            Console.ReadLine();






        }
    }
}
