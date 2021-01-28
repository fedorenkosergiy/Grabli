namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultTypeConfigTests
    {
        private class FakeFactory : DefaultFactory
        {
            public override T CreateTypeConfig<T>(string guid)
            {
                if (typeof(T) == typeof(TypeConfig))
                {
                    return (T) (TypeConfig) (new DefaultWritableTypeConfig(guid));
                }

                return base.CreateTypeConfig<T>(guid);
            }
        }
        
        private Factory CreateFakeFactory()
        {
            return new FakeFactory();
        }
    }
}