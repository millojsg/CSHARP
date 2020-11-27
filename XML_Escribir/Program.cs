using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Escribir
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Se obtiene la url del xml.
            string path = @".//XMLFile1.xml";
            string path2 = @".//XMLFile2.xml";


            UsandoXmlWriter(path);

            UsandoXmlDocument(path2);

        }

        private static void UsandoXmlDocument(string path2)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode nodo1 = doc.CreateElement("Nodo1");
            doc.AppendChild(nodo1);

            XmlNode nodo2 = doc.CreateElement("Nodo2");
            XmlAttribute atributo1 = doc.CreateAttribute("Atributo1");
            atributo1.Value = "Valor de atributo1";
            nodo2.Attributes.Append(atributo1);
            nodo2.InnerText = "John Wick";
            nodo1.AppendChild(nodo2);

            doc.Save(path2);
   
        }

        private static void UsandoXmlWriter(string path)
        {
            XmlWriter xmlWriter = XmlWriter.Create(path);
            //
            //Se abre nodo raiz
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("Contactos");
            xmlWriter.WriteStartElement("Contacto");
            xmlWriter.WriteAttributeString("Telefono", "945141715");
            xmlWriter.WriteString("John Wick");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Contacto");
            xmlWriter.WriteAttributeString("Telefono", "945141715");
            xmlWriter.WriteAttributeString("Telefono2", "945141715");
            xmlWriter.WriteAttributeString("Telefono3", "945141715");
            xmlWriter.WriteString("John Wick");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();

            xmlWriter.Close();
        }
    }
}
