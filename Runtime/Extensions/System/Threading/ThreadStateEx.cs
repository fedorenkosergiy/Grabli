using static System.Threading.ThreadState;

namespace System.Threading
{
	public static class ThreadStateEx
	{
		public static bool IsRunning(this ThreadState state) => state == Running;
		public static bool IsStopped(this ThreadState state) => state == Stopped;


		public static bool IsNotRunning(this ThreadState state) => !state.IsRunning();


		//Running = 0,
		//StopRequested = 1,
		//SuspendRequested = 2,
		//Background = 4,
		//Unstarted = 8,
		//Stopped = 16,
		//WaitSleepJoin = 32,
		//Suspended = 64,
		//AbortRequested = 128,
		//Aborted = 256
	}
}
