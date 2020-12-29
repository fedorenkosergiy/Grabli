namespace UnityEngine
{
	internal class AssetBundleCreateRequestAwaiter : AsyncOperationAwaiter<AssetBundleCreateRequest, AssetBundle>, AssetBundleAwaiter
	{
		public AssetBundleCreateRequestAwaiter(AssetBundleCreateRequest request) : base(request) { }

		public override AssetBundle GetResult() => request.assetBundle;
	}
}
