namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultRootTypes
	{
		public Initializer GetInitializer()
		{
			throw new System.NotImplementedException();
		}

		private class DefaultInitializer : Initializer
		{
			public bool IsInitialized { get; }
			
			public void Init()
			{
				throw new System.NotImplementedException();
			}

			public void Deinit()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
