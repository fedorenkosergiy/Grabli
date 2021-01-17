namespace Grabli.WrappedUnity.CodeGen
{
	public interface Factory
	{
		T CreateTypeConfig<T>(TypeConfigRaw raw) where T : ReadonlyTypeConfig;
		Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter);
		DependenciesResolver GetResolver();
		TypesReader GetReader();
	}
}
