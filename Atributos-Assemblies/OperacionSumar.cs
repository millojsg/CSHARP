using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensamblado
{
    [InfoOperacionesAtributos("Emilio Sanchez","Solo permite sumar")]
    class OperacionSumar : IOperaciones
    {
        public double Calcular(double a, double b) => a + b;
    }
}
