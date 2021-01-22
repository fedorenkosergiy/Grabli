namespace Grabli.WrappedUnity.CodeGen
{
	public interface Factory
	{
		T CreateTypeConfig<T>(string guid) where T : ReadonlyTypeConfig;
		Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter);
        Initializer CreateInitializer(string guid, TypeConfigRawSetter setter);
		DependenciesResolver GetResolver();
		TypeReader GetReader();
	}
}
