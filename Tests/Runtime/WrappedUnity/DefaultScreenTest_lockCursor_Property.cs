using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckLockCursorGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var lockCursor = screen.lockCursor;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckLockCursorSetterToExceptions(bool lockCursor)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.lockCursor = lockCursor;
			});
		}
	}
}
