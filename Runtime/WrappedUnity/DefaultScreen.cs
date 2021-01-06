using System;
using UnityEngine;

namespace Grabli.WrappedUnity
{
	public class DefaultScreen : Screen
	{
		public FullScreenMode fullScreenMode
		{
			get => UnityEngine.Screen.fullScreenMode;
			set => UnityEngine.Screen.fullScreenMode = value;
		}

		public Resolution[] GetResolution => throw new NotImplementedException();

		public float brightness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int sleepTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ScreenOrientation orientation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool autorotateToLandscapeRight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool autorotateToLandscapeLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool autorotateToPortraitUpsideDown { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool autorotateToPortrait { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Rect[] cutouts => throw new NotImplementedException();

		public Rect safeArea => throw new NotImplementedException();

		public bool lockCursor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool fullScreen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Resolution[] resolutions => throw new NotImplementedException();

		public Resolution currentResolution => throw new NotImplementedException();

		public float dpi => throw new NotImplementedException();

		public int height => throw new NotImplementedException();

		public int width => throw new NotImplementedException();

		public bool showCursor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void SetResolution(int width, int height, bool fullscreen)
		{
			throw new NotImplementedException();
		}

		public void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate)
		{
			throw new NotImplementedException();
		}

		public void SetResolution(int width, int height, FullScreenMode fullscreenMode)
		{
			throw new NotImplementedException();
		}

		public void SetResolution(int width, int height, FullScreenMode fullscreenMode, int preferredRefreshRate)
		{
			throw new NotImplementedException();
		}
	}
}
