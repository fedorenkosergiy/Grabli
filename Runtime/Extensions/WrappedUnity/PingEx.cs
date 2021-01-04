using System.Threading.Tasks;

namespace Grabli.WrappedUnity
{
	public static class PingEx
	{
		public static int Run(this Ping ping)
		{
			while (!ping.isDone) ;
			return ping.time;
		}

		public static async Task<int> RunAsync(this Ping ping)
		{
			return await RunAsync(ping, false);
		}

		public static async Task<int> RunAsyncAndDestroy(this Ping ping)
		{
			return await RunAsync(ping, true);
		}

		private static async Task<int> RunAsync(Ping ping, bool destroyOnFinish)
		{
			while (!ping.isDone)
			{
				await Task.Yield();
			}
			int result = ping.time;
			if (destroyOnFinish)
			{
				ping.DestroyPing();
			}
			return result;
		}
	}
}
