using System;
using System.Collections.Generic;

namespace Grabli.Pools
{
	internal static class TypesFitter
	{
		private static IDictionary<Type, string> _betterPools = new Dictionary<Type, string>()
		{
			{ typeof(List<>), nameof(UnityEngine.Pool.ListPool<object>) },
			{ typeof(Stack<>), nameof(StackPool<object>) },
		};

		public static void ThrowExceptionIfNotFits<T>() where T : class, new()
		{
			Type targetType = typeof(T);
			if (targetType.IsGenericType)
			{
				targetType = targetType.GetGenericTypeDefinition();
			}
			if (_betterPools.TryGetValue(targetType, out string betterType))
			{
				throw new ThereIsBetterPoolException(betterType, targetType);
			}
		}
	}
}
