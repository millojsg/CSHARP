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
            Ballena ballena1 = new Ballena("Willy");
            Lagartija lagartija1 = new Lagartija("Juancho");

            Animales[] misAnimales = new Animales[5];
            misAnimales[0] = humano1;
            misAnimales[1] = caballo1;
            misAnimales[2] = gorila1;
            misAnimales[3] = ballena1;
            misAnimales[4] = lagartija1;

            Mamiferos[] misMamiferos = new Mamiferos[4];
            misMamiferos[0] = humano1;
            misMamiferos[1] = caballo1;
            misMamiferos[2] = gorila1;
            misMamiferos[3] = ballena1;

            // Solo mamimeferos
            // Notese que no se puede agregar a Juancho a esta lista debido a que Juancho no es un mamifero.
            Console.WriteLine("***Mamiferos***");
            foreach (Mamiferos mamifero in misMamiferos)
            {
                System.Console.WriteLine(mamifero.Clasificacion() + " - " + mamifero.GetNombre());
            }

            // Todos los animales
            Console.WriteLine("\r\n***Todos los animales***");
            foreach (Animales animales in misAnimales)
            {
                System.Console.WriteLine(animales.Clasificacion() + " - " + animales.GetNombre());
            }

            Console.ReadLine();
        }
    }

    abstract class Animales
    {
        private string nombreAnimal;

        protected Animales(string nombreAnimal)
        {
            this.nombreAnimal = nombreAnimal;
        }

        //parte del constructor que funciona como Get de la variable nombreMamifero
        public string GetNombre()
        {
            return nombreAnimal;
        }

        public void Respirar()
        {
            Console.WriteLine("Soy capaz de respirar");
        }

        /// <summary>
        /// Ejemplo. Mamifero, Reptil, Anfibio, Pez
        /// </summary>
        public abstract string Clasificacion();
    }

    class Mamiferos : Animales
    {
        private const string clasificacion = "Soy mamifero";

        //constructor que reemplaza el constructor por defecto :base a su vez funciona como Set de la variable nombreMamifero
        public Mamiferos(string nombre) : base(nombre)
        {
        }

        public override string Clasificacion()
        {
            return clasificacion;
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

    class Lagartija : Animales
    {
        const string clasificacion = "Soy Reptil";

        public Lagartija(string nombreAnimal) : base(nombreAnimal)
        {
        }

        public override string Clasificacion()
        {
            return clasificacion;
        }
    }


    class Humanos : Mamiferos, IMamiferosTerrestres
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Humanos(string nombreHumano) : base(nombreHumano) { }

        public void Pensar()
        {
            Console.WriteLine("Soy capaz de pensar");
        }

        public void NumeroPatas()
        {
            Console.WriteLine("Tengo 2 patas");
        }
    }
    
    class Gorilas : Mamiferos, IMamiferosTerrestres
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Gorilas(String nombreGorila) : base(nombreGorila) { }

        public void Trepar()
        {
            Console.WriteLine("Soy capaz de trepar");
        }

        public void NumeroPatas()
        {
            Console.WriteLine("Tengo 4 patas");
        }
    }

    class Caballos : Mamiferos, IMamiferosTerrestres
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Caballos(String nombreCaballo) : base(nombreCaballo) { }

        public void Galopar()
        {
            Console.WriteLine("Soy capaz de galopar");
        }

        public void NumeroPatas()
        {
            Console.WriteLine("Tengo 4 patas");      
        }
    }

    class Ballena : Mamiferos
    {
        //Al modificar el constructos de la clase heredada se debe modifica el constructor base de esta clase
        public Ballena(String nombreBallena) : base(nombreBallena) { }

        public void Sumergirse()
        {
            Console.WriteLine("Soy capaz de sumergirme");
        }
    }

    /// <summary>
    /// Esta interfaz se crea por la necesidad de implentar sobre los mamiferos terrestres unicamente
    /// debido a que la clase ballena no tiene patas.
    /// </summary>
    interface IMamiferosTerrestres
    {
        void NumeroPatas();    
    }
}
