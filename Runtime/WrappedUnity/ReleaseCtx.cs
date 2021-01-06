#if RELEASE_CTX && !CUSTOM_CTX
namespace Grabli.WrappedUnity
{
	public static class Ctx
	{
		public readonly static Time Time = new DefaultTime();

		public readonly static Input Input = new DefaultInput();

		public readonly static Screen Screen = new DefaultScreen();

		public readonly static WrappersFactory Factory = new DefaultWrappersFactory();
	}
}
#endif
