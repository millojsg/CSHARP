using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async_Await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //La tecnica de async / await solo se debe utilizar en un manejador de eventos.
        //Probar método escribiendo en el ritchBox.
        private async void btnCargar_Click(object sender, EventArgs e)
        {
            //La ruta de los recursos no existen porque estan cargados en memoria ram
            //por esto se puede guardar en archivos temporales el recurso y así acceder a la ruta
            var path = System.IO.Path.GetTempPath();
            path = System.IO.Path.Combine(path, System.IO.Path.GetRandomFileName());
            global::Async_Await.Properties.Resources.tenor.Save(path);

            //pbCargando es un PictureBox, que contiene el método asincrono para cargar la imagen
            //esto para casos de imagenes pesadas,
            //este método se debe complementar con el método LoadCompleted el cual 
            //debe apuntar a un método que contenga la siguiente firma
            //(object sender, AsyncCompletedEventArgs e) <=== Este método se conoce como CallBack
            pbCargando.LoadAsync(path);
            pbCargando.LoadCompleted += new AsyncCompletedEventHandler(MiPortaImagen_LoadCompleted);

            //Aqui va la tarea forzosa, que consume tiempo 
            //la cual va antecedida por la palabra reservada await
            //Aqui se inicia un nuevo hilo
            List<string> miLista = new List<string>();
            await Task.Run(() => {
                for (int i = 0; i < 10; i++)
                {
                    miLista.Add(i.ToString());
                    Thread.Sleep(1000);
                }
            });

            //Una vez terminada la tarea, la ejecucion se devuelve al hilo principal.
            foreach (string t in miLista) rtbTexto.Text += t + "  ";

            //Ejemplo de como acceder a un recurso en memoria.
            this.pbCargando.Image = global::Async_Await.Properties.Resources.load;
            this.lblInfo.Text = "Terminado";
            this.Text = "Proceso asincrono terminado";
        }

        //CallBack, es importante que tenga la firma (object sender, AsyncCompletedEventArgs e)
        private void MiPortaImagen_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Text = "Imagen Cargada";
            this.lblInfo.Text = "Img. Cargada";
        }
    }
}
