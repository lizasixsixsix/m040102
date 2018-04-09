using System;
using System.IO;

namespace m040102.Logging
{
    public class Logger
    {
        private readonly StreamWriter writer;

        public Logger(StreamWriter writer)
        {
            this.writer = writer ?? throw new ArgumentNullException();

            this.writer.AutoFlush = true;
        }

        public void Log(string str)
        {
            this.writer.Write(str);
        }
    }
}
