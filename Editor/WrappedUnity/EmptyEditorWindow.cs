using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Grabli.WrappedUnity
{
    public class EmptyEditorWindow : EditorWindow
    {
        private EditorWindowState state;

        public event EditorWindowStateGetter OnStateRequired;

        public virtual VisualElement rootVisualElement => GetState().rootVisualElement;
        private EditorWindowState GetState() => state ?? (state = OnStateRequired?.Invoke());

        public void Show()
        {
            GetState().Show();
        }

        public virtual void OnEnable()
        {
        }

        public virtual void OnGUI()
        {
        }
    }
}