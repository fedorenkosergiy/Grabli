namespace UnityEngine
{
	public static partial class AssetBundleRequestEx
	{
		public static ObjectAwaiter GetAwaiter(this AssetBundleRequest request)
		{
			return new AssetBundleRequestAwaiter(request);
		}
	}
}
