using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckFullScreenGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var fullScreen = screen.fullScreen;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckFullScreenSetterToExceptions(bool fullScreen)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.fullScreen = fullScreen;
			});
		}
	}
}
