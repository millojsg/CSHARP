using System;
using System.Diagnostics;

namespace UtilidadesCSharp
{
    public static class EjecutarComandosConsolaWindows
    {
        // Comandos ejemplos
        // start /max chrome "C:\Users\Desarrollo\Documents\GitHub\CSHARP\Variables Primitivas Limites\StandarNumericaFormat.html"

        public static void ExecuteCommand(string comando)
        {
            // Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            // (/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            // Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comando);

            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;

            // Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;

            proc.Start();

            proc.WaitForExit();

            proc.Close();

        }
    }
}
