using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_Thread_Safe_con_Singleton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
        }

        public void metodosAsincronos()
        {
            int i = 1;
            string miCadena = "Tarea 2";

           
            Action miDelegado = delegate () {
                do
                {
                    ClaseEstatica.texto = $"Tarea {i} - { Thread.CurrentThread.ManagedThreadId}";
                   
                    this.Invoke(
                        ClaseEstatica.miRichTextBoxAction,
                        new object[] { richTextBox1, ClaseEstatica.texto });

                    Thread.Sleep(1200);
                } while (true);
            };

            Task T1 = new Task(miDelegado);

            Task T2 = new Task((miTexto) => System.Console.WriteLine(miTexto), miCadena);

            Task T3 = new Task(() =>
            {
                do
                {
                    ClaseEstatica.texto = $"Tarea 3 -{ Thread.CurrentThread.ManagedThreadId}";
                    this.Invoke(ClaseEstatica.miRichTextBoxAction,
                        new object[] { richTextBox1, ClaseEstatica.texto });
                    Thread.Sleep(1100);
                } while (true);
            }
            );

            T1.Start();
            T2.Start();
            T3.Start();

            do
            {
                ClaseEstatica.texto = $"Hilo actual: { Thread.CurrentThread.ManagedThreadId}";
                this.Invoke(ClaseEstatica.miRichTextBoxAction, new object[] { richTextBox1, ClaseEstatica.texto });

                Thread.Sleep(1000);
            } while (true);

        }

        private async void richTextBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.Show();

            await Task.Run(() => metodosAsincronos());

        }
    }

    static class ClaseEstatica
    {
        public static string texto { get; set; }

        public static Action<RichTextBox, String> miRichTextBoxAction =
                (RichTextBox rtb, string texto) => { rtb.AppendText("\r\n" + texto); rtb.ScrollToCaret(); };
    }
}
