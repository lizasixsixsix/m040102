using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using m040102.Configuration;
using m040102.FileSystem;
using m040102.Logging;

namespace m040102
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Properties.Strings.Hello);

            Console.CancelKeyPress += Program.Exit;

            var logger = new Logger(
                new StreamWriter(Console.OpenStandardOutput()));

            var config = (FileMoverConfigSection)ConfigurationManager
                .GetSection("customSections/FileMoverConfigSection");

            var directories = config.Directories.Select(
                d => new DirectoryInfo(d.Path));

            var patternDictionary = config.Rules.ToDictionary(
                p => new Regex(p.FileNamePattern),
                p => new DirectoryInfo(p.DestinationPath));

            var defaultDirectory =
                new DirectoryInfo(config.DefaultDirectory.Path);

            var fileMover = new FileMover(directories,
                patternDictionary,
                defaultDirectory,
                logger);

            fileMover.StartWatching();

            while (true)
            {
                Console.ReadKey();

                if (Program.cancel)
                {
                    break;
                }
            }
        }

        private static bool cancel = false;

        private static void Exit(object sender, ConsoleCancelEventArgs e)
        {
            Program.cancel = true;
        }
    }
}
