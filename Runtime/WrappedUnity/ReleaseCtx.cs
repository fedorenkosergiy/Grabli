#if !(DEVELOPMENT_BUILD || UNITY_EDITOR || DEV)
namespace Grabli.WrappedUnity
{
	public static partial class Ctx
	{
		public readonly static Time Time = new DefaultTime();

		public readonly static Input Input = new DefaultInput();

		public readonly static Screen Screen = new DefaultScreen();

		public readonly static WrappersFactory Factory = new DefaultWrappersFactory();
	}
}
#endif
