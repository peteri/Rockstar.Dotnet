// <copyright file="KeywordEntry.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter
{
    /// <summary>
    /// Represents a keyword.
    /// </summary>
    public class KeywordEntry
    {
        /// <summary>
        /// Static list of keywords used by the tokeniser.
        /// </summary>
        private static KeywordEntry[] _keywords =
        {
            new KeywordEntry(Keyword.Aint, "ain\'t"),
            new KeywordEntry(Keyword.And, "and"),
            new KeywordEntry(Keyword.Around, "around"),
            new KeywordEntry(Keyword.We, "we"),
            new KeywordEntry(Keyword.Back, "back"),
            new KeywordEntry(Keyword.BoolFalse, "false"),
            new KeywordEntry(Keyword.BoolTrue, "true"),
            new KeywordEntry(Keyword.Break, "break"),
            new KeywordEntry(Keyword.Build, "build"),
            new KeywordEntry(Keyword.Comma, ","),
            new KeywordEntry(Keyword.Continue, "continue"),
            new KeywordEntry(Keyword.Definitely, "definitely"),
            new KeywordEntry(Keyword.Down, "down"),
            new KeywordEntry(Keyword.DownPling, "down!"),
            new KeywordEntry(Keyword.End, "end"),
            new KeywordEntry(Keyword.From, "from"),
            new KeywordEntry(Keyword.Give, "give"),
            new KeywordEntry(Keyword.Go, "go"),
            new KeywordEntry(Keyword.HigherGreaterBiggerStronger, "higher"),
            new KeywordEntry(Keyword.HigherGreaterBiggerStronger, "greater"),
            new KeywordEntry(Keyword.HigherGreaterBiggerStronger, "bigger"),
            new KeywordEntry(Keyword.HigherGreaterBiggerStronger, "stronger"),
            new KeywordEntry(Keyword.If, "if"),
            new KeywordEntry(Keyword.Into, "into"),
            new KeywordEntry(Keyword.IsWasWere, "is"),
            new KeywordEntry(Keyword.IsWasWere, "was"),
            new KeywordEntry(Keyword.IsWasWere, "were"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "it"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "he"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "she"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "him"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "her"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "them"),
            new KeywordEntry(Keyword.ItHeSheHimHerThemThey, "they"),
            new KeywordEntry(Keyword.Knock, "knock"),
            new KeywordEntry(Keyword.Listen, "listen"),
            new KeywordEntry(Keyword.LowerLessSmallerWeaker, "lower"),
            new KeywordEntry(Keyword.LowerLessSmallerWeaker, "less"),
            new KeywordEntry(Keyword.LowerLessSmallerWeaker, "smaller"),
            new KeywordEntry(Keyword.LowerLessSmallerWeaker, "weaker"),
            new KeywordEntry(Keyword.Maybe, "maybe"),
            new KeywordEntry(Keyword.MyOurYour, "my"),
            new KeywordEntry(Keyword.MyOurYour, "our"),
            new KeywordEntry(Keyword.MyOurYour, "your"),
            new KeywordEntry(Keyword.Mysterious, "mysterious"),
            new KeywordEntry(Keyword.Not, "not"),
            new KeywordEntry(Keyword.NullNothingNowhereNobody, "null"),
            new KeywordEntry(Keyword.NullNothingNowhereNobody, "nothing"),
            new KeywordEntry(Keyword.NullNothingNowhereNobody, "nowhere"),
            new KeywordEntry(Keyword.NullNothingNowhereNobody, "nobody"),
            new KeywordEntry(Keyword.Put, "put"),
            new KeywordEntry(Keyword.SayShoutWisperScream, "say"),
            new KeywordEntry(Keyword.SayShoutWisperScream, "shout"),
            new KeywordEntry(Keyword.SayShoutWisperScream, "wisper"),
            new KeywordEntry(Keyword.SayShoutWisperScream, "scream"),
            new KeywordEntry(Keyword.Says, "says"),
            new KeywordEntry(Keyword.Take, "take"),
            new KeywordEntry(Keyword.Takes, "takes"),
            new KeywordEntry(Keyword.Taking, "taking"),
            new KeywordEntry(Keyword.Than, "than"),
            new KeywordEntry(Keyword.The, "the"),
            new KeywordEntry(Keyword.To, "to"),
            new KeywordEntry(Keyword.Top, "top"),
            new KeywordEntry(Keyword.Until, "until"),
            new KeywordEntry(Keyword.Up, "up"),
            new KeywordEntry(Keyword.While, "while"),
        };

        private readonly Keyword _keyword;
        private readonly string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeywordEntry"/> class.
        /// </summary>
        /// <param name="keyword">Keyword token value.</param>
        /// <param name="text">Text strings.</param>
        private KeywordEntry(Keyword keyword, string text)
        {
            _keyword = keyword;
            _text = text;
        }

        /// <summary>
        /// Finds the keyword code for a string of text.
        /// Currently this is a brute force job.
        /// </summary>
        /// <param name="text">Text to search for.</param>
        /// <returns>Keyword code if we get a match, otherwise KeyWord.NoMatch.
        /// </returns>
        public static Keyword FindKeyword(string text)
        {
            if (text.Length == 0)
            {
                return Keyword.NoMatch;
            }

            text = text.ToLower();
            foreach (var entry in _keywords)
            {
                if (entry._text == text)
                {
                    return entry._keyword;
                }
            }

            return Keyword.NoMatch;
        }
    }
}
