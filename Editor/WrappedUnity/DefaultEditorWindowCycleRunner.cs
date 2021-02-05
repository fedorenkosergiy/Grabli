using System;
using UnityEditor;
using UnityEngine.UIElements;

namespace Grabli.WrappedUnity
{
    public class DefaultEditorWindowCycleRunner<T> : UnityEditor.EditorWindow, EditorWindowState,
        EditorWindowCycleRunner where T : class, EditorWindow, new()
    {
        private EditorWindow window;

        public EditorWindow Window
        {
            get
            {
                if (window.IsNull())
                {
                    window = new T();
                    window.OnStateRequired += ProvideState;
                }

                return window;
            }
        }

        private void OnEnable()
        {
            Window.OnEnable();
        }

        private EditorWindowState ProvideState() => this;

        private void OnGUI()
        {
            Window.OnGUI();
        }

        private void OnDestroy()
        {
            Window.OnStateRequired -= ProvideState;
            window = null;
        }

        public static DefaultEditorWindowCycleRunner<T> Create()
        {
            return CreateInstance<DefaultEditorWindowCycleRunner<T>>();
        }
    }
}