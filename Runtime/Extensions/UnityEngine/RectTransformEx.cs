using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine
{
	public static class RectTransformEx
	{
		private const int CORNERS_COUNT = 4;

		public static Rect GetWorldCornersRect(this RectTransform rect)
		{
			Vector3[] corners = new Vector3[CORNERS_COUNT];
			rect.GetWorldCorners(corners);
			return new Rect(corners[0], corners[2] - corners[0]);
		}
	}
}
