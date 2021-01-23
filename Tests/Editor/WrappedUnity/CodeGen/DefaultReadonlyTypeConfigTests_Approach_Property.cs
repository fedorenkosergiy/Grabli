using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckApproachIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Approach unused = config.Approach;
            });
        }

        [TestCase(RootTypeGuidApplication, Approach.EncapsulateStaticType)]
        [TestCase(RootTypeGuidScreen, Approach.EncapsulateStaticType)]
        public void CheckApproachIfWorks(string guid, Approach expected)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                Approach actual = config.Approach;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}