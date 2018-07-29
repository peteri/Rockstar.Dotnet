// <copyright file="Program.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Console
{
    using System;
    using System.IO;
    using Autofac;
    using Rockstar.Interpreter;
    using Rockstar.Interpreter.Interfaces;

    /// <summary>
    /// Console host for the Rockstar interpreter.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">Arguments from comand line.</param>
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Usage();
                return;
            }

            var builder = new ContainerBuilder();
            builder.RegisterInstance(new GlassTeletype()).As<ITeletype>();
            RegisterTypes.Register(builder);
            try
            {
                var program = File.ReadAllLines(args[0]);
                var container = builder.Build();
                var interpreter = container.Resolve<IInterpreter>();
                interpreter.Execute(program);
            }
            catch (Exception ex)
            {
                Console.WriteLine($".Net exception {ex}");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Displays usage to user.
        /// </summary>
        private static void Usage()
        {
            Console.WriteLine("Usage: dotnet Rockstar.Console FileName.rockstar");
        }
    }
}
