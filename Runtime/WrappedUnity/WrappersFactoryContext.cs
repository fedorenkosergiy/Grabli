namespace Grabli.WrappedUnity
{
	public class WrappersFactoryContext : Context<WrappersFactoryContext, DefaultWrappersFactory, WrappersFactory>
	{
        protected override bool MoveEventInvocationLists => false;
	}
}
