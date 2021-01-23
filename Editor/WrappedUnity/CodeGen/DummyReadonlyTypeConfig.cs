using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public abstract class DummyReadonlyTypeConfig : ReadonlyTypeConfig
    {
        private Type type;
        private string nameSpace;
        private string interfaceName;
        private string className;
        private bool unityVersionSpecific;
        private string packageId;
        private Approach approach;
        private ReadonlyTypeConfig[] dependencies;

        public string Guid { get; protected set; }

        public virtual Type Type
        {
            get
            {
                ThrowIfNotInitialized();
                return type;
            }
            protected set => type = value;
        }

        public virtual string Namespace
        {
            get
            {
                ThrowIfNotInitialized();
                return nameSpace;
            }
            protected set => nameSpace = value;
        }

        public virtual string InterfaceName
        {
            get
            {
                ThrowIfNotInitialized();
                return interfaceName;
            }
            protected set => interfaceName = value;
        }

        public virtual string ClassName
        {
            get
            {
                ThrowIfNotInitialized();
                return className;
            }
            protected set => className = value;
        }

        public virtual bool UnityVersionSpecific
        {
            get
            {
                ThrowIfNotInitialized();
                return unityVersionSpecific;
            }
            protected set => unityVersionSpecific = value;
        }

        public virtual string PackageId
        {
            get
            {
                ThrowIfNotInitialized();
                return packageId;
            }
            protected set => packageId = value;
        }

        public virtual Approach Approach
        {
            get
            {
                ThrowIfNotInitialized();
                return approach;
            }
            protected set => approach = value;
        }

        public virtual ReadonlyTypeConfig[] Dependencies
        {
            get
            {
                ThrowIfNotInitialized();
                return dependencies;
            }
            protected set => dependencies = value;
        }

        protected DummyReadonlyTypeConfig(string guid)
        {
            Guid = guid;
        }

        protected void ThrowIfNotInitialized()
        {
            Initializer initializer = GetInitializer();
            if (initializer.IsInitialized)
            {
                return;
            }

            const string message = "Object is not initialized. The only method you can call is GetInitializer()";
            throw new InvalidOperationException(message);
        }

        public virtual void ResolveDependencies(DependenciesResolver resolver)
        {
            ThrowIfNotInitialized();
            ThrowIfDependenciesResolved();
        }

        private void ThrowIfDependenciesResolved()
        {
            if (dependencies.Is())
            {
                const string message = "Dependencies already resolved";
                throw new InvalidOperationException(message);
            }
        }

        public abstract Initializer GetInitializer();
    }
}