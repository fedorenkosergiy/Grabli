using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckShowCursorGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var showCursor = screen.showCursor;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckShowCursorSetterToExceptions(bool showCursor)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.showCursor = showCursor;
			});
		}
	}
}
