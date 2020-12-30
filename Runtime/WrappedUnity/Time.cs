namespace Grabli.WrappedUnity
{
	public interface Time
	{
		/// <summary>
		/// Slows game playback time to allow screenshots to be saved between frames.
		/// </summary>
		float captureDeltaTime { get; set; }
		/// <summary>
		/// The real time in seconds since the game started (Read Only).
		/// </summary>
		float realtimeSinceStartup { get; }

		int renderedFrameCount { get; }
		/// <summary>
		/// The total number of frames that have passed (Read Only).
		/// </summary>
		int frameCount { get; }
		/// <summary>
		/// The scale at which time passes. This can be used for slow motion effects.
		/// </summary>
		float timeScale { get; set; }
		/// <summary>
		/// The maximum time a frame can spend on particle updates.
		/// If the frame takes longer than this, then updates are split into multiple smaller updates.
		/// </summary>
		float maximumParticleDeltaTime { get; set; }
		/// <summary>
		/// A smoothed out Time.deltaTime (Read Only).
		/// </summary>
		float smoothDeltaTime { get; }
		/// <summary>
		/// The maximum time a frame can take. Physics and other fixed frame rate updates
		/// (like MonoBehaviour's MonoBehaviour.FixedUpdate) will be performed only for this
		/// duration of time per frame.
		/// </summary>
		float maximumDeltaTime { get; set; }
		/// <summary>
		/// The interval in seconds at which physics and other fixed frame rate updates (like
		/// MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.
		/// </summary>
		float fixedDeltaTime { get; set; }
		/// <summary>
		/// The timeScale-independent interval in seconds from the last fixed frame to the
		/// current one (Read Only).
		/// </summary>
		float fixedUnscaledDeltaTime { get; }
		/// <summary>
		/// The timeScale-independent interval in seconds from the last frame to the current
		/// one (Read Only).
		/// </summary>
		float unscaledDeltaTime { get; }
		/// <summary>
		/// The TimeScale-independant time the latest MonoBehaviour.FixedUpdate has started
		/// (Read Only). This is the time in seconds since the start of the game.
		/// </summary>
		float fixedUnscaledTime { get; }
		/// <summary>
		/// The timeScale-independant time for this frame (Read Only). This is the time in
		///  seconds since the start of the game.
		/// </summary>
		float unscaledTime { get; }
		/// <summary>
		/// The time the latest MonoBehaviour.FixedUpdate has started (Read Only). This is
		/// the time in seconds since the start of the game.
		/// </summary>
		float fixedTime { get; }
		/// <summary>
		/// The completion time in seconds since the last frame (Read Only).
		/// </summary>
		float deltaTime { get; }
		/// <summary>
		/// The time this frame has started (Read Only). This is the time in seconds since
		/// the last level has been loaded.
		/// </summary>
		float timeSinceLevelLoad { get; }
		/// <summary>
		/// The time at the beginning of this frame (Read Only). This is the time in seconds
		/// since the start of the game.
		/// </summary>
		float time { get; }
		/// <summary>
		/// The reciprocal of Time.captureDeltaTime.
		/// </summary>
		int captureFramerate { get; set; }
		/// <summary>
		/// Returns true if called inside a fixed time step callback (like MonoBehaviour's
		/// MonoBehaviour.FixedUpdate), otherwise returns false.
		/// </summary>
		bool inFixedTimeStep { get; }
	}
}
