using NUnit.Framework;
using System;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckGetResolutionGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.Catch<NotImplementedException>(() =>
			{
				var resolutions = screen.GetResolution;
			});
		}
	}
}
