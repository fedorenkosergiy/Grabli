using UnityEngine;

namespace Grabli.WrappedUnity
{
	/// <summary>
	/// Use this delegate type with Application.logMessageReceived or Application.logMessageReceivedThreaded to monitor what gets logged.
	/// </summary>
	/// <param name="condition"></param>
	/// <param name="stackTrace"></param>
	/// <param name="type"></param>
	public delegate void LogCallback(string condition, string stackTrace, LogType type);
}
