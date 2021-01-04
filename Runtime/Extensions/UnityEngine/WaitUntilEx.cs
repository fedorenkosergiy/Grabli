using System.Threading.Tasks;

namespace UnityEngine
{
	public static class WaitUntilEx
	{
		public static async Task RunAsync(this WaitUntil instruction)
		{
			while (instruction.keepWaiting)
			{
				await Task.Yield();
			}
		}
	}
}
