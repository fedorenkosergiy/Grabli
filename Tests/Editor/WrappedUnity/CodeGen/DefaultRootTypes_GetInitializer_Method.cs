using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultRootTypesTests
    {
        [Test]
        public void CheckGetInitializerIfWorks()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultRootTypes types = new DefaultRootTypes(factory, RootTypesFilePath);
                Initializer initializer = types.GetInitializer();
                initializer.Init();
                Assert.IsTrue(initializer.IsInitialized);
            }
        }
    }
}