using System;

namespace Patron_Estrategia
{
    /// Patron de estrategia (Strategy) permite variar un algoritmo sin afectar al cliente.
    /// Un ejemplo de uso es cuando tenemos diferentes soluciones para un mismo fin
    /// estas soluciones pueden variar en calidad y tiempo de ejecución entonces el cliente (Aplicacion) o usuario
    /// puede seleccionar el algoritmo a utilizar. Otro ejemplo es el de exportar datos a un formato determinado
    /// pdf, excel, txt, scv, etc...
    /// Es de tipo comportamiento

    class Program
    {
        static void Main(string[] args)
        {
            Cantinero cantinero = new Cantinero();

            cantinero.PrepararBebida(new JugoNaranja());
            cantinero.PrepararBebida(new Pizco());
            cantinero.PrepararBebida(new JugoFresa());

            Console.ReadLine();
        }
    }

    /// <summary>
    /// ESTRATEGIA conocido como COMPONEDOR. Declara el tipo comun para todas las estrategias concretas.
    /// </summary>
    public interface IBebida
    {
        public void Preparar();
    }

    /// <summary>
    /// CONTEXTO conocido como COMPOSICIÓN. Es quien consume la estrategia concreta.  
    /// </summary>
    internal class Cantinero
    {
        public Cantinero() { } // Constructor

        internal void PrepararBebida(IBebida bebida) => bebida.Preparar();
    }

    /// <summary>
    /// Estrategia concreta. 
    /// </summary>
    internal class JugoNaranja : IBebida
    {
        internal JugoNaranja() { }  // Constructor

        public void Preparar() => Console.WriteLine("Aquí esta tú jugo de naranja");    
    }

    /// <summary>
    /// Estrategia concreta. 
    /// </summary>
    internal class JugoFresa : IBebida
    {
        internal JugoFresa(){} // Constructor

        public void Preparar() => Console.WriteLine("Aquí esta tú jugo de fresas.");    
    }

    /// <summary>
    /// Estrategia concreta. 
    /// </summary>
    internal class Pizco : IBebida
    {
        internal Pizco(){ } // Constructor

        public void Preparar() => Console.WriteLine("Aquí esta tú Pizco Sour.");        
    }
}
