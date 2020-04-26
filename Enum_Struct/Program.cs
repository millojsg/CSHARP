using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enum_Struct
{
    enum bonus { bajo = 1000, medio = 2500, extra = 5000 };





    class Program
    {
        static void Main(string[] args)
        {
            //Se usa interrogante en el caso de declarar un enum nulo.
            //Los enum son constantes no son string.
            //En el caso de acceder al valor de Enum se debe declar la variable en casting double.
            bonus? Emilio = null;

            bonus ana = bonus.bajo;

            double valorBonusAna = (Double)ana;

            Console.WriteLine("El empleado {0} tiene de bonus {1}",ana,  valorBonusAna);

            
           Empleado Frany = new Empleado(bonus.medio, 4500);

            // Me falata obtener el nombre
          Console.WriteLine("El empleado {0} tiene de bonus {1}", Frany.GetType(), Frany.GetSalario());

            Console.WriteLine(Frany.GetType());
            Console.WriteLine(Frany.GetType().Name);
            Console.WriteLine(Frany.GetType().FullName);
            Console.WriteLine(Frany.GetType().Assembly);
            Console.WriteLine(Frany.GetType().AssemblyQualifiedName);
            Console.WriteLine(Frany.GetType().Attributes);
            Console.WriteLine(Frany.GetType().BaseType);
            Console.WriteLine(Frany.GetType().ContainsGenericParameters);
            Console.WriteLine(Frany.GetType().CustomAttributes);
         //   Console.WriteLine(Frany.GetType().DeclaringMethod);
            Console.WriteLine(Frany.GetType().DeclaringType);
            //Console.WriteLine(Frany.GetType().GenericParameterAttributes);
            //Console.WriteLine(Frany.GetType().GenericParameterPosition);
            Console.WriteLine(Frany.GetType().GenericTypeArguments);
           // Console.WriteLine(Frany.GetType().GetArrayRank());
            Console.WriteLine(Frany.GetType().GetConstructors());
            Console.WriteLine(Frany.GetType().GetCustomAttributesData());
            Console.WriteLine(Frany.GetType().GetDefaultMembers());
            Console.WriteLine(Frany.GetType().GetElementType());
            //Console.WriteLine(Frany.GetType().GetEnumNames());
            //Console.WriteLine(Frany.GetType().GetEnumUnderlyingType());
            //Console.WriteLine(Frany.GetType().GetGenericTypeDefinition());

            Console.WriteLine(Frany.GetType().FullName);
            Console.WriteLine(Frany.GetType().UnderlyingSystemType);
            Console.WriteLine(Frany.ToString());
            Console.WriteLine(GetName(() => Frany));
            
            Console.WriteLine();
            Console.ReadLine();
         }

        class Empleado
        {
            private double salario, bonus;
            
            public Empleado(bonus bonus, double salario)
            {
                this.bonus = (double)bonus;

                this.salario = salario;
            }

            public double GetSalario()
            {
                return salario + bonus;
            }
        }

        static string GetName<T>(Expression<Func<T>> expr)
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }


    }
}
