using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectComparer
{
    public class ArrayComparer : IComparer
    {
        public bool AreSimilar<T>(T first, T second)
        {
            var firstObjectValues = (Array)((IList)first);
            var secondObjectValues = (Array)((IList)second);

            if (firstObjectValues.Length != secondObjectValues.Length)
                return false;

            Array.Sort(firstObjectValues);
            Array.Sort(secondObjectValues);

            for (int i = 0; i < firstObjectValues.Length; i++)
            {
                if (!new PrimitiveComparer().AreSimilar(firstObjectValues.GetValue(i), secondObjectValues.GetValue(i)))
                    return false;
            }

            return true;
        }
    }
}
