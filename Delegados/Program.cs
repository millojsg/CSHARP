using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegados
{
    class Program
    {
        public delegate void miFirma(int a, int b);

        static void Main(string[] args)
        {
            miFirma miDelegado = new miFirma(Calculo.suma);

            miDelegado(4, 4);

            //En elc caso de querer quitar un metodo se cambia el + por -
            miDelegado += new miFirma(Calculo.resta);
            miDelegado += new miFirma(Calculo.dividir);
            miDelegado(100, 50);

            //Saber cantidad de metodos en el delegado

            int CantDelegados = miDelegado.GetInvocationList().GetLength(0);

            Console.WriteLine("La cantidad de metodos en el delegado son: {0} ", CantDelegados);

            //Mostrar informacion del delegado
            TratarDelegados.InfoDelegado(miDelegado);
                        
            Console.ReadLine();
        }
    }

    class Calculo
    {
        public static void suma(int num1, int num2)
        {
            Console.WriteLine("La suma de {0} y {1} es: {2}", num1, num2, num1 + num2);
            Console.WriteLine();
        }

        public static void resta(int num1, int num2)
        {
            Console.WriteLine("La resta de {0} y {1} es: {2}", num1, num2, num1 - num2);
            Console.WriteLine();
        }
        public static void dividir(int num1, int num2)
        {
            Console.WriteLine("La division de {0} y {1} es: {2}", num1, num2, num1 / num2);
            Console.WriteLine();
        }
    }

    public class TratarDelegados
    {
        public static void InfoDelegado(Delegate objDelegado)
        {

            Console.WriteLine("--Informacion delegado {0}--", objDelegado.GetType().FullName);

            if (objDelegado == null)
            {
                Console.WriteLine("El objeto delegado no referencia ningun método");
                return;
            }
            else
            {
                foreach (var item in objDelegado.GetInvocationList())
                {
                    Console.WriteLine("\tMetodo: {0}", item.Method);

                    //Nota si los metodos asignados al delegado son static no muetran la clase de la que provienen
                    Console.WriteLine("\tClase: {0}", item.Target);
                }
            }
        }
    }





}
