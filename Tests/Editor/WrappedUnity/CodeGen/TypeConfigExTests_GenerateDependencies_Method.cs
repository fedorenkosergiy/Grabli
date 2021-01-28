using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class TypeConfigExTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        [TestCase(RootTypeGuidInput)]
        public void CheckGenerateDependenciesIfNotInitialized(string guid)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Factory factory = CreateFakeFactory();
                    TypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(guid);
                    config.GenerateDependencies();
                });
            }
        }

        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        [TestCase(RootTypeGuidInput)]
        public void CheckGenerateDependenciesIfNotResolved(string guid)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Factory factory = CreateFakeFactory();
                    ReadonlyTypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(guid);
                    Initializer initializer = config.GetInitializer();
                    initializer.Init();
                    config.GenerateDependencies();
                });
            }
        }

        [TestCase(RootTypeGuidApplication, 0)]
        [TestCase(RootTypeGuidScreen, 0)]
        [TestCase(RootTypeGuidInput, 1)]
        public void CheckGenerateDependenciesIfNotResolved(string guid, int expectedCount)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                ReadonlyTypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                DependenciesResolver resolver = factory.GetResolver();
                config.ResolveDependencies(resolver);
                string[] guids = config.GenerateDependencies();
                int actualCount = guids.Length;
                Assert.AreEqual(expectedCount, actualCount);
            }
        }
    }
}