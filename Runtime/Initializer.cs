namespace Grabli
{
	public interface Initializer
	{
		bool IsInitialized { get; }
		void Init();
		void Deinit();
	}
}
