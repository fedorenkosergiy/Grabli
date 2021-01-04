using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public interface AssetBundleAwaiter : INotifyCompletion
	{
		bool IsCompleted { get; }
		AssetBundle GetResult();
	}
}
