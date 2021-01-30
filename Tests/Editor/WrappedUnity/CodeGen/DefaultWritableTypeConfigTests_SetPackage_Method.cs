using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [TestCase("com.unity.json")]
        [TestCase("com.unity.ui")]
        [TestCase("com.grabli.core")]
        public void CheckSetPackageSpecificIfWorks(string expected)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetPackage(expected);
            Assert.AreEqual(expected, config.PackageId);
        }
        
        [TestCase("com.unity.json")]
        [TestCase("com.unity.ui")]
        [TestCase("com.grabli.core")]
        public void CheckSetPackageIfLogsWarningWhenDoubleCall(string expected)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetPackage(expected);
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.SetPackage(expected);
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CheckSetPackageIfArgumentNull()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentNullException>(() => config.SetPackage(null));
        }
        
        [Test]
        public void CheckSetPackageIfArgumentEmpty()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetPackage(string.Empty));
        }
        
        [TestCase("com.Unity.Json")]
        [TestCase("com.")]
        [TestCase("com.unity")]
        [TestCase("com..")]
        [TestCase("unity.json")]
        [TestCase("json.unity.com")]
        [TestCase("json.unity.com$")]
        [TestCase("json.un?ity.com")]
        [TestCase(TooLongPackageId)]
        public void CheckSetPackageIfInvalidPackageId(string packageId)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetPackage(packageId));
        }
    }
}