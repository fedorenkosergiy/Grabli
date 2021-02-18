namespace System.Collections.Generic
{
    public static class IReadOnlyListEx
    {
        public static T First<T>(this IReadOnlyList<T> list)
        {
            if (list.IsEmptyReadOnlyCollection())
            {
                throw new IndexOutOfRangeException();
            }
            return list[0];
        }
    }
}
