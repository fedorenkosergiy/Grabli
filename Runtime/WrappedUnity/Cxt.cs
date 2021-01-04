namespace Grabli.WrappedUnity
{
	public static class Cxt
	{
		public static Time Time => TimeContext.Instance;

		public static Input Input => InputContext.Instance;
	}
}
