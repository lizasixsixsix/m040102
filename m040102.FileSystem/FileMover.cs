﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using m040102.Logging;

namespace m040102.FileSystem
{
    public class FileMover
    {
        private readonly IEnumerable<DirectoryInfo> directories;
        private readonly DirectoryInfo defaultDirectory;

        private readonly IReadOnlyDictionary<Regex, DirectoryInfo> patternDictionary;

        private readonly IList<FileSystemWatcher> fileSystemWatchers;

        private readonly Logger logger;

        public FileMover(IEnumerable<DirectoryInfo> directories,
                         IReadOnlyDictionary<Regex, DirectoryInfo> patternsDictionary,
                         DirectoryInfo defaultDirectory,
                         Logger logger)
        {

            #region ParametersValidation

            this.directories = directories ?? throw new ArgumentNullException();

            if (directories.Any(d => !d.Exists))
            {
                throw new ArgumentException();
            }

            this.patternDictionary = patternsDictionary
                ?? throw new ArgumentNullException();

            this.defaultDirectory = defaultDirectory
                ?? throw new ArgumentNullException();

            #endregion

            this.fileSystemWatchers = new List<FileSystemWatcher>(
                this.directories.Select(
                    d =>
                    {
                        var w = new FileSystemWatcher(d.FullName)
                        {
                            IncludeSubdirectories = true,
                        };

                        w.Created += this.OnCreated;

                        return w;
                    }));

            this.logger = logger ?? throw new ArgumentNullException();
        }

        public void StartWatching()
        {
            foreach (var w in this.fileSystemWatchers)
            {
                w.EnableRaisingEvents = true;
            }
        }

        public void StopWatching()
        {
            foreach (var w in this.fileSystemWatchers)
            {
                w.EnableRaisingEvents = false;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            this.MoveFile(e.FullPath);
        }

        private void MoveFile(string fileName)
        {
            try
            {
                var file = new FileInfo(fileName);

                var match = patternDictionary.FirstOrDefault(
                    p => p.Key.IsMatch(file.Name))
                    .Value;

                var destination = match ?? defaultDirectory;

                if (!destination.Exists)
                {
                    destination.Create();
                }

                file.MoveTo(Path.Combine(destination.FullName, file.Name));
            }
            catch (IOException ex)
            {
                this.logger.Log(ex.Message);
            }
        }
    }
}
