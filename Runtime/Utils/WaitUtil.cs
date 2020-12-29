using Grabli.WrappedUnity;
using System.Threading.Tasks;
namespace Grabli.Utils
{
	public static class WaitUtil
	{
		public static async Task SkipFrame() => await SkipFrames(numberOfFramesToSkip: 1U);

		public static async Task SkipFrames(uint numberOfFramesToSkip)
		{
			Time time = Cxt.Time;
			int frameNumber = time.frameCount;
			while (time.frameCount - frameNumber < numberOfFramesToSkip)
			{
				await Task.Yield();
			}
		}
	}
}
