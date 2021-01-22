namespace Grabli.WrappedUnity.CodeGen
{
    public class DefaultTypeReader : DummyTypeReader
    {
        private readonly Factory factory;

        public DefaultTypeReader(Factory factory)
        {
            this.factory = factory;
        }

        protected override ReadonlyTypeConfig DoRead(string guid)
        {
            ReadonlyTypeConfig config = factory.CreateTypeConfig<ReadonlyTypeConfig>(guid);
            Initializer initializer = config.GetInitializer();
            initializer.Init();
            return config;
        }
    }
}