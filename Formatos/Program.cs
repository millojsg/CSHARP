using System;
using System.Globalization;
using System.Threading;

namespace Formatos
{
    class Program
    {
        enum Color { Yellow = 1, Blue, Green };
        static DateTime thisDate = DateTime.Now;

        static void Main(string[] args)
        {
            // Format a negative integer or floating-point number in various ways.
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Standard Numeric Format Specifiers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "(C) Currency: . . . . . . . . {0:C}\n" +
                "(D) Decimal:. . . . . . . . . {0:D}\n" +
                "(E) Scientific: . . . . . . . {1:E}\n" +
                "(F) Fixed point:. . . . . . . {1:F}\n" +
                "(G) General:. . . . . . . . . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(N) Number: . . . . . . . . . {0:N}\n" +
                "(N0) Number entrada decimal: .{1:N0}\n" +
                "(N2) Number: . . . . . . . . .{1:N2}\n" +
                "(P) Percent:. . . . . . . . . {1:P}\n" +
                "(R) Round-trip: . . . . . . . {1:R}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n",
                -123456, -123456.456f);

            // Math round example
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Usando Math.Round");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Valor original ({123456.456m}). Nota sufijo m indica que es decimal. \r\n" +
                $"             Valor formateado 0 decimal. MidpointRounding.AwayFromZero {Math.Round(123456.456m, 0, MidpointRounding.AwayFromZero)} \r\n" +
                $"             Valor formateado 1 decimal. MidpointRounding.AwayFromZero {Math.Round(123456.456m, 1, MidpointRounding.AwayFromZero)}\r\n");

            // Math Truncate
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Truncate");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Usando Math.Truncate.\r\n" +
               $"             Valor Original {123456.456m} formateado. Resultado=> {Math.Truncate(123456.456m)} \r\n" +
               $"             Valor Original {123456.856m} formateado. Resultado=> {Math.Truncate(123456.856m)} \r\n");

            // Sufijos de C#
            Console.WriteLine("Sufijos de .net \r\n" +
                "l ====> Long\r\n" +
                "f ====> Float\r\n" +
                "m ====> Decimal\r\n" +
                "d ====> Double(opcional?)\r\n" +
                "ui ===> uint(opcional?)\r\n" +
                "ul ===> ulong(opcional?)\r\n"

                );


            // Format the current date in various ways.
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Standard DateTime Format Specifiers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "(d) Short date: . . . . . . . {0:d}\n" +
                "(D) Long date:. . . . . . . . {0:D}\n" +
                "(t) Short time: . . . . . . . {0:t}\n" +
                "(T) Long time:. . . . . . . . {0:T}\n" +
                "(f) Full date/short time: . . {0:f}\n" +
                "(F) Full date/long time:. . . {0:F}\n" +
                "(g) General date/short time:. {0:g}\n" +
                "(G) General date/long time: . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(M) Month:. . . . . . . . . . {0:M}\n" +
                "(R) RFC1123:. . . . . . . . . {0:R}\n" +
                "(s) Sortable: . . . . . . . . {0:s}\n" +
                "(u) Universal sortable: . . . {0:u} (invariant)\n" +
                "(U) Universal full date/time: {0:U}\n" +
                "(Y) Year: . . . . . . . . . . {0:Y}\n",
                thisDate);

            // Format a Color enumeration value in various ways.
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Standard Enumeration Format Specifiers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "(G) General:. . . . . . . . . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(F) Flags:. . . . . . . . . . {0:F} (flags or integer)\n" +
                "(D) Decimal number: . . . . . {0:D}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n",
                Color.Green);

            // Formatos personalizados
            Console.ForegroundColor = ConsoleColor.DarkBlue;  
            Console.WriteLine("\r\nFORMATOS PERSONALIZADOS");
            Console.ForegroundColor = ConsoleColor.White;
            double value;

            value = 123;
            Console.WriteLine(value.ToString("00000"));
            Console.WriteLine(String.Format("{0:00000}", value));
            // Displays 00123

            value = 1.2;
            Console.WriteLine(value.ToString("0.00", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                              "{0:0.00}", value));
            // Displays 1.20

            Console.WriteLine(value.ToString("00.00", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:00.00}", value));
            // Displays 01.20

            CultureInfo daDK = CultureInfo.CreateSpecificCulture("da-DK");
            Console.WriteLine(value.ToString("00.00", daDK));
            Console.WriteLine(String.Format(daDK, "{0:00.00}", value));
            // Displays 01,20

            value = .56;
            Console.WriteLine(value.ToString("0.0", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0.0}", value));
            // Displays 0.6

            value = 1234567890;
            Console.WriteLine(value.ToString("0,0", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0,0}", value));
            // Displays 1,234,567,890

            CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
            Console.WriteLine(value.ToString("0,0", elGR));
            Console.WriteLine(String.Format(elGR, "{0:0,0}", value));
            // Displays 1.234.567.890

            value = 1234567890.123456;
            Console.WriteLine(value.ToString("0,0.0", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0,0.0}", value));
            // Displays 1,234,567,890.1

            value = 1234.567890;
            Console.WriteLine(value.ToString("0,0.00", CultureInfo.InvariantCulture));
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                            "{0:0,0.00}", value));
            // Displays 1,234.57


            // Convertir un dato con formato personalizado a formato nativo del sistema.
            string miDatoPersonalizado= "1000.30";

            CultureInfo miCulturaPersonalizada = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            miCulturaPersonalizada.NumberFormat.NumberDecimalSeparator = ".";
            decimal miDatoNativo = Convert.ToDecimal(miDatoPersonalizado, miCulturaPersonalizada);
            
            Console.WriteLine(miDatoNativo);


        }
    }
}
