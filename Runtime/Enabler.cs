namespace Grabli
{
    public interface Enabler
    {
        bool IsEnabled { get; }
        void Enable();
        void Disable();
    }
}