// <copyright file="Parser.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// Parses the input file.
    /// This is done in multiple phases.
    /// </summary>
    public class Parser : IParser
    {
        /// <summary>
        /// Parse the whole program.
        /// </summary>
        /// <param name="program">Array of strings reprenensting the program.</param>
        /// <returns>An Enumerable of program lines to run.</returns>
        public IEnumerable<IProgramLine> Parse(string[] program)
        {
           return null;
        }
    }
}
