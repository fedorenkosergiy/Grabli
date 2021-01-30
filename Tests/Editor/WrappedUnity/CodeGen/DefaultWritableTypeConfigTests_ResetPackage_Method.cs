using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckResetPackageIfWorks()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetPackage("com.unity.json");
            config.ResetPackage();
            Assert.IsFalse(config.IsPackageDependent());
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CheckResetPackageIfLogsWarning()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.ResetPackage();
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CheckResetPackageIfLogsWarningWhenDoubleCall()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetPackage("com.unity.json");
            config.ResetPackage();
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.ResetPackage();
            LogAssert.NoUnexpectedReceived();
        }
    }
}