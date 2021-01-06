using NUnit.Framework;
using System;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckShowCursorGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.Catch<NotImplementedException>(() =>
			{
				var showCursor = screen.showCursor;
			});
		}

		[TestCase(true)]
		[TestCase(false)]
		public void CheckShowCursorSetterToExceptions(bool showCursor)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.Catch<NotImplementedException>(() =>
			{
				screen.showCursor = showCursor;
			});
		}
	}
}
