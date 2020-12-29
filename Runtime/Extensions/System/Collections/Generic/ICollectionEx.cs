
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

		public static int FirstIndex<T>(this ICollection<T> list)
		{
			return 0;
		}

		public static int LastIndex<T>(this ICollection<T> list)
		{
			if (list.IsEmpty())
			{
				return -1;
			}
			return list.Count - 1;
		}
	}
}
