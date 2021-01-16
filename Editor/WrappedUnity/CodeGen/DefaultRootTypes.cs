namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultRootTypes : RootTypes
	{
		private string filePath;
		private Initializer initializer;

		public ReadonlyTypeConfig[] Configs { get; }

		public DefaultRootTypes(string filePath)
		{
			this.filePath = filePath;
		}

		public Initializer GetInitializer() => initializer ?? (initializer = new DefaultInitializer(this));
	}
}
