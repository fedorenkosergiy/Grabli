using UnityEngine;

namespace Grabli.WrappedUnity.Inspector
{
    public class CodeGenMainWindow : EmptyEditorWindow
    {
        public override void OnGUI()
        {
            base.OnGUI();
            GUILayout.Label("text");
        }
    }
}