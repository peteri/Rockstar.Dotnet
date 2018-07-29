// <copyright file="TokeniserTests.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// Tests for the tokeniser.
    /// </summary>
    [TestClass]
    public class TokeniserTests
    {
        private ITokeniser _sut;
        private Mock<IErrorHandler> _errorHandler;

        /// <summary>
        /// Setup routine for the tests.
        /// </summary>
        [TestInitialize]
        public void SetupTests()
        {
            _errorHandler = new Mock<IErrorHandler>();
            _sut = new Tokeniser(_errorHandler.Object);
        }

        /// <summary>
        /// Tests we recognise a common variable.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesCommonVariable()
        {
            var results = _sut.Tokenise(2, "my house");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(TokenClass.CommonVariable, results.First().Class);
            Assert.AreEqual("my house", results.First().Text);
        }

        /// <summary>
        /// Tests we recognise a common variable (Case insensitive)
        /// and the prefix is converted to lower case.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesCommonVariableWithInsensitivePrefix()
        {
            var results = _sut.Tokenise(2, "Our house");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(TokenClass.CommonVariable, results.First().Class);
            Assert.AreEqual("our house", results.First().Text);
        }

        /// <summary>
        /// Tests we recognise a common variable (Case insensitive)
        /// and the prefix is converted to lower case.
        /// </summary>
        [TestMethod]
        public void TokeniserGivesErrorOnBadCommonVariable()
        {
            var results = _sut.Tokenise(2, "Our House");
            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Once);
            _errorHandler.Verify(eh => eh.ReportError(3, ErrorCode.BadCharactersInCommonVariable), Times.Once);
            Assert.AreEqual(0, results.Count);
        }

        /// <summary>
        /// Tests we recognise a single word proper variable.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesSingleWordProperVariable()
        {
            var results = _sut.Tokenise(2, "Gina");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(TokenClass.ProperVariable, results.First().Class);
            Assert.AreEqual("Gina", results.First().Text);
        }

        /// <summary>
        /// Tests we recognise a multi word proper variable.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesProperVariableWithMultipleParts()
        {
            var results = _sut.Tokenise(2, "Axl Rose");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(TokenClass.ProperVariable, results.First().Class);
            Assert.AreEqual("Axl Rose", results.First().Text);
        }

        /// <summary>
        /// Tests we recognise a poetic string literal with a proper variable.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesPoeticStringLiteralsWithProperVariables()
        {
            var results = _sut.Tokenise(2, "Billy says hello world!");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(TokenClass.ProperVariable, results[0].Class);
            Assert.AreEqual("Billy", results[0].Text);
            Assert.AreEqual(TokenClass.Keyword, results[1].Class);
            Assert.AreEqual(Keyword.Says, results[1].Keyword);
            Assert.AreEqual(TokenClass.StringLiteral, results[2].Class);
            Assert.AreEqual("hello world!", results[2].Text);
        }

        /// <summary>
        /// Tests we recognise a poetic string literal with a common variable.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesPoeticStringLiteralsWithCommonVariables()
        {
            var results = _sut.Tokenise(2, "The world says hello back");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(TokenClass.CommonVariable, results[0].Class);
            Assert.AreEqual("the world", results[0].Text);
            Assert.AreEqual(TokenClass.Keyword, results[1].Class);
            Assert.AreEqual(Keyword.Says, results[1].Keyword);
            Assert.AreEqual(TokenClass.StringLiteral, results[2].Class);
            Assert.AreEqual("hello back", results[2].Text);
        }

        /// <summary>
        /// Tests we recognise a poetic Numeric literal with a common variable.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesPoeticNumericLiteralsWithCommonVariables()
        {
            var results = _sut.Tokenise(2, "The world is hello back");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(TokenClass.CommonVariable, results[0].Class);
            Assert.AreEqual("the world", results[0].Text);
            Assert.AreEqual(TokenClass.Keyword, results[1].Class);
            Assert.AreEqual(Keyword.IsWasWere, results[1].Keyword);
            Assert.AreEqual(TokenClass.Text, results[2].Class);
            Assert.AreEqual("hello", results[2].Text);
            Assert.AreEqual(TokenClass.Text, results[3].Class);
            Assert.AreEqual("back", results[3].Text);
        }

        /// <summary>
        /// Tests we recognise and around we go, and tokenise it as a single entry.
        /// </summary>
        [TestMethod]
        public void TokeniserRecognisesAndGoRoundAgain()
        {
            var results = _sut.Tokenise(2, "And around we go");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(TokenClass.Keyword, results.First().Class);
            Assert.AreEqual(Keyword.And, results.First().Keyword);
            Assert.AreEqual(Keyword.Around, results.First().Keyword);
            Assert.AreEqual(Keyword.We, results.First().Keyword);
            Assert.AreEqual(Keyword.Go, results.First().Keyword);
        }

        /// <summary>
        /// Tests we can put numbers into common variables.
        /// </summary>
        [TestMethod]
        public void TokeniserPutsNumberIntoCommonVariable()
        {
            var results = _sut.Tokenise(2, "Put 123.4 into my heart");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(TokenClass.Keyword, results[0].Class);
            Assert.AreEqual(Keyword.Put, results[0].Keyword);
            Assert.AreEqual(TokenClass.CommonVariable, results[1].Class);
            Assert.AreEqual("123.4", results[1].Text);
            Assert.AreEqual(TokenClass.Keyword, results[2].Class);
            Assert.AreEqual(Keyword.Into, results[2].Keyword);
            Assert.AreEqual(TokenClass.CommonVariable, results[3].Class);
            Assert.AreEqual("my heart", results[3].Text);
        }

        /// <summary>
        /// Tests we can put strings in.
        /// </summary>
        [TestMethod]
        public void TokeniserPutsStringWithSingleQuoteIntoCommonVariable()
        {
            var results = _sut.Tokenise(2, "Put \'123.4 more\' into my heart");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(TokenClass.Keyword, results[0].Class);
            Assert.AreEqual(Keyword.Put, results[0].Keyword);
            Assert.AreEqual(TokenClass.StringLiteral, results[1].Class);
            Assert.AreEqual("123.4  more", results[1].Text);
            Assert.AreEqual(TokenClass.Keyword, results[2].Class);
            Assert.AreEqual(Keyword.Into, results[2].Keyword);
            Assert.AreEqual(TokenClass.CommonVariable, results[3].Class);
            Assert.AreEqual("my heart", results[3].Text);
        }

        /// <summary>
        /// Tests we can put strings in.
        /// </summary>
        [TestMethod]
        public void TokeniserPutsStringWithDoubleQuoteIntoProperVariable()
        {
            var results = _sut.Tokenise(2, "Put \"123.4 more\" into Death Metal");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(TokenClass.Keyword, results[0].Class);
            Assert.AreEqual(Keyword.Put, results[0].Keyword);
            Assert.AreEqual(TokenClass.StringLiteral, results[1].Class);
            Assert.AreEqual("123.4  more", results[1].Text);
            Assert.AreEqual(TokenClass.Keyword, results[2].Class);
            Assert.AreEqual(Keyword.Into, results[2].Keyword);
            Assert.AreEqual(TokenClass.ProperVariable, results[3].Class);
            Assert.AreEqual("Death Metal", results[3].Text);
        }

        /// <summary>
        /// Tests poetic initialisers don't parse out tokens on the rest of the line.
        /// </summary>
        [TestMethod]
        public void TokeniserPoeticInitialisersDoNotParseTokens()
        {
            var results = _sut.Tokenise(2, "My dreams were ice. A life unfulfilled; wakin\' everybody up, taking booze and pills");

            _errorHandler.Verify(eh => eh.ReportError(It.IsAny<int>(), It.IsAny<ErrorCode>()), Times.Never);
            Assert.AreEqual(13, results.Count);
            Assert.AreEqual(TokenClass.CommonVariable, results[0].Class);
            Assert.AreEqual("my dreams", results[0].Text);

            Assert.AreEqual(TokenClass.Keyword, results[1].Class);
            Assert.AreEqual(Keyword.IsWasWere, results[1].Keyword);

            Assert.AreEqual(TokenClass.Text, results[2].Class);
            Assert.AreEqual("ice.", results[2].Text);

            Assert.AreEqual(TokenClass.Text, results[3].Class);
            Assert.AreEqual("A", results[3].Text);

            Assert.AreEqual(TokenClass.Text, results[4].Class);
            Assert.AreEqual("life", results[4].Text);

            Assert.AreEqual(TokenClass.Text, results[5].Class);
            Assert.AreEqual("unfulfilled;", results[5].Text);

            Assert.AreEqual(TokenClass.Text, results[6].Class);
            Assert.AreEqual("wakin\'", results[6].Text);

            Assert.AreEqual(TokenClass.Text, results[7].Class);
            Assert.AreEqual("everybody", results[7].Text);

            Assert.AreEqual(TokenClass.Text, results[8].Class);
            Assert.AreEqual("up,", results[8].Text);

            Assert.AreEqual(TokenClass.Text, results[9].Class);
            Assert.AreEqual("taking", results[9].Text);

            Assert.AreEqual(TokenClass.Text, results[10].Class);
            Assert.AreEqual("booze", results[10].Text);

            Assert.AreEqual(TokenClass.Text, results[11].Class);
            Assert.AreEqual("and", results[11].Text);

            Assert.AreEqual(TokenClass.Text, results[12].Class);
            Assert.AreEqual("pills", results[12].Text);
        }
    }
}
