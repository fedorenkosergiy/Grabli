using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckAddDependencyIfWorks()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
                TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
                config.AddDependency(dependency);
                config.ResolveDependencies(factory.GetResolver());
                Assert.IsTrue(config.IsDependentOn(dependency));
            }
        }

        [Test]
        public void CheckAddDependencyIfThrowsWhenAlreadyAdded()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
            config.AddDependency(dependency);
            Assert.Throws<ArgumentException>(() => config.AddDependency(dependency));
        }

        [Test]
        public void CheckAddDependencyIfThrowsWhenNull()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            Assert.Throws<ArgumentNullException>(() => config.AddDependency(null));
        }

        [Test]
        public void CheckAddDependencyIfRequireResolutionAfter()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidApplication);
                TypeConfig input = factory.CreateTypeConfig<WritableTypeConfig>(RootTypeGuidInput);
                config.AddDependency(input);
                config.ResolveDependencies(factory.GetResolver());
                
                TypeConfig compas = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
                config.AddDependency(compas);
                Assert.IsFalse(config.IsDependenciesResolved());
            }
        }
    }
}