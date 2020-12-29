using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Grabli.Pools
{
	using static Defines;

	public static class Debugger
	{
		private static object _locker = new object();
		private static IDictionary<Type, Counter> _counters = new Dictionary<Type, Counter>();
		private static List<Type> _types = new List<Type>();

		public static IReadOnlyList<Type> GetTypes()
		{
			return _types;
		}

		public static Countable GetCountable(Type type)
		{
			if (_counters.TryGetValue(type, out Counter counter))
			{
				return counter;
			}
			return default;
		}

		internal static Counter GetOrRegisterCounter(Type type)
		{
			lock (_locker)
			{
				if (_counters.TryGetValue(type, out Counter counter))
				{
					return counter;
				}
				counter = new DefaultCounter();
				_counters.Add(type, counter);
				_types.Add(type);
				return counter;
			}
		}

		/// <summary>
		/// Works only in a development build or in the editor
		/// </summary>
		[Conditional(DEVELOPMENT_BUILD), Conditional(UNITY_EDITOR)]
		public static void ResetAllPools()
		{
			lock (_locker)
			{
				foreach (Type type in _counters.Keys)
				{
					Type genericType = typeof(FastPool<>).MakeGenericType(type);
					MethodInfo method = genericType.GetMethod(nameof(FastPool<object>.Reset));
					method.Invoke(null, null);
				}
				_counters.Clear();
				_types.Clear();
			}
		}
	}
}
