using System;
using System.Data;

namespace Metodos_de_Extensión.Consultar_Data_Reader_Field_es_Null
{
    internal static class DataRecordExtensionsBase
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}