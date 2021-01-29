using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultWritableTypeConfig : DefaultTypeConfig, WritableTypeConfig, Thrower
    {
        private readonly Factory factory;
        private string[] dependenciesGuids;

        public DefaultWritableTypeConfig(Factory factory) : this(factory, default) { }

        public DefaultWritableTypeConfig(Factory factory, string guid) : base(guid)
        {
            this.factory = factory;
        }


        public void SetType(Type type)
        {
            this.ThrowIfArgumentIsNull(type, nameof(type));
            ThrowIfTypeIsInvalid(type, nameof(type));
            Type = type;
        }

        private void ThrowIfTypeIsInvalid(Type type, string argumentName)
        {
            Validator validator = factory.CreateTypeValidator(type);
            if (validator.IsValid(out string message))
            {
                return;
            }

            throw new ArgumentException(message, argumentName);
        }

        public void SetInterfaceName(string interfaceName)
        {
            throw new NotImplementedException();
        }

        public void SetClassName(string className)
        {
            throw new NotImplementedException();
        }

        public void SetSpaceName(string spaceName)
        {
            throw new NotImplementedException();
        }

        public void SetUnityVersionSpecific()
        {
            throw new NotImplementedException();
        }

        public void ResetUnityVersionSpecific()
        {
            throw new NotImplementedException();
        }

        public void SetPackage(string packageId)
        {
            throw new NotImplementedException();
        }

        public void ResetPackage()
        {
            throw new NotImplementedException();
        }

        public void SetApproach(Approach approach)
        {
            throw new NotImplementedException();
        }

        public void AddDependency(TypeConfig config)
        {
            throw new NotImplementedException();
        }

        public void RemoveDependency(TypeConfig config)
        {
            throw new NotImplementedException();
        }

        protected override string[] GetDependenciesGuids()
        {
            throw new NotImplementedException();
            return dependenciesGuids ?? null;
        }

        public void SetSource(TypeConfig source, DependenciesResolver resolver)
        {
            Guid = source.Guid;
            Type = source.Type;
            SpaceName = source.SpaceName;
            InterfaceName = source.InterfaceName;
            ClassName = source.ClassName;
            UnityVersionSpecific = source.UnityVersionSpecific;
            PackageId = source.PackageId;
            Approach = source.Approach;
            dependenciesGuids = source.GenerateDependencies();
            ResolveDependencies(resolver);
            throw new NotImplementedException();
        }
    }
}