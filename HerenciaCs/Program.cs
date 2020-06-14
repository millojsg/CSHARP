using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Humanos humano1 = new Humanos("Frany");
            Caballos caballo1 = new Caballos("Rayo");
            Gorilas gorila1 = new Gorilas("KingKong");

            Mamiferos[] misMamiferos = new Mamiferos[3];

            misMamiferos[0] = humano1;
            misMamiferos[1] = caballo1;
            misMamiferos[2] = gorila1;

            foreach (Mamiferos i in misMamiferos)
            {
                System.Console.WriteLine(i.GetNombre());
            }

            Console.ReadLine();
        }
    }
    
    class Mamiferos
    {
        private string nombreMamifero;
        //constructor que reemplaza el constructor por defecto :base a su vez funciona como Set de la variable nombreMamifero
        public Mamiferos(string nombre)
        {
            nombreMamifero = nombre;
        }
        //parte del constructor que funciona como Get de la variable nombreMamifero
        public string GetNombre()
        {
            return nombreMamifero;
        }

        public void Respirar()
        {
            Console.WriteLine("Soy capaz de respirar");
        }

        public void Lactar()
        {
            Console.WriteLine("Soy capaz de lactar");
        }

        public void Reproduccion()
        {
            Console.WriteLine("Soy capaz de reproducirme");
        }
    }
    
    class Humanos : Mamiferos
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Humanos(string nombreHumano) : base(nombreHumano) { }

        public void Pensar()
        {
            Console.WriteLine("Soy capaz de pensar");
        }

    }
    
    class Gorilas : Mamiferos
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Gorilas(String nombreGorila) : base(nombreGorila) { }

        public void Trepar()
        {
            Console.WriteLine("Soy capaz de trepar");
        }
    }

    class Caballos : Mamiferos
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Caballos(String nombreCaballo) : base(nombreCaballo) { }

        public void Galopar()
        {
            Console.WriteLine("Soy capaz de galopar");
        }
    }
}
