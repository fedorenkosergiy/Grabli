using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class PackageIdValidatorTests
    {
        [TestCase("com.unity.json", true)]
        [TestCase("com.unity.ui", true)]
        [TestCase("com.grabli.core", true)]
        [TestCase(maxLongPackageId, true)]
        [TestCase("com.Unity.Json", false)]
        [TestCase("com.", false)]
        [TestCase("com.unity", false)]
        [TestCase("com..", false)]
        [TestCase("unity.json", false)]
        [TestCase("json.unity.com", false)]
        [TestCase("json.unity.com$", false)]
        [TestCase("json.un?ity.com", false)]
        [TestCase(null, false)]
        [TestCase("", false)]
        public void CheckIsValid(string packageId, bool expected)
        {
            PackageIdValidator validator = new PackageIdValidator(packageId);
            bool actual = validator.IsValid(out string unused);
            Assert.AreEqual(expected, actual);
        }
    }
}