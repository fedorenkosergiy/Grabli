using UnityEditor;
using UnityEngine;

namespace Grabli.Utils
{
	[InitializeOnLoad]
	public class PreloadedAssetsActivator
	{
		static PreloadedAssetsActivator()
		{
			EditorApplication.playModeStateChanged += DoOnPlay;
		}

		private static void DoOnPlay(PlayModeStateChange state)
		{
			if (state != PlayModeStateChange.EnteredPlayMode)
			{
				return;
			}
			Object[] assets = PlayerSettings.GetPreloadedAssets();
			for (int i = 0; i < assets.Length; ++i)
			{
				assets[i].LogFormat($"PreloadedAssets[{i}]: {{0}}");
			}
		}
	}
}
