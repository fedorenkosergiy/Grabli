using NUnit.Framework;
using UnityEngine;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckSleepTimeoutGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var sleepTimeout = screen.sleepTimeout;
			});
		}

		[TestCase(SleepTimeout.NeverSleep)]
		[TestCase(SleepTimeout.SystemSetting)]
		[TestCase(10)]
		public void CheckSleepTimeoutSetterToExceptions(int sleepTimeout)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.sleepTimeout = sleepTimeout;
			});
		}
	}
}
