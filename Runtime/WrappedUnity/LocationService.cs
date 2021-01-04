using UnityEngine;

namespace Grabli.WrappedUnity
{
	public interface LocationService
	{
		/// <summary>
		///   <para>Specifies whether location service is enabled in user settings.</para>
		/// </summary>
		bool isEnabledByUser { get; }

		/// <summary>
		///   <para>Returns location service status.</para>
		/// </summary>
		LocationServiceStatus status { get; }

		/// <summary>
		///   <para>Last measured device geographical location.</para>
		/// </summary>
		LocationInfo lastData { get; }

		/// <summary>
		///   <para>Starts location service updates.  Last location coordinates could be.</para>
		/// </summary>
		/// <param name="desiredAccuracyInMeters"></param>
		/// <param name="updateDistanceInMeters"></param>
		void Start(float desiredAccuracyInMeters, float updateDistanceInMeters);

		/// <summary>
		///   <para>Starts location service updates.  Last location coordinates could be.</para>
		/// </summary>
		/// <param name="desiredAccuracyInMeters"></param>
		/// <param name="updateDistanceInMeters"></param>
		void Start(float desiredAccuracyInMeters);

		/// <summary>
		///   <para>Starts location service updates.  Last location coordinates could be.</para>
		/// </summary>
		/// <param name="desiredAccuracyInMeters"></param>
		/// <param name="updateDistanceInMeters"></param>
		void Start();

		/// <summary>
		///   <para>Stops location service updates. This could be useful for saving battery life.</para>
		/// </summary>
		void Stop();
	}
}
