using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckAutorotateToLandscapeLeftGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var autorotateToLandscapeLeft = screen.autorotateToLandscapeLeft;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckAutorotateToLandscapeLeftSetterToExceptions(bool autorotateToLandscapeLeft)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.autorotateToLandscapeLeft = autorotateToLandscapeLeft;
			});
		}
	}
}
