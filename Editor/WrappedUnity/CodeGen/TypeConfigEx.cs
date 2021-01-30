using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public static class ReadonlyTypeConfigEx
    {
        public static bool IsPackageDependent(this TypeConfig config)
        {
            return config.PackageId.IsSmth();
        }

        public static TypeConfigRaw ToRaw(this TypeConfig config)
        {
            TypeConfigRaw typeConfigRaw = default;
            typeConfigRaw.FullTypeName = config.Type.FullName;
            typeConfigRaw.SpaceName = config.SpaceName;
            typeConfigRaw.InterfaceName = config.InterfaceName;
            typeConfigRaw.ClassName = config.ClassName;
            typeConfigRaw.UnityVersionSpecific = config.UnityVersionSpecific;
            typeConfigRaw.PackageId = config.PackageId;
            typeConfigRaw.Approach = config.Approach;
            typeConfigRaw.DependencyGuids = config.GenerateDependencies();
            return typeConfigRaw;
        }

        public static string[] GenerateDependencies(this TypeConfig config)
        {
            if (!config.IsDependenciesResolved())
            {
                const string message = "Dependencies are not resolved";
                throw new ArgumentException(message, nameof(config));
            }

            TypeConfig[] dependencies = config.Dependencies;
            string[] result = new string[dependencies.Length];
            for (int i = 0; i < dependencies.Length; ++i)
            {
                result[i] = dependencies[i].Guid;
            }

            return result;
        }

        public static bool IsDependenciesResolved(this TypeConfig config)
        {
            if (config is Initializable initable)
            {
                Initializer initializer = initable.GetInitializer();
                if (!initializer.IsInitialized)
                {
                    return false;
                }
            }

            return config.Dependencies.Is();
        }

        public static bool IsDependentOn(this TypeConfig config, TypeConfig dependency)
        {
            if (!config.IsDependenciesResolved())
            {
                const string message = "Dependencies are not resolved";
                throw new ArgumentException(message, nameof(config));
            }

            TypeConfig[] dependencies = config.Dependencies;

            for (int i = 0; i < dependencies.Length; ++i)
            {
                if (dependencies[i] == dependency)
                {
                    return true;
                }
            }

            return false;
        }
    }
}