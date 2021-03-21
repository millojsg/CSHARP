using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Primer parámetro incluye el modificadoo <this>.
//Solo en clases estaticas no anidadas no genericas.

namespace Metodo_de_extension
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "1", "22", "333", "4444" };
        
            foreach (string s in Extensions.Slice(strings, 1,3))  
            {
                Console.WriteLine(Extensions.ToInt32(s));
            }

            //Otra manera de invocarlo
            foreach (string s in strings.Slice(1, 2))
            {
                Console.WriteLine(s.ToInt32());
            }

            Console.ReadLine();
        }
    }

    public static class Extensions
    { 
        //Convierte de string a entero
        public static int ToInt32(this string s)
        {
            return Int32.Parse(s);
        }

        //Retorna una una porcion del array que se le pase
        public static T[] Slice<T>(this T[] source, int index, int count)
        {
            if (index < 0 || count < 0 || source.Length - index < count)
                {throw new ArgumentException();}

            T[] result = new T[count];
            Array.Copy(source, index, result, 0, count);
            return result;
        }
    }
}
