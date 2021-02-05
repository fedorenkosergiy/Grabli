using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultFactoryTests
    {
        [Test]
        public void CheckCreateInitializerOfRootTypes()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = new DefaultFactory();
                void Setter(ReadonlyTypeConfig[] configs) { }
                Initializer initializer = factory.CreateInitializer(RootTypesFilePath, Setter);
                Assert.IsNotNull(initializer);
            }
        }
    }
}