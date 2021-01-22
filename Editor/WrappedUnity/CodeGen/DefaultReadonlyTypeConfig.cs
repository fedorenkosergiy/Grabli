using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultReadonlyTypeConfig : DummyReadonlyTypeConfig
    {
        public DefaultReadonlyTypeConfig(string guid) : base(guid) { }

        public override void ResolveDependencies(DependenciesResolver resolver)
        {
            throw new NotImplementedException();
        }

        public override Initializer GetInitializer()
        {
            throw new NotImplementedException();
        }

        private void SetRaw(TypeConfigRaw raw)
        {
            throw new NotImplementedException();
        }
    }
}