﻿using CommandLine;
using System;
using System.ComponentModel;

namespace DisplaySettingsChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options.StoreOptions, Options.RestoreOptions, Options.SetOptions, Options.EnumOptions>(args)
                .WithParsed<Options.StoreOptions>(options => Commands.StoreResolution(options.DisplayIndex))
                .WithParsed<Options.RestoreOptions>(options => Commands.RestoreResolution())
                .WithParsed<Options.SetOptions>(options => Commands.SetResolution(options.Width, options.Height, options.RefreshRate, options.DisplayIndex))
                .WithParsed<Options.EnumOptions>(options => Commands.EnumerateModes(options.DisplayIndex))
                .WithNotParsed(errors => Console.Error.WriteLine(errors));
        }
    }
}
