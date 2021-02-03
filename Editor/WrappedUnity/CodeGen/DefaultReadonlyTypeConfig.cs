using System;

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

        public override Initializer GetInitializer()
        {
            return initializer ?? (initializer = factory.CreateInitializer(Guid, SetRaw));
        }

        protected override string[] GetUnresolvedDependenciesGuids()
        {
            return dependencyGuids;
        }

        private void SetRaw(TypeConfigRaw? rawObject)
        {
            if (rawObject.HasValue)
            {
                SetRaw(rawObject.Value);
            }
            else
            {
                Reset();
            }
        }

        private void SetRaw(TypeConfigRaw raw)
        {
            SpaceName = raw.SpaceName;
            InterfaceName = raw.InterfaceName;
            ClassName = raw.ClassName;
            UnityVersionSpecific = raw.UnityVersionSpecific;
            PackageId = raw.PackageId;
            Approach = raw.Approach;
            dependencyGuids = raw.DependencyGuids;
            if (AppDomain.CurrentDomain.TryGetType(raw.FullTypeName, out Type type))
            {
                Type = type;
            }
            else
            {
                string message = $"Type {raw.FullTypeName} doesn't exist in the current AppDomain";
                throw new ArgumentException(message, nameof(raw));
            }
        }

        private void Reset()
        {
            SpaceName = default;
            InterfaceName = default;
            ClassName = default;
            UnityVersionSpecific = default;
            PackageId = default;
            Approach = Approach.Undefined;
            dependencyGuids = default;
            Type = default;
        }
    }
}