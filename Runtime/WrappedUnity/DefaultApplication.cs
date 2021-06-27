using System;
using UnityEngine;
using UnityEngine.Events;
using UApplication = UnityEngine.Application;

namespace Grabli.WrappedUnity
{
	public class DefaultApplication : Application
	{
		public string version => UApplication.version;

		public string unityVersion => throw new NotImplementedException();

		public string absoluteURL => throw new NotImplementedException();

		public string temporaryCachePath => throw new NotImplementedException();

		public string persistentDataPath => throw new NotImplementedException();

		public string streamingAssetsPath => UApplication.streamingAssetsPath;

		public string installerName => throw new NotImplementedException();

		public string dataPath => throw new NotImplementedException();

		public int loadedLevel => throw new NotImplementedException();

		public string buildGUID => throw new NotImplementedException();

		public bool isFocused => throw new NotImplementedException();

        public bool isPlaying => UApplication.isPlaying;

		public bool webSecurityEnabled => throw new NotImplementedException();

		public int streamedBytes => throw new NotImplementedException();

		public bool isBatchMode => throw new NotImplementedException();

		public string identifier => throw new NotImplementedException();

		public ApplicationInstallMode installMode => throw new NotImplementedException();

		public ApplicationSandboxType sandboxType => throw new NotImplementedException();

		public NetworkReachability internetReachability => throw new NotImplementedException();

		public SystemLanguage systemLanguage => throw new NotImplementedException();

		public bool isConsolePlatform => throw new NotImplementedException();

		public bool isMobilePlatform => UApplication.isMobilePlatform;

		public RuntimePlatform platform => UApplication.platform;

		public bool isShowingSplashScreen => throw new NotImplementedException();

		public bool genuineCheckAvailable => throw new NotImplementedException();

		public bool genuine => throw new NotImplementedException();

		public ThreadPriority backgroundLoadingPriority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string consoleLogPath => throw new NotImplementedException();

		public StackTraceLogType stackTraceLogType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int targetFrameRate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string cloudProjectId => throw new NotImplementedException();

		public string companyName => throw new NotImplementedException();

		public string productName => throw new NotImplementedException();

		public bool isLoadingLevel => throw new NotImplementedException();

		public bool isPlayer => throw new NotImplementedException();

		public bool runInBackground { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool isEditor => UApplication.isEditor;

		public string loadedLevelName => throw new NotImplementedException();

		public int levelCount => throw new NotImplementedException();

		public event UnityAction onBeforeRender;
		public event Action quitting;
		public event Func<bool> wantsToQuit;
		public event LowMemoryCallback lowMemory;
		public event LogCallback logMessageReceived;
		public event Action<string> deepLinkActivated;
		public event LogCallback logMessageReceivedThreaded;
		public event Action<bool> focusChanged;

        public DefaultApplication()
        {
            UApplication.logMessageReceived += InvokeLogMessageReceived;
        }

        private void InvokeLogMessageReceived(string condition, string stackTrace, LogType type)
        {
            logMessageReceived?.Invoke(condition, stackTrace, type);
        }

		public void CancelQuit()
		{
			throw new NotImplementedException();
		}

		public bool CanStreamedLevelBeLoaded(int levelIndex)
		{
			throw new NotImplementedException();
		}

		public bool CanStreamedLevelBeLoaded(string levelName)
		{
			throw new NotImplementedException();
		}

		public void CaptureScreenshot(string filename)
		{
			throw new NotImplementedException();
		}

		public void CaptureScreenshot(string filename, int superSize)
		{
			throw new NotImplementedException();
		}

		public void DontDestroyOnLoad(UnityEngine.Object o)
		{
			throw new NotImplementedException();
		}

		public void ExternalCall(string functionName, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void ExternalEval(string script)
		{
			throw new NotImplementedException();
		}

		public void ForceCrash(int mode)
		{
			throw new NotImplementedException();
		}

		public string[] GetBuildTags()
		{
			throw new NotImplementedException();
		}

		public StackTraceLogType GetStackTraceLogType(LogType logType)
		{
			throw new NotImplementedException();
		}

		public float GetStreamProgressForLevel(string levelName)
		{
			throw new NotImplementedException();
		}

		public float GetStreamProgressForLevel(int levelIndex)
		{
			throw new NotImplementedException();
		}

		public bool HasProLicense()
		{
			throw new NotImplementedException();
		}

		public bool HasUserAuthorization(UserAuthorization mode)
		{
			throw new NotImplementedException();
		}

		public bool IsPlaying(UnityEngine.Object obj)
		{
			throw new NotImplementedException();
		}

		public void LoadLevel(int index)
		{
			throw new NotImplementedException();
		}

		public void LoadLevel(string name)
		{
			throw new NotImplementedException();
		}

		public void LoadLevelAdditive(int index)
		{
			throw new NotImplementedException();
		}

		public void LoadLevelAdditive(string name)
		{
			throw new NotImplementedException();
		}

		public AsyncOperation LoadLevelAdditiveAsync(string levelName)
		{
			throw new NotImplementedException();
		}

		public AsyncOperation LoadLevelAdditiveAsync(int index)
		{
			throw new NotImplementedException();
		}

		public AsyncOperation LoadLevelAsync(int index)
		{
			throw new NotImplementedException();
		}

		public AsyncOperation LoadLevelAsync(string levelName)
		{
			throw new NotImplementedException();
		}

		public void OpenURL(string url) => UApplication.OpenURL(url);

		public void Quit(int exitCode)
		{
			throw new NotImplementedException();
		}

		public void Quit()
		{
			throw new NotImplementedException();
		}

		public void RegisterLogCallback(LogCallback handler)
		{
			throw new NotImplementedException();
		}

		public void RegisterLogCallbackThreaded(LogCallback handler)
		{
			throw new NotImplementedException();
		}

		public bool RequestAdvertisingIdentifierAsync(AdvertisingIdentifierCallback delegateMethod)
		{
			throw new NotImplementedException();
		}

		public AsyncOperation RequestUserAuthorization(UserAuthorization mode)
		{
			throw new NotImplementedException();
		}

		public void SetBuildTags(string[] buildTags)
		{
			throw new NotImplementedException();
		}

		public void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType)
		{
			throw new NotImplementedException();
		}

		public void Unload()
		{
			throw new NotImplementedException();
		}

		public bool UnloadLevel(string scenePath)
		{
			throw new NotImplementedException();
		}

		public bool UnloadLevel(int index)
		{
			throw new NotImplementedException();
		}
	}
}
