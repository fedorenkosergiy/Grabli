namespace Grabli.WrappedUnity
{
	/// <summary>
	/// Delegate method for fetching advertising ID.
	/// </summary>
	/// <param name="advertisingId"> Advertising ID.</param>
	/// <param name="trackingEnabled">Indicates whether user has chosen to limit ad tracking.</param>
	/// <param name="errorMsg">Error message.</param>
	public delegate void AdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled, string errorMsg);
}
