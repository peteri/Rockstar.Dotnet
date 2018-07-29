// <copyright file="GlassTeletype.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Console
{
    using System;
    using System.Text;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// Glass teletype for the interpreter.
    /// </summary>
    public class GlassTeletype : ITeletype
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlassTeletype"/> class.
        /// </summary>
        public GlassTeletype()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
        }

        /// <summary>
        /// Event handler for cancel (aka Ctrl-C).
        /// </summary>
        event ConsoleCancelEventHandler ITeletype.CancelEventHandler
        {
            add
            {
                Console.CancelKeyPress += value;
            }

            remove
            {
                Console.CancelKeyPress -= value;
            }
        }

        /// <summary>
        /// Read a line from the console.
        /// </summary>
        /// <returns>Line of text from the console.</returns>
        public string Read()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Writes text to the console.
        /// </summary>
        /// <param name="output">string to output.</param>
        public void Write(string output)
        {
            Console.Write(output);
        }
    }
}
