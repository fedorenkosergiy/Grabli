using System.Collections.Generic;

namespace Grabli.Utils
{
	public interface WordsExtractor
	{
		void Extract(string text, ref HashSet<string> result);
	}
}
