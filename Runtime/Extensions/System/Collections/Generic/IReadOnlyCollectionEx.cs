namespace System.Collections.Generic
{
    public static class IReadOnlyCollectionEx
    {
        public static bool IsEmptyReadOnlyCollection<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.Count == 0;
        }
    }
}
