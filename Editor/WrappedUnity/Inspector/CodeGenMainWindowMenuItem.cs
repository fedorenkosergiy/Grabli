using UnityEditor;

namespace Grabli.WrappedUnity.Inspector
{
    public class CodeGenMainWindowMenuItem
    {
        [MenuItem("Window/Grabli/WrappedUnity/Inspector/CodeGenMain")]
        private static void ShowCodeGenMain()
        {
            EditorWindow window = EditorCtx.EditorWindowFactory.Instantiate<CodeGenMainWindow>();
            window.Show();
        }
    }
}