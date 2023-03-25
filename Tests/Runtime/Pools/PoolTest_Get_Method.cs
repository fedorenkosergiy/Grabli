using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Grabli.Pools
{
	public partial class PoolTest
	{
		[Test]
		public static void GetObjectNotNull()
		{
			object obj = Pool<object>.Get();
			Assert.NotNull(obj);
		}

		[Test]
		public static void GetTwoDifferentObjects()
		{
			object first = Pool<object>.Get();
			object second = Pool<object>.Get();
			Assert.AreNotEqual(first, second);
		}

		[Test]
		public static void GetListLeadsToException()
		{
			Assert.Catch<ThereIsBetterPoolException>(() =>
			{
				List<object> list = Pool<List<object>>.Get();
			});
		}
	}
}
