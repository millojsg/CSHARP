using System;
using System.Linq;
using System.Reflection;

namespace Atributos
{
    /*
        Atributos
        - Se utilizan para decorar clases y objetos.
        - Adicionan informacion al metadata. Los atributos son visibles desde el metadata.
        - Son clases que descienden de System.Attribute.
        - Pueden recibir parametros.
        - Tienen nombre corto y largo. [Serializable] ó [SerializableAttribute] 
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Notese como sale una advertencia en tiempos de desarrollo, pues la ClaseAntigua tiene la decoracion [Obsolete]
            ClaseAntigua.Funciones();

            ClaseActualizada.Funciones();

            // Reflexion para ver informacion de las clases
            Type t = typeof(ClaseActualizada);

            // Obtener la lista de atributos
            object[] atributos = t.GetCustomAttributes(false);

            // Mostrar atributos
            //atributos.ToList<object>().ForEach((objeto) => Console.WriteLine(((MisAtributos)objeto).Identificacion)); LinQ
            foreach (MisAtributos misAtributos in atributos) Console.WriteLine(misAtributos.Identificacion);

            // E J E R C I O    # 2
            // Ejercicio llamando a un assembly
            Console.WriteLine("EJERCICIO #2: viendo los atributos de un assembly");

            // Cargar assembly
            Assembly ensamble = Assembly.LoadFrom(@"C:\Users\Desarrollo\Documents\GitHub\CSHARP\Atributos-Assemblies\bin\Debug\net5.0\Atributos-Assemblies");
            
            // Obtener el tipo del Atributo
            Type tipoAtributo = ensamble.GetType("Ensamblado.InfoOperacionesAtributos");

            // Obtener informacion de la propiedad de interes. En este caso "Creador"
            PropertyInfo propiedadCreador = tipoAtributo.GetProperty("Creador");
            PropertyInfo propiedadDetallesClase = tipoAtributo.GetProperty("DetallesClase");

            // Obtener lista de las clases o tipos (son lo mismo) dentro del assembly
            Type[] clasesEnEnsamblado = ensamble.GetTypes();

            // Para cada tipo en el assembly obtener atributo
            foreach (Type claseEnEnsamblado in clasesEnEnsamblado)
            {
                object[] atributosPersonalizado = claseEnEnsamblado.GetCustomAttributes(tipoAtributo, false);

                // Recorrer atributos
                foreach (object atributoPersonalizado in atributosPersonalizado)
                {
                    Console.WriteLine(claseEnEnsamblado.Name + "  " + propiedadCreador.GetValue(atributoPersonalizado, null) + " " + propiedadDetallesClase.GetValue(atributoPersonalizado, null));
                } 
            }

            Console.ReadLine();
        }
    }



    /// <summary>
    /// Soy la clase atributos. Tips:
    /// La clase debe ser publica
    /// La clase debe ser sealed. Nota las clases Sealed no se pueden heredar.
    /// </summary>
    public sealed class MisAtributos : System.Attribute
    {
        public string Identificacion { get; set; }

        [Obsolete("No recomendable. Usa el constructor pasandole la identificacion")]
        public MisAtributos() { } // Constructor

        public MisAtributos(string identificacion) => Identificacion = identificacion; // Constructor

        // Esta clase atributo puede tener objetivos.

        public enum AttributeTargets
        {
            All,
            Assembly,
            Class,
            Constructor,
            Delegate,
            Enum,
            Event,
            Fiel,
            GenericParameter,
            Interfase,
            Method,
            Module,
            Parameter,
            Property,
            ReturnValue,
            Struct
        }

        //[AtributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    }

    /// <summary>
    /// Ejemplo de uso de atributos.
    /// </summary>
    [Obsolete("Por favor usa la ClaseActualizada. Me conocen como la antigua.")]
    public static class ClaseAntigua
    {
        public static void Funciones() => Console.WriteLine("Soy una clase vieja con Funciones obsoletas.");
    }


    [MisAtributos("Esta es la clase actualizada, Me conocen como la nueva.")]
    public static class ClaseActualizada
    {
        public static void Funciones() => Console.WriteLine("Soy la clase actualizada. Tengo funciones actuales.");
    }






}
