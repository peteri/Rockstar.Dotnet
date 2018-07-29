// <copyright file="KeywordEntryTests.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the keyword finder.
    /// </summary>
    [TestClass]
    public class KeywordEntryTests
    {
        /// <summary>
        /// Test an empty string returns NoMatch.
        /// </summary>
        [TestMethod]
        public void EmptyStringReturnsKeywordNoMatch()
        {
            var result = KeywordEntry.FindKeyword(string.Empty);
            Assert.AreEqual(Keyword.NoMatch, result);
        }

        /// <summary>
        /// Test we can find a string.
        /// </summary>
        [TestMethod]
        public void MatchingKeywordReturnsKeywordEnum()
        {
            var result = KeywordEntry.FindKeyword("take");
            Assert.AreEqual(Keyword.Take, result);
        }

        /// <summary>
        /// Non matching keyword returns no match.
        /// </summary>
        [TestMethod]
        public void NonMatchingKeywordReturnsKeywordNoMatch()
        {
            var result = KeywordEntry.FindKeyword("takexx");
            Assert.AreEqual(Keyword.NoMatch, result);
        }
    }
}
