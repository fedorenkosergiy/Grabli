namespace Grabli.WrappedUnity
{
	public class InputContext : Context<InputContext, DefaultInput, Input>
	{
		public InputContext()
		{
		}

		public InputContext(Input instance) : base(instance)
		{
		}
	}
}
