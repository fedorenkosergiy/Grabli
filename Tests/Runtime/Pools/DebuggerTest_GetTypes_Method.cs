using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grabli.Pools
{
	public partial class DebuggerTest
	{
		[Test]
		public void GetTypesReturnsNotNull()
		{
			IReadOnlyList<Type> types = Debugger.GetTypes();
			Assert.NotNull(types);
		}

		[Test]
		public void GetTypesMustBeEmpty()
		{
			IReadOnlyList<Type> types = Debugger.GetTypes();
			Assert.IsEmpty(types);
		}

		[Test]
		public void GeTypesCheckExistance()
		{
			Pool<object>.Get();
			IReadOnlyList<Type> types = Debugger.GetTypes();
			Assert.IsTrue(types.Contains(typeof(object)));
		}

		[Test]
		public void GetTypesMustContainsSingleType()
		{
			Pool<object>.Get();
			int actual = Debugger.GetTypes().Count;
			const int EXPECTED = 1;
			Assert.AreEqual(EXPECTED, actual);
		}
	}
}
