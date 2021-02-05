namespace Grabli.WrappedUnity
{
    public interface EditorWindowFactory
    {
        EditorWindow Instantiate<T>() where T : class, EditorWindow, new();
    }
}