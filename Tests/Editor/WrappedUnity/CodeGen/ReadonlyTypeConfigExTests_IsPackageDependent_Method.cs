using Moq;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class ReadonlyTypeConfigExTests
	{
		[TestCase("com.unity.ext.nunit", true)]
		[TestCase("", false)]
		[TestCase(null, false)]
		public void CheckIsPackageDependent(string packageId, bool expected)
		{
			Mock<ReadonlyTypeConfig> mock = new Mock<ReadonlyTypeConfig>();
			mock.Setup(config => config.PackageId).Returns(packageId);
			bool actual = mock.Object.IsPackageDependent();
			Assert.AreEqual(expected, actual);
		}
	}
}
