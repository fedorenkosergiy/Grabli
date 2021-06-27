namespace Grabli.WrappedUnity
{
    public class EditorWindowFactoryContext : Context<EditorWindowFactoryContext, DefaultEditorWindowFactory, EditorWindowFactory>
    {
        protected override bool MoveEventInvocationLists => false;
    }
}