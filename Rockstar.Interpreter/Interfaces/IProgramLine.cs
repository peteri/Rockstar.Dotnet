// <copyright file="IProgramLine.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter.Interfaces
{
    using System.Collections.Generic;

    public interface IProgramLine
    {
        IEnumerable<IInstruction> Line { get; }
    }
}