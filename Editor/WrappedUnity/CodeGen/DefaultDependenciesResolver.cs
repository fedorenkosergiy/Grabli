using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultDependenciesResolver : DependenciesResolver
    {
        private readonly Factory factory;

        private readonly IDictionary<string, TypeConfig> readTypes = new Dictionary<string, TypeConfig>();

        public DefaultDependenciesResolver(Factory factory)
        {
            this.factory = factory;
        }

        public TypeConfig[] Resolve(string[] dependencyGuids)
        {
            if (dependencyGuids.IsNull())
            {
                throw new ArgumentNullException(nameof(dependencyGuids));
            }

            if (dependencyGuids.IsEmpty())
            {
                return Array.Empty<TypeConfig>();
            }

            TypeConfig[] configs = new TypeConfig[dependencyGuids.Length];
            for (int i = 0; i < dependencyGuids.Length; ++i)
            {
                if (!readTypes.TryGetValue(dependencyGuids[i], out TypeConfig config))
                {
                    config = factory.CreateTypeConfigInitialized<ReadonlyTypeConfig>(dependencyGuids[i]);
                    readTypes.Add(dependencyGuids[i], config);
                }

                configs[i] = config;
            }

            return configs;
        }
    }
}