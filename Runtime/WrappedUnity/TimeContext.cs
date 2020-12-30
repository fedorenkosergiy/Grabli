namespace Grabli.WrappedUnity
{
	public class TimeContext : Context<TimeContext, DefaultTime, Time>
	{
		public TimeContext()
		{
		}

		public TimeContext(Time instance) : base(instance)
		{
		}
	}
}
