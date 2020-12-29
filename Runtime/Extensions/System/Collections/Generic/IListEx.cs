namespace System.Collections.Generic
{
	public static class IListEx
	{
		public static T First<T>(this IList<T> list)
		{
			if (list.IsEmpty())
			{
				throw new IndexOutOfRangeException();
			}
			return list[0];
		}

		public static T Last<T>(this IList<T> list)
		{
			if (list.IsEmpty())
			{
				throw new IndexOutOfRangeException();
			}
			return list[list.LastIndex()];
		}

		public static bool TryGetMedian<T>(this IList<T> list, Func<T, T, T> avgFunction, out T result) where T : IComparable
		{
			result = default;
			if (list == default)
			{
				return false;
			}
			if (avgFunction == default)
			{
				return false;
			}
			if (list.IsEmpty())
			{
				return false;
			}
			if (list.Count == 1)
			{
				result = list.First();
				return true;
			}
			if (list.Count == 2)
			{
				result = avgFunction(list.First(), list.Last());
				return true;
			}

			List<T> copy = new List<T>(list);
			copy.Sort();
			if (copy.Count.IsOdd())
			{
				int centralIndex = copy.LastIndex() >> 1;
				result = copy[centralIndex];
			}
			else
			{
				int rightCentralIndex = copy.Count >> 1;
				int leftCentralIndex = rightCentralIndex - 1;
				result = avgFunction(copy[leftCentralIndex], copy[rightCentralIndex]);
			}
			return true;
		}
	}
}
