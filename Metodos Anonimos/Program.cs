using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_Anonimos
{
    class Program
    {
        static void Main(string[] args)
        {
            //El método anonimo, es la declaracion de un metodo sin nombre de identificacion
            //para que este sea valido se debe usar la paabra delegate antes de los parentesis
            //Ejemplo
            Action<string> miDelegadoEscribir = delegate (string x) { System.Console.WriteLine(x); System.Console.ReadLine();};
            miDelegadoEscribir.Invoke("Esta es un delegado con método anonimo");

            Func<int, int, int> miDelegadoSuma = delegate (int a, int b) { return a + b;};

            miDelegadoEscribir.Invoke(miDelegadoSuma(5, 4).ToString());
        }
    }
}
