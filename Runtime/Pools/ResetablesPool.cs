namespace Grabli.Pools
{
	public static class ResetablesPool<T> where T : class, Resetable, new()
	{
		public static T Get() => FastPool<T>.Get();

		public static void Release(T value)
		{
			value.Reset();
			FastPool<T>.Release(value);
		}
	}
}
