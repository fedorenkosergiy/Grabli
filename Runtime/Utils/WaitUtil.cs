using System.Threading.Tasks;
using UnityEngine;
namespace Grabli.Utils
{
	public static class WaitUtil
	{
		public static async Task SkipFrame() => await SkipFrames(numberOfFramesToSkip: 1U);

		public static async Task SkipFrames(uint numberOfFramesToSkip)
		{
			int frameNumber = Time.frameCount;
			while (Time.frameCount - frameNumber < numberOfFramesToSkip)
			{
				await Task.Yield();
			}
		}
	}
}
