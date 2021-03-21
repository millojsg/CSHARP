using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Metodos_de_Extension_II
{
    public static class ArrayIndexExtension
    {
        internal static bool TryIndex<T>(this T[] array, int index, out T result, object defaultValue = null)
        {
            index = Math.Abs(index);
            
            if (defaultValue != null)
            {
                result = (T)defaultValue;
            }
            else
            {
                result = default(T);
            }
           
            bool success = false;

            if (array != null && index < array.Length)
            {
                result = (T)array.GetValue(index);
                success = true;
            }

            return success;
        }
    }
}
