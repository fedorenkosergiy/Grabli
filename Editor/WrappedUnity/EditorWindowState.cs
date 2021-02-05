using UnityEngine.UIElements;

namespace Grabli.WrappedUnity
{
    public interface EditorWindowState
    {
        VisualElement rootVisualElement { get; }

        void Show();
    }
}