using Grabli.WrappedUnity;
using NUnit.Framework;
using System.Threading.Tasks;
using Moq;

namespace Grabli.Utils
{
	public partial class WaitUtilTest
	{
		[TestCase(0, 1)]
		[TestCase(100, 101)]
		[TestCase(28, 29)]
		[TestCase(int.MaxValue-1, int.MaxValue)]
		public void CheckIfSkipFrameWorksWell(int currentFrame, int nextFrame)
		{
			Time fakeTime = GetTimeThatIncreaseFrameNumberEachTenRequests(currentFrame);
			using (TimeContext context = new TimeContext(fakeTime))
			{
				Task.Run(async () =>
				{
					await WaitUtil.SkipFrame();
				}).GetAwaiter().GetResult();
				Assert.AreEqual(TimeContext.Time.frameCount, nextFrame);
			}
		}

		private Time GetTimeThatIncreaseFrameNumberEachTenRequests(int startFrame)
		{
			Mock<Time> time = new Mock<Time>();
			int? currentFrame = startFrame;
			int? nextFrameTrashold = 10;
			int? requestNumber = 1;
			time.Setup(t => t.frameCount).Returns(() =>
			{
				int number = requestNumber.Value;
				requestNumber++;
				if (number % nextFrameTrashold == 0)
				{
					currentFrame++;
				}
				return currentFrame.Value;
			});
			return time.Object;
		}
	}
}
