using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Las clases contienen métodos, propiedades y eventos.
//El evento siempre requiere de un delegado.
//La declaracion de evento en un formalismo recomendado por Microsoft.
//Este es un ejemplo para levantar un evento cada vez que se divida por cero.
//La clase creadora del evento se le conoce como editor.
//La clase que maneja el evento se le conoce como suscriptor.
//En este ejemplo la firma del delegado del evento no devuelve valores.
//Para que el delegado devuelva valores se tiene que crear una clase que derive de la clase EventArgs.
//La otra forma de crear notificaciones es atraves de excepciones.

namespace Eventos
{
    class Program
    {
        public static Action<string> mostrar = (x)=>Console.WriteLine(x);

        static void Main(string[] args)
        {
            Operaciones miOperacion = new Operaciones();
            miOperacion.miEvento += miManejador;    
            double a, b, c;

            do {
                try
                {
                    Console.WriteLine("Introduzca el enumerador");
                    a = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Introduzca el divisor");
                    b = Int32.Parse(Console.ReadLine());

                    c = miOperacion.Division(a, b);

                    Console.WriteLine($"El resultado es {c}");

                    Console.WriteLine("Presione 'q' si desea pasar al siguiente ejemplo. Si desea continuar con el actual ejemplo presione cualquier otra tecla...");
                    if (Console.ReadLine() == "q") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (true);



           // Segundo ejemplo...
                mostrar("****Este es el segundo ejemplo. sin EventArgs o sender*******");

                OperacionesConEventoIndormal miOperacion2 = new OperacionesConEventoIndormal();
                miOperacion2.miEvento += miManejadorInformal;
            do
            {
                try
                {
                    Console.WriteLine("Introduzca el enumerador");
                    a = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Introduzca el divisor");
                    b = Int32.Parse(Console.ReadLine());

                    c = miOperacion2.Division(a, b);

                    Console.WriteLine($"El resultado es {c}");

                    Console.WriteLine("Presione 'q' si desea finalizar aplicacion, en caso de querer continuar con este ejemplo presione cualquier otra tecla...");
                    if (Console.ReadLine() == "q") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);


        }
        
        private static void miManejador(object sender, EventArgs e) //Manejador del evento
        {
            Console.WriteLine("Mensaje activado por evento. Estas dividiendo por cero");
        }

        private static void miManejadorInformal(string mensaje) //Manejador del evento
        {
            Console.WriteLine(mensaje);
        }

    }

    class Operaciones
    {
        public delegate void  miDelegado(object sender, EventArgs e);
        public event miDelegado miEvento;

        public double Division(double a, double b)
        {
            double resultado = 0;

            if (b == 0)
            {
                if (miEvento != null)
                {
                    miEvento(this, EventArgs.Empty);    //Esta intruccion levanta la notificacion del lado del suscriptor            
                }
            }
            else
            {
                resultado = a / b; 
            }          
            return resultado;
        }
    }

    class OperacionesConEventoIndormal
    {
        public delegate void miDelegado(string mensaje);
        public event miDelegado miEvento;

        public double Division(double a, double b)
        {
            double resultado = 0;

            if (b == 0)
            {
                if (miEvento != null)
                {
                    miEvento("Hey soy el Evento. Estas intentando dividir entre cero, que burro...");    //Esta intruccion levanta la notificacion del lado del suscriptor            
                }
            }
            else
            {
                resultado = a / b;
            }
            return resultado;
        }
    }


}


