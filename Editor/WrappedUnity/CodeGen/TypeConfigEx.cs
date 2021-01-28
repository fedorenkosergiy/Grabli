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
            typeConfigRaw.Namespace = config.Namespace;
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

            string[] result = new string[config.Dependencies.Length];
            for (int i = 0; i < config.Dependencies.Length; ++i)
            {
                result[i] = config.Dependencies[i].Guid;
            }

            return result;
        }

        public static bool IsDependenciesResolved(this TypeConfig config)
        {
            if (config is Initializable initializable)
            {
                Initializer initializer = initializable.GetInitializer();
                if (!initializer.IsInitialized)
                {
                    return false;
                }
            }

            return config.Dependencies.Is();
        }
    }
}