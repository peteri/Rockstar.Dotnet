// <copyright file="Tokeniser.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter
{
    using System.Collections.Generic;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// Tokenises a line, splitting into either keywords or not.
    /// </summary>
    public class Tokeniser : ITokeniser
    {
        private readonly IErrorHandler _errorHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tokeniser"/> class.
        /// </summary>
        /// <param name="errorHandler">Error handler to call.</param>
        public Tokeniser(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        /// <summary>
        /// Tokenise a line.
        /// </summary>
        /// <param name="lineNumber">Line number, used for error reporting.</param>
        /// <param name="line">line of Rockstar code to parse.</param>
        /// <returns>A list of IToken elements.</returns>
        public List<IToken> Tokenise(int lineNumber, string line)
        {
            var result = new List<IToken>();

            return result;
        }
    }
}
