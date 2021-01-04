using System.Collections.Generic;

namespace Grabli.Pools
{
	public static class ListPool<T>
	{
		public static List<T> Get() => FastPool<List<T>>.Get();

		public static T[] GetArrayAndRelease(List<T> value)
		{
			T[] result = value.ToArray();
			Release(value);
			return result;
		}

		public static void Release(List<T> value)
		{
			value.Clear();
			FastPool<List<T>>.Release(value);
		}
	}
}
