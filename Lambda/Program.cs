using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    public delegate string OpMatematicas(int num);
    public delegate int Suma(int n1,int n2);


    class Program
    {

        //  =>   Equivale al operador lambda
        //  Seguido viene el la expresion y despoes el bloque de setencia
        static void Main(string[] args)
        {
            // L A M B D AS 
            Action<string> mostrar = (string texto) => Console.WriteLine(texto);  //No devuelve valores

            Func<String> leer = () => { return Console.ReadLine(); };  //Devuelve valor

            Suma miSuma = (n1, n2) => n1 + n2; // Este es un lambda que necesita la declaracion de la firma previamente

            // A P L I C A N D O 

            OpMatematicas miDelegado = new OpMatematicas(Cuadrado);

            mostrar("Resultados");

            mostrar(miDelegado(8));

            mostrar(Convert.ToString(miSuma(4, 40)));

            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 8, 7, 9, 10 };
            List<int> numPares = numeros.FindAll(i => i % 2 == 0);  //Se usa Lambda a cambio del predicado para ahorrar codigo. Ver predicado en Explorador
            foreach (int i in numPares)
            {
                mostrar(Convert.ToString(i));
            }
            leer();
        }

        public static string Cuadrado(int num)
        {
            return Convert.ToString(num * num);
        }




    }

    class Persona
    {
        private string _nombre;
       private int _edad;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
    }



}
