namespace Grabli.Pools
{
	public static class Pool<T> where T : class, new()
	{
		public static T Get()
		{
			TypesFitter.ThrowExceptionIfNotFits<T>();
			return FastPool<T>.Get();
		}

		public static void Release(T value)
		{
			TypesFitter.ThrowExceptionIfNotFits<T>();
			FastPool<T>.Release(value);
		}

		public static void Clear()
		{
			FastPool<T>.Clear();
		}
	}
}
