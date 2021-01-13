namespace Grabli.WrappedUnity.CodeGen
{
	public static class ReadonlyTypeConfigEx
	{
		public static bool IsPackageDependent(this ReadonlyTypeConfig config)
		{
			return config.PackageId.IsSmth();
		}

		public static RawTypeConfig ToRaw(this ReadonlyTypeConfig config)
		{
			RawTypeConfig raw = default;
			raw.FullTypeName = config.Type.FullName;
			raw.Namespace = config.Namespace;
			raw.InterfaceName = config.InterfaceName;
			raw.ClassName = config.ClassName;
			raw.UnityVersionSpecific = config.UnityVersionSpecific;
			raw.PackageId = config.PackageId;
			raw.Approach = config.Approach;
			raw.Dependencies = GenerateDependencies(config.Dependencies);
			return raw;
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
