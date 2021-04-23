using System;
using System.Threading.Tasks;

namespace Delegados_IV
{
    // En este ejercicio usaré Func, el cual es un tipo de delegado predefinido  en C#.
    // El truco esta que al Func le entra un objeto tipo Task.

    class Program
    {
        static async Task Main(string[] args)
        {
            Func<Task> miDelegadoAsyncrono = async () =>
            {
                Console.WriteLine("Entrada en método asincrono");
                await Task.Delay(1000);
                Console.WriteLine("Primer delay");
                await Task.Delay(5000);
                Console.WriteLine("Segundo delay");
            };
            
            Console.WriteLine("Yo estoy antes del await");
            
            await miDelegadoAsyncrono();

            Console.WriteLine("Yo estoy despues del await");

            Console.ReadLine();

        }
    
    }
}
