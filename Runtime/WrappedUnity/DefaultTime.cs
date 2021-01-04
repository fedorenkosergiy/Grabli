namespace Grabli.WrappedUnity
{
	public class DefaultTime : Time
	{
		float Time.captureDeltaTime
		{
			get => UnityEngine.Time.captureDeltaTime;
			set => UnityEngine.Time.captureDeltaTime = value;
		}
		float Time.realtimeSinceStartup => UnityEngine.Time.realtimeSinceStartup;
		int Time.renderedFrameCount => UnityEngine.Time.renderedFrameCount;
		int Time.frameCount => UnityEngine.Time.frameCount;
		float Time.timeScale
		{
			get => UnityEngine.Time.timeScale;
			set => UnityEngine.Time.timeScale = value;
		}
		float Time.maximumParticleDeltaTime
		{
			get => UnityEngine.Time.maximumParticleDeltaTime;
			set => UnityEngine.Time.maximumParticleDeltaTime = value;
		}
		float Time.smoothDeltaTime => UnityEngine.Time.smoothDeltaTime;
		float Time.maximumDeltaTime
		{
			get => UnityEngine.Time.maximumDeltaTime;
			set => UnityEngine.Time.maximumDeltaTime = value;
		}
		float Time.fixedDeltaTime
		{
			get => UnityEngine.Time.fixedDeltaTime;
			set => UnityEngine.Time.fixedDeltaTime = value;
		}
		float Time.fixedUnscaledDeltaTime => UnityEngine.Time.fixedUnscaledDeltaTime;
		float Time.unscaledDeltaTime => UnityEngine.Time.unscaledDeltaTime;
		float Time.fixedUnscaledTime => UnityEngine.Time.fixedUnscaledTime;
		float Time.unscaledTime => UnityEngine.Time.unscaledTime;
		float Time.fixedTime => UnityEngine.Time.fixedTime;
		float Time.deltaTime => UnityEngine.Time.deltaTime;
		float Time.timeSinceLevelLoad => UnityEngine.Time.timeSinceLevelLoad;
		float Time.time => UnityEngine.Time.time;
		int Time.captureFramerate
		{
			get => UnityEngine.Time.captureFramerate;
			set => UnityEngine.Time.captureFramerate = value;
		}
		bool Time.inFixedTimeStep => UnityEngine.Time.inFixedTimeStep;
	}
}
