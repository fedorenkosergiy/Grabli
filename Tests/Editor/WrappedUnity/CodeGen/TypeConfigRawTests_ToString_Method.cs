using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class TypeConfigRawTests
	{
		[Test]
		public void CheckToString()
		{
			var config = GetConfigA();
			var expected = GetConfigAString();
			var actual = config.ToString();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CheckToStringWithNullDependentcies()
		{
			var config = GetConfigWithNullDependencies();
			var expected = GetConfigWithNullDependenciesString();
			var actual = config.ToString();
			Assert.AreEqual(expected, actual);
		}
	}
}
