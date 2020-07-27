using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            int b = 10;

            try
            {
                do
                {
                    a = a / b;

                    if (a == 0) { throw new miExcepcion("Error a = 0"); }

                } while (true);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Excepcion controlada");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();


            //OTRO EJEMPLO
            Console.WriteLine("Ejemplo 2*************");
           a = 100;
           b = 0;

            try
            {
                    a = a / b;
            }
            catch (Exception ex)
            {
                throw new miExcepcion("Error a = 0", "Este es el mensaje para el usuario");
            }
            Console.ReadLine();

            Console.WriteLine("Terminado");









        }
    }

    class miExcepcion : Exception
    {
        public miExcepcion() : base() { }
        public miExcepcion(string message) : base(message) { }
        public miExcepcion(string message, string mensajeUsuario) : base(message) { Console.WriteLine(mensajeUsuario); }
        public miExcepcion(string message, Exception exception) : base(message, exception) { }
    }


}
