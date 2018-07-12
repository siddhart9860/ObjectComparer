namespace ObjectComparer
{
    public class PrimitiveComparer : IComparer
    {
        public bool AreSimilar<T>(T first, T second)
        {
            if (!first.Equals(second))
            {
                return false;
            }

            return true;
        }
    }
}
