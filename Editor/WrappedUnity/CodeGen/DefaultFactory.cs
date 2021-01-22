using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultFactory : Factory
	{
		private DependenciesResolver resolver;
		private TypeReader reader;

		public T CreateTypeConfig<T>(string guid) where T : ReadonlyTypeConfig
		{
			Type type = typeof(T);
			if (type == typeof(ReadonlyTypeConfig))
            {
                return (T)(ReadonlyTypeConfig)(new DefaultReadonlyTypeConfig(guid));
            }

            if (type == typeof(TypeConfig))
            {
                return (T)(TypeConfig)(new DefaultTypeConfig(guid));
            }

            throw new InvalidOperationException($"Type {type.FullName} is not supported");
		}

		public Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter)
		{
			return new RootTypesInitializer(this, filePath, setter);
		}

        public Initializer CreateInitializer(string guid, TypeConfigRawSetter setter)
        {
            throw new NotImplementedException();
        }

        public DependenciesResolver GetResolver()
		{
			return resolver ?? (resolver = new DefaultDependenciesResolver(this));
		}

		public TypeReader GetReader()
		{
			return reader ?? (reader = new DefaultTypeReader(this));
		}
	}
}
