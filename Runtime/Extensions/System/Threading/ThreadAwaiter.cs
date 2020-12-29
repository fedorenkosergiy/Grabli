using System.Runtime.CompilerServices;

namespace System.Threading
{
	public class ThreadAwaiter : INotifyCompletion
	{
		private Thread thread;
		private Action callback;
		private bool used;

		public bool IsCompleted => TryCallCallback();
		
		public ThreadAwaiter(Thread thread)
		{
			this.thread = thread;
			if (thread.ThreadState.IsNotRunning())
			{
				thread.Start();
			}
		}

		private bool TryCallCallback()
		{
			if (used)
			{
				return false;
			}
			if (thread.ThreadState.IsStopped())
			{
				used = true;
				callback();
			}
			return true;
		}

		public void GetResult() { }
		public void OnCompleted(Action continuation) => callback = continuation;
	}
}
