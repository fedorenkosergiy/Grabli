
namespace System.Collections.Generic
{
	public static class ICollectionEx
	{
		public static bool IsEmpty<T>(this ICollection<T> collection)
		{
			return collection.Count == 0;
		}

		public static bool IsNotEmpty<T>(this ICollection<T> collection)
		{
			return !collection.IsEmpty();
		}
		public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
		{
			return collection.IsNull() || collection.IsEmpty();
		}
	}
}
