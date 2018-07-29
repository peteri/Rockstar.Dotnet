// <copyright file="ITokeniser.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Tokenises a line, splitting into either keywords or not.
    /// </summary>
    public interface ITokeniser
    {
        /// <summary>
        /// Tokenise a line.
        /// </summary>
        /// <param name="lineNumber">Line number to report for errors.</param>
        /// <param name="line">Line of Rockstar code to parse.</param>
        /// <returns>An list of IToken elements.</returns>
        List<IToken> Tokenise(int lineNumber, string line);
    }
}