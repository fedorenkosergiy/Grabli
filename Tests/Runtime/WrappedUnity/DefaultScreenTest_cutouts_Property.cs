using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckCutoutsGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var cutouts = screen.cutouts;
			});
		}
	}
}
