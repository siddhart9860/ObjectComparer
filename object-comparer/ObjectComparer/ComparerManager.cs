using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class ComparerManager
    {
        public static IComparer Comparer(Type obj)
        {
            if (obj.IsPrimitive || obj == typeof(string))
                return new PrimitiveComparer();

            else if (obj.IsArray)
                return new ArrayComparer();

            else if (obj.IsClass)
                return new ObjectComparer();

            throw new Exception("");
        }
    }
}
