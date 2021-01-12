namespace Grabli.WrappedUnity.CodeGen
{
	public static class ReadonlyTypeHandlingConfigEx
	{
		public static bool IsPackageDependent(this ReadonlyTypeHandlingConfig config)
		{
			return config.PackageId.IsSmth();
		}
	}
}
