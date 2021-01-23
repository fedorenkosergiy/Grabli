namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultReadonlyTypeConfig : DummyReadonlyTypeConfig
    {
        private readonly Factory factory;
        private Initializer initializer;
        private string[] dependencyGuids;

        public DefaultReadonlyTypeConfig(Factory factory, string guid) : base(guid)
        {
            this.factory = factory;
        }

        public override void ResolveDependencies(DependenciesResolver resolver)
        {
            base.ResolveDependencies(resolver);
            Dependencies = resolver.Resolve(dependencyGuids);
        }

        public override Initializer GetInitializer()
        {
            return initializer ?? (initializer = factory.CreateInitializer(guid, SetRaw));
        }

        private void SetRaw(TypeConfigRaw raw)
        {
            Namespace = raw.Namespace;
            InterfaceName = raw.InterfaceName;
            ClassName = raw.ClassName;
            UnityVersionSpecific = raw.UnityVersionSpecific;
            PackageId = raw.PackageId;
            Approach = raw.Approach;
            dependencyGuids = raw.DependencyGuids;
        }
    }
}