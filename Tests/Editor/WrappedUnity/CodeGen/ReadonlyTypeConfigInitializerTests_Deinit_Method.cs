using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class ReadonlyTypeConfigInitializerTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckDeinitIfWorks(string guid)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(CreateFakeFactory(), guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                initializer.Deinit();
                Assert.IsFalse(initializer.IsInitialized);
            }
        }

        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckDeinitIfThrowsWhenAlreadyDeinitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(CreateFakeFactory(), guid);
                    Initializer initializer = config.GetInitializer();
                    initializer.Init();
                    initializer.Deinit();
                    initializer.Deinit();
                }
            });
        }
    }
}