using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos
{
    class Program
    {
        static void Main(string[] args)
        {
            AlmacenObjetos textos = new AlmacenObjetos(4);

            textos.Agregar("Juan");
            textos.Agregar("Antonio");
            textos.Agregar("Jose");
            textos.Agregar("Maria");

            string nombrePersona = (string)textos.GetElemento(1);

            Console.WriteLine(nombrePersona);
            Console.ReadLine();
        }
    }

    class AlmacenObjetos
    {
        private object[] datosElementos;
        private int i = 0;
        public AlmacenObjetos(int z)
        {
            datosElementos = new object[z];

        }
        public void Agregar(object obj)
        {
            datosElementos[i] = obj;
            i++;
        }

        public object GetElemento(int i)
        {
            return datosElementos[i];
        }
    }


    class Empleado
    {
        string nombre;
        double salario;

        public Empleado(string nombre, double salario)
        {
            this.nombre = nombre;
            this.salario = salario;
        }

       



    }
}
