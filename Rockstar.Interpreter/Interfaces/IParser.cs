// <copyright file="IParser.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the parser.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse the program.
        /// </summary>
        /// <param name="program">Lines in the program.</param>
        /// <returns>IEnumberable of program lines.</returns>
        IEnumerable<IProgramLine> Parse(string[] program);
    }
}
