using UnityEngine;

namespace Grabli.WrappedUnity
{
	public interface Gyroscope
	{
		/// <summary>
		///   <para>Returns rotation rate as measured by the device's gyroscope.</para>
		/// </summary>
		Vector3 rotationRate { get; }

		/// <summary>
		///   <para>Returns unbiased rotation rate as measured by the device's gyroscope.</para>
		/// </summary>
		Vector3 rotationRateUnbiased { get; }

		/// <summary>
		///   <para>Returns the gravity acceleration vector expressed in the device's reference frame.</para>
		/// </summary>
		Vector3 gravity { get; }

		/// <summary>
		///   <para>Returns the acceleration that the user is giving to the device.</para>
		/// </summary>
		Vector3 userAcceleration { get; }

		/// <summary>
		///   <para>Returns the attitude (ie, orientation in space) of the device.</para>
		/// </summary>
		Quaternion attitude { get; }

		/// <summary>
		///   <para>Sets or retrieves the enabled status of this gyroscope.</para>
		/// </summary>
		bool enabled { get; set; }

		/// <summary>
		///   <para>Sets or retrieves gyroscope interval in seconds.</para>
		/// </summary>
		float updateInterval { get; set; }
	}
}
