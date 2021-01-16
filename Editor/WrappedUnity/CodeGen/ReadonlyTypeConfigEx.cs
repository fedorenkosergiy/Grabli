namespace Grabli.WrappedUnity.CodeGen
{
	public static class ReadonlyTypeConfigEx
	{
		public static bool IsPackageDependent(this ReadonlyTypeConfig config)
		{
			return config.PackageId.IsSmth();
		}

		public static TypeConfigRaw ToRaw(this ReadonlyTypeConfig config)
		{
			TypeConfigRaw typeConfigRaw = default;
			typeConfigRaw.FullTypeName = config.Type.FullName;
			typeConfigRaw.Namespace = config.Namespace;
			typeConfigRaw.InterfaceName = config.InterfaceName;
			typeConfigRaw.ClassName = config.ClassName;
			typeConfigRaw.UnityVersionSpecific = config.UnityVersionSpecific;
			typeConfigRaw.PackageId = config.PackageId;
			typeConfigRaw.Approach = config.Approach;
			typeConfigRaw.DependencyGuids = GenerateDependencies(config.Dependencies);
			return typeConfigRaw;
		}

		private static string[] GenerateDependencies(ReadonlyTypeConfig[] dependencies)
		{
			string[] result = new string[dependencies.Length];
			for (int i = 0; i < dependencies.Length; ++i)
			{
				result[i] = dependencies[i].Guid.ToString("N");
			}
			return result;
		}
	}
}
