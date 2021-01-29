using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public abstract class DefaultTypeConfig : TypeConfig
    {
        public string Guid { get; protected set; }
        public virtual Type Type { get; protected set; }
        public virtual string SpaceName { get; protected set; }
        public virtual string InterfaceName { get; protected set; }
        public virtual string ClassName { get; protected set; }
        public virtual bool UnityVersionSpecific { get; protected set; }
        public virtual string PackageId { get; protected set; }
        public virtual Approach Approach { get; protected set; }
        public virtual TypeConfig[] Dependencies { get; private set; }

        protected DefaultTypeConfig(string guid)
        {
            Guid = guid;
        }

        public virtual void ResolveDependencies(DependenciesResolver resolver)
        {
            ThrowIfDependenciesResolved();
            Dependencies = resolver.Resolve(GetDependenciesGuids());
        }

        private void ThrowIfDependenciesResolved()
        {
            if (Dependencies.Is())
            {
                const string message = "Dependencies already resolved";
                throw new InvalidOperationException(message);
            }
        }

        protected abstract string[] GetDependenciesGuids();

        protected void ResetDependencies()
        {
            Dependencies = default;
        }
    }
}