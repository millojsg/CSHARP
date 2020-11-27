using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Leer
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Se obtiene la url del xml.
            string path = @".//XMLFile1.xml";

            UsandoXmlReader(path);
            UsandoXmlDocument(path);

            Console.ReadLine();
     
        }



        /// <summary>
        /// El XmlDocument carga en memoria todo el xml
        /// solo si el xml es muy grande representa un problema 
        /// de rendimiento
        /// </summary>
        /// <param name="path"></param>
        private static void UsandoXmlDocument(string path)
        {
            Console.WriteLine("\r\nUsando XmlDocument *************************");

            //
            // Inicializar el XmlDocument
            XmlDocument miXML = new XmlDocument();

            //
            // Cargar en memoria desde un url
            miXML.Load(path);

            foreach (XmlNode nodo in miXML.ChildNodes[2].ChildNodes[0])
            {
                if (nodo.Attributes.Count>0)
                    Console.WriteLine(nodo.Attributes["atributo1"].Value);

                foreach (XmlNode item in nodo.ChildNodes)
                {
                    Console.WriteLine($"Item: {item.InnerText}");
                }
            }


            //
            //Usando XPath protocolo de consultas xml
            Console.WriteLine("\r\nUsando XPath ***************************");

            XmlNodeList nodos = miXML.SelectNodes("//Edit_Mensaje//Mensaje");

            foreach (XmlNode item in nodos)
            {
                foreach (XmlNode item2 in item.SelectSingleNode("Texto"))
                {
                    Console.WriteLine(item2.InnerText);
                }          
            }
        }

        /// <summary>
        /// El XmlReader lee linea por linea. Solo permite el avance
        /// por lo tanto no consume tanta memoria. Importante
        /// no distingue nodos padres solo el linea por linea
        /// </summary>
        /// <param name="path"></param>
        private static void UsandoXmlReader(string path)
        {
            Console.WriteLine("Usando XmlReader *******************");
            //
            // Opcional crear un objeto de configuracion del xml
            // En este caso el xml tiene un documento .dtd que sirve 
            // como interfaz esté es para corroborar la estructura del 
            // xml.
            XmlReaderSettings miConfiguracion = new XmlReaderSettings();
            miConfiguracion.DtdProcessing = DtdProcessing.Parse;

            //
            // Crear el objeto XmlReader que ejecuta el proceso de leer 
            // linea por linea el xml
            XmlReader miReader = XmlReader.Create(path, miConfiguracion);

            while (miReader.Read())
            {
                // Corroborar que el nodo del linea es de tipo element
                if (miReader.NodeType == XmlNodeType.Element)
                {
                    // Consultar nodos especifico
                    // El xmlReader no distingue nodos padres
                    if (miReader.Name == "Remitente")
                    {
                        // Validar si tiene atributos
                        if (miReader.HasAttributes)
                        {
                            Console.WriteLine($"Atributo1 de Remitente: {miReader.GetAttribute("atributo1")}");
                            Console.WriteLine($"Atributo2 de Remitente: {miReader.GetAttribute("atributo2")}");
                        }
                    }

                    if (miReader.Name == "Nombre")
                    {
                        Console.WriteLine($"Nombre: {miReader.NamespaceURI} ");
                        Console.WriteLine($"Nombre: {miReader.ReadInnerXml()}");                    
                    }
                }
            }
        }










    }
}
