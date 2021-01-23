using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckResolveDependenciesIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    Factory factory = CreateFakeFactory();
                    DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                    DependenciesResolver resolver = factory.GetResolver();
                    config.ResolveDependencies(resolver);
                }
            });
        }

        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckResolveDependenciesIfWorksWithIndependentTypes(string guid)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                DependenciesResolver resolver = factory.GetResolver();
                config.ResolveDependencies(resolver);
                Assert.IsEmpty(config.Dependencies);
            }
        }

        [TestCase(RootTypeGuidInput, 1)]
        public void CheckResolveDependenciesIfWorksWithDependentTypes(string guid, int expectedDependenciesCount)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                DependenciesResolver resolver = factory.GetResolver();
                config.ResolveDependencies(resolver);
                int actual = config.Dependencies.Length;
                Assert.AreEqual(expectedDependenciesCount, actual);
            }
        }

        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckResolveDependenciesThrowsIfAlreadyResolved(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    Factory factory = CreateFakeFactory();
                    DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                    Initializer initializer = config.GetInitializer();
                    initializer.Init();
                    DependenciesResolver resolver = factory.GetResolver();
                    config.ResolveDependencies(resolver);
                    config.ResolveDependencies(resolver);
                }
            });
        }
    }
}