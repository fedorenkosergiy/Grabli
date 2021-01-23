namespace Grabli.WrappedUnity.CodeGen
{
    public partial class ReadonlyTypeConfigInitializerTests
    {
        private class FakeFactory : DefaultFactory
        {
            public override Initializer CreateInitializer(string guid, TypeConfigRawSetter setter)
            {
                return new ReadonlyTypeConfigInitializer(this, guid, setter);
            }
        }

        private static Factory CreateFakeFactory() => new FakeFactory();
    }
}