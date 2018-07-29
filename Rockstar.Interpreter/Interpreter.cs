// <copyright file="Interpreter.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter
{
    using System;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// The main interpreter.
    /// </summary>
    public class Interpreter : IInterpreter
    {
        private readonly IParser _parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Interpreter"/> class.
        /// </summary>
        /// <param name="parser">Parser to use.</param>
        public Interpreter(IParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Execute the interpreter.
        /// </summary>
        /// <param name="programLines">Array containing the lines of the program.</param>
        public void Execute(string[] programLines)
        {
            var parsedLines = _parser.Parse(programLines);
        }
    }
}
