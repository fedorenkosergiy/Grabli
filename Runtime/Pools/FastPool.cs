using System.Collections.Generic;

namespace Grabli.Pools
{
	using static Debugger;
	internal static class FastPool<T> where T : class, new()
	{
		private static Stack<T> _pool = new Stack<T>();
		private static List<T> _gotten = new List<T>();

		public static T Get()
		{
			lock (_pool)
			{
				T result;
				if (_pool.IsEmptyReadOnlyCollection())
				{
					result = new T();
					GetOrRegisterCounter(typeof(T)).GoUp();
				}
				else
				{
					result = _pool.Pop();
				}
				_gotten.Add(result);
				return result;
			}
		}

		public static void Release(T value)
		{
			lock (_pool)
			{
				if (!_gotten.Contains(value))
				{
					throw new WrongOriginException<T>(value);
				}
				_gotten.Remove(value);
				_pool.Push(value);
			}
		}

		public static void Clear()
		{
			lock (_pool)
			{
				_pool.Clear();
			}
		}

		public static void Reset()
		{
			lock (_pool)
			{
				_pool.Clear();
				_gotten.Clear();
			}
		}
	}
}
