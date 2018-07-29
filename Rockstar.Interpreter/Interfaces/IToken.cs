// <copyright file="IToken.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Interfaces
{
    /// <summary>
    /// Token.
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Gets the class of the token.
        /// </summary>
        TokenClass Class { get; }

        /// <summary>
        /// Gets the keyword identity.
        /// </summary>
        Keyword Keyword { get; }

        /// <summary>
        /// Gets the text representing the token if appropriate.
        /// </summary>
        string Text { get; }
    }
}