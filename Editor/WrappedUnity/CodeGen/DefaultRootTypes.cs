namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultRootTypes : RootTypes
	{
		private Factory factory;
		private string filePath;
		private Initializer initializer;

		public ReadonlyTypeConfig[] Configs { get; private set; }

		public DefaultRootTypes(Factory factory, string filePath)
		{
			this.factory = factory;
			this.filePath = filePath;
		}

		public Initializer GetInitializer()
		{
			return initializer ?? (initializer = factory.CreateInitializer(filePath, SetConfigs));
		}

		private void SetConfigs(ReadonlyTypeConfig[] configs) => Configs = configs;
	}
}
