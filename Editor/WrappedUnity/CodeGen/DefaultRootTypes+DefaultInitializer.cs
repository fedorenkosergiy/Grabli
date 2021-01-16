namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultRootTypes
	{
		private class DefaultInitializer : Initializer
		{
			private DefaultRootTypes host;

			public bool IsInitialized { get; }

			public DefaultInitializer(DefaultRootTypes host)
			{
				this.host = host;
			}

			public void Init()
			{
				string text = FileContext.Instance.ReadAllText(host.filePath);

				throw new System.NotImplementedException();
			}

			public void Deinit()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
