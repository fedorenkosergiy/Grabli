using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public abstract class DefaultTypeConfig : TypeConfig
    {
        public string Guid { get; protected set; }
        public virtual Type Type { get; protected set; }
        public virtual string Namespace { get; protected set; }
        public virtual string InterfaceName { get; protected set; }
        public virtual string ClassName { get; protected set; }
        public virtual bool UnityVersionSpecific { get; protected set; }
        public virtual string PackageId { get; protected set; }
        public virtual Approach Approach { get; protected set; }
        public virtual ReadonlyTypeConfig[] Dependencies { get; protected set; }

        protected DefaultTypeConfig(string guid)
        {
            Guid = guid;
        }

        public abstract void ResolveDependencies(DependenciesResolver resolver);
    }
}