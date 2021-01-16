namespace Grabli.WrappedUnity
{
	public class AssetDatabaseContext : Context<AssetDatabaseContext, DefaultAssetDatabase, AssetDatabase>
	{
		public AssetDatabaseContext(AssetDatabase assetDatabase) : base(assetDatabase)
		{
		}

		public AssetDatabaseContext()
		{
		}
	}
}
