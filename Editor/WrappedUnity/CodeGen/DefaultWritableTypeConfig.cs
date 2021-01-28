using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultWritableTypeConfig : DefaultTypeConfig, WritableTypeConfig, Thrower
    {
        private string[] dependenciesGuids;
        public DefaultWritableTypeConfig(string guid) : base(guid) { }

        public DefaultWritableTypeConfig() : base(default) { }

        public void SetType(Type type)
        {
            this.ThrowIfArgumentIsNull(type, nameof(type));
            ThrowIfTypeIsInvalid(type, nameof(type));
            Type = type;
        }

        private void ThrowIfTypeIsInvalid(Type type, string argumentName)
        {
            if (IsValidType(type, out string message))
            {
                return;
            }

            throw new ArgumentException(message, argumentName);
        }

        private bool IsValidType(Type type, out string message)
        {
            message = null;
            if (type.IsDelegate())
            {
                message = "Type can not be a delegate";
            }

            if (type.IsAttribute())
            {
                message = "Type can not be an attribute";
            }

            if (type.IsClass)
            {
                return message.IsNullOrEmpty();
            }

            message = "Type should be a class";
            return false;
        }

        public void SetInterfaceName(string interfaceName)
        {
            throw new NotImplementedException();
        }

        public void SetClassName(string className)
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
            Namespace = source.Namespace;
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