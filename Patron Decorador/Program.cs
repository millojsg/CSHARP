using System;

namespace Patron_Decorador
{
    /// El patron decorador permite agregar funcionalidad a un objeto dinamicamente.
    /// Es de tipo Estructural.
    /// 
    /// 



    class Program
    {
        static void Main(string[] args)
        {
            Action<string> mostrar = (msj) => Console.WriteLine("\r\n" + msj);

            IDecorable miRobot = new Robot("Carlos", "Prototipo1", "Soy un robot al cual se le pueden añadir funcionalidades, es decir, soy decorable.", 20000);

            mostrar(miRobot.ToString());
            mostrar(miRobot.Funciones());
            mostrar($"Precio: {miRobot.ObtenerCosto()}");

            mostrar("Ahora agregaremos la funcionalidad de piernas.");
            miRobot = new Piernas(miRobot);
            mostrar(miRobot.Funciones());
            mostrar($"Precio: {miRobot.ObtenerCosto()}");

            mostrar("Ahora agregaremos la funcionalidad de brazos.");
            miRobot = new BrazosMecanicos(miRobot);
            mostrar(miRobot.Funciones());
            mostrar($"Precio: {miRobot.ObtenerCosto()}");

            mostrar("Ahora agregaremos la funcionalidad de sensor de temperatura.");
            miRobot = new SensorTemperatura(miRobot);
            mostrar(miRobot.Funciones());
            mostrar($"Precio: {miRobot.ObtenerCosto()}");

            Console.ReadLine();
        }
    }


    /// <summary>
    /// Conocido como COMPONENTE.
    /// Define una interfaz para los objetos a los cuales se le pueden agregar 
    /// decoraciones dinámicamente.
    /// </summary>
    public interface IDecorable
    { 
         public string Funciones();
         public double ObtenerCosto();
    }

    /// <summary>
    /// Conocido como DECORADOR.
    /// Es una interfaz que hereda de la interfaz COMPONENTE y solicita que se agrega la propiedad
    /// ComponenteConcreto.
    /// ComponenteConcreto es el objeto de tipo COMPONENTE al cual se le agregaran las decoraciones.
    /// </summary>
    public interface IDecoracion : IDecorable
    {
        IDecorable ComponenteConcreto { get; set; } 
    }

    /// <summary>
    /// Conocido como COPONENTE CONCRETO.
    /// Es una clase que hereda de COMPONENTE. Esta clase representa el objeto al cual se desea agregar funcionalidades.
    /// </summary>
    public class Robot : IDecorable
    {
        private string nombre;
        private string modelo;
        private string caracteristicas;
        private double costo;

        // Constructor
        public Robot(string nombre, string modelo, string caracteristicas, double costo)
        {
            this.nombre = nombre;
            this.modelo = modelo;
            this.caracteristicas = caracteristicas;
            this.costo = costo;
        }

        // Métodos propios de la clase Robot.
        public void CerrarPuertas()=>  Console.WriteLine("Puertas cerradas."); 
        public void AbrirPuertas()=>  Console.WriteLine("Puertas abiertas.");
        public override string ToString() => $"Soy {nombre}, {modelo} - {caracteristicas}";

        // Implementacion de la interfaz
        public string Funciones() => $"{nombre}:\r\n- Puedo ser programado. Función base.";
        public double ObtenerCosto() => costo;
    }

    /// <summary>
    /// Conocido como DECORADOR CONCRETO
    /// Es una clase que hereda de la interfaz DECORADOR. Contiene las funcionalidades extras que se desean 
    /// agregar al ComponenteConcreto.
    /// </summary>
    public class Piernas : IDecoracion
    {
        public IDecorable ComponenteConcreto { get; set; }

        public Piernas(IDecorable componenteConcreto)=>  ComponenteConcreto = componenteConcreto;        // Constructor

        public string Funciones() => ComponenteConcreto.Funciones() + "\r\n- Ahora puedo caminar. Agregado con decorador";

        public double ObtenerCosto() => ComponenteConcreto.ObtenerCosto() + 5000d;
    }

    /// <summary>
    /// Conocido como DECORADOR CONCRETO
    /// Es una clase que hereda de la interfaz DECORADOR. Contiene las funcionalidades extras que se desean 
    /// agregar al ComponenteConcreto.
    /// </summary>
    public class BrazosMecanicos : IDecoracion
    {
        public IDecorable ComponenteConcreto { get; set; }

        public BrazosMecanicos(IDecorable componenteConcreto) => ComponenteConcreto = componenteConcreto;        // Constructor

        public string Funciones() => ComponenteConcreto.Funciones() + "\r\n- Ahora puedo sujetar cosas. Agregado con decorador";

        public double ObtenerCosto() => ComponenteConcreto.ObtenerCosto() + 2000d;
    }

    /// <summary>
    /// Conocido como DECORADOR CONCRETO
    /// Es una clase que hereda de la interfaz DECORADOR. Contiene las funcionalidades extras que se desean 
    /// agregar al ComponenteConcreto.
    /// </summary>
    public class SensorTemperatura : IDecoracion
    {
        public IDecorable ComponenteConcreto { get; set; }

        public SensorTemperatura(IDecorable componenteConcreto) => ComponenteConcreto = componenteConcreto;        // Constructor

        public string Funciones() => ComponenteConcreto.Funciones() + "\r\n- Ahora puedo medir la temperatura. Agregado con decorador";

        public double ObtenerCosto() => ComponenteConcreto.ObtenerCosto() + 2000d;
    }
}
