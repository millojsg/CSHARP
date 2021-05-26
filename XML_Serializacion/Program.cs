using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Linq;


namespace XML_Serializacion
{

    /// <summary>
    /// NOTAS:
    /// 1- Solo puede existir un elemento root. Por la tanto las sub clases que tengan el atributo XmlRoot seran ignoradas si la subclase es hija de un root.
    /// 2- Solo se serializan las propiedades publicas que no tengan el atributo de [obsolete] [XmlIgnore].
    /// 3- Si la propiedad no tiene la etiqueta [XmlElemente("Nombre del elemento")] entonces tomará por defecto el nombre de la propiedad.
    /// 4- Si la propiedad es nula entonces no agrega tag.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Padre0 padre0 = new Padre0() { Hijo0 = "Valor0 de Hijo0", Hijo1 = "Valor0 de Hijo1" };
            Padre1 padre1 = new Padre1() { Hijo0 = "Valor0 de Hijo0", Hijo1 = "Valor0 de Hijo1" };
            List<Contacto> contactos = new List<Contacto>()
            {
                {new Contacto() {Nombre="Nombre0", Telefono= "Num0" } },
                {new Contacto() {Nombre="Nombre1", Telefono= "Num1" } },
                {new Contacto() {Nombre="Nombre2", Telefono= "Num2" } },
                {new Contacto() {Nombre="Nombre3", Telefono= "Num3" } }
            };
            Nieto nieto = new Nieto() { NietoNombre = "Soy el unico nieto", Datos = new List<string>() { "Dato1", "Dato2", "Dato3" } };

            Raiz raiz = new Raiz();
            raiz.Padre0 = padre0;
            raiz.Padre1 = padre1;
            raiz.Contactos = contactos;
            // padre1.Nieto = nieto;
            // raiz.Serializar = false;


            // XmlSerializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Raiz));

            MemoryStream memory = new MemoryStream();

            xmlSerializer.Serialize(memory, raiz);

            String strXml = Encoding.UTF8.GetString(memory.ToArray());

            Console.WriteLine(strXml);

            memory.Position = 0;

            Raiz raiz1 = (Raiz)xmlSerializer.Deserialize(memory);

            // Leer XML con LinQ

            /// NOTAS LINQ XML
            /// Importar System.Xml.Linq
            /// using System.Linq;
            /// XElement.Element("") Ya trae por defecto el nodo Raiz. Por tanto no se debe referenciar.
            /// Si el xml tiene NameSpace entonces todos los nodos se deben llamar antecediendo el namespace entre llaves.

            Action<string> mostrar = (msg) => Console.WriteLine(msg);
            
     XElement xml = XElement.Parse(strXml);

            mostrar(@"******Usando LINQ*******");

            mostrar(@"******Caso 0*******");
            var query0 = from alias in xml.Elements()
                         //where alias.Name.LocalName =="MisContactos"
                         select alias;

            foreach (var elemento in query0)
            {
                Console.WriteLine("Value: " + elemento.Value);
                Console.WriteLine("LocalName: "+ elemento.Name.LocalName);
                Console.WriteLine("Name: " + elemento.Name);
                Console.WriteLine("Namespace: " + elemento.Name.Namespace);
            }

            mostrar(@"******Caso 1*******");
            var query1 = from alias in xml.Element("{PropiedadEmilio}MisContactos").Elements("{PropiedadEmilio}Contac")
                        where alias.Element("{PropiedadEmilio}Nombre").Value == "Nombre0"
                        select alias;
            
            foreach (var elemento in query1)
            {
                Console.WriteLine(elemento);
            }

            mostrar(@"******Caso 2*******");

            var query2 = from alias in xml.Elements("{PropiedadEmilio/Padre0}Padre")
                             //where alias.Name.LocalName =="MisContactos"
                         select alias;

            foreach (var elemento in query2)
            {
                Console.WriteLine(elemento);
            }

            mostrar(@"******Caso 3*******");
            var query3 = from alias in xml.Element("{PropiedadEmilio}MisContactos").Elements("{PropiedadEmilio}Contac")
                         select new Contacto
                         {
                             Nombre = alias.Element("{PropiedadEmilio}Nombre").Value,
                             Telefono = alias.Element("{PropiedadEmilio}Telefono").Value
                         };

            foreach (Contacto elemento in query3)
            {
                Console.WriteLine(elemento.Nombre);
                Console.WriteLine(elemento.Telefono);
            }

            Console.ReadLine(); 
        }
    }


    [Serializable]
    [XmlRoot(ElementName ="RAIZ", Namespace = "PropiedadEmilio", IsNullable = false, DataType ="Raiz")]
    public class Raiz
    {
        [XmlAttribute]
        public string Version { get; set; } = "1.0";

        [XmlElement(ElementName ="Padre", Namespace ="PropiedadEmilio/Padre0")]
        public Padre0 Padre0 { get; set; }
        public bool ShouldSerializePadre0() { return Serializar; }

        [XmlElement(ElementName ="Padre", Namespace ="PropiedadEmilio/Padre1")]
        public Padre1 Padre1 { get; set; }
        public bool ShouldSerializePadre1() { return Serializar; }

        [XmlArray("MisContactos")]
        [XmlArrayItem("Contac")]
        public List<Contacto> Contactos { get; set; }

        [XmlIgnore()]
        public bool Serializar { get; set; } = true;   
    }

    [Serializable]
    public class Padre0
    {
        [XmlElement(ElementName ="Hijo", Namespace ="Padre0/Hijo0")]
        public string Hijo0 { get; set; }
     
        [XmlElement(ElementName = "Hijo", Namespace = "Padre0/Hijo1")]
        public string Hijo1 { get; set; }
    }

    [Serializable]
    public class Padre1
    {
        [XmlElement(ElementName = "Hijo", Namespace = "Padre1/Hijo0")]
        public string Hijo0 { get; set; }

        [XmlElement(ElementName = "Hijo", Namespace = "Padre1/Hijo1")]
        public string Hijo1 { get; set; }

        [XmlElement(ElementName ="Nieto")]
        public Nieto Nieto { get; set; }


    }


    [Serializable]
    public class Contacto
    { 
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    
    }

    [Serializable]
    public class Nieto
    {
        public string NietoNombre { get; set; }

        public List<string> Datos { get; set; }
    }


}
