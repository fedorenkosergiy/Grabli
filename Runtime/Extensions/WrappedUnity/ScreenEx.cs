using UnityEngine;

namespace Grabli.WrappedUnity
{
	public static class ScreenEx
	{
		public static Vector2Int GetSize(this Screen screen) => new Vector2Int(screen.width, screen.height);

		public static Vector2 GetPhysicalSize(this Screen screen)
		{
			Vector2 size = new Vector2(screen.width, screen.height);
			return size / screen.dpi;
		}
	}
}
