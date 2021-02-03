using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultWritableTypeConfig : DefaultTypeConfig, WritableTypeConfig, Thrower, WastingLogger
    {
        private readonly Factory factory;
        private string[] dependenciesGuidsCache;
        private readonly List<string> dynamicDependencies = new List<string>();

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
            this.LogWarningValueDidntChange(Approach, approach);
            Approach = approach;
        }

        public void AddDependency(TypeConfig dependency)
        {
            this.ThrowIfArgumentIsNull(dependency, nameof(dependency));
            ThrowIfDependencyAlreadyExists(dependency, nameof(dependency));
            dynamicDependencies.Add(dependency.Guid);
            ClearCachedData();
        }

        private void ThrowIfDependencyAlreadyExists(TypeConfig dependency, string argumentName)
        {
            if (dynamicDependencies.Contains(dependency.Guid))
            {
                const string message = "Dependency already exists";
                throw new ArgumentException(message, argumentName);
            }
        }

        public void RemoveDependency(TypeConfig dependency)
        {
            this.ThrowIfArgumentIsNull(dependency, nameof(dependency));
            ThrowIfDependencyDoesntExist(dependency, nameof(dependency));
            dynamicDependencies.Remove(dependency.Guid);
            ClearCachedData();
        }

        private void ThrowIfDependencyDoesntExist(TypeConfig dependency, string argumentName)
        {
            if (dynamicDependencies.Contains(dependency.Guid))
            {
                return;
            }

            const string message = "Dependency doesn't exists";
            throw new ArgumentException(message, argumentName);
        }

        protected override string[] GetUnresolvedDependenciesGuids()
        {
            return dependenciesGuidsCache ?? CacheDependenciesGuids();
        }

        private string[] CacheDependenciesGuids()
        {
            dependenciesGuidsCache = new string [dynamicDependencies.Count];
            for (int i = 0; i < dynamicDependencies.Count; ++i)
            {
                dependenciesGuidsCache[i] = dynamicDependencies[i];
            }
            return dependenciesGuidsCache;
        }

        private void ClearCachedData()
        {
            dependenciesGuidsCache = default;
        }

        public void SetSource(TypeConfig source, DependenciesResolver resolver)
        {
            this.ThrowIfArgumentIsNull(source, nameof(source));
            this.ThrowIfArgumentIsNull(resolver, nameof(resolver));
            source.ThrowDependenciesAreNotResolved(nameof(source));

            Guid = source.Guid;
            Type = source.Type;
            SpaceName = source.SpaceName;
            InterfaceName = source.InterfaceName;
            ClassName = source.ClassName;
            UnityVersionSpecific = source.UnityVersionSpecific;
            PackageId = source.PackageId;
            Approach = source.Approach;
            dynamicDependencies.AddRange(source.GenerateDependencies());
            ResolveDependencies(resolver);
        }
    }
}