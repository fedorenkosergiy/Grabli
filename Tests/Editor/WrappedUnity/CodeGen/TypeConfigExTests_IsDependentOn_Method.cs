using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class TypeConfigExTests
    {
        [Test]
        public void CheckIsDependentOnIfTrueForAllDependencies()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
                TypeConfig dependencyA = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
                TypeConfig dependencyB = factory.CreateTypeConfig<WritableTypeConfig>(RootTypeGuidApplication);
                config.AddDependency(dependencyA);
                config.AddDependency(dependencyB);
                config.ResolveDependencies(factory.GetResolver());
                Assert.IsTrue(config.IsDependentOn(dependencyA));
                Assert.IsTrue(config.IsDependentOn(dependencyB));
            }
        }
    }
}