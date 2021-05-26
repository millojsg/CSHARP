using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    /// <summary>
    /// Notas:
    /// Hay un ejemplo del LINQ XML en XML_Serializacion
    /// Son de tipo IEnumerable
    /// </summary>


    class Program
    {
        static void Main(string[] args)
        {
            //Ejemplo con numeros
            //Arreglo para trabaja
            int[] numeros = { 1, 5, 8, 4, 64565, 4, 84, 453, 546, 686 };

            //Query
            IEnumerable<int> valores = from O in numeros where O > 3 && O < 500 select O;

            // Ordenar numeros
            IEnumerable<int> valoresOrdenados = from alias in numeros orderby alias select alias;

            foreach (int num in valores)
            {
                Console.WriteLine("Los numeros que estan entre 3 y 500 {0}-----------", num);
            }

            foreach (int num in valoresOrdenados)
            {
                Console.WriteLine("Los valores ahora estan ordenados {0}-----------", num);
            }



            Console.WriteLine();

            InformacionResultado(valores);

            Console.WriteLine();


            //Ejemplo con cadenas
            string[] postres = { "TORTA DE CHOCOLATE", "GALLETAS", "TORTA DE PARCHITA", "CARAMELOS", "TORTA DE TRES LECHES", "TIRAMIZU", "OTROS" };

            //Query
            IEnumerable<string> TORTAS = from O in postres where O.Contains("TORTA") orderby O select O;

            foreach (var item in TORTAS)
            {
                Console.WriteLine("Las tortas disponibles son: {0}", item);
            }

            Console.WriteLine();

            InformacionResultado(TORTAS);

            Console.WriteLine();

            //EJEMPLO CON VARIABLE IMPLICITA
            //Hacemos el query usando una variable de tipo implicito var

            var divisibles = from O in numeros where O % 2 == 0 select O;

            foreach (var item in divisibles)
            {
                Console.WriteLine("Los numeros divisibles entre 2 son: {0}", item);
            }

            InformacionResultado(divisibles);

            Console.WriteLine();

            //LINQ EJECUCION DIFERIDA
            //La expresion del query no se evalua hasta que se itere sobre el arreglo
            //Despues de moficar la fuente se puede utilizar el mismo query y la informacion estara actualizada
            //ejemplo

            numeros[0] = 4654;
            numeros[1] = 466;
            numeros[2] = 675;
            numeros[3] = 44;
            numeros[4] = 544;
            numeros[5] = 7423;
            numeros[6] = 457;
            foreach (var item in divisibles)
            {
                Console.WriteLine("Los numeros divisibles entre 2 son: {0}", item);
            }

            Console.WriteLine();

            //LINQ EJECUCION INMEDIATA

            int[] misNumeros = (from O in numeros where O % 2 == 0 select O).ToArray<int>();

            List<string> misTortas = (from O in postres where O.Contains("TORTA") orderby O select O).ToList<string>();

            foreach (var item in misNumeros)
            {
                Console.WriteLine(item);
            }
            foreach (var item in misTortas)
            {
                Console.WriteLine(item);
            }


            /// PRUEBA LINQ SOBRE COLECCION DE CLASES
            claseCompleja[] clasesComplejas =
                {
                    new claseCompleja(){dato1="Esta es una prueba0", dato2="A" },
                    new claseCompleja(){dato1="Esta es una prueba5", dato2="D" },
                    new claseCompleja(){dato1="Esta es una prueba2", dato2="H" },
                    new claseCompleja(){dato1="Esta es una prueba3", dato2="H" },
                    new claseCompleja(){dato1="Esta es una prueba4", dato2="E" },
                    new claseCompleja(){dato1="Esta es una prueba5", dato2="A" },
                    new claseCompleja(){dato1="Esta es una prueba1", dato2="G" },
                };

            // 
            // 
            (from alias in clasesComplejas
             where alias.dato2 == "G" || alias.dato2 == "A"
             select alias).ToList().ForEach((x)=> Console.WriteLine(x.dato1));

            //
            //
            claseCompleja miDato2 = (from alias in clasesComplejas
                                     where alias.dato2 == "A"
                                     select alias).FirstOrDefault();
            Console.WriteLine(miDato2.dato1);



            Console.ReadLine();
        }

        static void InformacionResultado(object pResultados)
        {
            Console.WriteLine("Tipo {0}",pResultados.GetType().Name);
            Console.WriteLine("Locacion {0}", pResultados.GetType().Assembly.GetName().Name);
        }



    }

    public class claseCompleja 
    {
        public string dato1 { get; set; }
        public string dato2 { get; set; }
    }
}

//'Idea con linq descartada por que no sé como usar funcion like para optimizar el buscador
//            'Dim tTemp As DataTable = miTabla.Clone
//            'Dim q = From f As DataRow In miTabla.AsEnumerable
//            '        Where
//            '        (f.Item("codigo") = filtros("Codigo") Or String.IsNullOrEmpty(filtros("Codigo"))) And
//            '        (f.Item("numeroLegal") = filtros(keyNumLegal) Or String.IsNullOrEmpty(filtros(keyNumLegal))) And
//            '        (f.Item(keyDv) = filtros(keyDv) Or String.IsNullOrEmpty(filtros(keyDv))) And
//            '        (f.Item("razonSocial").ToUpper.StartsWith(filtros(keyRznSocial)) Or String.IsNullOrEmpty(filtros(keyRznSocial))) And
//            '        (f.Item(keyFantasia).ToUpper.StartsWith(filtros(keyFantasia)) Or String.IsNullOrEmpty(filtros(keyFantasia))) And
//            '        (f.Item(keyTipo) = filtros(keyTipo) Or filtros.Item(keyTipo) = "TODOS")
//            '        Select f

//            'For Each elemento In q
//            '    tTemp.Rows.Add(elemento.ItemArray)
//            'Next