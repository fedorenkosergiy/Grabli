namespace Grabli.Utils
{
	[System.Flags]
	public enum WordType
	{
		None = 0,
		Real = 1 << 0,
		Number = 1 << 1,
		All = -1,
	}
}
