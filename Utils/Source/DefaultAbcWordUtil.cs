using System.Collections.Generic;
using System.Linq;
using static Grabli.Utils.WordType;

namespace Grabli.Utils
{
	public class DefaultAbcWordUtil : AbcWordUtil
	{
		private HashSet<string> extractionResult = new HashSet<string>();

		public virtual WordType TargetWords { get; set; }

		public bool IgnoreCase { get; set; }

		protected virtual WordsExtractor RealWordsExtractor { get; } = new RealAbcWordsExtractor();

		protected virtual WordsExtractor NumbesExtractor { get; } = new NumbersExtractor();

		public virtual string[] GetWords(string text)
		{
			if (TargetWords.HasReal())
			{
				RealWordsExtractor.Extract(text, ref extractionResult);
			}
			if (TargetWords.HasNumber())
			{
				NumbesExtractor.Extract(text, ref extractionResult);
			}
			return extractionResult.ToArray();
		}

		public DefaultAbcWordUtil() : this(All) { }

		public DefaultAbcWordUtil(WordType targetWords) : this(targetWords, false)
		{
		}

		public DefaultAbcWordUtil(WordType targetWords, bool ignoreCase)
		{
			TargetWords = targetWords;
			IgnoreCase = ignoreCase;
		}
	}
}
