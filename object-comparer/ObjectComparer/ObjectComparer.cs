using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class ObjectComparer : IComparer
    {
        public bool AreSimilar<T>(T first, T second)
        {
            var firstObjectProperties = first.GetType().GetProperties();
            var secondObjectProperties = first.GetType().GetProperties();

            if (firstObjectProperties.Count() != secondObjectProperties.Count())
                return false;

            for (int i = 0; i < firstObjectProperties.Count(); i++)
            {
                var typeOfObject = firstObjectProperties[i].PropertyType;

                if (!typeOfObject.IsNested)
                {
                    if (!ComparerManager.Comparer(typeOfObject).AreSimilar(firstObjectProperties[i].GetValue(first), secondObjectProperties[i].GetValue(second)))
                        return false;
                }
                else
                {
                    if (!new ObjectComparer().AreSimilar(firstObjectProperties[i], secondObjectProperties[i]))
                        return false;
                }
            }

            return true;
        }
    }
}
