using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Enum
{
    class Program
    {

        static miEnum tipo  = miEnum.mediano;

        public enum miEnum : int
        {
            [XmlEnum("")]
            NotSet,

            [XmlEnum("1")]
            pequeño = 1,

            [XmlEnum("2")]
             mediano = 2,

            [XmlEnum("3")]
            grande = 3,

            [XmlEnum("4")]
            extraGrande = 4,
          
            [XmlEnum("9")]
            Otros = 9
        }

        static void Main(string[] args)
        {
            tipo = (miEnum)Convert.ToInt16("3");
            pruebaEnum(tipo);
            Console.ReadLine();
        }

        private static void pruebaEnum(miEnum TipoEnum)
        {
            switch (TipoEnum)
            {
                case miEnum.NotSet:
                    break;
                case miEnum.pequeño:
                    Console.WriteLine(TipoEnum);
                    Console.WriteLine("TipoEnum: pequeño");
                    break;
                case miEnum.mediano:
                    Console.WriteLine(TipoEnum);
                    Console.WriteLine("TipoEnum: mediano");
                    break;
                case miEnum.grande:
                    Console.WriteLine(TipoEnum);
                    Console.WriteLine("TipoEnum: grande");
                    break;
                case miEnum.extraGrande:
                    Console.WriteLine(TipoEnum);
                    Console.WriteLine("TipoEnum: extra grande");
                    break;
                case miEnum.Otros:
                    Console.WriteLine(TipoEnum);
                    Console.WriteLine("TipoEnum: otros");
                    break;
                default:
                    break;
            }

            tipo = TipoEnum;
         }          
    }
}
