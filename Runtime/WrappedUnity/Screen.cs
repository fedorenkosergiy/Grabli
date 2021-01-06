using System;
using UnityEngine;

namespace Grabli.WrappedUnity
{
	public interface Screen
	{
		/// <summary>
		/// Set this property to one of the values in FullScreenMode to change the display mode of your application.
		/// </summary>
		FullScreenMode fullScreenMode { get; set; }

		[Obsolete("Property GetResolution has been deprecated. Use resolutions instead (UnityUpgradable) -> resolutions", true)]
		Resolution[] GetResolution { get; }

		/// <summary>
		/// The current brightness of the screen.
		/// </summary>
		float brightness { get; set; }

		/// <summary>
		/// A power saving setting, allowing the screen to dim some time after the last active user interaction.
		/// </summary>
		int sleepTimeout { get; set; }

		/// <summary>
		/// Specifies logical orientation of the screen.
		/// </summary>
		ScreenOrientation orientation { get; set; }

		/// <summary>
		/// Allow auto-rotation to landscape right?
		/// </summary>
		bool autorotateToLandscapeRight { get; set; }

		/// <summary>
		/// Allow auto-rotation to landscape left?
		/// </summary>
		bool autorotateToLandscapeLeft { get; set; }

		/// <summary>
		/// Allow auto-rotation to portrait, upside down?
		/// </summary>
		bool autorotateToPortraitUpsideDown { get; set; }

		/// <summary>
		/// Allow auto-rotation to portrait?
		/// </summary>
		bool autorotateToPortrait { get; set; }

		/// <summary>
		/// Returns a list of screen areas that are not functional for displaying content (Read Only).
		/// </summary>
		Rect[] cutouts { get; }

		/// <summary>
		/// Returns the safe area of the screen in pixels (Read Only).
		/// </summary>
		Rect safeArea { get; }

		/// <summary>
		/// Should the cursor be locked?
		/// </summary>
		[Obsolete("Use Cursor.lockState and Cursor.visible instead.", false)]
		bool lockCursor { get; set; }

		/// <summary>
		/// Is the game running full-screen?
		/// </summary>
		bool fullScreen { get; set; }

		/// <summary>
		/// All full-screen resolutions supported by the monitor (Read Only).
		/// </summary>
		Resolution[] resolutions { get; }

		/// <summary>
		/// The current screen resolution (Read Only).
		/// </summary>
		Resolution currentResolution { get; }

		/// <summary>
		/// The current DPI of the screen / device (Read Only).
		/// </summary>
		float dpi { get; }

		/// <summary>
		/// The current height of the screen window in pixels (Read Only).
		/// </summary>
		int height { get; }

		/// <summary>
		/// The current width of the screen window in pixels (Read Only).
		/// </summary>
		int width { get; }

		/// <summary>
		///  Should the cursor be visible?
		/// </summary>
		[Obsolete("Property showCursor has been deprecated. Use Cursor.visible instead (UnityUpgradable) -> UnityEngine.Cursor.visible", true)]
		bool showCursor { get; set; }
		
		/// <summary>
		/// Switches the screen resolution.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="fullscreen"></param>
		void SetResolution(int width, int height, bool fullscreen);

		/// <summary>
		/// Switches the screen resolution.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="fullscreen"></param>
		/// <param name="preferredRefreshRate"></param>
		void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate);

		/// <summary>
		/// Switches the screen resolution.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="fullscreenMode"></param>
		void SetResolution(int width, int height, FullScreenMode fullscreenMode);

		/// <summary>
		/// Switches the screen resolution.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="fullscreenMode"></param>
		/// <param name="preferredRefreshRate"></param>
		void SetResolution(int width, int height, FullScreenMode fullscreenMode, int preferredRefreshRate);
	}
}
