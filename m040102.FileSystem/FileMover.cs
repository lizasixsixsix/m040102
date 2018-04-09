﻿using m040102.Extensions;
using m040102.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace m040102.FileSystem
{
    public class FileMover
    {
        private readonly IEnumerable<DirectoryInfo> directories;
        private readonly IReadOnlyDictionary<Regex, DirectoryInfo> patternsDictionary;
        private readonly DirectoryInfo defaultDirectory;

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

            this.patternsDictionary = patternsDictionary
                ?? throw new ArgumentNullException();

            if (this.patternsDictionary.Select(
                p => p.Value).Any(d => !d.Exists))
            {
                throw new ArgumentException();
            }

            this.defaultDirectory = defaultDirectory
                ?? throw new ArgumentNullException();

            if (!this.defaultDirectory.Exists)
            {
                throw new ArgumentException();
            }

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

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            //
        }

        public void MoveFile()
        {
            try
            {
                //
            }
            catch (IOException ex)
            {
                this.logger.Log(ex.Message);
            }
        }
    }
}
