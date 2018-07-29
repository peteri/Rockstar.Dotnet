// <copyright file="RegisterTypes.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter
{
    using Autofac;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// Register the types for the interpreter.
    /// </summary>
    public class RegisterTypes
    {
        /// <summary>
        /// Registers the types contained in the interpreter.
        /// </summary>
        /// <param name="builder">Builder to register.</param>
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<Interpreter>().As<IInterpreter>().SingleInstance();
        }
    }
}