using NUnit.Framework;
using System.Threading.Tasks;

namespace Grabli.WrappedUnity
{
	public partial class PingExTest
	{
		[TestCase("8.8.8.8", true, (byte)10, 10)]
		[TestCase("8.8.8.8", true, (byte)13, 13)]
		[TestCase("8.8.8.8", false, (byte)10, -1)]
		public void CheckRunAsyncAndDestroy(string address, bool success, byte time, int expectedTime)
		{
			Ping fakePing = CreateFakePing(address, success, time);
			int actualTime = Task.Run(async () => await fakePing.RunAsyncAndDestroy()).GetAwaiter().GetResult();
			Assert.AreEqual(expectedTime, actualTime);
		}
	}
}
