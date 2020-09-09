namespace System.Collections
{
	public static class ICollectionEx
	{
		public static bool IsEmpty(this ICollection collection)
		{
			return collection.Count == 0;
		}

		public static bool IsNotEmpty(this ICollection collection)
		{
			return !collection.IsEmpty();
		}

		public static bool IsNullOrEmpty(this ICollection collection)
		{
			return collection.IsNull() || collection.IsEmpty();
		}

		public static int FirstIndex(this ICollection list)
		{
			return 0;
		}

		public static int LastIndex(this ICollection list)
		{
			if (list.IsEmpty())
			{
				return -1;
			}
			return list.Count - 1;
		}
	}
}
