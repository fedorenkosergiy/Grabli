using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public abstract class DummyReadonlyTypeConfig : DefaultTypeConfig, ReadonlyTypeConfig
    {
        public override Type Type
        {
            get
            {
                ThrowIfNotInitialized();
                return base.Type;
            }
        }

        public override string Namespace
        {
            get
            {
                ThrowIfNotInitialized();
                return base.Namespace;
            }
        }

        public override string InterfaceName
        {
            get
            {
                ThrowIfNotInitialized();
                return base.InterfaceName;
            }
        }

        public override string ClassName
        {
            get
            {
                ThrowIfNotInitialized();
                return base.ClassName;
            }
        }

        public override bool UnityVersionSpecific
        {
            get
            {
                ThrowIfNotInitialized();
                return base.UnityVersionSpecific;
            }
        }

        public override string PackageId
        {
            get
            {
                ThrowIfNotInitialized();
                return base.PackageId;
            }
        }

        public override Approach Approach
        {
            get
            {
                ThrowIfNotInitialized();
                return base.Approach;
            }
        }

        public override ReadonlyTypeConfig[] Dependencies
        {
            get
            {
                ThrowIfNotInitialized();
                return base.Dependencies;
            }
        }

        protected DummyReadonlyTypeConfig(string guid) : base(guid) { }

        private void ThrowIfNotInitialized()
        {
            Initializer initializer = GetInitializer();
            if (initializer.IsInitialized)
            {
                return;
            }

            const string message = "Object is not initialized. The only method you can call is GetInitializer()";
            throw new InvalidOperationException(message);
        }

        public override void ResolveDependencies(DependenciesResolver resolver)
        {
            ThrowIfNotInitialized();
            ThrowIfDependenciesResolved();
        }

        private void ThrowIfDependenciesResolved()
        {
            if (Dependencies.Is())
            {
                const string message = "Dependencies already resolved";
                throw new InvalidOperationException(message);
            }
        }

        public abstract Initializer GetInitializer();
    }
}