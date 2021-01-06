using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultScreenTest
	{
		[Test]
		public void CheckBrightnessGetterToExceptions()
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				var brightness = screen.brightness;
			});
		}

		[TestCase(0.0f)]
		[TestCase(0.5f)]
		[TestCase(1.0f)]
		public void CheckBrightnessSetterToExceptions(float brightness)
		{
			DefaultScreen screen = new DefaultScreen();
			Assert.DoesNotThrow(() =>
			{
				screen.brightness = brightness;
			});
		}
	}
}
