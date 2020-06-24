using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//En este ejemplo se va usar begininvoke
//el cual convierte el método apuntado en segundo plano

namespace Delegados_III
{
    class Program
    {
        delegate List<string> objDelegado();
        static objDelegado miDelegado;
        static List<string> numeros = new List<string>();

        static void Main(string[] args)
        {
            miDelegado = new objDelegado(miMetodo);
            AsyncCallback acb = new AsyncCallback(miCallBack);
            miDelegado.BeginInvoke(acb, null);
            Console.ReadLine();

        }

        private static void miCallBack(IAsyncResult ar)
        {
            if (ar.IsCompleted)
            {
                numeros = miDelegado.EndInvoke(ar);

                //Estos se usan con windows form
                //MethodInvoker mi = new MethodInvoker(pintarPantalla);
                //this.Invoke (mi);
                
                foreach (string t in numeros) Console.WriteLine(t + "  ");
            }
        }

        private static void pintarPantalla()
        {
            //control.Datasource= numeros;
        }

        static List<string> miMetodo()
        {
            List<string> miLista = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                miLista.Add(i.ToString());
                System.Threading.Thread.Sleep(1000);
            }
            return miLista;
        }


    }
}
