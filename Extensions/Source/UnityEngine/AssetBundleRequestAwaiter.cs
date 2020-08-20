namespace UnityEngine
{
	internal class AssetBundleRequestAwaiter : AsyncOperationAwaiter<AssetBundleRequest, Object>, ObjectAwaiter
	{
		public AssetBundleRequestAwaiter(AssetBundleRequest request) : base(request) { }

		public override Object GetResult() => request.asset;
	}
}
