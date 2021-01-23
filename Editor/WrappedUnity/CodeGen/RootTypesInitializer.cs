using UnityEngine;

namespace Grabli.WrappedUnity.CodeGen
{
    public class RootTypesInitializer : EmptyInitializer
    {
        private Factory factory;
        private string filePath;
        private ReadonlyTypeConfigsSetter setter;

        public RootTypesInitializer(Factory factory, string filePath, ReadonlyTypeConfigsSetter setter)
        {
            this.factory = factory;
            this.filePath = filePath;
            this.setter = setter;
        }

        protected override void RunInitActions()
        {
            RootTypesRaw types = ReadTypesFromFile();
            ReadonlyTypeConfig[] configs = CreateConfigs(types);
            setter.Invoke(configs);
        }

        private RootTypesRaw ReadTypesFromFile()
        {
            string content = FileContext.Instance.ReadAllText(filePath);
            RootTypesRaw types = JsonUtility.FromJson<RootTypesRaw>(content);
            return types;
        }

        private ReadonlyTypeConfig[] CreateConfigs(RootTypesRaw types)
        {
            int count = types.Guids.Length;
            ReadonlyTypeConfig[] configs = new ReadonlyTypeConfig[count];
            TypeReader reader = factory.GetReader();
            for (int i = 0; i < count; ++i)
            {
                ReadonlyTypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(types.Guids[i]);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                configs[i] = config;
            }

            return configs;
        }

        protected override void RunDeinitActions() => setter.Invoke(null);
    }
}