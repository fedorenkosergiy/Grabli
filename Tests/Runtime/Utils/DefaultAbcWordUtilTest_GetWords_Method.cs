using NUnit.Framework;
using static Grabli.Utils.WordType;

namespace Grabli.Utils
{
	public partial class DefaultAbcWordUtilTest
	{
		private static object[] checkIfGetWordsWorksWellSource =
		{
			new object[]{"Hello world", Real,false, new string[] {"Hello", "world"} },
			new object[]{"Hello world!", Real, false, new string[] {"Hello", "world" } },
			new object[]{"This is the test with numbers: 1, 2, 100500.", Real, false, new string[] {"This", "is", "the", "test", "with", "numbers"}},
			new object[]{"This is the second test with numbers: 1, 2, 100500.", (Real | Number), false, new string[] {"This", "is", "the", "second", "test", "with", "numbers", "1", "2", "100500"}},
			new object[]{"This is the third test with numbers: 1, 2, 100500.", Number, false, new string [] {"1", "2", "100500"}},
			new object[]{"This is the test with negative numbers: 1, -1, 100, -361", Number, false, new string[] {"1", "-1", "100", "-361" } },
			new object[]{"This is the test of words with hyphen: long-term, pick-me-up", Real, false, new string[] {"This", "is", "the", "test", "of", "words", "with", "hyphen", "long-term", "pick-me-up" } },
			new object[]{"This is the test with repetitions. Word \"test\" should be included into a result only once", Real, false, new string[] {"This", "is", "the", "test", "with", "repetitions", "Word", "should", "be", "included", "into", "a", "result", "only", "once"} },

			new object[]{"", All, true, new string[]{} },
			new object[]{"This is the test with empty result", None, true, new string[] { } },
			new object[]{"Це тест написаний українською", Real, false, new string[] {"Це", "тест", "написаний", "українською" } },
			new object[]{"Це мішаний тест. This is a mixed test", Real, false, new string[] {"Це", "мішаний", "тест", "This", "is", "a", "mixed", "test" } },
			new object[]{"Слова з апострофом: здоров'я, сім'я", Real, false, new string[] {"Слова", "з", "апострофом", "здоров'я", "сім'я"}},
		};

		[TestCaseSource("checkIfGetWordsWorksWellSource")]
		public void CheckIfGetWordsWorksWell(string text, WordType target, bool ignoreCase, string[] expected)
		{
			DefaultAbcWordUtil util = new DefaultAbcWordUtil(target, ignoreCase);
			string[] actual = util.GetWords(text);
			Assert.AreEqual(expected, actual);
			//Enumerable.SequenceEqual
		}
	}
}
