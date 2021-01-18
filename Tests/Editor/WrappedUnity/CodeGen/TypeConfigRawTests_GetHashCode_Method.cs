using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class TypeConfigRawTests
	{
		[Test]
		public void CheckGetHashCodeIsTheSameForEqualObjects()
		{
			var a = GetConfigA();
			var a2 = GetConfigA();
			int hashA = a.GetHashCode();
			int hashA2 = a2.GetHashCode();
			Assert.AreNotEqual(hashA, hashA2);
		}

		[TestCaseSource(nameof(GetDifferentConfigs))]
		public void CheckGetHashCodeIsDifferentForDifferentConfigs(TypeConfigRaw a, TypeConfigRaw b)
		{
			int hashA = a.GetHashCode();
			int hashB = b.GetHashCode();
			Assert.AreNotEqual(hashA, hashB);
		}
	}
}
