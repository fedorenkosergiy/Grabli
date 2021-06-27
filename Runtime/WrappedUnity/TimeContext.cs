namespace Grabli.WrappedUnity
{
	public class TimeContext : Context<TimeContext, DefaultTime, Time>
	{
        protected override bool MoveEventInvocationLists => false;
        
		public TimeContext()
		{
		}

		public TimeContext(Time instance) : base(instance)
		{
		}
	}
}
