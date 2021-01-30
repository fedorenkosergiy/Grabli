using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [TestCaseSource(nameof(GetAllApproachValues))]
        public void CheckSetApproachIfWorks(Approach approach)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetApproach(approach);
            Assert.AreEqual(approach, config.Approach);
        }
        
        [TestCaseSource(nameof(GetAllApproachValuesExceptUndefined))]
        public void CheckSetApproachIfLogsWarningWhenDoubleCall(Approach approach)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetApproach(approach);
            LogAssert.Expect(LogType.Warning, WastingLoggerEx.ValueDidntChange);
            config.SetApproach(approach);
            LogAssert.NoUnexpectedReceived();
        }
    }
}