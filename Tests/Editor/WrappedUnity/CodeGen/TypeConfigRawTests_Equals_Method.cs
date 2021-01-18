using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class TypeConfigRawTests
	{
		[Test]
		public void CheckIfTwoConfigsAreEqual()
		{
			var a = GetConfigA();
			var a2 = GetConfigA();
			bool equals = a.Equals(a2);
			Assert.IsTrue(equals);
		}

		[TestCaseSource(nameof(GetDifferentConfigs))]
		public void CheckIfTwoConfigsAreNotEqual(TypeConfigRaw a, TypeConfigRaw b)
		{
			bool equals = a.Equals(b);
			Assert.False(equals);
			equals = b.Equals(a);
			Assert.False(equals);
		}
	}
}
