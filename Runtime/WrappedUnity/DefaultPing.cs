namespace Grabli.WrappedUnity
{
	public class DefaultPing : Ping
	{
		private UnityEngine.Ping ping;

		public bool isDone => ping.isDone;

		public int time => ping.time;

		public string ip => ping.ip;

		/// <summary>
		/// Perform a ping to the supplied target IP address.
		/// </summary>
		/// <param name="address">address</param>
		public DefaultPing(string address) => ping = new UnityEngine.Ping(address);

		public void DestroyPing() => ping.DestroyPing();
	}
}
