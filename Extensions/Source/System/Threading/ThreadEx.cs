namespace System.Threading
{
	public static class ThreadEx
	{
		public static ThreadAwaiter GetAwaiter(this Thread thread)
		{
			return new ThreadAwaiter(thread);
		}
	}
}