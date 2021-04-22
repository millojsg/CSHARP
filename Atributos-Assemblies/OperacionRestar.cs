﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensamblado
{
    [InfoOperacionesAtributos("Emilio Sanchez", "Solo permite restar")]
    class OperacionRestar : IOperaciones
    {
        public double Calcular(double a, double b) => a - b;
    }
}