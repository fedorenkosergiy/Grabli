using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckAutorotateToPortraitGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var autorotateToPortrait = screen.autorotateToPortrait;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckAutorotateToPortraitSetterToExceptions(bool autorotateToPortrait)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.autorotateToPortrait = autorotateToPortrait;
			});
		}
	}
}
