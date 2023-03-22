using Grabli.Abstraction;

namespace Grabli.Pools
{
	public static class ResetablesPool<T> where T : class, ResetCallbackReceiver, new()
	{
		public static T Get() => FastPool<T>.Get();

		public static void Release(T value)
		{
			value.OnReset();
			FastPool<T>.Release(value);
		}
	}
}
