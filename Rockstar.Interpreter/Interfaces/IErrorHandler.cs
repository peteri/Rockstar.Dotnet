// <copyright file="IErrorHandler.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used to report back errors from the tokeniser and parser.
    /// </summary>
    public interface IErrorHandler
    {
        /// <summary>
        /// Report an error to the user.
        /// </summary>
        /// <param name="lineNumber">Line number to report error on.</param>
        /// <param name="errorCode">Error code of the message to display.</param>
        void ReportError(int lineNumber, ErrorCode errorCode);
    }
}
