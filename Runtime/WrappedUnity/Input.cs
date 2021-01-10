using System;

namespace Grabli.WrappedUnity
{
	public interface Input
	{
		/// <summary>
		///   <para>Returns the value of the virtual axis identified by axisName.</para>
		/// </summary>
		/// <param name="axisName"></param>
		float GetAxis(string axisName);

		/// <summary>
		///   <para>Returns the value of the virtual axis identified by axisName with no smoothing filtering applied.</para>
		/// </summary>
		/// <param name="axisName"></param>
		float GetAxisRaw(string axisName);

		/// <summary>
		///   <para>Returns true while the virtual button identified by buttonName is held down.</para>
		/// </summary>
		/// <param name="buttonName">The name of the button such as Jump.</param>
		/// <returns>
		///   <para>True when an axis has been pressed and not released.</para>
		/// </returns>
		bool GetButton(string buttonName);

		/// <summary>
		///   <para>Returns true during the frame the user pressed down the virtual button identified by buttonName.</para>
		/// </summary>
		/// <param name="buttonName"></param>
		bool GetButtonDown(string buttonName);

		/// <summary>
		///   <para>Returns true the first frame the user releases the virtual button identified by buttonName.</para>
		/// </summary>
		/// <param name="buttonName"></param>
		bool GetButtonUp(string buttonName);

		/// <summary>
		///   <para>Returns whether the given mouse button is held down.</para>
		/// </summary>
		/// <param name="button"></param>
		bool GetMouseButton(int button);

		/// <summary>
		///   <para>Returns true during the frame the user pressed the given mouse button.</para>
		/// </summary>
		/// <param name="button"></param>
		bool GetMouseButtonDown(int button);

		/// <summary>
		///   <para>Returns true during the frame the user releases the given mouse button.</para>
		/// </summary>
		/// <param name="button"></param>
		bool GetMouseButtonUp(int button);

		/// <summary>
		///   <para>Resets all input. After ResetInputAxes all axes return to 0 and all buttons return to 0 for one frame.</para>
		/// </summary>
		void ResetInputAxes();
#if UNITY_LINUX
		/// <summary>
		///   <para>Determine whether a particular joystick model has been preconfigured by Unity. (Linux-only).</para>
		/// </summary>
		/// <param name="joystickName">The name of the joystick to check (returned by Input.GetJoystickNames).</param>
		/// <returns>
		///   <para>True if the joystick layout has been preconfigured; false otherwise.</para>
		/// </returns>
		bool IsJoystickPreconfigured(string joystickName);
#endif

		/// <summary>
		///   <para>Returns an array of strings describing the connected joysticks.</para>
		/// </summary>
		string[] GetJoystickNames();

		/// <summary>
		///   <para>Call Input.GetTouch to obtain a Touch struct.</para>
		/// </summary>
		/// <param name="index">The touch input on the device screen.</param>
		/// <returns>
		///   <para>Touch details in the struct.</para>
		/// </returns>
		UnityEngine.Touch GetTouch(int index);

		/// <summary>
		///   <para>Returns specific acceleration measurement which occurred during last frame. (Does not allocate temporary variables).</para>
		/// </summary>
		/// <param name="index"></param>
		UnityEngine.AccelerationEvent GetAccelerationEvent(int index);

		/// <summary>
		///   <para>Returns true while the user holds down the key identified by the key KeyCode enum parameter.</para>
		/// </summary>
		/// <param name="key"></param>
		bool GetKey(UnityEngine.KeyCode key);

		/// <summary>
		///   <para>Returns true while the user holds down the key identified by name.</para>
		/// </summary>
		/// <param name="name"></param>
		bool GetKey(string name);

		/// <summary>
		///   <para>Returns true during the frame the user releases the key identified by the key KeyCode enum parameter.</para>
		/// </summary>
		/// <param name="key"></param>
		bool GetKeyUp(UnityEngine.KeyCode key);

		/// <summary>
		///   <para>Returns true during the frame the user releases the key identified by name.</para>
		/// </summary>
		/// <param name="name"></param>
		bool GetKeyUp(string name);

		/// <summary>
		///   <para>Returns true during the frame the user starts pressing down the key identified by the key KeyCode enum parameter.</para>
		/// </summary>
		/// <param name="key"></param>
		bool GetKeyDown(UnityEngine.KeyCode key);

		/// <summary>
		///   <para>Returns true during the frame the user starts pressing down the key identified by name.</para>
		/// </summary>
		/// <param name="name"></param>
		bool GetKeyDown(string name);

		/// <summary>
		///   <para>Enables/Disables mouse simulation with touches. By default this option is enabled.</para>
		/// </summary>
		bool simulateMouseWithTouches { get; set; }

		/// <summary>
		///   <para>Is any key or mouse button currently held down? (Read Only)</para>
		/// </summary>
		bool anyKey { get; }

		/// <summary>
		///   <para>Returns true the first frame the user hits any key or mouse button. (Read Only)</para>
		/// </summary>
		bool anyKeyDown { get; }

		/// <summary>
		///   <para>Returns the keyboard input entered this frame. (Read Only)</para>
		/// </summary>
		string inputString { get; }

		/// <summary>
		///   <para>The current mouse position in pixel coordinates. (Read Only)</para>
		/// </summary>
		UnityEngine.Vector3 mousePosition { get; }

		/// <summary>
		///   <para>The current mouse scroll delta. (Read Only)</para>
		/// </summary>
		UnityEngine.Vector2 mouseScrollDelta { get; }

		/// <summary>
		///   <para>Controls enabling and disabling of IME input composition.</para>
		/// </summary>
		UnityEngine.IMECompositionMode imeCompositionMode { get; set; }

		/// <summary>
		///   <para>The current IME composition string being typed by the user.</para>
		/// </summary>
		string compositionString { get; }

		/// <summary>
		///   <para>Does the user have an IME keyboard input source selected?</para>
		/// </summary>
		bool imeIsSelected { get; }

		/// <summary>
		///   <para>The current text input position used by IMEs to open windows.</para>
		/// </summary>
		UnityEngine.Vector2 compositionCursorPos { get; set; }

		/// <summary>
		///   <para>Property indicating whether keypresses are eaten by a textinput if it has focus (default true).</para>
		/// </summary>
		[Obsolete("eatKeyPressOnTextFieldFocus property is deprecated, and only provided to support legacy behavior.")]
		bool eatKeyPressOnTextFieldFocus { get; set; }

		/// <summary>
		///   <para>Indicates if a mouse device is detected.</para>
		/// </summary>
		bool mousePresent { get; }

		/// <summary>
		///   <para>Number of touches. Guaranteed not to change throughout the frame. (Read Only)</para>
		/// </summary>
		int touchCount { get; }

		/// <summary>
		///   <para>Bool value which let's users check if touch pressure is supported.</para>
		/// </summary>
		bool touchPressureSupported { get; }

		/// <summary>
		///   <para>Returns true when Stylus Touch is supported by a device or platform.</para>
		/// </summary>
		bool stylusTouchSupported { get; }

		/// <summary>
		///   <para>Returns whether the device on which application is currently running supports touch input.</para>
		/// </summary>
		bool touchSupported { get; }

		/// <summary>
		///   <para>Property indicating whether the system handles multiple touches.</para>
		/// </summary>
		bool multiTouchEnabled { get; set; }

		[Obsolete("isGyroAvailable property is deprecated. Please use SystemInfo.supportsGyroscope instead.")]
		bool isGyroAvailable { get; }

		/// <summary>
		///   <para>Device physical orientation as reported by OS. (Read Only)</para>
		/// </summary>
		UnityEngine.DeviceOrientation deviceOrientation { get; }

		/// <summary>
		///   <para>Last measured linear acceleration of a device in three-dimensional space. (Read Only)</para>
		/// </summary>
		UnityEngine.Vector3 acceleration { get; }

		/// <summary>
		///   <para>This property controls if input sensors should be compensated for screen orientation.</para>
		/// </summary>
		bool compensateSensors { get; set; }

		/// <summary>
		///   <para>Number of acceleration measurements which occurred during last frame.</para>
		/// </summary>
		int accelerationEventCount { get; }

		/// <summary>
		///         <para>Should  Back button quit the application?
		/// 
		/// Only usable on Android, Windows Phone or Windows Tablets.</para>
		///       </summary>
		bool backButtonLeavesApp { get; set; }

		/// <summary>
		///   <para>Property for accessing device location (handheld devices only). (Read Only)</para>
		/// </summary>
		LocationService location { get; }

		/// <summary>
		///   <para>Property for accessing compass (handheld devices only). (Read Only)</para>
		/// </summary>
		Compass compass { get; }

		/// <summary>
		///   <para>Returns default gyroscope.</para>
		/// </summary>
		Gyroscope gyro { get; }

		/// <summary>
		///   <para>Returns list of objects representing status of all touches during last frame. (Read Only) (Allocates temporary variables).</para>
		/// </summary>
		UnityEngine.Touch[] touches { get; }

		/// <summary>
		///   <para>Returns list of acceleration measurements which occurred during the last frame. (Read Only) (Allocates temporary variables).</para>
		/// </summary>
		UnityEngine.AccelerationEvent[] accelerationEvents { get; }
	}
}
