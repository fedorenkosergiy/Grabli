namespace Grabli.WrappedUnity
{
	/// <summary>
	/// Ping any given IP address (given in dot notation).
	/// </summary>
	public interface Ping
	{
		/// <summary>
		/// Has the ping function completed?
		/// </summary>
		bool isDone { get; }

		/// <summary>
		///  This property contains the ping time result after isDone returns true.
		/// </summary>
		int time { get; }

		/// <summary>
		/// The IP target of the ping.
		/// </summary>
		string ip { get; }

		void DestroyPing();
	}
}
