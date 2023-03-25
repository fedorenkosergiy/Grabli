using System.Text;

namespace Grabli.Pools
{
	internal static class StringBuilderPool
	{
		public static StringBuilder Get() => FastPool<StringBuilder>.Get();

		public static void Release(StringBuilder value)
		{
			value.Clear();
			FastPool<StringBuilder>.Release(value);
		}

		public static string GetValueAndRelease(StringBuilder value)
		{
			string result = value.ToString();
			value.Clear();
			FastPool<StringBuilder>.Release(value);
			return result;
		}
	}
}
