using UnityEngine;

namespace Grabli.WrappedUnity
{
	public class DefaultInput : Input
	{
		public bool simulateMouseWithTouches
		{
			get => UnityEngine.Input.simulateMouseWithTouches;
			set => UnityEngine.Input.simulateMouseWithTouches = value;
		}

		public bool anyKey => UnityEngine.Input.anyKey;

		public bool anyKeyDown => UnityEngine.Input.anyKeyDown;

		public string inputString => UnityEngine.Input.inputString;

		public Vector3 mousePosition => UnityEngine.Input.mousePosition;

		public Vector2 mouseScrollDelta => UnityEngine.Input.mouseScrollDelta;

		public IMECompositionMode imeCompositionMode
		{
			get => UnityEngine.Input.imeCompositionMode;
			set => UnityEngine.Input.imeCompositionMode = value;
		}

		public string compositionString => UnityEngine.Input.compositionString;

		public bool imeIsSelected => UnityEngine.Input.imeIsSelected;

		public Vector2 compositionCursorPos
		{
			get => UnityEngine.Input.compositionCursorPos;
			set => UnityEngine.Input.compositionCursorPos = value;
		}
#pragma warning disable CS0618 // Type or member is obsolete
		public bool eatKeyPressOnTextFieldFocus
		{
			get => UnityEngine.Input.eatKeyPressOnTextFieldFocus;
			set => UnityEngine.Input.eatKeyPressOnTextFieldFocus = value;
		}
#pragma warning restore CS0618 // Type or member is obsolete

		public bool mousePresent => UnityEngine.Input.mousePresent;

		public int touchCount => UnityEngine.Input.touchCount;

		public bool touchPressureSupported => UnityEngine.Input.touchPressureSupported;

		public bool stylusTouchSupported => UnityEngine.Input.stylusTouchSupported;

		public bool touchSupported => UnityEngine.Input.touchSupported;

		public bool multiTouchEnabled
		{
			get => UnityEngine.Input.multiTouchEnabled;
			set => UnityEngine.Input.multiTouchEnabled = value;
		}

#pragma warning disable CS0618 // Type or member is obsolete
		public bool isGyroAvailable => UnityEngine.Input.isGyroAvailable;
#pragma warning restore CS0618 // Type or member is obsolete

		public DeviceOrientation deviceOrientation => UnityEngine.Input.deviceOrientation;

		public Vector3 acceleration => UnityEngine.Input.acceleration;

		public bool compensateSensors
		{
			get => UnityEngine.Input.compensateSensors;
			set => UnityEngine.Input.compensateSensors = value;
		}

		public int accelerationEventCount => UnityEngine.Input.accelerationEventCount;

		public bool backButtonLeavesApp
		{
			get => UnityEngine.Input.backButtonLeavesApp;
			set => UnityEngine.Input.backButtonLeavesApp = value;
		}

		public LocationService location { get; } = new DefaultLocationService();

		public Compass compass { get; } = new DefaultCompas();

		public Gyroscope gyro { get; } = new DefaultGyroscope();

		public Touch[] touches => UnityEngine.Input.touches;

		public AccelerationEvent[] accelerationEvents => UnityEngine.Input.accelerationEvents;

		public AccelerationEvent GetAccelerationEvent(int index)
		{
			return UnityEngine.Input.GetAccelerationEvent(index);
		}

		public float GetAxis(string axisName) => UnityEngine.Input.GetAxis(axisName);

		public float GetAxisRaw(string axisName) => UnityEngine.Input.GetAxisRaw(axisName);

		public bool GetButton(string buttonName) => UnityEngine.Input.GetButton(buttonName);

		public bool GetButtonDown(string buttonName) => UnityEngine.Input.GetButtonDown(buttonName);

		public bool GetButtonUp(string buttonName) => UnityEngine.Input.GetButtonUp(buttonName);

		public string[] GetJoystickNames() => UnityEngine.Input.GetJoystickNames();

		public bool GetKey(KeyCode key) => UnityEngine.Input.GetKey(key);

		public bool GetKey(string name) => UnityEngine.Input.GetKey(name);

		public bool GetKeyDown(KeyCode key) => UnityEngine.Input.GetKeyDown(key);

		public bool GetKeyDown(string name) => UnityEngine.Input.GetKeyDown(name);

		public bool GetKeyUp(KeyCode key) => UnityEngine.Input.GetKeyUp(key);

		public bool GetKeyUp(string name) => UnityEngine.Input.GetKeyUp(name);

		public bool GetMouseButton(int button) => UnityEngine.Input.GetMouseButton(button);

		public bool GetMouseButtonDown(int button) => UnityEngine.Input.GetMouseButtonDown(button);

		public bool GetMouseButtonUp(int button) => UnityEngine.Input.GetMouseButtonUp(button);

		public Touch GetTouch(int index) => UnityEngine.Input.GetTouch(index);

		public bool IsJoystickPreconfigured(string joystickName)
		{
			return UnityEngine.Input.IsJoystickPreconfigured(joystickName);
		}

		public void ResetInputAxes() => UnityEngine.Input.ResetInputAxes();
	}
}
