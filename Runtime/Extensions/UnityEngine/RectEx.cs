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

		public static Rect MoveRight(this Rect rect, float distance)
		{
			return new Rect(rect.x + distance, rect.y, rect.width, rect.height);
		}

		public static Rect MoveLeft(this Rect rect, float distance)
		{
			return new Rect(rect.x - distance, rect.y, rect.width, rect.height);
		}

		public static Rect MoveUp(this Rect rect, float distance)
		{
			return new Rect(rect.x, rect.y - distance, rect.width, rect.height);
		}

		public static Rect MoveDown(this Rect rect, float distance)
		{
			return new Rect(rect.x, rect.y + distance, rect.width, rect.height);
		}

		public static Rect Move(this Rect rect, Vector2 direction)
		{
			return new Rect(rect.position + direction, rect.size);
		}

		public static Rect GetLeftHalf(this Rect rect)
		{
			return new Rect(rect.x, rect.y, rect.width * 0.5f, rect.height);
		}

		public static Rect GetRightHalf(this Rect rect)
		{
			float width = rect.width * 0.5f;
			return new Rect(rect.x + width, rect.y, width, rect.height);
		}

		public static Rect GetInner(this Rect rect, float border)
		{
			return new Rect(
				rect.x + border,
				rect.y + border,
				rect.width - border - border,
				rect.height - border - border);
		}

		public static Rect GetRightPart(this Rect rect, float width)
		{
			if (width > 0.0f)
			{
				return new Rect(
					rect.xMax - width,
					rect.y,
					width,
					rect.height);
			}
			else if (width < 0.0f)
			{
				return new Rect(
					rect.x - width,
					rect.y,
					rect.width + width,
					rect.height);
			}
			throw new ArgumentException("Width can not be 0.0f", nameof(width));
		}

		public static Rect GetLeftPart(this Rect rect, float width)
		{
			if (width > 0.0f)
			{
				return new Rect(
					rect.x,
					rect.y,
					width,
					rect.height);
			}
			else if (width < 0.0f)
			{
				return new Rect(
					rect.x,
					rect.y,
					rect.width + width,
					rect.height);
			}
			throw new ArgumentException("Width can not be 0.0f", nameof(width));
		}
	}
}
