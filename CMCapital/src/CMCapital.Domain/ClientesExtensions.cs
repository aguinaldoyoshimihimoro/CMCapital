using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCapital.Domain
{
    public static class ClientesExtensions
    {
        public static bool Compare(this Clientes obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            var result = true;
            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.Name == "Id")
                    continue;
                var objValue = property.GetValue(obj);
                var anotherValue = property.GetValue(another);
                if (objValue == null && anotherValue == null)
                    continue;

                if (objValue != null && anotherValue != null)
                {
                    if (!objValue.Equals(anotherValue)) return false;
                }
                else return false;
            }

            return result;
        }
    }
}