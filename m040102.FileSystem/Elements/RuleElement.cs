using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace m040102.FileSystem.Elements
{
    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("fileNamePattern")]
        public Regex FileNamePattern
            =>
            new Regex((string)base["fileNamePattern"]);

        [ConfigurationProperty("destinationPath")]
        public DirectoryInfo DestinationPath
            =>
            new DirectoryInfo((string)base["destinationPath"]);
    }
}
