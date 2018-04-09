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
        }

        public void Log(string str)
        {
            this.writer.Write(str);

            this.writer.Flush();
        }
    }
}
