using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckResetUnityVersionSpecificIfWorks()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetUnityVersionSpecific();
            config.ResetUnityVersionSpecific();
            Assert.IsFalse(config.UnityVersionSpecific);
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CheckResetUnityVersionSpecificIfLogsWarning()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.ResetUnityVersionSpecific();
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CheckResetUnityVersionSpecificIfLogsWarningWhenDoubleCall()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetUnityVersionSpecific();
            config.ResetUnityVersionSpecific();
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.ResetUnityVersionSpecific();
            LogAssert.NoUnexpectedReceived();
        }
    }
}