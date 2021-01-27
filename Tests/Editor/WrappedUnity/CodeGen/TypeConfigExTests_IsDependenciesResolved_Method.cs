using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class TypeConfigExTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        [TestCase(RootTypeGuidInput)]
        public void CheckIsDependenciesResolved(string guid)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                ReadonlyTypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                DependenciesResolver resolver = factory.GetResolver();
                Assert.IsFalse(config.IsDependenciesResolved());
                config.ResolveDependencies(resolver);
                Assert.IsTrue(config.IsDependenciesResolved());
            }
        }
    }
}