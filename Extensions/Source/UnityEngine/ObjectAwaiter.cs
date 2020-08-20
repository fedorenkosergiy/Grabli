using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public interface ObjectAwaiter : INotifyCompletion
	{
		bool IsCompleted { get; }
		Object GetResult();
	}
}
