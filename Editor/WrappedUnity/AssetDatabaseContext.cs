namespace Grabli.WrappedUnity
{
	public class AssetDatabaseContext : Context<AssetDatabaseContext, DefaultAssetDatabase, AssetDatabase>
	{
        protected override bool MoveEventInvocationLists => false;
        
		public AssetDatabaseContext(AssetDatabase assetDatabase) : base(assetDatabase)
		{
		}

		public AssetDatabaseContext()
		{
		}
	}
}
