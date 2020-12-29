namespace System.Reflection
{
	public static class MethodInfoEx
	{
		public static bool IsParameterless(this MethodInfo methodInfo)
		{
			return methodInfo.GetParameters().Length == 0;
		}
	}
}
