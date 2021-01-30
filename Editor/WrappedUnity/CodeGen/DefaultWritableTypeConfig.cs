using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultWritableTypeConfig : DefaultTypeConfig, WritableTypeConfig, Thrower, WastingLogger
    {
        private readonly Factory factory;
        private string[] dependenciesGuids;

        public override string PackageId { get; protected set; } = string.Empty;

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
            validator.ThrowArgumentExceptionIfInvalid(argumentName);
        }

        public void SetInterfaceName(string interfaceName)
        {
            this.ThrowIfStringIsNullOrEmpty(interfaceName, nameof(interfaceName));
            InterfaceName = interfaceName;
        }

        public void SetClassName(string className)
        {
            this.ThrowIfStringIsNullOrEmpty(className, nameof(className));
            ClassName = className;
        }

        public void SetSpaceName(string spaceName)
        {
            this.ThrowIfStringIsNullOrEmpty(spaceName, nameof(spaceName));
            SpaceName = spaceName;
        }

        public void SetUnityVersionSpecific()
        {
            SetUnityVersionSpecific(true);
        }

        private void SetUnityVersionSpecific(bool value)
        {
            this.LogWarningValueDidntChange(UnityVersionSpecific, value);
            UnityVersionSpecific = value;
        }

        public void ResetUnityVersionSpecific()
        {
            SetUnityVersionSpecific(false);
        }

        public void SetPackage(string packageId)
        {
            this.LogWarningValueDidntChange(PackageId, packageId);
            this.ThrowIfStringIsNullOrEmpty(packageId, nameof(packageId));
            ThrowIfPackageIdIsInvalid(packageId, nameof(packageId));
            PackageId = packageId;
        }
        
        private void ThrowIfPackageIdIsInvalid(string packageId, string argumentName)
        {
            Validator validator = factory.CreatePackageIdValidator(packageId);
            validator.ThrowArgumentExceptionIfInvalid(argumentName);
        }

        public void ResetPackage()
        {
            this.LogWarningValueDidntChange(PackageId, string.Empty);
            PackageId = string.Empty;
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