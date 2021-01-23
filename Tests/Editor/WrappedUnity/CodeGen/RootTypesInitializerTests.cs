using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class RootTypesInitializerTests
    {
        private class FakeFactory : DefaultFactory
        {
            public override Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter)
            {
                return new RootTypesInitializer(this, filePath, setter);
            }
        }

        private Factory CreateFakeFactory() => new FakeFactory();

        private void DefaultConfigsSetter(ReadonlyTypeConfig[] configs) { }
    }
}