namespace Grabli.WrappedUnity.CodeGen
{
	public interface Factory
	{
        T CreateTypeConfigInitialized<T>(string guid) where T : TypeConfig, Initializable;
		T CreateTypeConfig<T>(string guid) where T : TypeConfig;
		Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter);
        Initializer CreateInitializer(string guid, TypeConfigRawSetter setter);
		DependenciesResolver GetResolver();
		TypeReader GetReader();
	}
}
