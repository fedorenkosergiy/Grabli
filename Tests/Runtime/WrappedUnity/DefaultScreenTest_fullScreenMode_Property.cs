using NUnit.Framework;
using UnityEngine;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckFullScreenModeGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var fullScreenMode = screen.fullScreenMode;
			});
		}

		[TestCase(FullScreenMode.ExclusiveFullScreen)]
		[TestCase(FullScreenMode.FullScreenWindow)]
		[TestCase(FullScreenMode.MaximizedWindow)]
		[TestCase(FullScreenMode.Windowed)]
		public void CheckFullScreenModeSetterToExceptions(FullScreenMode mode)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.fullScreenMode = mode;
			});
		}
	}
}
