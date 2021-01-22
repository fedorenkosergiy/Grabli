using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultDependenciesResolver : DependenciesResolver
	{
		private readonly Factory factory;
		private readonly IDictionary<string, ReadonlyTypeConfig> readTypes = new Dictionary<string, ReadonlyTypeConfig>();

		public DefaultDependenciesResolver(Factory factory)
		{
			this.factory = factory;
		}

		public ReadonlyTypeConfig[] Resolve(string[] dependencyGuids)
		{
			if (dependencyGuids.IsNull())
			{
				throw new ArgumentNullException(nameof(dependencyGuids));
			}

			ReadonlyTypeConfig[] configs = new ReadonlyTypeConfig[dependencyGuids.Length];
			TypeReader reader = factory.GetReader();
			for (int i = 0; i < dependencyGuids.Length; ++i)
			{
				if (!readTypes.TryGetValue(dependencyGuids[i], out ReadonlyTypeConfig config))
				{
					config = reader.Read(dependencyGuids[i]);
					readTypes.Add(dependencyGuids[i], config);
				}

				configs[i] = config;
			}

			return configs;
		}
	}
}
