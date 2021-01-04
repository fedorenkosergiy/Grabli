using UnityEngine;

namespace Grabli.WrappedUnity
{
	public interface Compass
	{
		/// <summary>
		///   <para>The heading in degrees relative to the magnetic North Pole. (Read Only)</para>
		/// </summary>
		float magneticHeading { get; }

		/// <summary>
		///   <para>The heading in degrees relative to the geographic North Pole. (Read Only)</para>
		/// </summary>
		float trueHeading { get; }

		/// <summary>
		///   <para>Accuracy of heading reading in degrees.</para>
		/// </summary>
		float headingAccuracy { get; }

		/// <summary>
		///   <para>The raw geomagnetic data measured in microteslas. (Read Only)</para>
		/// </summary>
		Vector3 rawVector { get; }

		/// <summary>
		///   <para>Timestamp (in seconds since 1970) when the heading was last time updated. (Read Only)</para>
		/// </summary>
		double timestamp { get; }

		/// <summary>
		///   <para>Used to enable or disable compass. Note, that if you want Input.compass.trueHeading property to contain a valid value, you must also enable location updates by calling Input.location.Start().</para>
		/// </summary>
		bool enabled { get; set; }
	}
}
