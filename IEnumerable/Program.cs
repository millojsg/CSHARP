using System;
using System.Collections;

namespace miIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona[] aPersona = new Persona[3]
            {
            new Persona("John", "Smith"),
            new Persona("Jim", "Johnson"),
            new Persona("Sue", "Rabon"),
            };

            Personas misPersonas = new Personas(aPersona);

            //Usando la clase Array para escribir en consola
            Array.ForEach<Persona>(aPersona, (p) => Console.WriteLine(p.Nombre + " " + p.Apellido));

            //El foreach consulta el método GetEnumerator embebido en la clase Array del FrameWork
            foreach (Persona p in aPersona)
            {
                {Console.WriteLine(p.Nombre + " " + p.Apellido);}
            }

            //El foreach consulta directamente el metodo GetEnumerator de la clase Personas creado por mí.
            //El método GetEnumerator le entrega una instancia de la clase PersonasEnumerator.
            foreach (Persona p in misPersonas)
            { Console.WriteLine(p.Nombre + " " + p.Apellido); }

            Console.ReadLine();
        }
    }

//  ___ _      _   ___ ___   _  _ ___ ___  ___   ___ ___ ___  
// / __| |    /_\ / __| __| | \| | __/ __|/ _ \ / __|_ _/ _ \ 
//| (__| |__ / _ \\__ \ _|  | .` | _| (_ | (_) | (__ | | (_) |
// \___|____/_/ \_\___/___| |_|\_|___\___|\___/ \___|___\___/ 
    // Clase tipo objeto de negocio
    public class Persona
    {
        public Persona(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
   
//  ___ _      _   ___ ___     ___ ___ _  _ _   _ __  __ ___ ___    _   ___ _    ___
// / __| |    /_\ / __| __|   |_ _| __| \| | | | |  \/  | __| _ \  /_\ | _ ) |  | __|
//| (__| |__ / _ \\__ \ _|     | || _|| .` | |_| | |\/| | _||   / / _ \| _ \ |__| _|
// \___|____/_/ \_\___/___|   |___|___|_|\_|\___/|_|  |_|___|_|_\/_/ \_\___/____|___|
    // Clase que representa una coleccion de persona. 
    // Como implementa IEnumerable debe usar la sintaxis de foreach en el constructor 
    public class Personas : System.Collections.IEnumerable
    {
        private Persona[] aPersona; //Array clase Persona
     
        public Personas(Persona[] aPersona) // Constructor 
        {
           
            //Se inicializa el array aPersona
            this.aPersona = new Persona[aPersona.Length];

            for (int i = 0; i < aPersona.Length; i++)
            {
                this.aPersona[i] = aPersona[i];
            }
        }

        public IEnumerator GetEnumerator() //Solicitado por la interfaz IEnumerable
        {
            return new PersonasEnumerator(aPersona);
        }
    }

//  ___ _      _   ___ ___     ___ ___ _  _ _   _ __  __ ___ ___    _ _____ ___  ___
// / __| |    /_\ / __| __|   |_ _| __| \| | | | |  \/  | __| _ \  /_\_ _  / _ \| _ \
//| (__| |__ / _ \\__ \ _|     | || _|| .` | |_| | |\/| | _||   / / _ \| || (_) |   /
// \___|____/_/ \_\___/___|   |___|___|_|\_|\___/|_|  |_|___|_|_\/_/ \_\_| \___/|_|_\
    // Cuando se implementa un IEnumerable, acto seguido se debe implementar un IEnumerator
    // Esto por que es requerido por el método solicitado por la interfaz IEnumerable
    public class PersonasEnumerator : IEnumerator
    {
        public Persona[] aPersona {get; set;} //Array de la clase Persona
        private int posicion = -1; // Enumerators se posiciona antes del primer elemento hasta que MoveNext sea llamado

        public PersonasEnumerator(Persona[] aPersona) //Constructor
        {
            this.aPersona = aPersona;
        }

        public object Current //Propiedad get requerida por la interfaz IEnumerator
        {
            get
            {
                try
                {
                    return aPersona[posicion];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();

                }
            }
        }

        public bool MoveNext() //Requerido por la interfaz  IEnumerator
        {
            posicion++;
            return (posicion < aPersona.Length);
        }

        public void Reset() //Requerido por la interfaz IEnumerator
        {
            posicion = -1;
        }
    }

}





