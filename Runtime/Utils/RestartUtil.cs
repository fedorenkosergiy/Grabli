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
                default: throw new NotSupportedException();
            }
        }

        public void DoAndroidRestart()
        {
#if UNITY_ANDROID
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject mainActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
            mainActivity.Call("doRestart", 0);
            jc.Dispose();
            mainActivity.Dispose();
#endif
        }
    }
}
