namespace UnityEngine
{
	public static class WaitUntilEx
	{
		public static VoidAwaiter GetAwaiter(this WaitUntil instruction)
		{
			return new WaitUntilAwaiter(instruction);
		}
	}
}
