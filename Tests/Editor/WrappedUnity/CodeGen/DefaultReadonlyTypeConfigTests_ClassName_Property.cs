using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckClassNameIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(guid);
                string unused = config.ClassName;
            });
        }
    }
}