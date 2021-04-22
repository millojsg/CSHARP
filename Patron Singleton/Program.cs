using System;

namespace Patron_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> mostrar = (msj) => Console.WriteLine("\r\n" + msj);

            ClaseSingleton claseSingleton1 = ClaseSingleton.ObtenerInstancia("Maria");
            ClaseSingleton claseSingleton2 = ClaseSingleton.ObtenerInstancia("Jose");

            string cadena = $@"Soy claseSingleto2 supuestamente creado por Jose. 
igualmente preguntaré por mi creador usando la siguiente instrucción 
claseSingleton2.Creador => R. { claseSingleton2.Creador}";
            mostrar(cadena);

            claseSingleton1.Acumular(3);
            claseSingleton2.Acumular(4);

            mostrar(claseSingleton1.Acumulado.ToString());

            Console.ReadLine();
        }

       
    }

    public class ClaseSingleton
    { 
        private static ClaseSingleton instancia;

        private ClaseSingleton(string creador)
        {
            Creador = creador;
            Acumulado = 0; 
        }

        public static ClaseSingleton ObtenerInstancia(string creador = "Desconocido")
        {
            if (instancia == null)
            {
                instancia = new ClaseSingleton(creador);
            }

            return instancia;            
        }

        public string Creador { get; }

        public double Acumulado { get; set; }

        public double Acumular(double valor) => Acumulado += valor;
        
    }


}
