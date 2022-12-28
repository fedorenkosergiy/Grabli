using System;
using UnityEngine;

namespace Grabli.Runtime.Utils
{
    public class RestartUtil
    {
        public void Restart(RuntimePlatform platform)
        {
            switch(platform)
            {
                case RuntimePlatform.Android: DoAndroidRestart(); return;
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.LinuxEditor:
                    DoEditorRestart();return;
                default: throw new NotSupportedException();
            }
        }

        /// <summary>
        /// https://noodle1983.github.io/2018/11/17/RestartAndroidAppInUnityPureC/
        /// </summary>
        private void DoAndroidRestart()
        {
#if UNITY_ANDROID
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                const int kIntent_FLAG_ACTIVITY_CLEAR_TASK = 0x00008000;
                const int kIntent_FLAG_ACTIVITY_NEW_TASK = 0x10000000;

                var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                var pm = currentActivity.Call<AndroidJavaObject>("getPackageManager");
                var intent = pm.Call<AndroidJavaObject>("getLaunchIntentForPackage", Application.identifier);

                intent.Call<AndroidJavaObject>("setFlags",
                    kIntent_FLAG_ACTIVITY_NEW_TASK | kIntent_FLAG_ACTIVITY_CLEAR_TASK);
                currentActivity.Call("startActivity", intent);
                currentActivity.Call("finish");
                var process = new AndroidJavaClass("android.os.Process");
                int pid = process.CallStatic<int>("myPid");
                process.CallStatic("killProcess", pid);
            }
#endif
        }

        private  async void DoEditorRestart()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            await System.Threading.Tasks.Task.Delay(1000);
            UnityEditor.EditorApplication.isPlaying = true;
#endif
        }
    }
}