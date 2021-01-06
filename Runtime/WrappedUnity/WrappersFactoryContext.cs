namespace Grabli.WrappedUnity
{
	public class WrappersFactoryContext : Context<WrappersFactoryContext, DefaultWrappersFactory, WrappersFactory>
	{
		public WrappersFactoryContext()
		{
		}

		public WrappersFactoryContext(WrappersFactory instance) : base(instance)
		{
		}
	}
}
