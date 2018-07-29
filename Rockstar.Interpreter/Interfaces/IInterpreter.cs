// <copyright file="IInterpreter.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Interfaces
{
    /// <summary>
    /// Interface for the interpreter.
    /// </summary>
    public interface IInterpreter
    {
        /// <summary>
        /// Execute the interpreter.
        /// </summary>
        /// <param name="programLines">Array containing the lines of the program.</param>
        void Execute(string[] programLines);
    }
}
