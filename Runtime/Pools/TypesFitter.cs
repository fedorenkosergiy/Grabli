using System;
using System.Collections.Generic;
using System.Text;

namespace Grabli.Pools
{
	internal static class TypesFitter
	{
		private static IDictionary<Type, string> _betterPools = new Dictionary<Type, string>()
		{
			{ typeof(StringBuilder), nameof(StringBuilderPool) },
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
