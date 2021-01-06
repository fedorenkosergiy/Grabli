using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckAutorotateToPortraitUpsideDownGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var autorotateToPortraitUpsideDown = screen.autorotateToPortraitUpsideDown;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckAutorotateToPortraitUpsideDownSetterToExceptions(bool autorotateToPortraitUpsideDown)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.autorotateToPortraitUpsideDown = autorotateToPortraitUpsideDown;
			});
		}
	}
}
