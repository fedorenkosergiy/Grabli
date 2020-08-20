namespace UnityEngine
{
	internal class WaitForEndOfFrameAwaiter : YieldInstructionAwaiter<WaitForEndOfFrame>
	{
		private int frameNumber;

		public WaitForEndOfFrameAwaiter(WaitForEndOfFrame instruction) : base(instruction)
		{
			frameNumber = Time.frameCount;
		}

		protected override bool CheckIfCompleted() => frameNumber != Time.frameCount;
	}
}