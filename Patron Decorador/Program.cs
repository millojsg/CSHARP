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

            IRobot miRobot = new Robot("Carlos","Prototipo1","Es un robot al cual se le pueden añadir funcionalidades", 20000);

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

    public interface IRobot
    {
        public string Funciones();
        public double ObtenerCosto();
    }

    public class Robot : IRobot
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

    public class Piernas : IRobot
    {
        IRobot robot;

        public Piernas(IRobot robot)
        {
            this.robot = robot;
        }

        public string Funciones() => robot.Funciones() + "\r\n- Ahora puedo caminar. Agregado con decorador";

        public double ObtenerCosto() => robot.ObtenerCosto() + 5000d;
    }

    public class BrazosMecanicos : IRobot
    {
        IRobot robot;

        public BrazosMecanicos(IRobot robot)
        {
            this.robot = robot;
        }

        public string Funciones() => robot.Funciones() + "\r\n- Ahora puedo sujetar cosas. Agregado con decorador";

        public double ObtenerCosto() => robot.ObtenerCosto() + 2000d;
    }

    public class SensorTemperatura : IRobot
    {
        IRobot robot;

        public SensorTemperatura(IRobot robot)
        {
            this.robot = robot;
        }

        public string Funciones() => robot.Funciones() + "\r\n- Ahora puedo medir la temperatura. Agregado con decorador";

        public double ObtenerCosto() => robot.ObtenerCosto() + 2000d;
    }








}
