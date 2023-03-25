using System;

namespace Grabli.Pools
{
	internal static class SmartPool<T> where T : class, Property, new()
	{
		public static T Get(object owner)
		{
			T result = FastPool<T>.Get();
			if (result.SetOwner(owner))
			{
				return result;
			}
			else
			{
				FastPool<T>.Release(result);
				throw new Exception();
			}
		}

		public static void Release(object owner, T value)
		{
			if (value.ResetOwner(owner))
			{
				FastPool<T>.Release(value);
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
