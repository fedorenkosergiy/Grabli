
namespace System.Collections.Generic
{
	public static class ICollectionEx
	{
		public static bool IsEmptyCollection<T>(this ICollection<T> collection)
		{
			return collection.Count == 0;
		}

		public static bool IsNotEmpty<T>(this ICollection<T> collection)
		{
			return !collection.IsEmptyCollection();
		}
		public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
		{
			return collection.IsNull() || collection.IsEmptyCollection();
		}

		public static int FirstIndex<T>(this ICollection<T> list)
		{
			return 0;
		}

		public static int LastIndex<T>(this ICollection<T> list)
		{
			if (list.IsEmptyCollection())
			{
				return -1;
			}
			return list.Count - 1;
		}
	}
}
