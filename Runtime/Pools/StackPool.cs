using System.Collections.Generic;

namespace Grabli.Pools
{
	internal static class StackPool<T>
	{
		public static Stack<T> Get() => FastPool<Stack<T>>.Get();

		public static void Release(Stack<T> value)
		{
			value.Clear();
			FastPool<Stack<T>>.Release(value);
		}
	}
}
