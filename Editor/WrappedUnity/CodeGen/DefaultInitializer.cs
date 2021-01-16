using System;
using UnityEngine;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultInitializer : EmptyInitializer
	{
		private Factory factory;
		private string filePath;
		private ReadonlyTypeConfigsSetter setter;

		public DefaultInitializer(Factory factory, string filePath, ReadonlyTypeConfigsSetter setter)
		{
			this.factory = factory;
			this.filePath = filePath;
			this.setter = setter;
		}

		protected override void RunInitActions()
		{
			base.RunInitActions();
			RootTypesRaw types = ReadTypesFromFile();
			ReadonlyTypeConfig[] configs = CreateConfigs(types);
			setter.Invoke(configs);
		}

		private RootTypesRaw ReadTypesFromFile()
		{
			string content = FileContext.Instance.ReadAllText(filePath);
			RootTypesRaw types = JsonUtility.FromJson<RootTypesRaw>(content);
			return types;
		}

		private ReadonlyTypeConfig[] CreateConfigs(RootTypesRaw types)
		{
			int count = types.Guids.Length;
			ReadonlyTypeConfig[] configs = new ReadonlyTypeConfig[count];
			for (int i = 0; i < count; ++i)
			{
				string path = AssetDatabaseContext.Instance.GUIDToAssetPath(types.Guids[i]);
				string content = FileContext.Instance.ReadAllText(path);
				TypeConfigRaw type = JsonUtility.FromJson<TypeConfigRaw>(content);
				ReadonlyTypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(type);
				configs[i] = config;
			}

			return configs;
		}

		protected override void RunDeinitActions()
		{
			base.RunDeinitActions();
			setter.Invoke(null);
		}
	}
}
