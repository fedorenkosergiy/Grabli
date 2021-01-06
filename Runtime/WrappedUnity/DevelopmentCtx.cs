#if (DEVELOPMENT_BUILD || UNITY_EDITOR || DEV)
namespace Grabli.WrappedUnity
{
	public static partial class Ctx
	{
		public static Time Time => TimeContext.Instance;

		public static Input Input => InputContext.Instance;

		public static Screen Screen => ScreenContext.Instance;

		public static WrappersFactory Factory => WrappersFactoryContext.Instance;
	}
}
#endif
