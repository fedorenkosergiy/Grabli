using UnityEngine;

namespace Grabli.WrappedUnity
{
	public class DefaultCompas : Compass
	{
		public float magneticHeading => UnityEngine.Input.compass.magneticHeading;

		public float trueHeading => UnityEngine.Input.compass.trueHeading;

		public float headingAccuracy => UnityEngine.Input.compass.headingAccuracy;

		public Vector3 rawVector => UnityEngine.Input.compass.rawVector;

		public double timestamp => UnityEngine.Input.compass.timestamp;

		public bool enabled
		{
			get => UnityEngine.Input.compass.enabled;
			set => UnityEngine.Input.compass.enabled = value;
		}
	}
}
