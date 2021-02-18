namespace System.Collections.Generic
{
    public static class IReadOnlyCollectionEx
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.Count == 0;
        }
    }
}
