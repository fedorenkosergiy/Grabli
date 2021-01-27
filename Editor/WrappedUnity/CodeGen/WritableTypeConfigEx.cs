using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public static class WritableTypeConfigEx
    {
        public static bool TryRemoveDependency(this WritableTypeConfig config, Type type)
        {
            if (config.IsDependenciesResolved())
            {
                TypeConfig[] dependencies = config.Dependencies;
                for (int i = 0; i < dependencies.Length; ++i)
                {
                    if (dependencies[i].Type == type)
                    {
                        config.RemoveDependency(dependencies[i]);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}