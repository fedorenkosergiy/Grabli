using NUnit.Framework;
using UnityEngine;
using static UnityEngine.ScreenOrientation;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckOrientationTimeoutGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var orientation = screen.orientation;
			});
		}

		[TestCase(AutoRotation)]
		[TestCase(Landscape)]
		[TestCase(LandscapeLeft)]
		[TestCase(LandscapeRight)]
		[TestCase(Portrait)]
		[TestCase(PortraitUpsideDown)]
		public void CheckOrientationSetterToExceptions(ScreenOrientation orientation)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.orientation = orientation;
			});
		}
	}
}
