using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckSetUnityVersionSpecificIfWorks()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetUnityVersionSpecific();
            Assert.IsTrue(config.UnityVersionSpecific);
            LogAssert.NoUnexpectedReceived();
        }
        
        [Test]
        public void CheckSetUnityVersionSpecificIfLogsWarningWhenDoubleCall()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetUnityVersionSpecific();
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.SetUnityVersionSpecific();
            LogAssert.NoUnexpectedReceived();
        }
    }
}