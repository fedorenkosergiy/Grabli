using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckAutorotateToLandscapeRightGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var autorotateToLandscapeRight = screen.autorotateToLandscapeRight;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckAutorotateToLandscapeRightSetterToExceptions(bool autorotateToLandscapeRight)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.autorotateToLandscapeRight = autorotateToLandscapeRight;
			});
		}
	}
}
