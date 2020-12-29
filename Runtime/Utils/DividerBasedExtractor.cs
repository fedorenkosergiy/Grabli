using System.Collections.Generic;
using System.Text;

namespace Grabli.Utils
{
	public abstract class DividerBasedExtractor : WordsExtractor
	{
		protected abstract char[] Dividers { get; }
		protected StringBuilder builder = new StringBuilder();

		public virtual void Extract(string text, ref HashSet<string> result)
		{
			BeginNewWord();
			for (int i = 0; i < text.Length; ++i)
			{
				if (IsDivider(text[i]))
				{
					if (TryCommitWord(ref result))
					{
						BeginNewWord();
					}
				}
				else
				{
					builder.Append(text[i]);
				}
			}
			TryCommitWord(ref result);
		}

		protected bool IsDivider(char symbol)
		{
			for (int i = 0; i < Dividers.Length; ++i)
			{
				if (symbol == Dividers[i])
				{
					return true;
				}
			}
			return false;
		}

		protected bool TryCommitWord(ref HashSet<string> result)
		{
			bool thereIsWord = builder.Length > 0;
			if (thereIsWord)
			{
				result.Add(builder.ToString());
			}
			return thereIsWord;
		}

		protected void BeginNewWord()
		{
			builder.Clear();
		}
	}
}
