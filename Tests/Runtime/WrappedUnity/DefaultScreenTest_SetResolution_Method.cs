using NUnit.Framework;
using UnityEngine;
using static UnityEngine.FullScreenMode;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[TestCase(100, 100, true)]
		[TestCase(100, 100, false)]
		public void CheckSetResolutionToExceptions(int width, int height, bool fullscreen)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.SetResolution(width, height, fullscreen);
			});
		}

		[TestCase(100, 100, true, 30)]
		[TestCase(100, 100, false, 30)]
		public void CheckSetResolutionToExceptions(int width, int height, bool fullscreen, int preferredRefreshRate)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
			});
		}

		[TestCase(100, 100, ExclusiveFullScreen)]
		[TestCase(100, 100, FullScreenWindow)]
		[TestCase(100, 100, MaximizedWindow)]
		[TestCase(100, 100, Windowed)]
		public void CheckSetResolutionToExceptions(int width, int height, FullScreenMode fullscreenMode)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.SetResolution(width, height, fullscreenMode);
			});
		}

		[TestCase(100, 100, ExclusiveFullScreen, 30)]
		[TestCase(100, 100, FullScreenWindow, 30)]
		[TestCase(100, 100, MaximizedWindow, 30)]
		[TestCase(100, 100, Windowed, 30)]
		public void CheckSetResolutionToExceptions(int width, int height, FullScreenMode fullscreenMode, int preferredRefreshRate)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.SetResolution(width, height, fullscreenMode, preferredRefreshRate);
			});
		}
	}
}
