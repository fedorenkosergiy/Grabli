namespace Grabli.WrappedUnity
{
	public class ScreenContext : Context<ScreenContext, DefaultScreen, Screen>
	{
		public ScreenContext()
		{
		}

		public ScreenContext(Screen instance) : base(instance)
		{
		}
	}
}
