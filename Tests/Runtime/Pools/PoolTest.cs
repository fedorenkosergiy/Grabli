using NUnit.Framework;
namespace Grabli.Pools
{
	using static Debugger;
	public partial class PoolTest
	{
		[TearDown]
		public static void TearDown() => ResetAllPools();
	}
}
