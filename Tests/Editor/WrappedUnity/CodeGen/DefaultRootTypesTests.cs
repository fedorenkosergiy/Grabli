namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultRootTypesTests
    {
        private class FakeFactory : DefaultFactory { }

        private static Factory CreateFakeFactory() => new FakeFactory();
    }
}