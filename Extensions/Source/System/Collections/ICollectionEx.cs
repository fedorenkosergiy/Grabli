namespace System.Collections
{
	public static class ICollectionEx
	{
		public static bool IsEmpty(this ICollection collection)
		{
			return collection.Count == 0;
		}
	}
}
