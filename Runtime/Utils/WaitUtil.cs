using System.Threading.Tasks;
namespace Grabli.Utils
{
	public static class WaitUtil
	{
		public static async Task SkipFrame() => await SkipFrames(numberOfFramesToSkip: 1U);

		public static async Task SkipFrames(uint numberOfFramesToSkip)
		{
			int frameNumber = MoqunityApi.Static.Time.frameCount;
			while (MoqunityApi.Static.Time.frameCount - frameNumber < numberOfFramesToSkip)
			{
				await Task.Yield();
			}
		}
	}
}
