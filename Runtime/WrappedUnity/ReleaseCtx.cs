#if RELEASE_CTX && !CUSTOM_CTX
using SystemInterface.IO;
using SystemWrapper.IO;

namespace Grabli.WrappedUnity
{
	public static class Ctx
	{
		public static readonly Time Time = new DefaultTime();
		public static readonly Input Input = new DefaultInput();
		public static readonly Screen Screen = new DefaultScreen();
		public static readonly Application Application = new DefaultApplication();
		public static readonly WrappersFactory Factory = new DefaultWrappersFactory();
		public static readonly IFile File = new FileWrap();
	}
}
#endif
