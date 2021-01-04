using NUnit.Framework;

namespace Grabli.Pools
{
	using static Debugger;
	public partial class DebuggerTest
	{
		[TearDown]
		public static void TearDown() => ResetAllPools();
	}
}
