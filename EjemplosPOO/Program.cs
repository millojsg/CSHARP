using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo MiCirculo;   //Variable objeto de tipo circulo

            MiCirculo = new Circulo(); //Ejemplerarizacion, Intanciacion, Instanciar clase, Ejmplar de clase

            double area;

            area = MiCirculo.CalculoArea(5);

            Console.WriteLine(area);

            //Variable anonima
            var MiClaseAnonima = new { Nombre = "Emilio", Edad = 16 };

            Console.WriteLine(MiClaseAnonima.Nombre + MiClaseAnonima.Edad);
            Console.ReadLine();
        }
    }

    class Circulo
    {
        const double pi = 3.1416; //Propiedad del circulo, campo de clase
       public double CalculoArea(int radio)
        {
            return pi * radio * radio;
        }
    }
          

}
