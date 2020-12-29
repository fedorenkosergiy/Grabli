namespace UnityEngine
{
	using static Mathf;

	public struct MathfEx
	{
		public static float GetFractionPart(float value)
		{
			return value - FloorToInt(value);
		}

		public static float MaxAbs(float a, float b)
		{
			return Max(Abs(a), Abs(b));
		}
	}
}
