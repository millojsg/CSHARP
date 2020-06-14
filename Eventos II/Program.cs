using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Eventos_II
{
    //Las clases contienen métodos, propiedades y eventos.
    //El evento siempre requiere de un delegado
    //La declaracion de evento en un formalismo recomendado por Microsoft.
    //La clase creadora del evento se le conoce como editor
    //La clase que maneja el evento se le conoce como suscriptor
    //En este ejemplo el evento  contine una clase derivada de EventArgs que devuelve valores 
    //Nota los eventos no devuelven valores. Quien devuelve el valor es la firma que derive de EventArgs
    //Para que la  firma devuelva valores se tiene que crear una clase que derive de la clase EventArgs


    class Program
    {
        //Clase suscriptor
        static void Main(string[] args)
        {
            Operaciones miOperacion = new Operaciones();
            miOperacion.miEvento += miManejador;
            List<double> reales = new List<double> { 5, 6, 1, 54, 654, 3, 13, 21, 564, 64, 643, 51, 321, 654 };
            List<double> pares;

            try
            {
                pares = miOperacion.numerosPares(reales);

                Console.WriteLine(" Los numeros pares son:");

                foreach (double valor in pares)
                {
                    Console.WriteLine(valor.ToString());
                }

                Console.WriteLine("Presione tecla enter para continuar usando método lambda");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //El mismo objetivo que arriba pero usando lambda
            Console.WriteLine("Numeros pares");
            pares = reales.FindAll((double x) => x % 2 == 0);
            foreach (double valor in pares)
            {
                Console.WriteLine(valor.ToString());
            }
            Console.WriteLine("Numeros Impares");
            foreach (double valor in reales.FindAll((double x) => x % 2 != 0))
            {
                Console.WriteLine(valor.ToString());
            }

            Console.WriteLine("Presione tecla enter para terminar");
            Console.ReadLine();
        }

        //class Program
        private static void miManejador(object sender, misArgumentos e) //Manejador del evento
        {
            Console.WriteLine($"Mensaje activado por evento. Mensaje: {e.Mensaje} ; Valor:{e.Valor}");
            //es posible retornar valores a la clase editor. Para que redefina el flujo del codigo, ej.
            e.Valor ++;
        }
    }

    //Clase editor
    class Operaciones
    {
        public delegate void miDelegado(object sender, misArgumentos e);
        public event miDelegado miEvento;

        public List<double> numerosPares(List<double> miLista)
        {
            List<double> resultado = new List<double> { };
            
            foreach (double valor in miLista)
            {
                if (valor % 2 == 0)
                {
                    resultado.Add(valor);
                }
                else
                {
                    //Con el simbolo de interrogacion, El codigo no se ejecuta si miEvento es null
                    //En la clase misArgumentos se puede definir un constructor, seria mas estetico.
                    miEvento?.Invoke(this, new misArgumentos {Mensaje="Este numero no es par, sera cambiado por la clase suscriptora", Valor=valor});
                    resultado.Add(valor) //este es un valor devuelto por el suscriptor, manejador de eventos
                }
            }        
            return resultado;
        }
    }

    class misArgumentos : EventArgs
    {
        string a;
        double b;
        
        public string Mensaje { get => a; set => a = value; }
        public double Valor { get => b; set => b = value; }
    }
}
