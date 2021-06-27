namespace Grabli.WrappedUnity
{
	public class ApplicationContext : Context<ApplicationContext, DefaultApplication, Application>
    {
        protected override bool MoveEventInvocationLists => false;
    }
}
