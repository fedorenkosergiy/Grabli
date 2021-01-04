using UnityEngine;

namespace Grabli.WrappedUnity
{
	public class DefaultLocationService : LocationService
	{
		public bool isEnabledByUser => UnityEngine.Input.location.isEnabledByUser;

		public LocationServiceStatus status => UnityEngine.Input.location.status;

		public LocationInfo lastData => UnityEngine.Input.location.lastData;

		public void Start(float desiredAccuracyInMeters, float updateDistanceInMeters)
		{
			UnityEngine.Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);
		}

		public void Start(float desiredAccuracyInMeters)
		{
			UnityEngine.Input.location.Start(desiredAccuracyInMeters);
		}

		public void Start() => UnityEngine.Input.location.Start();

		public void Stop() => UnityEngine.Input.location.Stop();
	}
}
