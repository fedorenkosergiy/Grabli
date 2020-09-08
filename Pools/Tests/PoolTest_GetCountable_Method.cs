using NUnit.Framework;
using System;
using Grabli;

namespace Grabli.Pools
{
	public partial class DebuggerTest
	{
		[Test]
		public void GetCounableReturnsNull()
		{
			Countable actual = Debugger.GetCountable(typeof(object));
			Assert.IsNull(actual);
		}

		[Test]
		public void GetCountableCountEqualsOne()
		{
			Pool<object>.Get();
			int actual = Debugger.GetCountable(typeof(object)).Count;
			const int EXPECTED = 1;
			Assert.AreEqual(EXPECTED, actual);
		}

		[Test]
		public void GetCountableCountStillEqualsOne()
		{
			object obj = Pool<object>.Get();
			Pool<object>.Release(obj);
			int actual = Debugger.GetCountable(typeof(object)).Count;
			const int EXPECTED = 1;
			Assert.AreEqual(EXPECTED, actual);
		}

		[Test]
		public void GetCountableCountEqualsN([Random(1, 100, 5)] int n)
		{
			for(int i = 0; i < n; ++i)
			{
				Pool<object>.Get();
			}
			int actual = Debugger.GetCountable(typeof(object)).Count;
			Assert.AreEqual(n, actual);
		}

		[Test]
		public void GetCountableCountEqualsN([Random(50, 100, 5)] int get, [Random(0, 50, 5)] int release)
		{
			for (int i = 0; i < get; ++i)
			{
				object obj = Pool<object>.Get();
				if (i < release)
				{
					Pool<object>.Release(obj);
				}
			}
			int actual = Debugger.GetCountable(typeof(object)).Count;
			int expected = get - release;
			Assert.AreEqual(expected, actual);
		}
	}
}
