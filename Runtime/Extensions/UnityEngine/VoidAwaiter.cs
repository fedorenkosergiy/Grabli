using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public interface VoidAwaiter : INotifyCompletion
	{
		bool IsCompleted { get; }
		void GetResult();
	}
}