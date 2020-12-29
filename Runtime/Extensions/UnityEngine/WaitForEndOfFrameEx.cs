namespace UnityEngine
{
	public static class WaitForEndOfFrameEx
	{
		public static VoidAwaiter GetAwaiter(this WaitForEndOfFrame instruction)
		{
			return new WaitForEndOfFrameAwaiter(instruction);
		}
	}
}