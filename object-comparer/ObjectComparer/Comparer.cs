using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second)
        {
            if (first == null && second == null)
                return true;

            if (first == null || second == null)
                return false;

            var typeOfObject = first.GetType();

            var typeOfComparer = ComparerManager.Comparer(typeOfObject);

            if (!typeOfComparer.AreSimilar(first, second))
            {
                return false;
            }

            return true;
        }
    }
}
