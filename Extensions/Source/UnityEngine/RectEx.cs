using System;
namespace UnityEngine
{
	public static class RectEx
	{
		private const int CORNERS_COUNT = 4;

		public static Rect ChangeHeight(this Rect rect, float height)
		{
			Rect result = new Rect(rect);
			result.height = height;
			return result;
		}

		public static Rect? OverlapShape(this Rect rect, Rect target)
		{
			if (!rect.Overlaps(target))
			{
				return null;
			}
			Vector2[] result = target.GetVerticies();
			for (int i = 0; i < CORNERS_COUNT; i += 2)
			{
				if (!rect.Contains(result[i]))
				{
					float x = Mathf.Clamp(result[i].x, rect.xMin, rect.xMax);
					float y = Mathf.Clamp(result[i].y, rect.yMin, rect.yMax);
					result[i] = new Vector2(x, y);
				}
			}
			return new Rect(result[0], result[2] - result[0]);
		}

		public static bool Contains(this Rect rect, Rect target)
		{
			Vector2[] targetVerticies = target.GetVerticies();
			for (int i = 0; i < CORNERS_COUNT; ++i)
			{
				if (!rect.Contains(targetVerticies[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static Vector2[] GetVerticies(this Rect rect)
		{
			Vector2[] result = new Vector2[CORNERS_COUNT];
			result[0] = rect.position;
			result[1] = new Vector2(rect.xMin, rect.yMax);
			result[2] = new Vector2(rect.xMax, rect.yMax);
			result[3] = new Vector2(rect.xMax, rect.yMin);
			return result;
		}

		public static Vector2 GetTopRightPosition(this Rect rect)
		{
			return new Vector2(rect.xMax, rect.yMin);
		}
	}
}
