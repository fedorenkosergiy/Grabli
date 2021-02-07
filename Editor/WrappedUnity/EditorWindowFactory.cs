namespace Grabli.WrappedUnity
{
    public interface EditorWindowFactory
    {
        T Instantiate<T>() where T : class, EditorWindow, new();
    }
}