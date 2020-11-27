using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtributosClaseDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaseDatos pruebas = new ClaseDatos();

            try
            {
                pruebas.Cadena = "[5] probando";
                pruebas.miLong = 101;
                pruebas.Cadena2 = "123";

                Console.WriteLine(pruebas.Cadena);
                Console.WriteLine(pruebas.miLong);
                Console.WriteLine(pruebas.Cadena2);
            
            
            }
            catch (Exception)
            {

                throw;
            }





        }
    }
}
