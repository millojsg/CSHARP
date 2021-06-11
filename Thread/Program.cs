using System;
using System.Threading;

namespace PracticaHilos
{
    class Program
    {
        private static bool ejecutar = true;
        

        static void Main(string[] args)
        {
            // Hilo básico, sin parametros.
            Thread miPrimerHilo = new Thread(Saludar);
            miPrimerHilo.Start();

            // Hilo con pase de parametros.
            // Nota los metodos Saludar y Mensaje son compatibles con 
            // los delegados pedidos por el constructor (ThreadStart y ParameterizedThreadStart).
            Thread miSegundoHilo = new Thread(Mensaje);
            miSegundoHilo.Start("El mensaje fue pasado por parametros.");

            // Creando multihilos
            // Notese que no son thread safe. Es decir, se cruza la informacion.
            //for (int i = 0; i < 9; i++)
            //{
            //    Thread misOchoHilos = new Thread(Funcion);
            //     misOchoHilos.Start(i);
            //}

            // Hay dos tipos de hilos
            // Foreground => Siguen existiendo aun si la aplicación termina el main. Thread es por defecto de tipo ForeGround
            // Background => Son hilos que finalizan si la aplicacón termina el main.

            // Notese con este ejemplo que a pesar del bucle infinito el hilo se cierra al 
            // terminar el main.
            Thread miTercerHiloBackGround = new Thread(FuncionBucle);
            miTercerHiloBackGround.IsBackground = true;
            miTercerHiloBackGround.Start(1);




            Console.WriteLine("Hello World! ");
        }



        static void Saludar()
        {
            System.Threading.Thread.Sleep(3500);
         Console.WriteLine("Hola soy el saludador."); 
        }

        static void Mensaje(object texto)
        {
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(texto.ToString());
        }

        static void FuncionBucle(object i)
        {
            while (ejecutar == true)
            {
                switch (i)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Soy el hilo 1");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Soy el hilo 2");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Soy el hilo 3");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Soy el hilo 4");
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Soy el hilo 5");
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Soy el hilo 6");
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Soy el hilo 7");
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Soy el hilo 8");
                        break;

                    default:
                        break;
                }

                Thread.Sleep(2000); 
            }
        
        
        }
    }
}
