using System.Collections.Generic;
using System.Text;

namespace Grabli.Utils
{
	public class NumbersExtractor : WordsExtractor
	{
		protected const char PositiveSign = '+';
		protected const char NegativeSign = '-';

		protected char[] fractionSymbols = { '.', ',', '/' };

		protected StringBuilder builder = new StringBuilder();

		public void Extract(string text, ref HashSet<string> result)
		{
			BeginNewWord();
			for (int i = 0; i < text.Length - 1; ++i)
			{
				if (IsDivider(text[i], text[i + 1], out bool addNext))
				{
					if (TryCommitWord(ref result))
					{
						BeginNewWord();
					}
				}
				else
				{
					builder.Append(text[i]);
					if (addNext)
					{
						builder.Append(text[++i]);
					}
				}
			}
			if (text.Length > 0)
			{
				char lastChar = text[text.Length - 1];
				if (lastChar.IsDecimalDigit())
				{
					builder.Append(lastChar);
				}
			}
			TryCommitWord(ref result);
		}

		protected bool IsDivider(char symbol, char nextSymbol, out bool addNext)
		{
			addNext = false;
			if (symbol.IsDecimalDigit())
			{
				return false;
			}
			if (IsSign(symbol, nextSymbol))
			{
				addNext = true;
				return false;
			}
			if (IsFraction(symbol, nextSymbol))
			{
				addNext = true;
				return false;
			}
			return true;
		}

		protected bool IsSign(char symbol, char nextSymbol)
		{
			if (!nextSymbol.IsDecimalDigit())
			{
				return false;
			}
			return symbol == PositiveSign || symbol == NegativeSign;
		}

		protected bool IsFraction(char symbol, char nextSymbol)
		{
			if (!nextSymbol.IsDecimalDigit())
			{
				return false;
			}
			for (int i = 0; i < fractionSymbols.Length; ++i)
			{
				if (symbol == fractionSymbols[i])
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
