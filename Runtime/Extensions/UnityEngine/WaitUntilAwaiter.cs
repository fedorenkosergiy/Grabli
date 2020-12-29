namespace UnityEngine
{
	internal class WaitUntilAwaiter : CustomYieldInstructionAwaiter<WaitUntil>
	{
		public WaitUntilAwaiter(WaitUntil instruction) : base(instruction)
		{
		}
	}
}
