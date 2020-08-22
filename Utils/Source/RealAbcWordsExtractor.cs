namespace Grabli.Utils
{
	public class RealAbcWordsExtractor : DividerBasedExtractor
	{
		protected char[] dividers =
		{
			'1', '2', '3', '4', '5',
			'6', '7', '8', '9', '0',
			' ', ',', '!', '?', '.',
			'"', '%', '@', '(', ')',
			'&', '^', ':', ';', '/',
			'=', '+', '#', '*', '<',
			'>', '~',

			'\t', '\n', '\r', '\\',
		};

		protected override char[] Dividers => dividers;
	}
}
