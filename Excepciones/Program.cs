using System;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            int b = 10;

            Console.WriteLine("Ejemplo de excepcion controlada");
            try
            {
                do
                {
                    a = a / b;

                    //Lanzar excepcion
                    if (a == 0) { throw new miExcepcion("Error a = 0"); }

                } while (true);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Excepcion controlada");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Presione enter para avanzar al ejemplo 2");
            Console.ReadLine();


            //OTRO EJEMPLO
            Console.WriteLine("Ejemplo 2: Excepcion no controlada");
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

    //Es importante que para crear una clase excepciones esta debe heredar de Exception
    class miExcepcion : Exception
    {
        //Construtor básico cuando se hereda una clase base determinada
        public miExcepcion() : base() { }
        public miExcepcion(string message) : base(message) { }
        public miExcepcion(string message, string mensajeUsuario) : base(message) { Console.WriteLine(mensajeUsuario); }
        public miExcepcion(string message, Exception exception) : base(message, exception) { }
    }


}
