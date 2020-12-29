using static Grabli.Utils.WordType;

namespace Grabli.Utils
{
	public static class WordTypeEx
	{
		public static bool HasReal(this WordType type)
		{
			return (type & Real) == Real;
		}

		public static bool HasNumber(this WordType type)
		{
			return (type & Number) == Number;
		}
	}
}
