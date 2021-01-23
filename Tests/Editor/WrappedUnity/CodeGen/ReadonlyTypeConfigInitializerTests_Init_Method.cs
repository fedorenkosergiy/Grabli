using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class ReadonlyTypeConfigInitializerTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckInitIfWorks(string guid)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(CreateFakeFactory(), guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
            }
        }

        [TestCase(GuidOfConfigWithCorruptedFullTypeName)]
        public void CheckInitIfThrowsWhenTypeIsCorrupted(string guid)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(CreateFakeFactory(), guid);
                    Initializer initializer = config.GetInitializer();
                    initializer.Init();
                }
            });
        }
    }
}