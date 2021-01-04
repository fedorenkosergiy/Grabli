using NUnit.Framework;
using Moq;
using System;

namespace Grabli.WrappedUnity
{
	public partial class PingExTest
	{
		private Ping CreateFakePing(string address, bool success, byte time)
		{
			int timeMs = time;

			DateTime date = DateTime.Now;
			Mock<Ping> ping = new Mock<Ping>();

			ping.Setup(p => p.isDone).Returns(() =>
			{
				return (DateTime.Now - date).TotalMilliseconds >= timeMs;
			});
			ping.Setup(p => p.ip).Returns(address);
			ping.Setup(p => p.time).Returns(() =>
			{
				if (ping.Object.isDone)
				{
					return success ? timeMs : -1;
				}
				return 0;
			});
			return ping.Object;
		}
	}
}
