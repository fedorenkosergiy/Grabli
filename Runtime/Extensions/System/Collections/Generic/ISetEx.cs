namespace System.Collections.Generic
{
	public static class ISetEx
	{
		public static bool AddDiff<T>(this ISet<T> set, IEnumerable<T> range)
		{
			bool result = true;
			foreach(T item in range)
			{
				result &= set.Add(item);
			}
			return result;
		}
	}
}
