using UnityEditor;
using UnityEngine;

namespace Grabli.Utils
{
	[InitializeOnLoad]
	public class PreloadedAssetsActivator
	{
		static PreloadedAssetsActivator()
		{
            ActivatePreloadedAssets();
            EditorApplication.playModeStateChanged += DoOnPlay;
		}

		private static void DoOnPlay(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredPlayMode)
            {
                return;
            }
            ActivatePreloadedAssets();
        }

        private static void ActivatePreloadedAssets()
        {
            Object[] assets = PlayerSettings.GetPreloadedAssets();
            for (int i = 0; i < assets.Length; ++i)
            {
                assets[i].UnityLogFormat($"PreloadedAssets[{i}]: {{0}}");
            }
        }
    }
}
