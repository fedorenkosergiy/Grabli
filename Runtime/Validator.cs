namespace Grabli
{
	public interface Validator
	{
		bool IsValid(out string message);
	}
}
