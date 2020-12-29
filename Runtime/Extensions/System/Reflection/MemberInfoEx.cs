namespace System.Reflection
{
	public static class MemberInfoEx
	{
		public static bool TryGetAttribute<T>(this MemberInfo member, out T result) where T : Attribute
		{
			result = member.GetCustomAttribute<T>();
			return result.Is();
		}
	}
}
