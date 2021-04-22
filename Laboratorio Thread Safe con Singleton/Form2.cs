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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                do
                {
                    ClaseEstatica.texto = Guid.NewGuid().ToString();

                    this.Invoke(ClaseEstatica.miRichTextBoxAction, new object[] { richTextBox1, ClaseEstatica.texto });

                    Thread.Sleep(1000);
                } while (true);
            }); 
        }
    }
}
