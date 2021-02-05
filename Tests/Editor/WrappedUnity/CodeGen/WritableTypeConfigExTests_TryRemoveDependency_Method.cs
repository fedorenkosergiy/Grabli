using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class WritableTypeConfigExTests
    {
        [Test]
        public void CheckTryRemoveDependencyIfWorks()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                WritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
                ReadonlyTypeConfig dependency = factory.CreateTypeConfig<ReadonlyTypeConfig>(TypeGuidCompas);
                Initializer initializer = dependency.GetInitializer();
                initializer.Init();
                config.AddDependency(dependency);
                config.ResolveDependencies(factory.GetResolver());
                bool removed = config.TryRemoveDependency(dependency.Type);
                Assert.IsTrue(removed);
                config.ResolveDependencies(factory.GetResolver());
                Assert.IsFalse(config.IsDependentOn(dependency));
            }
        }

        [Test]
        public void CheckTryRemoveDependencyIfWorksWithInvalidData()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                WritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
                TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
                config.AddDependency(dependency);
                config.ResolveDependencies(factory.GetResolver());
                bool removed = config.TryRemoveDependency(typeof(void));
                Assert.IsFalse(removed);
                Assert.IsTrue(config.IsDependentOn(dependency));
            }
        }
    }
}