using UnityEngine.UIElements;

namespace Grabli.WrappedUnity
{
    public interface EditorWindow
    {
        event EditorWindowStateGetter OnStateRequired;
        
        VisualElement rootVisualElement { get; }

        void Show();
        void OnEnable();
        void OnGUI();
    }
}