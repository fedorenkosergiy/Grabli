namespace UnityEngine
{
	public static partial class AsyncOperationEx
	{
		public static VoidAwaiter GetAwaiter(this AsyncOperation request)
		{
			return new AsyncOperationAwaiter(request);
		}
	}
}
