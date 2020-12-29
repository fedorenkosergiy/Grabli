using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public interface BoolAwaiter : INotifyCompletion
	{
		bool IsCompleted { get; }
		bool GetResult();
	}
}
