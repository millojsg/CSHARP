using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsolaCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Helloworld");

            int EDAD = 19;

            Console.WriteLine("lA EDAD ES DE " + EDAD);

            // string nombre = "Emilio";

            double temp;
            temp = 34;
            Console.WriteLine(temp);



            //casting
            EDAD = (int)temp;
            Console.WriteLine(EDAD);

            long litros;
            litros = 15000;
            Console.WriteLine(litros);

            float pCant = 385;
            Console.WriteLine(pCant);
            //Console.ReadLine();

            //casting usando parse


            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("La suma es " + (num1 + num2));
            //Console.ReadLine();

            //CONSTANTES

            const int valor1 = 15;
            const int valor2 = 16;

            Console.WriteLine("El valor es {0}", valor1, valor2);
            Console.ReadLine();


            Console.WriteLine("Introduce el radio del circulo");


            int R = int.Parse(Console.ReadLine());
            const double PI = 3.14;

            double AREA = Math.Pow(R, 2) * PI;

            Console.WriteLine($"eL AREA ES: {AREA}");
                MensajePantalla();
            Suma(5, 10);

            Console.WriteLine("Introduzca dos numeros a restar");
            double result = Resta(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Console.WriteLine(result);

            //Declarando variable booleana
            bool hacefrio = true;

            //el operador ! es como el not
            //Diferente de !=
            //Igual ==
            //&& (y) logico
            // ||  (o) logico

                                          
            Console.WriteLine(!hacefrio);


            if (EDAD>15)
            {
                MensajePantalla();
            }

            Leer_Texto("C:\\Users\\Desarrollo\\Desktop\\PRUEB.txt");
                                 
            Console.ReadLine();
        }

        static void MensajePantalla()
        {
            Console.WriteLine("Mensaje desde el metodo");
        }

        static void Suma(int num1, int num2)
        {
       Console.WriteLine("La suma por metodo es: " + (num1 + num2));
        }

        static double Resta (int num1, int num2)
        {
            return (num1 - num2);
        }


       // Otra forma de realizar return
        static double Division(int num1, int num2) => num1 / num2;

        //Leer archivo de texto
        
        static void Leer_Texto(string ruta)
        {
            System.IO.StreamReader archivo = null;
            try
            {

                string linea;
                int contador = 0;
                

                archivo = new System.IO.StreamReader(@ruta);

                while ((linea = archivo.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                    contador++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error de lectura");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (archivo!=null)
                {
                    archivo.Close();
                    Console.WriteLine("Archivo cerrado");
                }
            }

            


        }







     }
}
