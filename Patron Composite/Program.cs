using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patron_Composite
{
    /// Patron de Composicion (Composite). Es de tipo estructural.
    /// Se usa generalmente para dar solución tipo arbol de jerarquias
    /// En este ejemplo se pueden crear los diferentes nodos de un arbol de jerarquias.
    /// Por ejemplo Animales => Mamiferos, Reptiles, Anfibios, Peces, Aves etc...
   
    /// <summary>
    /// C L I E N T E
    /// Manipula objetos en la composición a través de la interfaz Componente.
    /// </summary>
    class Cliente
    {
        static void Main(string[] args)
        {
            static void Mostrar(string msj) => Console.WriteLine(msj + "\r\n");
            static string LeerOpcion()
            {
                string respuesta = string.Empty;
                respuesta = Console.ReadLine();
                List<string> validos = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };

                while (!validos.Contains(respuesta))
                {
                    Mostrar("Opcion no valida.");
                    Mostrar("1-Adicionar Compuesto a elemento actual, 2-Adicionar Hoja, 3-Borrar Hijo, 4-Buscar en arbol, 5-Mostrar arbol, 6-Limpiar, 7-Salir");
                    respuesta = Console.ReadLine();
                }

                return respuesta.ToUpper();
            }
            static string LeerDato()
            {
                string respuesta = string.Empty;
                respuesta = Console.ReadLine();

                while (respuesta.Trim().Length == 0)
                {
                    Mostrar("Introduzca un nombre valido");
                    respuesta = Console.ReadLine();
                }

                return respuesta.ToUpper();
            }

            Componente<string> arbol = new Compuesto<string>("ROOT", null);
            Componente<string> elementoActual = arbol;


            string opcion = "";
            while (opcion != "7")
            {
                Mostrar($"Estoy en {elementoActual.Tipo()}-{elementoActual.Nombre}: ");
                Mostrar("1-Adicionar Compuesto a elemento actual, 2-Adicionar Hoja, 3-Borrar Hijo, 4-Buscar en arbol, 5-Mostrar arbol, 6-Limpiar, 7-Salir");
                opcion = LeerOpcion();

                string dato;
                if (opcion == "1")
                {
                    Mostrar("Dame el nombre del nuevo Compuesto: ");
                    dato = LeerDato();

                    Componente<string> c = new Compuesto<string>(dato, arbol);
                    elementoActual = elementoActual.Adicionar(c);
                }

                if (opcion == "2")
                {
                    Mostrar("Dame el nombre de la hoja: ");
                    dato = LeerDato();
                    elementoActual.Adicionar(new Hoja<string>(dato, arbol));
                }

                if (opcion == "3")
                {
                    Mostrar("Dame el elemento que deseas borrar: ");
                    dato = LeerDato();
                    elementoActual.Borrar(dato);
                }

                if (opcion == "4")
                {
                    Mostrar("Dame el elemento que deseas obtener");
                    dato = LeerDato();
                    elementoActual = arbol.Buscar(dato);
                    if (elementoActual == null)
                    {
                        Mostrar("Elemento no encotrado. Posición actual ROOT");
                        elementoActual = arbol;
                    }
                }

                if (opcion == "5")
                {
                    Mostrar(arbol.Mostrar(0));
                }

                if (opcion == "6")
                {
                    Console.Clear();
                }
            }
        }
    }

    /// <summary>
    /// C O M P O N E N T E
    /// Declara la interfaz de los objetos de la composición.
    /// Implementa el comportamiento predeterminado de la interfaz que es comun a todas las clase.
    /// Declara una interfaz para accede a sus componentes hijos y gestionarlos.
    /// (opcional) Define una interfaz para acceder al padre de un componente en la estructura recursiva y si es necesario la implementa.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class Componente<T>
    {
        public T Nombre { get; set; }

        /// <summary>
        /// Corresponde al Compuesto Raiz. Nodo Principal.
        /// </summary>
        public Componente<T> Raiz { get; set; }

        // Constructor
        protected Componente(T nombre, Componente<T> raiz)
        {
            Nombre = nombre;
            Raiz = raiz ?? this;
        }


        public abstract Componente<T> Adicionar(Componente<T> componente);

        public abstract Componente<T> Borrar(T elemento);

        public abstract Componente<T> Buscar(T elemento);

        public abstract string Mostrar(int profundidad);

        public abstract string Tipo();
    }

    /// <summary>
    /// H O J A
    /// Representa objetos hoja en la composición. Una no tiene hijos.
    /// Define el comportamiento de los objetos primitivos de la composición.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Hoja<T> : Componente<T>
    {
        private const string tipo = "Soy Hoja";

        // Constructor
        public Hoja(T nombre, Componente<T> raiz) : base(nombre, raiz)
        {
        }

        public override Componente<T> Adicionar(Componente<T> componente)
        {
            Console.WriteLine("Una Hoja no puede adicionar componentes");
            return Raiz;
        }

        public override Componente<T> Borrar(T elemento)
        {
            Console.WriteLine("Una Hoja no se puede auto borrar.");
            return this;
        }

        public override Componente<T> Buscar(T elemento)
        {
            if (elemento.Equals(Nombre))
            { return this; }
            else
            { return null; }
        }

        public override string Mostrar(int profundidad)
        {
            return new string('-', profundidad) + "Hoja " + Nombre + "\r\n";
        }

        public override string Tipo()
        {
            return tipo;
        }
    }

    /// <summary>
    /// C O M P U E S T O 
    /// Define el comportamiento de los Componentes que tienen hijos
    /// Almacenta Componentes hijos.
    /// Implementa las operaciones de la interfaz Componente relacionadas con los hijos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Compuesto<T> : Componente<T>
    {
        public const string tipo = "Soy Compuesto";
        public List<Componente<T>> Elementos { get; set; }

        // Constructor
        public Compuesto(T nombre, Componente<T> raiz) : base(nombre, raiz)
        {
            // Inicializar lista
            Elementos = new List<Componente<T>>();
        }

        public override Componente<T> Adicionar(Componente<T> componente)
        {
            if (Raiz.Buscar(componente.Nombre) == null)
            {
                Elementos.Add(componente);
                return Elementos.LastOrDefault();
            }
            else
            {
                Console.WriteLine("El elemento ya existe. No se admiten duplicados.");
                return Raiz;
            }
        }

        public override Componente<T> Borrar(T elemento)
        {
            // Buscar elemento a borrar
            Componente<T> miElemento = this.Buscar(elemento);

            // Si elemento existe entonces remover
            if (miElemento != null)
            {
                Elementos.Remove(miElemento);
            }

            return this;
        }

        public override Componente<T> Buscar(T elemento)
        {
            // Si busca a this entonces lo regresamos
            if (elemento.Equals(this.Nombre))
            { return this; }

            // Busqueda recursiva entre todos los elementos
            Componente<T> encontrado = null;
            foreach (Componente<T> miElemento in Elementos)
            {
                encontrado = miElemento.Buscar(elemento);

                if (encontrado != null) break;
            }

            return encontrado;
        }

        public override string Mostrar(int profundidad)
        {
            string respuesta = string.Empty;

            // Construción de cadena
            StringBuilder stringBuilder = new StringBuilder(new String('-', profundidad));

            // Adicionar la información del compuesto
            stringBuilder.Append("Compuesto " + Nombre + " elementos :" + Elementos.Count + "\r\n");

            // Adicionar elementos
            foreach (Componente<T> miElemento in Elementos)
            {
                stringBuilder.Append(miElemento.Mostrar(profundidad + 1));
            }

            respuesta = stringBuilder.ToString();

            return respuesta;
        }

        public override string Tipo()
        {
            return tipo;
        }
    }
}
