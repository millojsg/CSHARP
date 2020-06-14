using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tareas
{
    class Program
    {

        static void Main(string[] args)
        {
            int i = 1;
            string miCadena = "Tarea 2";

            Action miDelegado = delegate(){ do { Console.WriteLine($"Tarea {i} - { Thread.CurrentThread.ManagedThreadId}"); Thread.Sleep(2000); } while (true); };

            Task T1 = new Task(miDelegado);

            Task T2 = new Task((miTexto) => System.Console.WriteLine(miTexto), miCadena);;

            Task T3 = new Task(() =>
            {
                do
                {
                    System.Console.WriteLine($"Tarea 3 -{ Thread.CurrentThread.ManagedThreadId}");                
                    Thread.Sleep(5000);
                } while (true);              
            }
            );

            T1.Start();
            T2.Start();
            T3.Start();

            do
            {
                System.Console.WriteLine($"Hilo actual: { Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(1000);
            } while (true);
        }

        private string HiloActual()
        {  
            return $"Hilo actual: { Thread.CurrentThread.ManagedThreadId}\n";
        }
    }
}
