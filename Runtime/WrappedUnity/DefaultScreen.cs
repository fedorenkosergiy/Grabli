using System;
using UnityEngine;
using UScreen = UnityEngine.Screen;

namespace Grabli.WrappedUnity
{
	public class DefaultScreen : Screen
	{
		public FullScreenMode fullScreenMode
		{
			get => UScreen.fullScreenMode;
			set => UScreen.fullScreenMode = value;
		}

		public Resolution[] GetResolution => throw new NotImplementedException();

		public float brightness { get => UScreen.brightness; set => UScreen.brightness = value; }
		public int sleepTimeout { get => UScreen.sleepTimeout; set => UScreen.sleepTimeout = value; }
		public ScreenOrientation orientation { get => UScreen.orientation; set => UScreen.orientation = value; }
		public bool autorotateToLandscapeRight
		{
			get => UScreen.autorotateToLandscapeRight;
			set => UScreen.autorotateToLandscapeRight = value;
		}
		public bool autorotateToLandscapeLeft
		{
			get => UScreen.autorotateToLandscapeLeft;
			set => UScreen.autorotateToLandscapeLeft = value;
		}
		public bool autorotateToPortraitUpsideDown
		{
			get => UScreen.autorotateToPortraitUpsideDown;
			set => UScreen.autorotateToPortraitUpsideDown = value;
		}
		public bool autorotateToPortrait
		{
			get => UScreen.autorotateToPortrait;
			set => UScreen.autorotateToPortrait = value;
		}

		public Rect[] cutouts => UScreen.cutouts;

		public Rect safeArea => UScreen.safeArea;

#pragma warning disable CS0618 // Type or member is obsolete
		public bool lockCursor { get => UScreen.lockCursor; set => UScreen.lockCursor = value; }
#pragma warning restore CS0618 // Type or member is obsolete
		public bool fullScreen { get => UScreen.fullScreen; set => UScreen.fullScreen = value; }

		public Resolution[] resolutions => UScreen.resolutions;

		public Resolution currentResolution => UScreen.currentResolution;

		public float dpi => UScreen.dpi;

		public int height => UScreen.height;

		public int width => UScreen.width;

		public bool showCursor
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public void SetResolution(int width, int height, bool fullscreen)
		{
			UScreen.SetResolution(width, height, fullscreen);
		}

		public void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate)
		{
			UScreen.SetResolution(width, height, fullscreen, preferredRefreshRate);
		}

		public void SetResolution(int width, int height, FullScreenMode fullscreenMode)
		{
			UScreen.SetResolution(width, height, fullscreenMode);
		}

		public void SetResolution(int width, int height, FullScreenMode fullscreenMode, int preferredRefreshRate)
		{
			UScreen.SetResolution(width, height, fullscreenMode, preferredRefreshRate);
		}
	}
}
