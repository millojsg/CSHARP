using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathMisDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreAplicacion = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            Uri uriRaiz = new Uri(Path.Combine(pathMisDocumentos, nombreAplicacion));


            Directory.CreateDirectory(Path.Combine(uriRaiz.LocalPath, DateTime.Now.ToShortDateString()));
        }
    }
}
