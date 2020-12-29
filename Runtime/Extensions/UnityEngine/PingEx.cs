namespace UnityEngine
{
	public static class PingEx
	{
		public static BoolAwaiter GetAwaiter(this Ping ping)
		{
			return new PingAwaiter(ping);
		}
	}
}
