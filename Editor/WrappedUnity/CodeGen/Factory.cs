namespace Grabli.WrappedUnity.CodeGen
{
	public interface Factory
	{
		T CreateTypeConfig<T>(TypeConfigRaw raw, string guid) where T : ReadonlyTypeConfig;
		Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter);
		DependenciesResolver GetResolver();
		TypeReader GetReader();
	}
}
