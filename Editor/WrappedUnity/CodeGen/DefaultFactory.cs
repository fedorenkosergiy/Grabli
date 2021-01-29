using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultFactory : Factory
    {
        private DependenciesResolver resolver;
        private TypeReader reader;

        public T CreateTypeConfigInitialized<T>(string guid) where T : TypeConfig, Initializable
        {
            T config = CreateTypeConfig<T>(guid);
            Initializer initializer = config.GetInitializer();
            initializer.Init();
            return config;
        }

        public virtual T CreateTypeConfig<T>(string guid) where T : TypeConfig
        {
            Type type = typeof(T);
            if (type == typeof(ReadonlyTypeConfig))
            {
                return (T) (ReadonlyTypeConfig) (new DefaultReadonlyTypeConfig(this, guid));
            }

            if (type == typeof(WritableTypeConfig))
            {
                return (T) (WritableTypeConfig) (new DefaultWritableTypeConfig(this, guid));
            }

            throw new InvalidOperationException($"Type {type.FullName} is not supported");
        }

        public virtual Initializer CreateInitializer(string filePath, ReadonlyTypeConfigsSetter setter)
        {
            return new RootTypesInitializer(this, filePath, setter);
        }

        public virtual Initializer CreateInitializer(string guid, TypeConfigRawSetter setter)
        {
            return new ReadonlyTypeConfigInitializer(this, guid, setter);
        }

        public virtual DependenciesResolver GetResolver()
        {
            return resolver ?? (resolver = new DefaultDependenciesResolver(this));
        }

        public TypeReader GetReader()
        {
            return reader ?? (reader = new DefaultTypeReader(this));
        }

        public Validator CreateTypeValidator(Type type)
        {
            return new SourceTypeValidator(type);
        }
    }
}