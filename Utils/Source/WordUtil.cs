namespace Grabli.Utils
{
	public interface WordUtil
	{
		WordType TargetWords { get; set; }
		string[] GetWords(string text);
	}
}
