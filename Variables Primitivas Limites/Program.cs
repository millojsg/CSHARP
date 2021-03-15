using ConvertirDataTableDesdeHtml;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using util = UtilidadesCSharp.EjecutarComandosConsolaWindows;

namespace Variables_Primitivas_Limites
{
    /// <summary>
    /// Ojo para más info revisar el Readme.
    /// Más info. https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#CFormatString
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> mostrar = (x) => Console.WriteLine(x);
            Action esperar = () => Console.ReadLine();

            // Mostrar más información desde html.
            string path = AppDomain.CurrentDomain.BaseDirectory;



            util.ExecuteCommand($@"start /max chrome ""{path}\StandarNumericaFormat.html""");
            
            Console.WriteLine("Hello World!");

            mostrar($"INTEGER: {String.Format("{0:N0}", int.MaxValue)} - {String.Format("{0:N}", int.MinValue)}");
            mostrar($"LONG: {String.Format("{0:N0}", long.MaxValue)} - {String.Format("{0:N}", long.MinValue)}");
            mostrar($"BYTE: {String.Format("{0:N0}", byte.MaxValue)} - {String.Format("{0:N}", byte.MinValue)}");
            mostrar("Ver más info en buscador Web...");
            esperar();
        }


    }
}
