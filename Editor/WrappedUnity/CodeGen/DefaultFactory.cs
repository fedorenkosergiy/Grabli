using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultFactory : Factory
	{
		private DependenciesResolver resolver;
		private TypeReader reader;

		public T CreateTypeConfig<T>(TypeConfigRaw raw, string guid) where T : ReadonlyTypeConfig
		{
			Type type = typeof(T);
			if (type == typeof(ReadonlyTypeConfig)) return (T)(ReadonlyTypeConfig)(new DefaultReadonlyTypeConfig(guid));
			if (type == typeof(TypeConfig)) return (T)(TypeConfig)(new DefaultTypeConfig(guid));
			throw new InvalidOperationException($"Type {type.FullName} is not supported");
		}

		public Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter)
		{
			return new RootTypesInitializer(this, filePath, setter);
		}

		public DependenciesResolver GetResolver()
		{
			return resolver ?? (resolver = new DefaultDependencyResolver(this));
		}

		public TypeReader GetReader()
		{
			return reader ?? (reader = new DefaultTypeReader(this));
		}
	}
}
