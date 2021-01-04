using UnityEngine;

namespace Grabli.WrappedUnity
{
	public class DefaultGyroscope : Gyroscope
	{
		public Vector3 rotationRate => UnityEngine.Input.gyro.rotationRate;

		public Vector3 rotationRateUnbiased => UnityEngine.Input.gyro.rotationRateUnbiased;

		public Vector3 gravity => UnityEngine.Input.gyro.gravity;

		public Vector3 userAcceleration => UnityEngine.Input.gyro.userAcceleration;

		public Quaternion attitude => UnityEngine.Input.gyro.attitude;

		public bool enabled
		{
			get => UnityEngine.Input.gyro.enabled;
			set => UnityEngine.Input.gyro.enabled = value;
		}

		public float updateInterval
		{
			get => UnityEngine.Input.gyro.updateInterval;
			set => UnityEngine.Input.gyro.updateInterval = value;
		}
	}
}
