namespace Grabli.WrappedUnity
{
	public class ScreenContext : Context<ScreenContext, DefaultScreen, Screen>
	{
        protected override bool MoveEventInvocationLists => false;
        
		public ScreenContext()
		{
		}

		public ScreenContext(Screen instance) : base(instance)
		{
		}
	}
}
