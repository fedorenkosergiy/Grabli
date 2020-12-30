using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Grabli.WrappedUnity
{
	public class DefaultInput : Input
	{
		public bool simulateMouseWithTouches { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool anyKey => throw new NotImplementedException();

		public bool anyKeyDown => throw new NotImplementedException();

		public string inputString => throw new NotImplementedException();

		public Vector3 mousePosition => throw new NotImplementedException();

		public Vector2 mouseScrollDelta => throw new NotImplementedException();

		public IMECompositionMode imeCompositionMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string compositionString => throw new NotImplementedException();

		public bool imeIsSelected => throw new NotImplementedException();

		public Vector2 compositionCursorPos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool eatKeyPressOnTextFieldFocus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool mousePresent => throw new NotImplementedException();

		public int touchCount => throw new NotImplementedException();

		public bool touchPressureSupported => throw new NotImplementedException();

		public bool stylusTouchSupported => throw new NotImplementedException();

		public bool touchSupported => throw new NotImplementedException();

		public bool multiTouchEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool isGyroAvailable => throw new NotImplementedException();

		public DeviceOrientation deviceOrientation => throw new NotImplementedException();

		public Vector3 acceleration => throw new NotImplementedException();

		public bool compensateSensors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int accelerationEventCount => throw new NotImplementedException();

		public bool backButtonLeavesApp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public LocationService location { get; } = new DefaultLocationService();

		public Compass compass { get; } = new DefaultCompas();

		public Gyroscope gyro { get; } = new DefaultGyroscope();

		public Touch[] touches => throw new NotImplementedException();

		public AccelerationEvent[] accelerationEvents => throw new NotImplementedException();

		public AccelerationEvent GetAccelerationEvent(int index)
		{
			throw new NotImplementedException();
		}

		public float GetAxis(string axisName)
		{
			throw new NotImplementedException();
		}

		public float GetAxisRaw(string axisName)
		{
			throw new NotImplementedException();
		}

		public bool GetButton(string buttonName)
		{
			throw new NotImplementedException();
		}

		public bool GetButtonDown(string buttonName)
		{
			throw new NotImplementedException();
		}

		public bool GetButtonUp(string buttonName)
		{
			throw new NotImplementedException();
		}

		public string[] GetJoystickNames()
		{
			throw new NotImplementedException();
		}

		public bool GetKey(KeyCode key)
		{
			throw new NotImplementedException();
		}

		public bool GetKey(string name)
		{
			throw new NotImplementedException();
		}

		public bool GetKeyDown(KeyCode key)
		{
			throw new NotImplementedException();
		}

		public bool GetKeyDown(string name)
		{
			throw new NotImplementedException();
		}

		public bool GetKeyUp(KeyCode key)
		{
			throw new NotImplementedException();
		}

		public bool GetKeyUp(string name)
		{
			throw new NotImplementedException();
		}

		public bool GetMouseButton(int button)
		{
			throw new NotImplementedException();
		}

		public bool GetMouseButtonDown(int button)
		{
			throw new NotImplementedException();
		}

		public bool GetMouseButtonUp(int button)
		{
			throw new NotImplementedException();
		}

		public Touch GetTouch(int index)
		{
			throw new NotImplementedException();
		}

		public bool IsJoystickPreconfigured(string joystickName)
		{
			throw new NotImplementedException();
		}

		public void ResetInputAxes()
		{
			throw new NotImplementedException();
		}
	}
}
