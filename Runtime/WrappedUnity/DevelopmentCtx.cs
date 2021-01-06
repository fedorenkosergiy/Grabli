#if (DEVELOPMENT_BUILD || UNITY_EDITOR || DEVELOPMENT_CTX) && !CUSTOM_CTX
namespace Grabli.WrappedUnity
{
	public static class Ctx
	{
		public static Time Time => TimeContext.Instance;

		public static Input Input => InputContext.Instance;

		public static Screen Screen => ScreenContext.Instance;

		public static WrappersFactory Factory => WrappersFactoryContext.Instance;
	}
}
#endif