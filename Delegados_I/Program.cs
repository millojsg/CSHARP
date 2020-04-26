using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegados_I
//DELEGADOS, EVENTOS Y MULTITREAD

//Cuando se usa Invoke a cualquier delegado Ejecuta el delegado desde segundo plano, 

//Continuar estudios desde el link https://www.youtube.com/watch?v=-xjH0hXLysU

{
    class Program
    {
        // Aqui declaro la firma
        delegate void miFirma(string texto);
                     
        static void Main(string[] args)
        {
            //Aqui declaro el delegado e indico el metodo a llamar
            miFirma miDelegado = new miFirma(Mensaje.Saludos);

            miDelegado("Prueba");
            
            //Aqui añado al delegado otro metodo 
            miDelegado += new miFirma(Mensaje.Despedida);

            //Se ejecutan los metodos del delegado
            miDelegado("Prueba2");

            Console.ReadLine();
        }



        class Mensaje
        {
             public static void Saludos(string texto)
            {
                Console.WriteLine(texto);
            }

            public static void Despedida(string Despedida)
            {
                Console.WriteLine("Este es el metodo despedida {0}", Despedida);
            }
        }
                              
    }
}
