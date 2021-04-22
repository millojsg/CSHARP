using System;


namespace Ensamblado
{

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class InfoOperacionesAtributos : System.Attribute
    {
        // Propiedades
        public string Creador { get; set; }

        public string DetallesClase { get; set; }


        // Constructor
        public InfoOperacionesAtributos(string creador, string detallesClase)
        {
            Creador = creador;
            DetallesClase = detallesClase;
        }
    }
}
