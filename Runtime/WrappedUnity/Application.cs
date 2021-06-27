using System;
using UnityEngine;
using UnityEngine.Events;
namespace Grabli.WrappedUnity
{
	/// <summary>
	/// Access to application run-time data.
	/// </summary>
	public interface Application
	{
		/// <summary>
		/// Returns application version number (Read Only).
		/// </summary>
		string version { get; }

		/// <summary>
		/// The version of the Unity runtime used to play the content.
		/// </summary>
		string unityVersion { get; }

		/// <summary>
		/// The URL of the document. For WebGL, this a web URL. For Android, iOS, or Universal Windows Platform (UWP) this is a deep link URL. (Read Only)
		/// </summary>
		string absoluteURL { get; }

		/// <summary>
		/// Contains the path to a temporary data / cache directory (Read Only).
		/// </summary>
		string temporaryCachePath { get; }

		/// <summary>
		/// Contains the path to a persistent data directory (Read Only).
		/// </summary>
		string persistentDataPath { get; }

		/// <summary>
		/// The path to the StreamingAssets folder (Read Only).
		/// </summary>
		string streamingAssetsPath { get; }

		/// <summary>
		/// Returns the name of the store or package that installed the application (Read Only).
		/// </summary>
		string installerName { get; }

		/// <summary>
		/// Contains the path to the game data folder on the target device (Read Only).
		/// </summary>
		string dataPath { get; }

		/// <summary>
		/// Note: This is now obsolete. Use SceneManager.GetActiveScene instead. (Read Only).
		/// </summary>
		[Obsolete("Use SceneManager to determine what scenes have been loaded")]
		int loadedLevel { get; }

		/// <summary>
		/// Returns a GUID for this build (Read Only).
		/// </summary>
		string buildGUID { get; }

		/// <summary>
		/// Whether the player currently has focus. Read-only.
		/// </summary>
		bool isFocused { get; }

		/// <summary>
		/// Returns true when called in any kind of built Player, or when called in the Editor in Play Mode (Read Only).
		/// </summary>
		bool isPlaying { get; }

		/// <summary>
		/// Indicates whether Unity's webplayer security model is enabled.
		/// </summary>
		[Obsolete("Application.webSecurityEnabled is no longer supported, since the Unity Web Player is no longer supported by Unity", true)]
		bool webSecurityEnabled { get; }

		/// <summary>
		/// How many bytes have we downloaded from the main unity web stream (Read Only).
		/// </summary>
		[Obsolete("Streaming was a Unity Web Player feature, and is removed. This property is deprecated and always returns 0.")]
		int streamedBytes { get; }

		/// <summary>
		/// Returns true when Unity is launched with the -batchmode flag from the command line (Read Only).
		/// </summary>
		bool isBatchMode { get; }

		/// <summary>
		/// Returns application identifier at runtime. On Apple platforms this is the 'bundleIdentifier' saved in the info.plist file, on Android it's the 'package' from the AndroidManifest.xml.
		/// </summary>
		string identifier { get; }

		/// <summary>
		/// Returns application install mode (Read Only).
		/// </summary>
		ApplicationInstallMode installMode { get; }

		/// <summary>
		/// Returns application running in sandbox (Read Only).
		/// </summary>
		ApplicationSandboxType sandboxType { get; }

		/// <summary>
		/// Returns the type of Internet reachability currently possible on the device.
		/// </summary>
		NetworkReachability internetReachability { get; }

		/// <summary>
		/// The language the user's operating system is running in.
		/// </summary>
		SystemLanguage systemLanguage { get; }

		/// <summary>
		/// Is the current Runtime platform a known console platform.
		/// </summary>
		bool isConsolePlatform { get; }

		/// <summary>
		/// Is the current Runtime platform a known mobile platform.
		/// </summary>
		bool isMobilePlatform { get; }

		/// <summary>
		/// Returns the platform the game is running on (Read Only).
		/// </summary>
		RuntimePlatform platform { get; }

		/// <summary>
		/// Checks whether splash screen is being shown.
		/// </summary>
		[Obsolete("This property is deprecated, please use SplashScreen.isFinished instead")]
		bool isShowingSplashScreen { get; }

		/// <summary>
		/// Returns true if application integrity can be confirmed.
		/// </summary>
		bool genuineCheckAvailable { get; }

		/// <summary>
		/// Returns false if application is altered in any way after it was built.
		/// </summary>
		bool genuine { get; }

		/// <summary>
		/// Priority of background loading thread.
		/// </summary>
		ThreadPriority backgroundLoadingPriority { get; set; }

		/// <summary>
		/// Returns the path to the console log file, or an empty string if the current platform does not support log files.
		/// </summary>
		string consoleLogPath { get; }

		/// <summary>
		/// Obsolete. Use Application.SetStackTraceLogType.
		/// </summary>
		[Obsolete("Use SetStackTraceLogType/GetStackTraceLogType instead")]
		StackTraceLogType stackTraceLogType { get; set; }

		/// <summary>
		/// Instructs the game to try to render at a specified frame rate.
		/// </summary>
		int targetFrameRate { get; set; }

		/// <summary>
		/// A unique cloud project identifier. It is unique for every project (Read Only).
		/// </summary>
		string cloudProjectId { get; }

		/// <summary>
		/// Return application company name (Read Only).
		/// </summary>
		string companyName { get; }

		/// <summary>
		/// Returns application product name (Read Only).
		/// </summary>
		string productName { get; }

		/// <summary>
		/// Is some level being loaded? (Read Only) (Obsolete).
		/// </summary>
		[Obsolete("This property is deprecated, please use LoadLevelAsync to detect if a specific scene is currently loading.")]
		bool isLoadingLevel { get; }

		[Obsolete("use Application.isEditor instead")]
		bool isPlayer { get; }

		/// <summary>
		/// Should the player be running when the application is in the background?
		/// </summary>
		bool runInBackground { get; set; }

		/// <summary>
		/// Are we running inside the Unity editor? (Read Only)
		/// </summary>
		bool isEditor { get; }

		/// <summary>
		/// The name of the level that was last loaded (Read Only).
		/// </summary>
		[Obsolete("Use SceneManager to determine what scenes have been loaded")]
		string loadedLevelName { get; }

		/// <summary>
		/// The total number of levels available (Read Only).
		/// </summary>
		[Obsolete("Use SceneManager.sceneCountInBuildSettings")]
		int levelCount { get; }

		event UnityAction onBeforeRender;
		event Action quitting;
		event Func<bool> wantsToQuit;
		event LowMemoryCallback lowMemory;
		event LogCallback logMessageReceived;
		event Action<string> deepLinkActivated;
		event LogCallback logMessageReceivedThreaded;
		event Action<bool> focusChanged;


		/// <summary>
		/// Cancels quitting the application. This is useful for showing a splash screen at the end of a game.
		/// </summary>
		[Obsolete("CancelQuit is deprecated. Use the wantsToQuit event instead.")]
		void CancelQuit();

		/// <summary>
		/// Can the streamed level be loaded?
		/// </summary>
		/// <param name="levelIndex"></param>
		/// <returns></returns>
		bool CanStreamedLevelBeLoaded(int levelIndex);

		/// <summary>
		/// Can the streamed level be loaded?
		/// </summary>
		/// <param name="levelName"></param>
		/// <returns></returns>
		bool CanStreamedLevelBeLoaded(string levelName);

		/// <summary>
		/// Captures a screenshot at path filename as a PNG file.
		/// </summary>
		/// <param name="filename">Pathname to save the screenshot file to.</param>
		[Obsolete("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead (UnityUpgradable) -> [UnityEngine] UnityEngine.ScreenCapture.CaptureScreenshot(*)", true)]
		void CaptureScreenshot(string filename);

		/// <summary>
		/// Captures a screenshot at path filename as a PNG file.
		/// </summary>
		/// <param name="filename">Pathname to save the screenshot file to.</param>
		/// <param name="superSize">Factor by which to increase resolution.</param>
		[Obsolete("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead (UnityUpgradable) -> [UnityEngine] UnityEngine.ScreenCapture.CaptureScreenshot(*)", true)]
		void CaptureScreenshot(string filename, int superSize);

		[Obsolete("Use Object.DontDestroyOnLoad instead")]
		void DontDestroyOnLoad(UnityEngine.Object o);

		/// <summary>
		/// Calls a function in the web page that contains the WebGL Player.
		/// </summary>
		/// <param name="functionName">Name of the function to call.</param>
		/// <param name="args">Array of arguments passed in the call.</param>
		[Obsolete("Application.ExternalCall is deprecated. See https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html for alternatives.")]
		void ExternalCall(string functionName, params object[] args);


		/// <summary>
		/// Execution of a script function in the contained web page.
		/// </summary>
		/// <param name="script">The Javascript function to call.</param>
		[Obsolete("Application.ExternalEval is deprecated. See https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html for alternatives.")]
		void ExternalEval(string script);
		[Obsolete("Use UnityEngine.Diagnostics.Utils.ForceCrash")]
		void ForceCrash(int mode);

		/// <summary>
		/// Returns an array of feature tags in use for this build.
		/// </summary>
		/// <returns></returns>
		string[] GetBuildTags();

		/// <summary>
		/// Get stack trace logging options. The default value is StackTraceLogType.ScriptOnly.
		/// </summary>
		/// <param name="logType"></param>
		/// <returns></returns>
		StackTraceLogType GetStackTraceLogType(LogType logType);

		/// <summary>
		/// How far has the download progressed? [0...1].
		/// </summary>
		/// <param name="levelName"></param>
		/// <returns></returns>
		[Obsolete("Streaming was a Unity Web Player feature, and is removed. This function is deprecated and always returns 1.0.")]
		float GetStreamProgressForLevel(string levelName);

		/// <summary>
		/// How far has the download progressed? [0...1].
		/// </summary>
		/// <param name="levelIndex"></param>
		/// <returns></returns>
		[Obsolete("Streaming was a Unity Web Player feature, and is removed. This function is deprecated and always returns 1.0 for valid level indices.")]
		float GetStreamProgressForLevel(int levelIndex);

		/// <summary>
		/// Is Unity activated with the Pro license?
		/// </summary>
		/// <returns></returns>
		bool HasProLicense();

		/// <summary>
		/// Check if the user has authorized use of the webcam or microphone in the Web Player.
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		bool HasUserAuthorization(UserAuthorization mode);


		/// <summary>
		/// Returns true if the given object is part of the playing world either in any kind of built Player or in Play Mode.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <returns>True if the object is part of the playing world.</returns>
		bool IsPlaying(UnityEngine.Object obj);

		/// <summary>
		/// Note: This is now obsolete. Use SceneManager.LoadScene instead.
		/// </summary>
		/// <param name="index">The level to load.</param>
		[Obsolete("Use SceneManager.LoadScene")]
		void LoadLevel(int index);

		/// <summary>
		/// Note: This is now obsolete. Use SceneManager.LoadScene instead.
		/// </summary>
		/// <param name="name">The name of the level to load.</param>
		[Obsolete("Use SceneManager.LoadScene")]
		void LoadLevel(string name);

		/// <summary>
		/// Loads a level additively.
		/// </summary>
		/// <param name="index"></param>
		[Obsolete("Use SceneManager.LoadScene")]
		void LoadLevelAdditive(int index);

		/// <summary>
		/// Loads a level additively.
		/// </summary>
		/// <param name="name"></param>
		[Obsolete("Use SceneManager.LoadScene")]
		void LoadLevelAdditive(string name);

		/// <summary>
		/// Loads the level additively and asynchronously in the background.
		/// </summary>
		/// <param name="levelName"></param>
		/// <returns></returns>
		[Obsolete("Use SceneManager.LoadSceneAsync")]
		AsyncOperation LoadLevelAdditiveAsync(string levelName);

		/// <summary>
		/// Loads the level additively and asynchronously in the background.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		[Obsolete("Use SceneManager.LoadSceneAsync")]
		AsyncOperation LoadLevelAdditiveAsync(int index);

		/// <summary>
		/// Loads the level asynchronously in the background.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		[Obsolete("Use SceneManager.LoadSceneAsync")]
		AsyncOperation LoadLevelAsync(int index);

		/// <summary>
		/// Loads the level asynchronously in the background.
		/// </summary>
		/// <param name="levelName"></param>
		/// <returns></returns>
		[Obsolete("Use SceneManager.LoadSceneAsync")]
		AsyncOperation LoadLevelAsync(string levelName);

		/// <summary>
		/// Opens the URL specified, subject to the permissions and limitations of your app’s current platform and environment. This is handled in different ways depending on the nature of the URL, and with different security restrictions, depending on the runtime platform.
		/// </summary>
		/// <param name="url">The URL to open.</param>
		void OpenURL(string url);

		/// <summary>
		/// Quits the player application.
		/// </summary>
		/// <param name="exitCode">An optional exit code to return when the player application terminates on Windows, macOS, and Linux. Defaults to 0.</param>
		void Quit(int exitCode);

		/// <summary>
		/// Quits the player application.
		/// </summary>
		void Quit();

		[Obsolete("Application.RegisterLogCallback is deprecated. Use Application.logMessageReceived instead.")]
		void RegisterLogCallback(LogCallback handler);

		[Obsolete("Application.RegisterLogCallbackThreaded is deprecated. Use Application.logMessageReceivedThreaded instead.")]
		void RegisterLogCallbackThreaded(LogCallback handler);

		bool RequestAdvertisingIdentifierAsync(AdvertisingIdentifierCallback delegateMethod);

		/// <summary>
		/// Request authorization to use the webcam or microphone on iOS.
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		AsyncOperation RequestUserAuthorization(UserAuthorization mode);

		/// <summary>
		/// Set an array of feature tags for this build.
		/// </summary>
		/// <param name="buildTags"></param>
		void SetBuildTags(string[] buildTags);

		/// <summary>
		/// Set stack trace logging options. The default value is StackTraceLogType.ScriptOnly.
		/// </summary>
		/// <param name="logType"></param>
		/// <param name="stackTraceType"></param>
		void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType);

		/// <summary>
		/// Unloads release memory acquired by the Unity Player and keeps current process alive.
		/// </summary>
		void Unload();

		/// <summary>
		/// Unloads all GameObject associated with the given Scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.
		/// </summary>
		/// <param name="scenePath">Name of the Scene to Unload.</param>
		/// <returns>Return true if the Scene is unloaded.</returns>
		[Obsolete("Use SceneManager.UnloadScene")]
		bool UnloadLevel(string scenePath);

		/// <summary>
		/// Unloads all GameObject associated with the given Scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.
		/// </summary>
		/// <param name="index">Index of the Scene in the PlayerSettings to unload.</param>
		/// <returns>Return true if the Scene is unloaded.</returns>
		[Obsolete("Use SceneManager.UnloadScene")]
		bool UnloadLevel(int index);
    }
}
