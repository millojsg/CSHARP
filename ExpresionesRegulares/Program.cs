using System;
using System.Text.RegularExpressions;

namespace ExpresionesRegulares
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "Mi nombre es Emilio y mi numero de telefono es de chile 9- 4514 -1715";

            string patron = @"\+56 | 4514";

            Regex miRegex = new Regex(patron);

            bool resultado;
            resultado = miRegex.IsMatch(frase);

            string[] cuenta;

            cuenta = miRegex.GetGroupNames();

            foreach (string i in cuenta)
            {
                Console.WriteLine(i);
            }

            if (resultado == true)
            {
                Console.WriteLine("El texto contiene +56 | 4514");
            }
            else
            {
                Console.WriteLine("El texto no contiene +56 | 4514");
            }
            Console.ReadLine();
        }
    }
}
