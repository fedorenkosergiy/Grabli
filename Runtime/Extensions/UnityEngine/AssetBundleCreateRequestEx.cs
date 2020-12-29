namespace UnityEngine
{
	public static class AssetBundleCreateRequestEx
	{
		public static AssetBundleAwaiter GetAwaiter(this AssetBundleCreateRequest request)
		{
			return new AssetBundleCreateRequestAwaiter(request);
		}
	}
}