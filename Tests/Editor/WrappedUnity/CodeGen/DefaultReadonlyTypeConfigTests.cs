using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        private class FakeFactory : DefaultFactory
        {
            public override T CreateTypeConfig<T>(string guid)
            {
                if (typeof(T) == typeof(ReadonlyTypeConfig))
                {
                    return (T) (ReadonlyTypeConfig) (new DefaultReadonlyTypeConfig(this, guid));
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