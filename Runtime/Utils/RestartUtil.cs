using Grabli.WrappedUnity;
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
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                AndroidJavaObject pm = currentActivity.Call<AndroidJavaObject>("getPackageManager");
                AndroidJavaObject intent = pm.Call<AndroidJavaObject>("getLaunchIntentForPackage", Application.identifier);
                intent.Call<AndroidJavaObject>("setFlags", 0x20000000);//Intent.FLAG_ACTIVITY_SINGLE_TOP

                AndroidJavaClass pendingIntent = new AndroidJavaClass("android.app.PendingIntent");
                AndroidJavaObject contentIntent = pendingIntent.CallStatic<AndroidJavaObject>("getActivity", currentActivity, 0, intent, 0x8000000); //PendingIntent.FLAG_UPDATE_CURRENT = 134217728 [0x8000000]
                AndroidJavaObject alarmManager = currentActivity.Call<AndroidJavaObject>("getSystemService", "alarm");
                AndroidJavaClass system = new AndroidJavaClass("java.lang.System");
                long currentTime = system.CallStatic<long>("currentTimeMillis");
                alarmManager.Call("set", 1, currentTime + 500, contentIntent); // android.app.AlarmManager.RTC = 1 [0x1]

                currentActivity.Call("finish");

                AndroidJavaClass process = new AndroidJavaClass("android.os.Process");
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